using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace HotelAddInApp
{
    internal static class OnlineBooking
    {
        #region Vars
        private static Thread _thread;

        private static DateTime _lastUpdate;
        #endregion

        #region Private Member - Run
        private static void _run(ThreadStart del)
        {
            if (_thread != null)
            {
                return;
            }

            _thread = new Thread(del);
            _thread.Start();
        }

        #endregion

        #region Private Member - Read
        private static StreamWriter _prepairFile()
        {
            string filename = Settings.GetSetting<string>("dirs21.output");
            StreamWriter stream = new StreamWriter(filename, true);

            if (stream.BaseStream.Length == 0)
            {
                stream.WriteLine("Salutation;Title;FirstName;LastName;Organisation;IsACompany;AdresseHome;CityHome;ZipHome;CountryHome;FederalState;Birthday (YYYY-MM-DD);TelHome;FaxHome;MailHome;Homepage;Notiz;CountVisits;");
            }

            return stream;
        }

        private static string[] _createRow(DataRow row)
        {
            return new string[] {
                row[1].ToString(),      // Anrede
                "",                     // Titel
                row[4].ToString(),      // Vorname
                row[3].ToString(),      // Nachname
                row[5].ToString(),      // Firma
                (row[5] == null || Convert.IsDBNull(row[5]) || String.IsNullOrEmpty(row[5].ToString()) ? "0" : "1"),  // Ist Firma (1 oder 0)
                row[6].ToString(),      // Adresse - Privat
                row[8].ToString(),      // Stadt
                row[7].ToString(),      // PLZ
                row[9].ToString(),      // Land
                "",                     // Bundesland
                "",                     // Geburtstag (YYYY-MM-DD)
                row[10].ToString(),     // Telefon - Home
                row[11].ToString(),     // Fax - Home
                row[12].ToString(),     // Mail - Home
                "",                     // Homepage
                "",                     // Notiz
                "0"                     // CountVisits
            };
        }
        #endregion

        #region Private Member - Write
        private static DataTable _query()
        {
            string allTypes = "";
            StringBuilder str = new StringBuilder();

            str.AppendLine("SELECT");
            str.AppendLine("    date(booking.BU_DATUM_VON) as arrival,");
            str.AppendLine("    date(booking.BU_DATUM_BIS) as depature,");
            str.AppendLine("    (CASE");

            foreach (RoomType type in RoomType.ReadAll())
            {
                str.AppendFormat("        WHEN roomtype.ZT_KURZ = '{0}' THEN {1}\n", type.RoomTypeId, type.DirsId);

                allTypes += String.Format(
                    "{1}'{0}'",
                    type.RoomTypeId,
                    (allTypes == "" ? "" : ", ")
                );
            }

            str.AppendLine("    END) as dirsid");
            str.AppendLine("FROM");
            str.AppendLine("    b_buchungen as booking,");
            str.AppendLine("    o_mieteinheit as room,");
            str.AppendLine("    o_objekt as hotel,");
            str.AppendLine("    o_zimmertyp as roomtype");
            str.AppendLine("WHERE");
            str.AppendLine("room.rowid = booking.BU_ZIMMER AND");
            str.AppendLine("hotel.rowid = room.ME_OBJEKT AND");
            str.AppendLine("roomtype.rowid = room.ME_ZIMMERTYP AND");
            str.AppendFormat("roomtype.ZT_KURZ IN ({0})", allTypes);

            string setting = Settings.GetSetting<string>("dirs21.hotels");

            if (!String.IsNullOrEmpty(setting))
            {
                str.AppendLine("    AND hotel.rowid IN (" + setting + ")");
            }

            return Program.AddIn.Query(str.ToString());
        }
        #endregion

        #region Member
        public static void RunThreadWriteRead()
        {
            _run(OnlineBooking.RunWriteRead);
        }

        public static void RunWriteRead()
        {
            Thread thread = _thread;

            OnlineBooking.RunWrite();
            _thread = thread;

            OnlineBooking.RunRead();            
        }

        public static void StopThread()
        {
            if (_thread != null)
            {
                _thread.Abort();
                _thread = null;
            }
        }
        #endregion

        #region Member - Read
        public static void RunThreadRead()
        {
            _run(OnlineBooking.RunRead);
        }

        public static void RunRead()
        {
            try
            {
                var knr = Settings.GetSetting<int>("dirs21.knr");
                var pwd = Settings.GetSetting<string>("dirs21.pwd");
                var flag = Settings.GetSetting<bool>("dirs21.flag");

                StatusInfo.StatusRunning = true;
                StatusInfo.StatusGroup = "Daten werden abgerufen...";
                StatusInfo.StatusLabel = "Bitte warten...";
                StatusInfo.StatusProgress = -1;

                var stream = _prepairFile();
                var dirs21 = new dirs21.DIRS21PMSInterface();
                var table = dirs21.ReadBookingsPMSValue(knr, pwd, 0).Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    int id = (int)row[0];

                    stream.WriteLine(
                        String.Join(";", _createRow(row))
                    );

                    Booking.SaveOne(
                        new Booking(
                            row,
                            dirs21.ReadBookingdetails(knr, pwd, id).Tables[0],
                            dirs21.ReadBookingAddOns(knr, pwd, id).Tables[0]
                        )
                    );

                    if (flag)
                    {
                        dirs21.WriteBookingFlag(knr, pwd, (int)row[0], 1);
                    }
                }

                stream.Close();

                StatusInfo.StatusRunning = false;

                if (table.Rows.Count > 0)
                {
                    StatusInfo.WriteLine(table.Rows.Count + " Buchungen eingelsen.");
                    StatusInfo.StatusBalloon = table.Rows.Count.ToString();
                }

                table.Dispose();
                dirs21.Dispose();
            }
            finally
            {
                _thread = null;
            }
        }
        #endregion

        #region Member - Write
        public static void RunWrite()
        {
            try
            {
                StatusInfo.StatusRunning = true;

                DateTime lastUpdate = DateTime.Parse((string)Program.AddIn.Query("SELECT MAX(updated_on) FROM b_buchungen").Rows[0][0]);

                if (lastUpdate == _lastUpdate)
                {
                    _thread = null;
                    StatusInfo.StatusRunning = false;
                    StatusInfo.WriteLine("Verfügbarkeiten senden: Keine veränderten Buchungen");

                    return;
                }
                _lastUpdate = lastUpdate;

                Dictionary<string, DayAva> avaNew = DayAva.ReadAllDefault();
                Dictionary<string, DayAva> avaOnline = DayAva.ReadAll();

                DataTable table = _query();

                StatusInfo.StatusGroup = "Errechnen der neuen Verfügbarkeiten...";

                int c = 0, p = 0, a = table.Rows.Count;
                foreach (DataRow row in table.Rows)
                {
                    int dirsId = (int)(long)row["dirsid"];
                    DateTime depature = (DateTime)row["depature"];

                    for (DateTime date = (DateTime)row["arrival"]; date < depature; date = date.AddDays(1))
                    {
                        string id = DayAva.GetID(date, dirsId);

                        if (!avaNew.ContainsKey(id))
                        {
                            var day = new DayAva(dirsId, date, RoomCount.GetCount(dirsId));

                            avaNew.Add(
                                day.Id,
                                day
                            );
                        }

                        avaNew[id].Value -= 1;
                    }

                    p = (int)((100.0f / a) * c);

                    StatusInfo.StatusLabel = String.Format("Buchung: {0} von {1}", c, a);
                    StatusInfo.StatusProgress = p;

                    c++;
                }

                StatusInfo.StatusGroup = "Differenzen senden...";

                var dirs21 = new dirs21.DIRS21PMSInterface();
                var knr = Settings.GetSetting<int>("dirs21.knr");
                var pwd = Settings.GetSetting<string>("dirs21.pwd");

                int send = 0;
                c = 0;
                a = avaNew.Count;
                foreach (var id in avaNew.Keys.ToArray())
                {
                    if (!avaOnline.ContainsKey(id) || avaNew[id].Value != avaOnline[id].Value)
                    {
                        var ava = avaNew[id];

                        try
                        {
                            dirs21.WriteAvailabilities(
                                knr,
                                pwd,
                                ava.DirsID,
                                ava.Date.ToString("dd.MM.yyyy"),
                                ava.Date.ToString("dd.MM.yyyy"),
                                ava.Value
                            );

                            send++;
                        }
                        catch
                        {
                            MessageBox.Show(
                                String.Format(
                                    "Datensatz konnte nicht an Dirs21 gesendet werden. Bitte tragen Sie die Werte manuell ein.\n\nDirsID: {0}\nDatum: {1}\nWert: {2}",
                                    ava.DirsID,
                                    ava.Date.ToString("dd.MM.yyyy"),
                                    ava.Value
                                ),
                                "Fehler",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }

                    p = (int)((100.0f / a) * c);

                    StatusInfo.StatusLabel = String.Format("Datensatz: {0} von {1}", c, a);
                    StatusInfo.StatusProgress = p;

                    c++;
                }
                dirs21.Dispose();

                StatusInfo.StatusGroup = "Speichern der Daten...";
                StatusInfo.StatusLabel = "Bitte Warten";
                StatusInfo.StatusProgress = -1;

                DayAva.SaveAll(avaNew);

                StatusInfo.StatusRunning = false;
                StatusInfo.WriteLine("Verfügbarkeiten senden: " + send + " Veränderungen gesendet.");
            }
            finally
            {
                _thread = null;
            }
        }

        public static void RunThreadWrite()
        {
            _run(OnlineBooking.RunWrite);
        }

        public static void RunThreadWriteAsk()
        {
            if (Program.Form.InvokeRequired)
            {
                Program.Form.Invoke(new Action(RunThreadWriteAsk));
                return;
            }

            DialogResult result = MessageBox.Show(
                Program.Form,
                "Zurücksetzen erfolgreich. Möchten Sie jetzt die Daten neu Senden?",
                "Online Buchungen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                OnlineBooking.RunThreadWrite();
            }
        }
        #endregion

        #region Member - Reset
        public static void RunReset()
        {
            try
            {
                StatusInfo.StatusRunning = true;
                StatusInfo.StatusGroup = "Daten zurücksetzen...";
                StatusInfo.StatusLabel = "Datenbank leeren.";
                StatusInfo.StatusProgress = -1;

                DayAva.SaveAll(
                    new Dictionary<string, DayAva>()
                );
                OnlineBooking.LastUpdate = DateTime.MinValue;

                DataTable table = Program.AddIn.Query(
                    String.Format(@"
                                SELECT
                                    price.KP_PREIS as price,
                                    price.KP_FROM as date_from,
                                    price.KP_TO as date_to,
                                    roomtype.ZT_KURZ as roomtype_id,
                                    roomtype.ZT_BEZ as roomtype_name
                                FROM
                                    o_zimmertyp as roomtype,
                                    o_katgoriepreis as price
                                WHERE
                                    roomtype.rowid = KP_ZIMMERTYP AND
                                    (CASE
                                        {0}
                                    END)",
                        String.Join(
                            "\n",
                            RoomType.ReadAll().Select(
                                t => String.Format(
                                    "WHEN roomtype.ZT_KURZ = '{0}' THEN price.KP_PERSON_FROM = {1}",
                                    t.RoomTypeId,
                                    t.DefaultPersons
                                )
                            ).ToArray()
                        )
                   )
                );

                int i = 0;
                int c = table.Rows.Count;
                int knr = Settings.GetSetting<int>("dirs21.knr");
                string pwd = Settings.GetSetting<string>("dirs21.pwd");
                var dirs21 = new HotelAddInApp.dirs21.DIRS21PMSInterface();

                foreach (DataRow row in table.Rows)
                {
                    StatusInfo.StatusLabel = row["roomtype_name"].ToString() + " wird zurückgesetzt.";
                    StatusInfo.StatusProgress = (int)((100.0f / c) * i);

                    try
                    {
                        RoomType type = RoomType.ReadAll().First(t => t.RoomTypeId == (string)row["roomtype_id"]);
                        double price = ((double)row["price"] + Settings.GetSetting<double>("dirs21.breakfast")) * type.DefaultPersons;

                        dirs21.WriteAvailabilitiesPricesMinstay(
                            knr,
                            pwd,
                            type.DirsIdPrice,
                            ((DateTime)row["date_from"]).ToString("dd.MM.yyyy"),
                            ((DateTime)row["date_to"]).ToString("dd.MM.yyyy"),
                            RoomCount.GetCount(type.DirsId),
                            (float)price,
                            1
                        );
                    }
                    catch (Exception ex)
                    {
                        StatusInfo.WriteLine("Zimmertype konnte nicht zurückgesetzt werden.\n\nFehler: " + ex.Message);
                    }

                    i++;
                }

                dirs21.Dispose();

                StatusInfo.StatusRunning = false;
                StatusInfo.WriteLine("Daten zurückgesetzt");
            }
            finally
            {
                _thread = null;

                RunThreadWriteAsk();
            }
        }

        public static void RunThreadReset()
        {
            DialogResult result = MessageBox.Show(
                Program.Form,
                "Möchten Sie die vorhandenen Daten wirklich löschen?",
                "Online Buchungen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                _run(OnlineBooking.RunReset);
            }
        }
        #endregion
        
        #region Fields
        public static bool IsRunning
        {
            get { return (_thread != null); }
        }

        public static DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }
        #endregion
    }
}
