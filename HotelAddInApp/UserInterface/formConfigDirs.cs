using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelAddInApp
{
    public partial class formConfigDirs : Form
    {
        #region Init
        public formConfigDirs()
        {
            InitializeComponent();

            try
            {
                textKnr.Text = Settings.GetSetting<int>("dirs21.knr").ToString();
                textPwd.Text = Settings.GetSetting<string>("dirs21.pwd");
                textOutput.Text = Settings.GetComputerSetting<string>("dirs21.output");

                checkFlag.Checked = Settings.GetSetting<bool>("dirs21.flag");
                checkAutoRead.Checked = Settings.GetComputerSetting<bool>("dirs21.autoread");

                textBreakfast.Text = Settings.GetSetting<double>("dirs21.breakfast").ToString();
            }
            catch
            {
            }
        }
        #endregion

        #region Events
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.SetSetting("dirs21.knr", Int32.Parse(textKnr.Text));
            }
            catch
            {
                textKnr.Text = "Fehler: " + textKnr.Text;
                return;
            }

            try
            {
                Settings.SetSetting("dirs21.breakfast", Double.Parse(textBreakfast.Text.Trim(' ', '€')));
            }
            catch
            {
                textBreakfast.Text = "Fehler: " + textBreakfast.Text;
                return;
            }

            Settings.SetSetting("dirs21.pwd", textPwd.Text);
            Settings.SetSetting("dirs21.flag", checkFlag.Checked);

            Settings.SetComputerSetting("dirs21.output", textOutput.Text);
            Settings.SetComputerSetting("dirs21.autoread", checkAutoRead.Checked);

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSelectHotel_Click(object sender, EventArgs e)
        {
            var form = new formConfigHotels("dirs21");
            
            form.ShowDialog(this);
            form.Dispose();
        }
        #endregion
    }
}
