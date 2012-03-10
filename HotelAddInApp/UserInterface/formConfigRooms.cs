using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelAddInApp
{
    public partial class formConfigRooms : Form
    {
        #region Vars
        private List<RoomType> _rooms;

        private string _mode;
        private RoomType _current;
        #endregion

        #region Init
        public formConfigRooms()
        {
            InitializeComponent();

            _rooms = RoomType.ReadAll();

            _createList();
        }
        #endregion

        #region Private Member
        private void _setMode(string mode, bool save)
        {
            if (save && _current != null)
            {
                _current.Name = textName.Text;
                _current.RoomTypeId = textRoomCode.Text;

                try
                {
                    _current.DirsId = Int32.Parse(textDirsID.Text);
                }
                catch
                {
                    textDirsID.Text = "Fehler: " + textDirsID.Text;
                }

                try
                {
                    _current.DirsIdPrice = Int32.Parse(textDirsIdPrice.Text);
                }
                catch
                {
                    textDirsIdPrice.Text = "Fehler: " + textDirsIdPrice.Text;
                }

                try
                {
                    _current.DefaultPersons = Int32.Parse(textPersons.Text);
                }
                catch
                {
                    textPersons.Text = "Fehler: " + textPersons.Text;
                }

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
                    _current = new RoomType();
                    enable = true;
                    break;
                case "edit":
                    if (listRooms.SelectedItems.Count > 0) _current = (RoomType)listRooms.SelectedItems[0].Tag;

                    if (_current != null) enable = true;
                    break;
            }

            groupEdit.Enabled = enable;
            cmdNew.Enabled = !enable;
            cmdEdit.Enabled = !enable;
            listRooms.Enabled = !enable;

            if (_current != null)
            {
                textName.Text = _current.Name;
                textRoomCode.Text = _current.RoomTypeId;
                textDirsID.Text = _current.DirsId.ToString();
                textDirsIdPrice.Text = _current.DirsIdPrice.ToString();
                textPersons.Text = _current.DefaultPersons.ToString();
            }
        }

        private void _createList()
        {
            listRooms.Items.Clear();

            foreach (RoomType type in _rooms)
            {
                ListViewItem item = new ListViewItem();

                item.Text = type.Name;
                item.SubItems.Add(type.RoomTypeId);
                item.SubItems.Add(type.DirsId.ToString());
                item.SubItems.Add(type.DirsIdPrice.ToString());
                item.SubItems.Add(type.DefaultPersons.ToString());
                item.Tag = type;

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
            RoomType.SaveAll(_rooms);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
