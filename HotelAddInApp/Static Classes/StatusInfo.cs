using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HotelAddInApp
{
    internal static class StatusInfo
    {
        #region Private Member
        private static void _invokeSet(string type, object value)
        {
            if (Program.Form.groupStatus.InvokeRequired)
            {
                try
                {
                    Program.Form.groupStatus.Invoke(
                        new Action<string, object>(_invokeSet),
                        type,
                        value
                    );
                }
                catch
                {
                }
                return;
            }

            var form = Program.Form;

            switch (type)
            {
                case "group":
                    form.groupStatus.Text = value.ToString();
                    break;
                case "label":
                    form.labelStatus.Text = value.ToString();
                    break;
                case "progress":
                    int value2 = (int)value;

                    form.progressStatus.Style = (value2 == -1 ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks);

                    form.progressStatus.Enabled = (value2 != 0 || value2 < 0);

                    if (value2 >= 0) Program.Form.progressStatus.Value = (int)value;
                    break;
                case "running":
                    bool running = (bool)value;

                    form.panelBookingButtons.Enabled = !running;
                    form.groupStatus.Visible = running;

                    if (!running)
                    {
                        _invokeSet("group", "Ruhezustand");
                        _invokeSet("label", "Start klicken zum ausführen.");
                        _invokeSet("progress", 0);

                        form.listBooking.DataSource = Booking.ReadAll();
                    }
                    break;
                case "text":
                    form.textStatus.Text += String.Format(
                        "[{0}] {1}{2}",
                        DateTime.Now.ToString("dd.MM.yyyy - HH:mm"),
                        (string)value,
                        Environment.NewLine
                    );
                    break;
                case "balloon":
                    form.notifyIcon.ShowBalloonTip(
                        60000,
                        "Neue Online-Buchungen",
                        String.Format("Es würden {0} neue Online-Buchungen eingelesen. Bitte hier klicken um mehr zu erfahren.", value),
                        ToolTipIcon.Info
                    );
                    break;
                case "callwatcher":
                    if (!(bool)value)
                    {
                        form.textCallPort.Text = "----";
                        form.textCallBaud.Text = "----";
                        form.textCallStatus.Text = "Bereit...";

                        form.cmdCallStart.Text = "Start";
                    }
                    else
                    {
                        form.textCallPort.Text = CallWatcher.Port.PortName;
                        form.textCallBaud.Text = CallWatcher.Port.BaudRate.ToString();
                        form.textCallStatus.Text = "Läuft...";

                        form.cmdCallStart.Text = "Stoppen";
                    } 
                    break;
            }
        }
        #endregion

        #region Fields
        public static string StatusGroup
        {
            set { _invokeSet("group", value); }
        }
        
        public static string StatusLabel
        {
            set { _invokeSet("label", value); }
        }

        public static int StatusProgress
        {
            set { _invokeSet("progress", value); }
        }

        public static bool StatusRunning
        {
            set { _invokeSet("running", value); }
        }

        public static string StatusBalloon
        {
            set { _invokeSet("balloon", value); }
        }

        public static bool CallWatcherRunning
        {
            set { _invokeSet("callwatcher", value); }
        }
        #endregion

        #region Member
        public static void SetCallWatcher()
        {
            _invokeSet("callwatcher", CallWatcher.Running);
        }

        public static void WriteLine(string line, params object[] args)
        {
            _invokeSet(
                "text",
                String.Format(line, args)
            );
        }
        #endregion
    }
}
