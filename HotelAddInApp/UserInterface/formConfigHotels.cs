using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotelAddInApp
{
    public partial class formConfigHotels : Form
    {
        #region Vars
        private string _saveMode;
        #endregion

        #region Init
        public formConfigHotels(string saveMode)
        {
            InitializeComponent();

            _saveMode = saveMode;
        }

        private void formConfigHotels_Load(object sender, EventArgs e)
        {
            listHotels.Bindings.AddRange(
                new ifListView.ListViewBinding[] {
                    new ifListView.SubItemBinding(0, "Name"),
                    new ifListView.PropertyBinding("Checked", "Active")
                }
            );

            listHotels.DataSource = Hotel.ReadAll(_saveMode);
        }
        #endregion

        #region Events
        private void buttonOk_Click(object sender, EventArgs e)
        {
            string setting = String.Join(
                ", ",
                listHotels.CheckedItems.Cast<ListViewItem>().Select(i => ((Hotel)i.Tag).Id).ToArray()
            );

            switch (_saveMode)
            {
                default:
                    HotelAddIn.Settings.ObjectIds = setting;
                    break;
                case "dirs21":
                    Settings.SetSetting("dirs21.hotels", setting);
                    break;
            }

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Class - Hotel
        private class Hotel
        {
            #region Init
            public Hotel()
            {
            }

            public Hotel(string id, string name, bool active)
            {
                this.Id = id;
                this.Name = name;
                this.Active = active;
            }
            #endregion

            #region Fields
            public string Id { get; set; }
            public bool Active { get; set; }
            public string Name { get; set; }
            #endregion

            #region Static Member
            public static Hotel[] ReadAll(string saveMode)
            {
                var list = new List<Hotel>();
                var table = Program.AddIn.Query("SELECT rowid as id, OB_BEZ as name FROM o_objekt");
                var setting = (saveMode == "dirs21" ? Settings.GetSetting<string>("dirs21.hotels") ?? "" : HotelAddIn.Settings.ObjectIds);
                var settings =  (setting != "" ? setting.Split(',').Select(id => id.Trim()) : new string[0]);

                foreach (DataRow row in table.Rows)
                {
                    list.Add(
                        new Hotel(
                            row["id"].ToString(),
                            (string)row["name"],
                            settings.Contains(row["id"].ToString())
                        )
                    );
                }

                return list.ToArray();
            }
            #endregion
        }
        #endregion
    }
}
