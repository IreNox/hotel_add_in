using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using HotelAddIn;
using System.IO;

namespace HotelAddInApp
{
    public partial class formMain : Form
    {
        #region Vars
        private Booking _booking;

        private bool _running = true;
        #endregion

        #region Init
        public formMain()
        {
            InitializeComponent();

#if !PHONE
            tabControl1.TabPages.Remove(pageCallWatcher);
            menuConfigCallWatcher.Enabled = false;
            menuConfigCallNumbers.Enabled = false;
#endif
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            StatusInfo.StatusRunning = false;

            timerRead.Enabled = Settings.GetComputerSetting<bool>("dirs21.autoread");
            checkCallAutostart.Checked = Settings.GetComputerSetting<bool>("call.autostart");

            if (checkCallAutostart.Checked)
            {
                cmdCallStart_Click(null, null);
            }

            textStatus.Text = Settings.GetComputerSetting<string>("status");

            listCall.Init();
            listCall.Bindings.AddRange(
                new ifListView.ListViewBinding[] {
                    new ifListView.SubItemBinding(0, "ExtensionLine"),
                    new ifListView.SubItemBinding(1, "DateTime"),
                    new ifListView.SubItemBinding(2, "CallNumber"),
                    new ifListView.SubItemBinding(3, "Duration"),
                    new ifListView.SubItemBinding(4, "Units")
                }
            );

            listBooking.Init();
            listBooking.Bindings.AddRange(
                new ifListView.ListViewBinding[] {
                    new ifListView.SubItemBinding(0, "BID"),
                    new ifListView.SubItemBinding(1, o=> ((Booking)o).Vorname + " " + ((Booking)o).Name),
                    new ifListView.SubItemBinding(2, "Firma"),
                    new ifListView.SubItemBinding(3, "Buchungsdatum"),
                    new ifListView.PropertyBinding("Checked", "Entered")
                }
            );

            listBookingData.Init();
            listBookingData.Bindings.AddRange(
                new ifListView.ListViewBinding[] {
                    new ifListView.SubItemBinding(0, "Key"),
                    new ifListView.SubItemBinding(1, "Value")
                }
            );

            listBookingAddOns.Init();
            listBookingAddOns.Bindings.AddRange(
                new ifListView.ListViewBinding[] {
                    new ifListView.SubItemBinding(0, "ZLAnzahl"),
                    new ifListView.SubItemBinding(1, "ZLText"),
                    new ifListView.SubItemBinding(2, "ZLEPreis"),
                    new ifListView.SubItemBinding(3, "ZLSumme")
                }
            );

            listBookingDetails.Init();
            listBookingDetails.Bindings.AddRange(
                new ifListView.ListViewBinding[] {
                    new ifListView.SubItemBinding(0, o => ((Booking.BookingDetail)o).Anreise.ToString("dd.MM.yyy")),
                    new ifListView.SubItemBinding(1, o => ((Booking.BookingDetail)o).Abreise.ToString("dd.MM.yyy")),
                    new ifListView.SubItemBinding(2, "ZTypBezeichnung"),
                    new ifListView.SubItemBinding(3, "Anzahl"),
                    new ifListView.SubItemBinding(4, "Einzelpreis"),
                    new ifListView.SubItemBinding(5, "Einzelsumme"),
                    new ifListView.SubItemBinding(6, "ZType")
                }
            );

            this.RefreshCallList();
        }
        #endregion

        #region Events
        private void cmdStart_Click(object sender, EventArgs e)
        {
            OnlineBooking.StopThread();
        }

        private void checkCallAutostart_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SetComputerSetting("call.autostart", checkCallAutostart.Checked);
        }

        private void timerRead_Tick(object sender, EventArgs e)
        {
            OnlineBooking.RunThreadWriteRead();
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            tabControl1.SelectedTab = pageOnlineBooking;
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _running;
            this.Visible = false;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
#if PHONE
            if (CallWatcher.Running) CallWatcher.StopWatch();
#endif

            Settings.SetComputerSetting("status", textStatus.Text);

            _running = false;
            this.Close();
        }
        #endregion

