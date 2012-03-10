using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAddInApp
{
    [Serializable]
    public class Call : IdObject
    {
        #region Fields
        public override string Id
        {
            get
            {
                return Hash.Compute(
                    this.CallNumber +
                    this.DateTime.ToString() +
                    this.Duration.ToString() +
                    this.ExtensionLine +
                    this.LineDescription
                );
            }
        }

        public string ExtensionLine { get; set; }
        public string LineDescription { get; set; }
        public string CallNumber { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public long Units { get; set; }
        public bool Entered { get; set; }
        #endregion
        
        #region Static Member
        public static List<Call> ReadAll()
        {
            var all = Settings.GetSetting<List<Call>>("call.list");

            return (all == null ? new List<Call>() : all);
        }

        public static void SaveAll(List<Call> all)
        {
            Settings.SetSetting("call.list", all);
        }
        #endregion
    }
}
