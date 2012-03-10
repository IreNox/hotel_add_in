using System;
using System.Data;
using System.Collections.Generic;
using HotelAddIn;
using System.Text;

namespace HotelAddInApp
{
    internal static class RoomCount
    {
        #region Vars
        private static Dictionary<int, int> _rooms;
        #endregion

        #region Init
        static RoomCount()
        {
            RoomCount.Refresh();
        }
        #endregion

        #region Private Member
        private static DataTable _query()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("SELECT");
            str.AppendLine("    type.ZT_KURZ as code");
            str.AppendLine("FROM");
            str.AppendLine("    o_mieteinheit as room,");
            str.AppendLine("    o_zimmertyp as type,");
            str.AppendLine("    o_objekt as hotel");
            str.AppendLine("WHERE");
            str.AppendLine("    type.rowid = room.ME_ZIMMERTYP AND");
            str.AppendLine("    hotel.rowid = room.ME_OBJEKT");

            string setting = Settings.GetSetting<string>("dirs21.hotels");

            if (!String.IsNullOrEmpty(setting))
            {
                str.AppendLine("    AND hotel.rowid IN (" + setting + ")");
            }

            return Program.AddIn.Query(str.ToString());
        }
        #endregion

        #region Member
        public static void Refresh()
        {
            _rooms = new Dictionary<int, int>();
            Dictionary<string, int> roomsLodgit = new Dictionary<string, int>();

            foreach (RoomType type in RoomType.ReadAll())
            {
                roomsLodgit[type.RoomTypeId] = type.DirsId;
            }

            DataTable table = _query();

            foreach (DataRow row in table.Rows)
            {
                string code = (string)row["code"];

                if (roomsLodgit.ContainsKey(code))
                {
                    int dirsId = roomsLodgit[code];

                    if (!_rooms.ContainsKey(dirsId)) _rooms[dirsId] = 0;

                    _rooms[dirsId] += 1;
                }
            }
        }
        #endregion

        #region Indexer
        public static int GetCount(int dirsId)
        {
            return _rooms[dirsId];
        }
        #endregion
    }
}
