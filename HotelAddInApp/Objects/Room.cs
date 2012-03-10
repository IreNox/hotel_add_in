using System;
using System.Collections.Generic;

namespace HotelAddInApp
{
    [Serializable]
    public class Room
    {
        #region Fields
        public string Number { get; set; }
        public string ExtensionLine { get; set; }
        #endregion
        
        #region Static Member
        public static List<Room> ReadAll()
        {
            var all = Settings.GetSetting<List<Room>>("room.list");

            return (all == null ? new List<Room>() : all);
        }

        public static void SaveAll(List<Room> all)
        {
            Settings.SetSetting("room.list", all);
        }
        #endregion
    }
}
