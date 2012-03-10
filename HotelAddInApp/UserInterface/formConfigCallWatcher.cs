using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace HotelAddInApp
{
    public partial class formConfigCallWatcher : Form
    {
        #region Init
        public formConfigCallWatcher()
        {
            InitializeComponent();
        }

        private void formConfigCallWatcher_Load(object sender, EventArgs e)
        {
            comboPort.DataSource = SerialPort.GetPortNames();
            comboPort.SelectedItem = Settings.GetSetting<string>("call.com.port");

            comboBaudRate.SelectedItem = Settings.GetSetting<int>("call.com.baudrate").ToString();

            comboParity.DataSource = Enum.GetNames(typeof(Parity));
            comboParity.SelectedItem = Settings.GetSetting<Parity>("call.com.parity").ToString();

            comboDataBits.SelectedItem = Settings.GetSetting<int>("call.com.databits").ToString();

            comboStopBits.DataSource = Enum.GetNames(typeof(StopBits));
            comboStopBits.SelectedItem = Settings.GetSetting<StopBits>("call.com.stopbits").ToString();

            comboHandshake.DataSource = Enum.GetNames(typeof(Handshake));
            comboHandshake.SelectedItem = Settings.GetSetting<Handshake>("call.com.handshake").ToString();

            comboPbx.DataSource = Directory.GetFiles(HotelAddIn.Settings.PathData + @"\Data\Telephone\");
            comboPbx.SelectedItem = Settings.GetSetting<string>("call.pbx").ToString();

            checkCensorship.Checked = Settings.GetSetting<bool>("call.censorship");

            ComboBox[] array = new ComboBox[] {
                comboPort,
                comboBaudRate,
                comboParity,
                comboDataBits,
                comboStopBits,
                comboHandshake,
                comboPbx
            };

            foreach (var box in array)
            {
                if (box.SelectedItem == null)
                {
                    box.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region Events
        private void buttonOk_Click(object sender, EventArgs e)
        {
            Settings.SetSetting("call.com.port", comboPort.SelectedItem);

            Settings.SetSetting(
                "call.com.baudrate",
                Int32.Parse((string)comboBaudRate.SelectedItem)
            );

            Settings.SetSetting(
                "call.com.parity",
                (Parity)Enum.Parse(typeof(Parity), (string)comboParity.SelectedItem)
            );

            Settings.SetSetting(
                "call.com.databits",
                Int32.Parse((string)comboDataBits.SelectedItem)
            );

            Settings.SetSetting(
                "call.com.stopbits",
                (StopBits)Enum.Parse(typeof(StopBits), (string)comboStopBits.SelectedItem)
            );

            Settings.SetSetting(
                "call.com.handshake",
                (Handshake)Enum.Parse(typeof(Handshake), (string)comboHandshake.SelectedItem)
            );

            Settings.SetSetting(
                "call.pbx",
                (string)comboPbx.SelectedItem
            );

            Settings.SetSetting(
                "call.censorship",
                checkCensorship.Checked
            );

            this.Close();
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