        #region Events - Run
        private void cmdRunWrite_Click(object sender, EventArgs e)
        {
            OnlineBooking.RunThreadWrite();
        }

        private void cmdRunRead_Click(object sender, EventArgs e)
        {
            OnlineBooking.RunThreadRead();
        }

        private void cmdCallStart_Click(object sender, EventArgs e)
        {
#if PHONE
            if (CallWatcher.Running)
            {
                CallWatcher.StopWatch();
            }
            else
            {
                CallWatcher.StartWatch();
            }
#endif
        }
        #endregion

        #region Events - Config
        private void cmdConfig_Click(object sender, EventArgs e)
        {
            Point p = this.PointToScreen(cmdConfig.Location);
            p.Offset(0, cmdConfig.Height);

            menuConfig.Show(p.X, p.Y);
        }

        private void menuConfigAddIn_Click(object sender, EventArgs e)
        {
            var form = new formConfigAddIn();
            
            form.ShowDialog(this);
            form.Dispose();

            Program.AddIn.Dispose();
            Program.AddIn = new CubeSqlAddIn();
        }

        private void menuConfigCubeSQL_Click(object sender, EventArgs e)
        {
            var form = new formConfigCubeSql();

            form.ShowDialog(this);
            form.Dispose();

            Program.AddIn.Dispose();
            Program.AddIn = new CubeSqlAddIn();
        }

        private void menuConfigDirs21_Click(object sender, EventArgs e)
        {
            var form = new formConfigDirs();

            form.ShowDialog(this);
            form.Dispose();

            timerRead.Enabled = Settings.GetComputerSetting<bool>("dirs21.autoread");
        }

        private void menuConfigRooms_Click(object sender, EventArgs e)
        {
            var form = new formConfigRooms();

            form.ShowDialog(this);
            form.Dispose();

            RoomCount.Refresh();
        }

        private void menuConfigCallWatcher_Click(object sender, EventArgs e)
        {
#if PHONE
            var form = new formConfigCallWatcher();

            form.ShowDialog(this);
            form.Dispose();

            CallWatcher.Refresh();
#endif
        }

        private void menuConfigCallNumbers_Click(object sender, EventArgs e)
        {
            var form = new formConfigCallNumbers();

            form.ShowDialog(this);
            form.Dispose();
        }

        private void menuConfigGastware_Click(object sender, EventArgs e)
        {
            var form = new formConfigGastware();

            form.ShowDialog(this);
            form.Dispose();
        }

        private void menuConfigHotels_Click(object sender, EventArgs e)
        {
            var form = new formConfigHotels("addin");

            form.ShowDialog(this);
            form.Dispose();
        }

        private void menuConfigDebug_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("test", "test", MessageBoxButtons.AbortRetryIgnore);

