using System;
using System.Linq;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;

namespace HotelAddInApp
{
    [Serializable]
    public class Booking : IdObject
    {
        #region Init
        public Booking()
        {
            this.AddOns = new List<BookingAddOn>();
            this.Details = new List<BookingDetail>();
        }

        public Booking(DataRow row, DataTable details, DataTable addOns)
            : this()
        {
            _fillObject(this, row);

            this.AddOns.AddRange(
                addOns.Rows.Cast<DataRow>().Select(r => new BookingAddOn(r))
            );

            this.Details.AddRange(
                details.Rows.Cast<DataRow>().Select(r => new BookingDetail(r))
            );
        }
        #endregion

        #region Fields
        [Browsable(false)]
        public override string Id
        {
            get
            {
                return this.BID.ToString();
            }
        }

        [Browsable(false)]
        public List<BookingAddOn> AddOns { get; private set; }

        [Browsable(false)]
        public List<BookingDetail> Details { get; private set; }

        public bool Entered { get; set; }
        #endregion

        #region Fields - Dirs21
        public int BID { get; set; }
        public string Anrede { get; set; }
        public string Titel { get; set; }
        public string Name { get; set; }
        public string Vorname  { get; set; }
        public string Firma { get; set; }
        public string Strasse { get; set; }
        public string PLZ { get; set; }
        public string Ort { get; set; }
        public string Land { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Bemerkungen { get; set; }
        public string CCTyp { get; set; }
        public string CCInhaber { get; set; }
        public string CCNummer { get; set; }
        public string CCGueltigBis { get; set; }
        public decimal Gesamtsumme { get; set; }
        public string Buchungsbestaetigung { get; set; }
        public DateTime Buchungsdatum { get; set; }
        public int Status { get; set; }
        public string Channel { get; set; }
        public string Waehrung { get; set; }
        public string gdsrate { get; set; }
        public string gdsbid { get; set; }
        public string garantielink { get; set; }
        public int Buchungsart  { get; set; }
        public string Garantie { get; set; }
        public string travelagent { get; set; }
        public int PMS_Value { get; set; }
        public string BuchungsName { get; set; }
        #endregion

        #region Member
        public IEnumerable<BookingData> GetBookingData()
        {
            Type t = this.GetType();
            List<BookingData> list = new List<BookingData>();

            foreach (var info in t.GetProperties())
            {
                if (info.IsBrowsable())
                {
                    try
                    {
                        list.Add(
                            new BookingData(
                                info.Name,
                                info.GetValue(this, null)
                            )
                        );
                    }
                    catch
                    {
                    }
                }
            }

            return list;
        }
        #endregion

        #region Static Member
        private static void _fillObject(object obj, DataRow row)
        {
            Type t = obj.GetType();
            DataTable table = row.Table;

            foreach (DataColumn column in table.Columns)
            {
                PropertyInfo info = t.GetProperty(column.ColumnName);

                try
                {
                    info.SetValue(obj, row[column], null);
                }
                catch
                {
                }
            }
        }
        #endregion

        #region Static Member - Read/Write
        public static List<Booking> ReadAll()
        {
            var all = Settings.GetSetting<List<Booking>>("booking.list");

            return (all == null ? new List<Booking>() : all);
        }

        public static void SaveAll(List<Booking> all)
        {
            Settings.SetSetting("booking.list", all);
        }

        public static void SaveOne(Booking booking)
        {
            var all = ReadAll();

            if (all.Contains(booking)) all.Remove(booking);

            all.Add(booking);

            SaveAll(all);
        }
        #endregion

        #region Class - BookingData
        public class BookingData
        {
            #region Init
            public BookingData()
            {
            }

            public BookingData(string key, object value)
            {
                this.Key = key;
                this.Value = value;
            }
            #endregion

            #region Fields
            public string Key { get; set; }
            public object Value { get; set; }
            #endregion
        }
        #endregion

        #region Class - BookingAddOn
        [Serializable]
        public class BookingAddOn
        {
            #region Init
            public BookingAddOn()
            {
            }

            public BookingAddOn(DataRow row)
            {
                _fillObject(this, row);
            }
            #endregion

            #region Fields
            public int uid { get; set; }
            public int bid { get; set; }
            public int ZLAnzahl { get; set; }
            public string ZLText { get; set; }
            public decimal ZLEPreis { get; set; }
            public decimal ZLSumme { get; set; }
            public int ZLPermanentID { get; set; }
            #endregion
        }
        #endregion

        #region Class - BookingDetail
        [Serializable]
        public class BookingDetail
        {
            #region Init
            public BookingDetail()
            {
            }

            public BookingDetail(DataRow row)
            {
                _fillObject(this, row);
            }
            #endregion

            #region Fields
            public int ID { get; set; }
            public int BID { get; set; }
            public DateTime Anreise { get; set; }
            public DateTime Abreise { get; set; }
            public int ZTyp { get; set; }
            public int Anzahl { get; set; }
            public decimal Einzelpreis { get; set; }
            public decimal Einzelsumme { get; set; }
            public string ZTypBezeichnung { get; set; }
            #endregion
        }
        #endregion
    }
}
