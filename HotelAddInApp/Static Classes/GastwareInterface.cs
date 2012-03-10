using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace HotelAddInApp
{
    internal static class GastwareInterface
    {
        #region Private Member
        private static CheckInElement _getCheckIn(Room room)
        {
            string filename = Settings.GetComputerSetting<string>("gastware.checkin");

            if (File.Exists(filename))
            {
                return File.ReadAllLines(filename).Select(l => new CheckInElement(l)).FirstOrDefault(e => e.RoomNumber == room.Number);
            }

            return null;
        }

        private static void _appendLine(string line)
        {
            StreamWriter writer = new StreamWriter(
                Settings.GetComputerSetting<string>("gastware.sales"),
                true
            );

            writer.WriteLine(line);

            writer.Close();
        }
        #endregion

        #region Member
        public static void BookCall(Call call)
        {
            string tax = Settings.GetSetting<string>("gastware.tax");
            string tradegroup = Settings.GetSetting<string>("gastware.tradegroup");
            double price = Settings.GetSetting<double>("gastware.price");

            Room room = Room.ReadAll().FirstOrDefault(r => r.ExtensionLine == call.ExtensionLine);

            if (room != null)
            {
                CheckInElement element = _getCheckIn(room);

                if (element != null)
                {
                    _appendLine(
                        String.Join(
                            ";",
                            new string[] {
                                room.Number,        // Zimmernummer
                                element.CustomerId, // Gastnummer
                                "1",    // Gastkonto(immer 1)
                                tradegroup,     // Artikel-Code
                                "Anruf: " + call.CallNumber,        // Artikel-Name
                                (price * call.Units).ToString().Replace(',', '.'),    // Artikel-Preis
                                tax,    // Artikel-MwSt
                                call.DateTime.ToString("yyyyMMdd"), // Datum (JJJJMMTT)
                                "1",        // Artikel-Anzahl
                                room.Number // Rechnungs-Nummer
                            }
                        )
                    );
                }
            }
        }
        #endregion

        #region Class - CheckInElement
        private class CheckInElement
        {
            #region Init
            public CheckInElement(string line)
            {
                string[] split = line.Split(';');

                this.RoomNumber = split[0];
                this.CustomerId = split[1];
            }
            #endregion

            #region Fields
            public string RoomNumber { get; set; }
            public string CustomerId { get; set; }
            #endregion
        }
        #endregion
    }
}
