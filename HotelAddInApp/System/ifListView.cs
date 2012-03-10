using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace HotelAddInApp
{
    public class ifListView : ListView
    {
        #region Vars
        private ContextMenuStrip _menuStrip;
        private ToolStripMenuItem _menuItem;
        private Dictionary<ToolStripMenuItem, View> _menuView = new Dictionary<ToolStripMenuItem, View>();

        private HeaderOrder _activeHead;
        private SortOrder _sortOrder = SortOrder.Ascending;
        private List<HeaderOrder> _orders = new List<HeaderOrder>();

        private List<object> _dataSource;
        private ListViewBindingCollection _bindings;
        private Dictionary<string, int> _searchList;
        private Dictionary<int, ListViewItem> _virtualCache;
        #endregion

        #region Init
        public ifListView()
        {
            _bindings = new ListViewBindingCollection(this);
            _virtualCache = new Dictionary<int, ListViewItem>();

            _initView();
            _initSorter();

            this.ColumnWidthChanged += new ColumnWidthChangedEventHandler(ListView_ColumnWidthChanged);

            this.FullRowSelect = true;
        }

        private void _initView()
        {
            foreach (View view in new View[] { View.Details, View.LargeIcon, View.List, View.Tile })
            {
                ToolStripMenuItem item = new ToolStripMenuItem();

                switch (view)
                {
                    case View.Details:
                        item.Name = "cmdMenuViewDetails";
                        item.Text = "Details";
                        break;
                    case View.LargeIcon:
                        item.Name = "cmdMenuViewLargeIcons";
                        item.Text = "Große Icons";
                        break;
                    case View.List:
                        item.Name = "cmdMenuViewList";
                        item.Text = "Liste";
                        break;
                    case View.Tile:
                        item.Name = "cmdMenuViewTile";
                        item.Text = "Kacheln";
                        break;
                }

                item.Click += new EventHandler(item_Click);

                _menuView.Add(item, view);
            }

            View = base.View;
        }

        private void _initSorter()
        {
            this.HeaderStyle = ColumnHeaderStyle.Clickable;
            this.ColumnClick += new ColumnClickEventHandler(ListView_ColumnClick);

            foreach (ColumnHeader header in this.Columns)
            {
                _orders.Add(
                    new HeaderOrder(header, header.DisplayIndex)
                );

                this.SetSortIcon(header.DisplayIndex, SortOrder.None);
            }

            this.ListViewItemSorter = new ItemSorter(this);

            try
            {
                ActiveHead = _orders[0];
            }
            catch
            {
            }
        }

        public void Init()
        {
            string name = "main." + this.Name + ".view";

            if (Settings.ExistsComputerSetting(name))
            {
                this.View = Settings.GetComputerSetting<View>(name);
            }
            else
            {
                this.View = base.View;
            }

            foreach (ColumnHeader header in Columns)
            {
                try
                {
                    ListView_ColumnWidthChanged(this, new ColumnWidthChangedEventArgs(header.DisplayIndex));
                }
                catch
                {
                }
            }
        }
        #endregion

        #region Private Member - Menu
        private void _resetOld()
        {
            if (_menuStrip != null)
            {
                foreach (ToolStripMenuItem item in _menuView.Keys)
                {
                    _menuStrip.Items.Remove(item);
                }

                _menuStrip = null;
            }
            else if (_menuItem != null)
            {
                foreach (ToolStripMenuItem item in _menuView.Keys)
                {
                    _menuItem.DropDownItems.Remove(item);
                }

                _menuItem = null;
            }
        }

        private void _setNew(Func<ToolStripMenuItem, int> addFunc)
        {
            foreach (ToolStripMenuItem item in _menuView.Keys)
            {
                addFunc(item);
            }
        }
        #endregion

        #region Private Member - DataSource
        private void _dataSourceRefresh()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(_dataSourceRefresh));
                return;
            }

            if (_bindings.Count != 0 && _dataSource != null)
            {
                if (_dataSource.Count > 50)
                {
                    if (!this.VirtualMode)
                    {
                        this.Items.Clear();
                        this.VirtualMode = true;
                        this.RetrieveVirtualItem += ifListView_RetrieveVirtualItem;
                        this.CacheVirtualItems += ifListView_CacheVirtualItems;
                        this.SearchForVirtualItem += ifListView_SearchForVirtualItem;
                    }

                    _searchList = null;
                    _virtualCache.Clear();

                    if (this.VirtualListSize == _dataSource.Count) this.VirtualListSize = 0;
                    this.VirtualListSize = _dataSource.Count;
                }
                else
                {
                    if (this.VirtualMode)
                    {
                        this.VirtualMode = false;
                        this.RetrieveVirtualItem -= ifListView_RetrieveVirtualItem;
                        this.CacheVirtualItems -= ifListView_CacheVirtualItems;
                        this.SearchForVirtualItem -= ifListView_SearchForVirtualItem;
                    }

                    this.Items.Clear();

                    List<ListViewItem> items = new List<ListViewItem>();
                    items.Capacity = _dataSource.Count;

                    foreach (object obj in _dataSource)
                    {
                        items.Add(
                            _dataSourceCreateItem(obj)
                        );
                    }

                    this.Items.AddRange(items.ToArray());
                }
            }
            else if (_dataSource == null)
            {
                this.Items.Clear();
            }
        }

        private ListViewItem _dataSourceCreateItem(object obj)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = obj;

            foreach (ListViewBinding binding in _bindings)
            {
                binding.SetItem(
                    item,
                    binding.GetValue(obj)
                );
            }

            return item;
        }
        #endregion

        #region Private Member - VirtualList
        void ifListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            int index = e.ItemIndex;

            if (index < _dataSource.Count)
            {
                if (!_virtualCache.ContainsKey(index))
                {
                    ListViewItem item = _dataSourceCreateItem(_dataSource[index]);

                    if (this.SmallImageList != null)
                    {
                        item.ImageIndex = this.SmallImageList.Images.IndexOfKey(item.ImageKey);
                    }

                    _virtualCache[index] = item;
                }

                e.Item = _virtualCache[index];
            }
            else
            {
                e.Item = new ListViewItem();
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    e.Item.SubItems.Add(new ListViewItem.ListViewSubItem());
                }
            }
        }

        void ifListView_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            for (int index = e.StartIndex; index < e.EndIndex; index++)
            {
                ListViewItem item;
                if (index < _dataSource.Count)
                {
                    item = _dataSourceCreateItem(_dataSource[index]);

                    if (this.SmallImageList != null)
                    {
                        item.ImageIndex = this.SmallImageList.Images.IndexOfKey(item.ImageKey);
                    }
                }
                else
                {
                    item = new ListViewItem();
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem());
                    }
                }

                _virtualCache[index] = item;
            }
        }

        void ifListView_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
            if (_searchList == null)
            {
                ListViewBinding binding = _bindings.OfType<SubItemBinding>().First(b => b.SubItemIndex == 0);

                if (binding != null)
                {
                    _searchList = new Dictionary<string, int>();

                    int index = 0;
                    foreach (object obj in _dataSource)
                    {
                        string value = binding.GetValue(obj).ToString();

                        _searchList[value] = index;

                        index++;
                    }
                }
            }

            if (_searchList != null)
            {
                string key = _searchList.Keys.FirstOrDefault(k => k.StartsWith(e.Text, StringComparison.OrdinalIgnoreCase));

                if (key != null)
                {
                    e.Index = _searchList[key];
                }
            }
        }
        #endregion

        #region Protected Member
        protected void SearchHeaderComparer(HeaderOrder ho)
        {
            Random r = new Random();

            IEnumerable<ListViewItem> items = Items.Cast<ListViewItem>();
            List<string> list = items.Select(i => i.SubItems[ho.SubItemIndex].Text).Where(s => !String.IsNullOrEmpty(s)).OrderBy(i => r.Next(-1, 1)).ToList();

            list = list.GetRange(
                0,
                (list.Count >= 10 ? 10 : list.Count)
            );

            long tryObjLong;
            double tryObjDouble;
            DateTime tryObjDate;

            Dictionary<Comparison<string>, int> dict = new Dictionary<Comparison<string>, int>();

            foreach (string str in list)
            {
                Comparison<string> func = null;

                if (Double.TryParse(str, out tryObjDouble))
                {
                    func = ho.CompareDouble;
                }
                else if (Int64.TryParse(str, out tryObjLong))
                {
                    func = ho.CompareLong;
                }
                else if (DateTime.TryParse(str, out tryObjDate))
                {
                    func = ho.CompareDate;
                }
                else
                {
                    string[] strs = str.Split(" ".ToCharArray());

                    if (strs.Length > 1 && Double.TryParse(strs[0], out tryObjDouble))
                    {
                        func = ho.CompareSubString;
                    }
                    else
                    {
                        func = ho.CompareString;
                    }
                }

                if (func != null)
                {
                    if (!dict.ContainsKey(func))
                    {
                        dict[func] = 0;
                    }

                    dict[func] += 1;
                }
            }

            if (dict.Count == 1)
            {
                ho.Comparison = dict.Keys.First();
            }
            else
            {
                ho.Comparison = ho.CompareString;
            }
        }

        [DebuggerHidden()]
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_CREATE:
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        if (Environment.OSVersion.Version.Major >= 6)
                        {
                            NativeMethods.SetWindowTheme(this.Handle, "Explorer", null);
                        }
                    }
                    break;
            }

            base.WndProc(ref m);
        }
        #endregion

        #region Fields - DataSource
        [Browsable(false)]
        public object DataSource
        {
            get { return _dataSource; }
            set
            {
                List<object> list = value as List<object>;

                if (list == null)
                {
                    if (value is IEnumerable<object>)
                    {
                        IEnumerable<object> e = value as IEnumerable<object>;

                        list = new List<object>(e);
                    }
                    else if (value is IEnumerable)
                    {
                        list = new List<object>();
                        IEnumerable e = value as IEnumerable;

                        foreach (object item in e)
                        {
                            list.Add(item);
                        }
                    }
                    else if (list == null && value != null)
                    {
                        list = new List<object>(new object[] { _dataSource });
                    }
                }

                _dataSource = list;

                _dataSourceRefresh();
            }
        }

        [Browsable(false)]
        public ListViewBindingCollection Bindings
        {
            get { return _bindings; }
        }
        #endregion

        #region Fields - ViewContext
        [DefaultValue(null)]
        public ContextMenuStrip ViewContextMenu
        {
            get { return _menuStrip; }
            set
            {
                if (_menuStrip != value)
                {
                    _resetOld();

                    _menuStrip = value;
                    base.ContextMenuStrip = _menuStrip;

                    if (_menuStrip != null)
                    {
                        _setNew(_menuStrip.Items.Add);
                    }
                }
            }
        }

        [DefaultValue(null)]
        public ToolStripMenuItem ViewMenuItem
        {
            get
            {
                return _menuItem;
            }
            set
            {
                _resetOld();

                _menuItem = value;

                if (_menuItem != null)
                {
                    _setNew(_menuItem.DropDownItems.Add);
                }
            }
        }

        new public View View
        {
            get { return base.View; }
            set
            {
                base.View = value;

                foreach (var kvp in _menuView)
                {
                    kvp.Key.Checked = (value == kvp.Value);
                }

                Settings.SetComputerSetting("main." + this.Name + ".view", value);
            }
        }
        #endregion

        #region Fields - HeadSorting
        [Browsable(false)]
        public List<HeaderOrder> HeaderOrders
        {
            get { return _orders; }
        }

        [Browsable(false)]
        [DefaultValue(null)]
        public ColumnHeader ActiveColumn
        {
            get { return _activeHead.Header; }
            protected set
            {
                try
                {
                    HeaderOrder ho = _orders.FirstOrDefault(ho2 => ho2.Header == value);

                    if (ho == null)
                    {
                        ho = new HeaderOrder(value, value.DisplayIndex);

                        _orders.Add(ho);
                    }

                    if (ActiveHead == ho)
                    {
                        SortOrder = (SortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);

                        if (!this.VirtualMode) this.Sort();
                    }
                    else
                    {
                        ActiveHead = ho;
                    }
                }
                catch
                {
                }
            }
        }

        [Browsable(false)]
        [DefaultValue(null)]
        public HeaderOrder ActiveHead
        {
            get { return _activeHead; }
            set
            {
                try
                {
                    if (_activeHead != null && _activeHead != value)
                    {
                        this.SetSortIcon(_activeHead.Header.DisplayIndex, SortOrder.None);
                    }

                    _activeHead = value;
                    SortOrder = SortOrder.Ascending;
                }
                catch
                {
                }
            }
        }

        [DefaultValue(SortOrder.Ascending)]
        public SortOrder SortOrder
        {
            get { return _sortOrder; }
            set
            {
                _sortOrder = value;

                if (_activeHead != null && !this.VirtualMode)
                {
                    this.Sorting = _sortOrder;

                    this.SetSortIcon(_activeHead.Header.DisplayIndex, _sortOrder);

                    this.Sort();
                }
            }
        }
        #endregion

        #region Member
        public override void Refresh()
        {
            _dataSourceRefresh();

            base.Refresh();
        }
        #endregion

        #region Events
        private void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item != null)
            {
                foreach (var kvp in _menuView)
                {
                    bool check = (kvp.Key == item);

                    if (check) this.View = kvp.Value;

                    kvp.Key.Checked = check;
                }
            }
        }

        void ListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            ColumnHeader header = this.Columns[e.ColumnIndex];

            int w = Settings.GetComputerSetting<int>("main." + this.Name + ".columns." + header.Index + ".width");

            if (w != 0 && w != 60 && header.Width == 60)
            {
                header.Width = w;
            }

            if (header.Width != 60) Settings.SetComputerSetting("main." + this.Name + ".columns." + header.Index + ".width", header.Width);
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader head = this.Columns[e.Column];

            this.ActiveColumn = head;
        }
        #endregion

        #region HeaderOrder
        public class HeaderOrder
        {
            #region Vars
            private ColumnHeader _header;
            private int _subItemIndex;

            private Comparison<string> _comparer;
            #endregion

            #region Init
            public HeaderOrder(ColumnHeader header, int subItemIndex)
            {
                _header = header;
                _subItemIndex = subItemIndex;
            }
            #endregion

            #region Fields
            public ColumnHeader Header
            {
                get { return _header; }
            }

            public int SubItemIndex
            {
                get { return _subItemIndex; }
                set { _subItemIndex = value; }
            }

            public Comparison<string> Comparison
            {
                get { return _comparer; }
                set { _comparer = value; }
            }
            #endregion

            #region Comparison Member
            public int CompareLong(string s1, string s2)
            {
                long l1 = Int64.Parse(s1);
                long l2 = Int64.Parse(s2);

                return (int)(l1 - l2);
            }

            public int CompareDouble(string s1, string s2)
            {
                double d1 = Double.Parse(s1);
                double d2 = Double.Parse(s2);

                return (int)(d1 - d2);
            }

            public int CompareDate(string s1, string s2)
            {
                DateTime d1 = DateTime.Parse(s1);
                DateTime d2 = DateTime.Parse(s2);

                return DateTime.Compare(d1, d2);
            }

            public int CompareString(string s1, string s2)
            {
                return String.Compare(s1, s2);
            }

            public int CompareSubString(string s1, string s2)
            {
                if (!String.IsNullOrEmpty(s1) && !String.IsNullOrEmpty(s2))
                {
                    char[] sep = " ".ToCharArray();
                    string[] sa1 = s1.Split(sep);
                    string[] sa2 = s2.Split(sep);

                    return CompareDouble(sa1[0], sa2[0]);
                }

                return CompareString(s1, s2);
            }
            #endregion
        }
        #endregion

        #region Bindings
        public enum BindingType
        {
            Delegate,
            StaticValue,
            ObjectProperty,
        }

        public abstract class ListViewBinding
        {
            #region Vars
            private BindingType _type;

            private string _propertyName;
            private Type _objectType;
            private PropertyInfo _objectPropertyInfo;

            private object _valueStatic;
            private Func<object, object> _valueDelegate;
            #endregion

            #region Init
            private ListViewBinding()
            {
            }

            private ListViewBinding(BindingType type)
            {
                _type = type;
            }

            public ListViewBinding(object staticValue, bool convert)
                : this(BindingType.StaticValue)
            {
                _valueStatic = staticValue;
            }

            public ListViewBinding(string objectPropertyName)
                : this(BindingType.ObjectProperty)
            {
                _propertyName = objectPropertyName;
            }

            public ListViewBinding(Func<object, object> valueDelegate)
                : this(BindingType.Delegate)
            {
                _valueDelegate = valueDelegate;
            }
            #endregion

            #region Fields
            public string PropertyName
            {
                get { return _propertyName; }
                set { _propertyName = value; }
            }
            #endregion

            #region Member
            public PropertyInfo GetPropertyInfo(object obj)
            {
                if (obj != null)
                {
                    if (obj.GetType() == _objectType && _objectPropertyInfo != null)
                    {
                        return _objectPropertyInfo;
                    }
                    else
                    {
                        _objectType = obj.GetType();
                        _objectPropertyInfo = _objectType.GetProperty(_propertyName);

                        return _objectPropertyInfo;
                    }
                }

                return null;
            }

            public object GetValue(object obj)
            {
                switch (_type)
                {
                    case BindingType.Delegate:
                        return _valueDelegate(obj);
                    case BindingType.ObjectProperty:
                        PropertyInfo info = GetPropertyInfo(obj);

                        if (info != null)
                        {
                            return info.GetValue(obj, null);
                        }

                        return null;
                    case BindingType.StaticValue:
                        return _valueStatic;
                }

                return null;
            }

            public abstract void SetItem(ListViewItem item, object value);
            #endregion
        }

        public class SubItemBinding : ListViewBinding
        {
            #region Vars
            private int _subItemIndex;
            #endregion

            #region Init
            public SubItemBinding(int subItemIndex, object staticValue, bool convert)
                : base(staticValue, convert)
            {
                _subItemIndex = subItemIndex;
            }

            public SubItemBinding(int subItemIndex, string propertyName)
                : base(propertyName)
            {
                _subItemIndex = subItemIndex;
            }

            public SubItemBinding(int subItemIndex, Func<object, object> valueDelegate)
                : base(valueDelegate)
            {
                _subItemIndex = subItemIndex;
            }
            #endregion

            #region Fields
            public int SubItemIndex
            {
                get { return _subItemIndex; }
            }
            #endregion

            #region Member
            public override void SetItem(ListViewItem item, object value)
            {
                while (item.SubItems.Count <= _subItemIndex)
                {
                    item.SubItems.Add("");
                }

                item.SubItems[_subItemIndex].Text = (value == null ? "" : value.ToString());
            }
            #endregion
        }

        public class PropertyBinding : ListViewBinding
        {
            #region Vars
            private PropertyInfo _itemPropertyInfo;
            #endregion

            #region Init
            public PropertyBinding(string itemPropertyName, object staticValue, bool convert)
                : base(staticValue, convert)
            {
                _loadPropertyInfo(itemPropertyName);
            }

            public PropertyBinding(string itemPropertyName, string objectPropertyName)
                : base(objectPropertyName)
            {
                _loadPropertyInfo(itemPropertyName);
            }

            public PropertyBinding(string itemPropertyName, Func<object, object> valueDelegate)
                : base(valueDelegate)
            {
                _loadPropertyInfo(itemPropertyName);
            }
            #endregion

            #region Private Member
            private void _loadPropertyInfo(string itemPropertyName)
            {
                Type itemType = typeof(ListViewItem);

                _itemPropertyInfo = itemType.GetProperty(itemPropertyName);

                if (_itemPropertyInfo == null)
                {
                    throw new ArgumentException("Property not found.", "itemPropertyName", null);
                }
            }
            #endregion

            #region Member
            public override void SetItem(ListViewItem item, object value)
            {
                _itemPropertyInfo.SetValue(item, value, null);
            }
            #endregion
        }
        #endregion

        #region ListViewBindingCollection
        public class ListViewBindingCollection : VirtualList<ListViewBinding>
        {
            private ifListView _listView = null;

            internal ListViewBindingCollection(ifListView listView)
            {
                _listView = listView;
            }

            public override void Add(ListViewBinding item)
            {
                base.Add(item);

                _listView._dataSourceRefresh();
            }

            public override bool Remove(ListViewBinding item)
            {
                bool ret = base.Remove(item);

                _listView._dataSourceRefresh();

                return ret;
            }
        }
        #endregion

        #region ListViewItemSorter
        public class ItemSorter : System.Collections.IComparer
        {
            #region Vars
            private ifListView _sorter;
            #endregion

            #region Init
            public ItemSorter(ifListView sorter)
            {
                _sorter = sorter;
            }
            #endregion

            #region IComparer Member
            public int Compare(object x, object y)
            {
                HeaderOrder ho = _sorter.ActiveHead;

                if (ho == null) return 0;

                if (ho.Comparison == null)
                {
                    _sorter.SearchHeaderComparer(_sorter.ActiveHead);
                }

                int c = 0;
                int subIndex = ho.SubItemIndex;

                try
                {
                    c = ho.Comparison(
                        ((ListViewItem)x).SubItems[subIndex].Text,
                        ((ListViewItem)y).SubItems[subIndex].Text
                    );

                    if (_sorter.SortOrder == SortOrder.Descending) c *= -1;

                    return c;
                }
                catch
                {
                }

                return 0;
            }
            #endregion
        }
        #endregion
    }
}