            if (result == DialogResult.Ignore)
            {
                Program.AddIn.RsJahr(2011);
            }
        }
        #endregion

        #region Events - CallList
        private void listCall_KeyUp(object sender, KeyEventArgs e)
        {
            if (listCall.SelectedIndices.Count > 0 && e.KeyData == Keys.Delete && sender == listCall)
            {
                DialogResult result = MessageBox.Show(
                    this,
                    "Möchten Sie die ausgewählten Elemente wirklich unwiederruflich löschen?",
                    "Telefonüberwachung",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    int i = 0;

                    var indices = listCall.SelectedIndices.Cast<int>();
                    //var list = ((List<object>)listCall.DataSource).Cast<Call>().Where(i => indices.Contains(i.Index)).Select(i => (Call)i.Tag);
                    var all = Call.ReadAll();
                    var list = all.Where(c => indices.Contains(i++)).ToArray();

                    foreach (var call in list)
                    {
                        all.Remove(call);
                    }

                    Call.SaveAll(all);
                    listCall.DataSource = all;
                }
            }
            else if (e.KeyData == Keys.F5 && sender == listCall)
            {
                if (!panelCallSearch.Visible)
                {
                    listCall.DataSource = Call.ReadAll();
                }
            }
            else if (e.KeyData == (Keys.Control | Keys.F))
            {
                panelCallSearch.Visible = !panelCallSearch.Visible;

                if (!panelCallSearch.Visible)
                {
                    textCallSearch.Text = "";
                    listCall.DataSource = Call.ReadAll();
                }
                else
                {
                    textCallSearch.Select();
                }
            }
        }

        private void textCallSearch_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<Call> list = Call.ReadAll();

            foreach (string word in textCallSearch.Text.Split(' '))
            {
                list = list.Where(
                    c =>    c.CallNumber.IndexOf(word, StringComparison.OrdinalIgnoreCase) != -1 ||
                            c.DateTime.ToString().IndexOf(word, StringComparison.OrdinalIgnoreCase) != -1 ||
                            c.Duration.ToString().IndexOf(word, StringComparison.OrdinalIgnoreCase) != -1 ||
                            c.ExtensionLine.IndexOf(word, StringComparison.OrdinalIgnoreCase) != -1 ||
                            c.LineDescription.IndexOf(word, StringComparison.OrdinalIgnoreCase) != -1
                );
            }

            listCall.SelectedIndices.Clear();
            listCall.DataSource = list;
        }

        private void buttonCallHelp_Click(object sender, EventArgs e)
        {
            groupCallHelp.Visible = !groupCallHelp.Visible;
        }
        #endregion

        #region Events - Booking
        private void buttonOnlineDelete_Click(object sender, EventArgs e)
        {
            string filename = Settings.GetSetting<string>("dirs21.output");

            if (System.IO.File.Exists(filename))
            {
                DialogResult result = MessageBox.Show(
                    this,
                    "Möchten Sie die vorhandene Adress-Datei wirklich löschen?",
                    "Online Buchungen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    System.IO.File.Delete(filename);
                }
            }
            else
            {
                MessageBox.Show(
                    this,
                    "Datei nicht vorhanden.",
                    "Online Buchungen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void buttonBookingRemoveAva_Click(object sender, EventArgs e)
        {
            OnlineBooking.RunThreadReset();
        }
        #endregion

        #region Events - BookingList
        private void listBooking_ItemActivate(object sender, EventArgs e)
        {
            if (listBooking.SelectedIndices.Count > 0)
            {
                ListViewItem item = listBooking.Items[listBooking.SelectedIndices[0]];
                Booking booking = (Booking)item.Tag;

                if (booking != null)
                {
                    if (_booking == booking)
                    {
                        splitContainerBooking.Panel2Collapsed = true;
                        _booking = null;
                        return;
                    }

                    _booking = booking;
                    splitContainerBooking.Panel2Collapsed = false;

                    listBookingData.DataSource = booking.GetBookingData();

                    listBookingAddOns.DataSource = booking.AddOns;
                    listBookingDetails.DataSource = booking.Details;
                }
            }
        }

        private void listBooking_KeyUp(object sender, KeyEventArgs e)
        {
            if (listBooking.SelectedIndices.Count > 0 && e.KeyData == Keys.Delete)
            {
                DialogResult result = MessageBox.Show(
                    this,
                    "Möchten Sie die ausgewählten Elemente wirklich unwiederruflich löschen?",
                    "Online Buchungen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    var indices = listBooking.SelectedIndices.Cast<int>();
                    var list = listBooking.Items.Cast<ListViewItem>().Where(i => indices.Contains(i.Index)).Select(i => (Booking)i.Tag);
                    var all = Booking.ReadAll();

                    foreach (var bk in list)
                    {
                        all.Remove(bk);
                    }

                    Booking.SaveAll(all);
                    listBooking.DataSource = all;
                }
            }
            else if (e.KeyData == Keys.F5)
            {
                listBooking.DataSource = Booking.ReadAll();
            }
        }

        private void listBooking_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Booking bk = (Booking)e.Item.Tag;

            bk.Entered = e.Item.Checked;

            Booking.SaveOne(bk);
        }
        #endregion

        #region Member
        internal void RefreshCallList()
        {
            listCall.DataSource = Settings.GetSetting<List<Call>>("call.list");
        }
        #endregion

        #region Properties
        public CubeSqlAddIn AddIn
        {
            get { return ucHotelAddIn1.AddIn; }
        }
        #endregion
    }
}
