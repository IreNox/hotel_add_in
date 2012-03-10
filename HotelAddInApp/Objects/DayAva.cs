using System;
using System.Collections.Generic;

namespace HotelAddInApp
{
    [Serializable]
    internal class DayAva
    {
        #region Init
        public DayAva(int dirsId, DateTime date, int value)
        {
            this.Date = date;
            this.Value = value;
            this.DirsID = dirsId;
        }
        #endregion

        #region Fields
        public string Id
        {
            get { return DayAva.GetID(this.Date, this.DirsID); }
        }

        public int DirsID { get; set; }
        public DateTime Date { get; set; }

        public int Value { get; set; }
        #endregion

        #region Static Member
        public static string GetID(DateTime date, int dirsId)
        {
            return String.Format(
                "{0}_{1}",
                date.Ticks,
                dirsId
            );
        }

        public static Dictionary<string, DayAva> ReadAll()
        {
            var ava = Settings.GetSetting<Dictionary<string, DayAva>>("ava");

            return (ava == null ? new Dictionary<string, DayAva>() : ava);
        }

        public static Dictionary<string, DayAva> ReadAllDefault()
        {
            var all = DayAva.ReadAll();
            var allDefault = new Dictionary<string, DayAva>();

            foreach (var ava in all.Values)
            {
                var copy = new DayAva(
                    ava.DirsID,
                    ava.Date,
                    RoomCount.GetCount(ava.DirsID)
                );

                allDefault.Add(
                    copy.Id,
                    copy
                );
            }

            return allDefault;
        }

        public static void SaveAll(Dictionary<string, DayAva> ava)
        {
            Settings.SetSetting("ava", ava);
        }
        #endregion
    }
}
