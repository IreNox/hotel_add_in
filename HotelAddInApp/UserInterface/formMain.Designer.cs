namespace HotelAddInApp
{
    partial class formMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.progressStatus = new System.Windows.Forms.ProgressBar();
            this.groupStatus = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdRunWrite = new System.Windows.Forms.Button();
            this.cmdRunRead = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageQuery = new System.Windows.Forms.TabPage();
            this.ucHotelAddIn1 = new HotelAddIn.ucHotelAddIn();
            this.pageOnlineBooking = new System.Windows.Forms.TabPage();
            this.splitContainerBooking = new System.Windows.Forms.SplitContainer();
            this.listBooking = new HotelAddInApp.ifListView();
            this.colBookingId = new System.Windows.Forms.ColumnHeader();
            this.colBookingName = new System.Windows.Forms.ColumnHeader();
            this.colBookingCompany = new System.Windows.Forms.ColumnHeader();
            this.colBookingDate = new System.Windows.Forms.ColumnHeader();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listBookingData = new HotelAddInApp.ifListView();
            this.colBkShowProperty = new System.Windows.Forms.ColumnHeader();
            this.colBkShowValue = new System.Windows.Forms.ColumnHeader();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBookingDetails = new HotelAddInApp.ifListView();
            this.colBkDetailsArrival = new System.Windows.Forms.ColumnHeader();
            this.colBkDetailsDepature = new System.Windows.Forms.ColumnHeader();
            this.colBkDetailsRoomtype = new System.Windows.Forms.ColumnHeader();
            this.colBkDetailsRoomCount = new System.Windows.Forms.ColumnHeader();
            this.colBkDetailsPricePerRoom = new System.Windows.Forms.ColumnHeader();
            this.colBkDetailsPricePerDay = new System.Windows.Forms.ColumnHeader();
            this.colBkDetailsRoomtypeId = new System.Windows.Forms.ColumnHeader();
            this.listBookingAddOns = new HotelAddInApp.ifListView();
            this.colBkAddOnsCount = new System.Windows.Forms.ColumnHeader();
            this.colBkAddOnsDescription = new System.Windows.Forms.ColumnHeader();
            this.colBkAddOnsPrice = new System.Windows.Forms.ColumnHeader();
            this.colBkAddOnsPricePerDay = new System.Windows.Forms.ColumnHeader();
            this.panelBookingButtons = new System.Windows.Forms.Panel();
            this.buttonBookingRemoveAva = new System.Windows.Forms.Button();
            this.buttonOnlineDelete = new System.Windows.Forms.Button();
            this.pageCallWatcher = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listCall = new HotelAddInApp.ifListView();
            this.colCallLine = new System.Windows.Forms.ColumnHeader();
            this.colCallDateTime = new System.Windows.Forms.ColumnHeader();
            this.colCallNumber = new System.Windows.Forms.ColumnHeader();
            this.colCallDuration = new System.Windows.Forms.ColumnHeader();
            this.colCallUnits = new System.Windows.Forms.ColumnHeader();
            this.groupCallHelp = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCallHelp = new System.Windows.Forms.Button();
            this.panelCallSearch = new System.Windows.Forms.Panel();
            this.textCallSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkCallAutostart = new System.Windows.Forms.CheckBox();
            this.textCallBaud = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCallStatus = new System.Windows.Forms.TextBox();
            this.textCallPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCallStart = new System.Windows.Forms.Button();
            this.pageStatus = new System.Windows.Forms.TabPage();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.menuConfig = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuConfigAddIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfigDirs21 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfigRooms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfigCallWatcher = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfigCallNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfigGastware = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfigHotels = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfigDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmdConfig = new System.Windows.Forms.Button();
            this.timerRead = new System.Windows.Forms.Timer(this.components);
            this.menuConfigCubeSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.groupStatus.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.pageQuery.SuspendLayout();
            this.pageOnlineBooking.SuspendLayout();
            this.splitContainerBooking.Panel1.SuspendLayout();
            this.splitContainerBooking.Panel2.SuspendLayout();
            this.splitContainerBooking.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelBookingButtons.SuspendLayout();
            this.pageCallWatcher.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupCallHelp.SuspendLayout();
            this.panelCallSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pageStatus.SuspendLayout();
            this.menuConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressStatus
            // 
            this.progressStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressStatus.Location = new System.Drawing.Point(6, 42);
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(608, 23);
            this.progressStatus.TabIndex = 2;
            // 
            // groupStatus
            // 
            this.groupStatus.Controls.Add(this.labelStatus);
            this.groupStatus.Controls.Add(this.cmdStart);
            this.groupStatus.Controls.Add(this.progressStatus);
            this.groupStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupStatus.Location = new System.Drawing.Point(3, 3);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(620, 100);
            this.groupStatus.TabIndex = 3;
            this.groupStatus.TabStop = false;
            this.groupStatus.Text = "#";
            this.groupStatus.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(4, 26);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(14, 13);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "#";
            // 
            // cmdStart
            // 
            this.cmdStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStart.Location = new System.Drawing.Point(539, 71);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 0;
            this.cmdStart.Text = "Stoppen";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(538, 446);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(99, 32);
            this.cmdExit.TabIndex = 4;
            this.cmdExit.Text = "Beenden";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdRunWrite
            // 
            this.cmdRunWrite.Location = new System.Drawing.Point(0, 1);
            this.cmdRunWrite.Name = "cmdRunWrite";
            this.cmdRunWrite.Size = new System.Drawing.Size(136, 32);
            this.cmdRunWrite.TabIndex = 6;
            this.cmdRunWrite.Text = "Verfügbarkeiten senden";
            this.cmdRunWrite.UseVisualStyleBackColor = true;
            this.cmdRunWrite.Click += new System.EventHandler(this.cmdRunWrite_Click);
            // 
            // cmdRunRead
            // 
            this.cmdRunRead.Location = new System.Drawing.Point(142, 1);
            this.cmdRunRead.Name = "cmdRunRead";
            this.cmdRunRead.Size = new System.Drawing.Size(136, 32);
            this.cmdRunRead.TabIndex = 7;
            this.cmdRunRead.Text = "Buchungen einlesen";
            this.cmdRunRead.UseVisualStyleBackColor = true;
            this.cmdRunRead.Click += new System.EventHandler(this.cmdRunRead_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.pageQuery);
            this.tabControl1.Controls.Add(this.pageOnlineBooking);
            this.tabControl1.Controls.Add(this.pageCallWatcher);
            this.tabControl1.Controls.Add(this.pageStatus);
            this.tabControl1.Location = new System.Drawing.Point(3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(634, 436);
            this.tabControl1.TabIndex = 8;
            // 
            // pageQuery
            // 
            this.pageQuery.Controls.Add(this.ucHotelAddIn1);
            this.pageQuery.Location = new System.Drawing.Point(4, 22);
            this.pageQuery.Name = "pageQuery";
            this.pageQuery.Size = new System.Drawing.Size(626, 410);
            this.pageQuery.TabIndex = 0;
            this.pageQuery.Text = "Abfrage";
            this.pageQuery.UseVisualStyleBackColor = true;
            // 
            // ucHotelAddIn1
            // 
            this.ucHotelAddIn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHotelAddIn1.Location = new System.Drawing.Point(0, 0);
            this.ucHotelAddIn1.Name = "ucHotelAddIn1";
            this.ucHotelAddIn1.Size = new System.Drawing.Size(626, 410);
            this.ucHotelAddIn1.TabIndex = 1;
            // 
            // pageOnlineBooking
            // 
            this.pageOnlineBooking.Controls.Add(this.splitContainerBooking);
            this.pageOnlineBooking.Controls.Add(this.panelBookingButtons);
            this.pageOnlineBooking.Controls.Add(this.groupStatus);
            this.pageOnlineBooking.Location = new System.Drawing.Point(4, 22);
            this.pageOnlineBooking.Name = "pageOnlineBooking";
            this.pageOnlineBooking.Padding = new System.Windows.Forms.Padding(3);
            this.pageOnlineBooking.Size = new System.Drawing.Size(626, 410);
            this.pageOnlineBooking.TabIndex = 1;
            this.pageOnlineBooking.Text = "Online Buchungen";
            this.pageOnlineBooking.UseVisualStyleBackColor = true;
            // 
            // splitContainerBooking
            // 
            this.splitContainerBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBooking.Location = new System.Drawing.Point(3, 103);
            this.splitContainerBooking.Name = "splitContainerBooking";
            this.splitContainerBooking.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBooking.Panel1
            // 
            this.splitContainerBooking.Panel1.Controls.Add(this.listBooking);
            // 
            // splitContainerBooking.Panel2
            // 
            this.splitContainerBooking.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainerBooking.Panel2Collapsed = true;
            this.splitContainerBooking.Size = new System.Drawing.Size(620, 270);
            this.splitContainerBooking.SplitterDistance = 155;
            this.splitContainerBooking.TabIndex = 12;
            // 
            // listBooking
            // 
            this.listBooking.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listBooking.CheckBoxes = true;
            this.listBooking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBookingId,
            this.colBookingName,
            this.colBookingCompany,
            this.colBookingDate});
            this.listBooking.DataSource = null;
            this.listBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBooking.FullRowSelect = true;
            this.listBooking.Location = new System.Drawing.Point(0, 0);
            this.listBooking.Name = "listBooking";
            this.listBooking.Size = new System.Drawing.Size(620, 270);
            this.listBooking.TabIndex = 10;
            this.listBooking.UseCompatibleStateImageBehavior = false;
            this.listBooking.View = System.Windows.Forms.View.Details;
            this.listBooking.ItemActivate += new System.EventHandler(this.listBooking_ItemActivate);
            this.listBooking.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listBooking_ItemChecked);
            this.listBooking.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBooking_KeyUp);
            // 
            // colBookingId
            // 
            this.colBookingId.Text = "Id";
            this.colBookingId.Width = 76;
            // 
            // colBookingName
            // 
            this.colBookingName.Text = "Name";
            this.colBookingName.Width = 154;
            // 
            // colBookingCompany
            // 
            this.colBookingCompany.Text = "Firma";
            this.colBookingCompany.Width = 73;
            // 
            // colBookingDate
            // 
            this.colBookingDate.Text = "Datum";
            this.colBookingDate.Width = 80;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listBookingData);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(150, 46);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 2;
            // 
            // listBookingData
            // 
            this.listBookingData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBkShowProperty,
            this.colBkShowValue});
            this.listBookingData.DataSource = null;
            this.listBookingData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBookingData.FullRowSelect = true;
            this.listBookingData.Location = new System.Drawing.Point(0, 0);
            this.listBookingData.Name = "listBookingData";
            this.listBookingData.Size = new System.Drawing.Size(150, 25);
            this.listBookingData.TabIndex = 0;
            this.listBookingData.UseCompatibleStateImageBehavior = false;
            this.listBookingData.View = System.Windows.Forms.View.Details;
            // 
            // colBkShowProperty
            // 
            this.colBkShowProperty.Text = "Eingenschaft";
            this.colBkShowProperty.Width = 108;
            // 
            // colBkShowValue
            // 
            this.colBkShowValue.Text = "Wert";
            this.colBkShowValue.Width = 123;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBookingDetails);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBookingAddOns);
            this.splitContainer1.Size = new System.Drawing.Size(150, 25);
            this.splitContainer1.SplitterDistance = 78;
            this.splitContainer1.TabIndex = 1;
            // 
            // listBookingDetails
            // 
            this.listBookingDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBkDetailsArrival,
            this.colBkDetailsDepature,
            this.colBkDetailsRoomtype,
            this.colBkDetailsRoomCount,
            this.colBkDetailsPricePerRoom,
            this.colBkDetailsPricePerDay,
            this.colBkDetailsRoomtypeId});
            this.listBookingDetails.DataSource = null;
            this.listBookingDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBookingDetails.FullRowSelect = true;
            this.listBookingDetails.Location = new System.Drawing.Point(0, 0);
            this.listBookingDetails.Name = "listBookingDetails";
            this.listBookingDetails.Size = new System.Drawing.Size(78, 25);
            this.listBookingDetails.TabIndex = 0;
            this.listBookingDetails.UseCompatibleStateImageBehavior = false;
            this.listBookingDetails.View = System.Windows.Forms.View.Details;
            // 
            // colBkDetailsArrival
            // 
            this.colBkDetailsArrival.Text = "Anreise";
            this.colBkDetailsArrival.Width = 77;
            // 
            // colBkDetailsDepature
            // 
            this.colBkDetailsDepature.Text = "Abreise";
            this.colBkDetailsDepature.Width = 84;
            // 
            // colBkDetailsRoomtype
            // 
            this.colBkDetailsRoomtype.Text = "Zimmertype";
            this.colBkDetailsRoomtype.Width = 90;
            // 
            // colBkDetailsRoomCount
            // 
            this.colBkDetailsRoomCount.Text = "Zimmeranzahl";
            this.colBkDetailsRoomCount.Width = 48;
            // 
            // colBkDetailsPricePerRoom
            // 
            this.colBkDetailsPricePerRoom.Text = "Preis pro Zimmer";
            this.colBkDetailsPricePerRoom.Width = 57;
            // 
            // colBkDetailsPricePerDay
            // 
            this.colBkDetailsPricePerDay.Text = "Preis pro Tag";
            // 
            // colBkDetailsRoomtypeId
            // 
            this.colBkDetailsRoomtypeId.Text = "Zimmertype Id";
            // 
            // listBookingAddOns
            // 
            this.listBookingAddOns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBkAddOnsCount,
            this.colBkAddOnsDescription,
            this.colBkAddOnsPrice,
            this.colBkAddOnsPricePerDay});
            this.listBookingAddOns.DataSource = null;
            this.listBookingAddOns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBookingAddOns.FullRowSelect = true;
            this.listBookingAddOns.Location = new System.Drawing.Point(0, 0);
            this.listBookingAddOns.Name = "listBookingAddOns";
            this.listBookingAddOns.Size = new System.Drawing.Size(68, 25);
            this.listBookingAddOns.TabIndex = 0;
            this.listBookingAddOns.UseCompatibleStateImageBehavior = false;
            this.listBookingAddOns.View = System.Windows.Forms.View.Details;
            // 
            // colBkAddOnsCount
            // 
            this.colBkAddOnsCount.Text = "Anzahl";
            this.colBkAddOnsCount.Width = 27;
            // 
            // colBkAddOnsDescription
            // 
            this.colBkAddOnsDescription.Text = "Beschreibung";
            this.colBkAddOnsDescription.Width = 100;
            // 
            // colBkAddOnsPrice
            // 
            this.colBkAddOnsPrice.Text = "Einzelpreis";
            // 
            // colBkAddOnsPricePerDay
            // 
            this.colBkAddOnsPricePerDay.Text = "Preis pro Tag";
            // 
            // panelBookingButtons
            // 
            this.panelBookingButtons.Controls.Add(this.buttonBookingRemoveAva);
            this.panelBookingButtons.Controls.Add(this.buttonOnlineDelete);
            this.panelBookingButtons.Controls.Add(this.cmdRunRead);
            this.panelBookingButtons.Controls.Add(this.cmdRunWrite);
            this.panelBookingButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBookingButtons.Location = new System.Drawing.Point(3, 373);
            this.panelBookingButtons.Name = "panelBookingButtons";
            this.panelBookingButtons.Size = new System.Drawing.Size(620, 34);
            this.panelBookingButtons.TabIndex = 9;
            // 
            // buttonBookingRemoveAva
            // 
            this.buttonBookingRemoveAva.Location = new System.Drawing.Point(426, 1);
            this.buttonBookingRemoveAva.Name = "buttonBookingRemoveAva";
            this.buttonBookingRemoveAva.Size = new System.Drawing.Size(136, 32);
            this.buttonBookingRemoveAva.TabIndex = 9;
            this.buttonBookingRemoveAva.Text = "Datenbank leeren";
            this.buttonBookingRemoveAva.UseVisualStyleBackColor = true;
            this.buttonBookingRemoveAva.Click += new System.EventHandler(this.buttonBookingRemoveAva_Click);
            // 
            // buttonOnlineDelete
            // 
            this.buttonOnlineDelete.Location = new System.Drawing.Point(284, 1);
            this.buttonOnlineDelete.Name = "buttonOnlineDelete";
            this.buttonOnlineDelete.Size = new System.Drawing.Size(136, 32);
            this.buttonOnlineDelete.TabIndex = 8;
            this.buttonOnlineDelete.Text = "Adressdatei löschen";
            this.buttonOnlineDelete.UseVisualStyleBackColor = true;
            this.buttonOnlineDelete.Click += new System.EventHandler(this.buttonOnlineDelete_Click);
            // 
            // pageCallWatcher
            // 
            this.pageCallWatcher.Controls.Add(this.groupBox2);
            this.pageCallWatcher.Controls.Add(this.groupBox1);
            this.pageCallWatcher.Location = new System.Drawing.Point(4, 22);
            this.pageCallWatcher.Name = "pageCallWatcher";
            this.pageCallWatcher.Padding = new System.Windows.Forms.Padding(3);
            this.pageCallWatcher.Size = new System.Drawing.Size(626, 410);
            this.pageCallWatcher.TabIndex = 2;
            this.pageCallWatcher.Text = "Telefonüberwachung";
            this.pageCallWatcher.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listCall);
            this.groupBox2.Controls.Add(this.groupCallHelp);
            this.groupBox2.Controls.Add(this.buttonCallHelp);
            this.groupBox2.Controls.Add(this.panelCallSearch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(620, 331);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Letzte Telefonate";
            // 
            // listCall
            // 
            this.listCall.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCallLine,
            this.colCallDateTime,
            this.colCallNumber,
            this.colCallDuration,
            this.colCallUnits});
            this.listCall.DataSource = null;
            this.listCall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCall.FullRowSelect = true;
            this.listCall.Location = new System.Drawing.Point(5, 46);
            this.listCall.Name = "listCall";
            this.listCall.Size = new System.Drawing.Size(610, 220);
            this.listCall.TabIndex = 0;
            this.listCall.UseCompatibleStateImageBehavior = false;
            this.listCall.View = System.Windows.Forms.View.Details;
            this.listCall.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listCall_KeyUp);
            // 
            // colCallLine
            // 
            this.colCallLine.Text = "Nebenstelle";
            this.colCallLine.Width = 104;
            // 
            // colCallDateTime
            // 
            this.colCallDateTime.Text = "Zeitpunkt";
            this.colCallDateTime.Width = 110;
            // 
            // colCallNumber
            // 
            this.colCallNumber.Text = "Telefonnummer";
            this.colCallNumber.Width = 120;
            // 
            // colCallDuration
            // 
            this.colCallDuration.Text = "Dauer";
            this.colCallDuration.Width = 75;
            // 
            // colCallUnits
            // 
            this.colCallUnits.Text = "Einheiten";
            this.colCallUnits.Width = 75;
            // 
            // groupCallHelp
            // 
            this.groupCallHelp.Controls.Add(this.label7);
            this.groupCallHelp.Controls.Add(this.label6);
            this.groupCallHelp.Controls.Add(this.label5);
            this.groupCallHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupCallHelp.Location = new System.Drawing.Point(5, 266);
            this.groupCallHelp.Name = "groupCallHelp";
            this.groupCallHelp.Size = new System.Drawing.Size(610, 60);
            this.groupCallHelp.TabIndex = 3;
            this.groupCallHelp.TabStop = false;
            this.groupCallHelp.Text = "Hilfe";
            this.groupCallHelp.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 39);
            this.label7.TabIndex = 2;
            this.label7.Text = "- Such-Feld ein- und ausblenden\r\n- Liste Aktualisieren\r\n- Ausgewählte Elemente lö" +
                "schen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 39);
            this.label6.TabIndex = 1;
            this.label6.Text = "STRG + F\r\nF5\r\nEntf";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 39);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tastenkombinationen:\r\nWichtig: Die Liste\r\nmuss das aktiv sein.";
            // 
            // buttonCallHelp
            // 
            this.buttonCallHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCallHelp.BackgroundImage = global::HotelAddInApp.Properties.Resources.help_browser;
            this.buttonCallHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCallHelp.Location = new System.Drawing.Point(592, 0);
            this.buttonCallHelp.Name = "buttonCallHelp";
            this.buttonCallHelp.Size = new System.Drawing.Size(22, 20);
            this.buttonCallHelp.TabIndex = 2;
            this.buttonCallHelp.UseVisualStyleBackColor = true;
            this.buttonCallHelp.Click += new System.EventHandler(this.buttonCallHelp_Click);
            // 
            // panelCallSearch
            // 
            this.panelCallSearch.Controls.Add(this.textCallSearch);
            this.panelCallSearch.Controls.Add(this.label3);
            this.panelCallSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCallSearch.Location = new System.Drawing.Point(5, 18);
            this.panelCallSearch.Name = "panelCallSearch";
            this.panelCallSearch.Size = new System.Drawing.Size(610, 28);
            this.panelCallSearch.TabIndex = 1;
            this.panelCallSearch.Visible = false;
            // 
            // textCallSearch
            // 
            this.textCallSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textCallSearch.Location = new System.Drawing.Point(56, 1);
            this.textCallSearch.Name = "textCallSearch";
            this.textCallSearch.Size = new System.Drawing.Size(610, 20);
            this.textCallSearch.TabIndex = 1;
            this.textCallSearch.TextChanged += new System.EventHandler(this.textCallSearch_TextChanged);
            this.textCallSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listCall_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Suchen:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkCallAutostart);
            this.groupBox1.Controls.Add(this.textCallBaud);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textCallStatus);
            this.groupBox1.Controls.Add(this.textCallPort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdCallStart);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 73);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Status";
            // 
            // checkCallAutostart
            // 
            this.checkCallAutostart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkCallAutostart.AutoSize = true;
            this.checkCallAutostart.Location = new System.Drawing.Point(539, 17);
            this.checkCallAutostart.Name = "checkCallAutostart";
            this.checkCallAutostart.Size = new System.Drawing.Size(68, 17);
            this.checkCallAutostart.TabIndex = 9;
            this.checkCallAutostart.Text = "Autostart";
            this.checkCallAutostart.UseVisualStyleBackColor = true;
            this.checkCallAutostart.CheckedChanged += new System.EventHandler(this.checkCallAutostart_CheckedChanged);
            // 
            // textCallBaud
            // 
            this.textCallBaud.Location = new System.Drawing.Point(201, 18);
            this.textCallBaud.Name = "textCallBaud";
            this.textCallBaud.ReadOnly = true;
            this.textCallBaud.Size = new System.Drawing.Size(100, 20);
            this.textCallBaud.TabIndex = 8;
            this.textCallBaud.Text = "----";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bits/s:";
            // 
            // textCallStatus
            // 
            this.textCallStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textCallStatus.Location = new System.Drawing.Point(52, 44);
            this.textCallStatus.Name = "textCallStatus";
            this.textCallStatus.ReadOnly = true;
            this.textCallStatus.Size = new System.Drawing.Size(481, 20);
            this.textCallStatus.TabIndex = 6;
            this.textCallStatus.Text = "Bereit...";
            // 
            // textCallPort
            // 
            this.textCallPort.Location = new System.Drawing.Point(52, 18);
            this.textCallPort.Name = "textCallPort";
            this.textCallPort.ReadOnly = true;
            this.textCallPort.Size = new System.Drawing.Size(100, 20);
            this.textCallPort.TabIndex = 5;
            this.textCallPort.Text = "----";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // cmdCallStart
            // 
            this.cmdCallStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCallStart.Location = new System.Drawing.Point(539, 42);
            this.cmdCallStart.Name = "cmdCallStart";
            this.cmdCallStart.Size = new System.Drawing.Size(75, 23);
            this.cmdCallStart.TabIndex = 0;
            this.cmdCallStart.Text = "Starten";
            this.cmdCallStart.UseVisualStyleBackColor = true;
            this.cmdCallStart.Click += new System.EventHandler(this.cmdCallStart_Click);
            // 
            // pageStatus
            // 
            this.pageStatus.Controls.Add(this.textStatus);
            this.pageStatus.Location = new System.Drawing.Point(4, 22);
            this.pageStatus.Name = "pageStatus";
            this.pageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.pageStatus.Size = new System.Drawing.Size(626, 410);
            this.pageStatus.TabIndex = 3;
            this.pageStatus.Text = "Status";
            this.pageStatus.UseVisualStyleBackColor = true;
            // 
            // textStatus
            // 
            this.textStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textStatus.Location = new System.Drawing.Point(3, 3);
            this.textStatus.Multiline = true;
            this.textStatus.Name = "textStatus";
            this.textStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textStatus.Size = new System.Drawing.Size(620, 404);
            this.textStatus.TabIndex = 8;
            // 
            // menuConfig
            // 
            this.menuConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfigAddIn,
            this.menuConfigCubeSQL,
            this.menuConfigDirs21,
            this.menuConfigRooms,
            this.menuConfigCallWatcher,
            this.menuConfigCallNumbers,
            this.menuConfigGastware,
            this.menuConfigHotels,
            this.menuConfigDebug});
            this.menuConfig.Name = "menuConfig";
            this.menuConfig.Size = new System.Drawing.Size(269, 224);
            // 
            // menuConfigAddIn
            // 
            this.menuConfigAddIn.Name = "menuConfigAddIn";
            this.menuConfigAddIn.Size = new System.Drawing.Size(268, 22);
            this.menuConfigAddIn.Text = "AddIn-Einstellungen";
            this.menuConfigAddIn.Click += new System.EventHandler(this.menuConfigAddIn_Click);
            // 
            // menuConfigDirs21
            // 
            this.menuConfigDirs21.Name = "menuConfigDirs21";
            this.menuConfigDirs21.Size = new System.Drawing.Size(268, 22);
            this.menuConfigDirs21.Text = "Dirs21-Einstellungen";
            this.menuConfigDirs21.Click += new System.EventHandler(this.menuConfigDirs21_Click);
            // 
            // menuConfigRooms
            // 
            this.menuConfigRooms.Name = "menuConfigRooms";
            this.menuConfigRooms.Size = new System.Drawing.Size(268, 22);
            this.menuConfigRooms.Text = "Zimmertypen-Einstellungen";
            this.menuConfigRooms.Click += new System.EventHandler(this.menuConfigRooms_Click);
            // 
            // menuConfigCallWatcher
            // 
            this.menuConfigCallWatcher.Name = "menuConfigCallWatcher";
            this.menuConfigCallWatcher.Size = new System.Drawing.Size(268, 22);
            this.menuConfigCallWatcher.Text = "Telefonüberwachungs-Einstellungen";
            this.menuConfigCallWatcher.Click += new System.EventHandler(this.menuConfigCallWatcher_Click);
            // 
            // menuConfigCallNumbers
            // 
            this.menuConfigCallNumbers.Name = "menuConfigCallNumbers";
            this.menuConfigCallNumbers.Size = new System.Drawing.Size(268, 22);
            this.menuConfigCallNumbers.Text = "Zimmertelefon-Einstellungen";
            this.menuConfigCallNumbers.Click += new System.EventHandler(this.menuConfigCallNumbers_Click);
            // 
            // menuConfigGastware
            // 
            this.menuConfigGastware.Name = "menuConfigGastware";
            this.menuConfigGastware.Size = new System.Drawing.Size(268, 22);
            this.menuConfigGastware.Text = "Gastware-Schnittstelle";
            this.menuConfigGastware.Click += new System.EventHandler(this.menuConfigGastware_Click);
            // 
            // menuConfigHotels
            // 
            this.menuConfigHotels.Name = "menuConfigHotels";
            this.menuConfigHotels.Size = new System.Drawing.Size(268, 22);
            this.menuConfigHotels.Text = "Hotels einstellen";
            this.menuConfigHotels.Click += new System.EventHandler(this.menuConfigHotels_Click);
            // 
            // menuConfigDebug
            // 
            this.menuConfigDebug.Name = "menuConfigDebug";
            this.menuConfigDebug.Size = new System.Drawing.Size(268, 22);
            this.menuConfigDebug.Text = "Debug-Konsole";
            this.menuConfigDebug.Click += new System.EventHandler(this.menuConfigDebug_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Lodgit Schnittstelle";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // cmdConfig
            // 
            this.cmdConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdConfig.BackgroundImage = global::HotelAddInApp.Properties.Resources.config;
            this.cmdConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdConfig.Location = new System.Drawing.Point(3, 446);
            this.cmdConfig.Name = "cmdConfig";
            this.cmdConfig.Size = new System.Drawing.Size(36, 32);
            this.cmdConfig.TabIndex = 9;
            this.cmdConfig.UseVisualStyleBackColor = true;
            this.cmdConfig.Click += new System.EventHandler(this.cmdConfig_Click);
            // 
            // timerRead
            // 
            this.timerRead.Interval = 60000;
            this.timerRead.Tick += new System.EventHandler(this.timerRead_Tick);
            // 
            // menuConfigCubeSQL
            // 
            this.menuConfigCubeSQL.Name = "menuConfigCubeSQL";
            this.menuConfigCubeSQL.Size = new System.Drawing.Size(268, 22);
            this.menuConfigCubeSQL.Text = "CubeSQL-Einstellungen";
            this.menuConfigCubeSQL.Click += new System.EventHandler(this.menuConfigCubeSQL_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 481);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMain";
            this.Text = "Lodgit Online Buchungs Schnittstelle";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.groupStatus.ResumeLayout(false);
            this.groupStatus.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.pageQuery.ResumeLayout(false);
            this.pageOnlineBooking.ResumeLayout(false);
            this.splitContainerBooking.Panel1.ResumeLayout(false);
            this.splitContainerBooking.Panel2.ResumeLayout(false);
            this.splitContainerBooking.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panelBookingButtons.ResumeLayout(false);
            this.pageCallWatcher.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupCallHelp.ResumeLayout(false);
            this.groupCallHelp.PerformLayout();
            this.panelCallSearch.ResumeLayout(false);
            this.panelCallSearch.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pageStatus.ResumeLayout(false);
            this.pageStatus.PerformLayout();
            this.menuConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdExit;
        internal System.Windows.Forms.ProgressBar progressStatus;
        internal System.Windows.Forms.GroupBox groupStatus;
        internal System.Windows.Forms.Label labelStatus;
        internal System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageQuery;
        private System.Windows.Forms.TabPage pageOnlineBooking;
        private HotelAddIn.ucHotelAddIn ucHotelAddIn1;
        private System.Windows.Forms.Button cmdConfig;
        private System.Windows.Forms.ContextMenuStrip menuConfig;
        private System.Windows.Forms.ToolStripMenuItem menuConfigAddIn;
        private System.Windows.Forms.ToolStripMenuItem menuConfigDirs21;
        private System.Windows.Forms.ToolStripMenuItem menuConfigRooms;
        internal System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.TabPage pageCallWatcher;
        private System.Windows.Forms.GroupBox groupBox2;
        private ifListView listCall;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem menuConfigCallWatcher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.NotifyIcon notifyIcon;
        internal System.Windows.Forms.TextBox textCallStatus;
        private System.Windows.Forms.CheckBox checkCallAutostart;
        private System.Windows.Forms.ToolStripMenuItem menuConfigCallNumbers;
        private System.Windows.Forms.ToolStripMenuItem menuConfigGastware;
        private System.Windows.Forms.Panel panelCallSearch;
        private System.Windows.Forms.TextBox textCallSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colCallLine;
        private System.Windows.Forms.ColumnHeader colCallDateTime;
        private System.Windows.Forms.ColumnHeader colCallNumber;
        private System.Windows.Forms.ColumnHeader colCallDuration;
        private System.Windows.Forms.ColumnHeader colCallUnits;
        private System.Windows.Forms.Button buttonCallHelp;
        private System.Windows.Forms.GroupBox groupCallHelp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader colBookingId;
        private System.Windows.Forms.ColumnHeader colBookingName;
        internal ifListView listBooking;
        private System.Windows.Forms.ColumnHeader colBookingCompany;
        private System.Windows.Forms.ColumnHeader colBookingDate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ifListView listBookingData;
        private ifListView listBookingDetails;
        private ifListView listBookingAddOns;
        private System.Windows.Forms.ColumnHeader colBkShowProperty;
        private System.Windows.Forms.ColumnHeader colBkShowValue;
        private System.Windows.Forms.ColumnHeader colBkDetailsArrival;
        private System.Windows.Forms.ColumnHeader colBkDetailsDepature;
        private System.Windows.Forms.ColumnHeader colBkDetailsRoomtype;
        private System.Windows.Forms.ColumnHeader colBkDetailsRoomCount;
        private System.Windows.Forms.ColumnHeader colBkDetailsPricePerRoom;
        private System.Windows.Forms.ColumnHeader colBkDetailsPricePerDay;
        private System.Windows.Forms.ColumnHeader colBkDetailsRoomtypeId;
        private System.Windows.Forms.ColumnHeader colBkAddOnsCount;
        private System.Windows.Forms.ColumnHeader colBkAddOnsDescription;
        private System.Windows.Forms.ColumnHeader colBkAddOnsPrice;
        private System.Windows.Forms.ColumnHeader colBkAddOnsPricePerDay;
        private System.Windows.Forms.TabPage pageStatus;
        private System.Windows.Forms.ToolStripMenuItem menuConfigHotels;
        private System.Windows.Forms.Timer timerRead;
        internal System.Windows.Forms.Button cmdCallStart;
        internal System.Windows.Forms.TextBox textCallBaud;
        internal System.Windows.Forms.TextBox textCallPort;
        internal System.Windows.Forms.Button buttonOnlineDelete;
        private System.Windows.Forms.SplitContainer splitContainerBooking;
        internal System.Windows.Forms.Panel panelBookingButtons;
        internal System.Windows.Forms.Button buttonBookingRemoveAva;
        private System.Windows.Forms.Button cmdRunWrite;
        private System.Windows.Forms.Button cmdRunRead;
        private System.Windows.Forms.ToolStripMenuItem menuConfigDebug;
        private System.Windows.Forms.ToolStripMenuItem menuConfigCubeSQL;
    }
}

