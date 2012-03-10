using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAddInApp
{
    [Serializable]
    internal class RoomType
    {
        #region Fields
        public string Name { get; set; }

        public int DirsId { get; set; }
        public int DirsIdPrice { get; set; }

        public string RoomTypeId { get; set; }

        public int DefaultPersons { get; set; }
        #endregion

        #region Static Member
        public static List<RoomType> ReadAll()
        {
            var all = Settings.GetSetting<List<RoomType>>("room.types");

            return (all == null ? new List<RoomType>() : all);
        }

        public static void SaveAll(List<RoomType> all)
        {
            Settings.SetSetting("room.types", all);

            RoomCount.Refresh();
        }
        #endregion
    }
}
