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
    public partial class formConfigGastware : Form
    {
        #region Init
        public formConfigGastware()
        {
            InitializeComponent();
        }

        private void formConfigGastware_Load(object sender, EventArgs e)
        {
            textSales.Text = Settings.GetComputerSetting<string>("gastware.sales");
            textCheckIn.Text = Settings.GetComputerSetting<string>("gastware.checkin");
            textTax.Text = Settings.GetSetting<string>("gastware.tax");
            textPrice.Text = Settings.GetSetting<double>("gastware.price").ToString();
            textTradegroup.Text = Settings.GetSetting<string>("gastware.tradegroup");
        }
        #endregion

        #region Events
        private void buttonOk_Click(object sender, EventArgs e)
        {
            Settings.SetComputerSetting("gastware.sales", textSales.Text);
            Settings.SetComputerSetting("gastware.checkin", textCheckIn.Text);
            Settings.SetSetting("gastware.tax", textTax.Text);
            Settings.SetSetting("gastware.tradegroup", textTradegroup.Text);

            try
            {
                Settings.SetSetting(
                    "gastware.price",
                    Double.Parse(textPrice.Text)
                );

                this.Close();
            }
            catch
            {
                textPrice.Text = "Fehler: " + textPrice.Text;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
