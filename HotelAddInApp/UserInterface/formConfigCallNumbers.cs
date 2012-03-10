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
    public partial class formConfigCallNumbers : Form
    {
        #region Vars
        private List<Room> _rooms;

        private string _mode;
        private Room _current;
        #endregion

        #region Init
        public formConfigCallNumbers()
        {
            InitializeComponent();

            _rooms = Room.ReadAll();

            _createList();
        }
        #endregion

        #region Private Member
        private void _setMode(string mode, bool save)
        {
            if (save && _current != null)
            {
                _current.Number = textDescription.Text;
                _current.ExtensionLine = textPhone.Text;

                if (_mode == "new") _rooms.Add(_current);

                _createList();
            }

            _mode = mode;
            bool enable = false;

            switch (_mode)
            {
                case "idle":
                    enable = false;
                    break;
                case "new":
                    _current = new Room();
                    enable = true;
                    break;
                case "edit":
                    if (listRooms.SelectedItems.Count > 0) _current = (Room)listRooms.SelectedItems[0].Tag;

                    if (_current != null) enable = true;
                    break;
            }

            groupEdit.Enabled = enable;
            cmdNew.Enabled = !enable;
            cmdEdit.Enabled = !enable;
            listRooms.Enabled = !enable;

            if (_current != null)
            {
                textDescription.Text = _current.Number;
                textPhone.Text = _current.ExtensionLine;
            }
        }

        private void _createList()
        {
            listRooms.Items.Clear();

            foreach (Room room in _rooms)
            {
                ListViewItem item = new ListViewItem();

                item.Text = room.Number;
                item.SubItems.Add(room.ExtensionLine);
                item.Tag = room;

                listRooms.Items.Add(item);
            }
        }
        #endregion

        #region Events
        private void cmdNew_Click(object sender, EventArgs e)
        {
            _setMode("new", false);
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            _setMode("edit", false);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            _setMode("idle", true);
        }

        private void formConfigRooms_FormClosing(object sender, FormClosingEventArgs e)
        {
            Room.SaveAll(_rooms);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
