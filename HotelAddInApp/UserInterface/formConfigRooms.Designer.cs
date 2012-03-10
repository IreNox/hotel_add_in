namespace HotelAddInApp
{
    partial class formConfigRooms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listRooms = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colRoomCode = new System.Windows.Forms.ColumnHeader();
            this.colDirsID = new System.Windows.Forms.ColumnHeader();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.groupEdit = new System.Windows.Forms.GroupBox();
            this.textDirsID = new System.Windows.Forms.TextBox();
            this.textRoomCode = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.colDirsIdPrice = new System.Windows.Forms.ColumnHeader();
            this.colPersons = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.textDirsIdPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textPersons = new System.Windows.Forms.TextBox();
            this.groupEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // listRooms
            // 
            this.listRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listRooms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colRoomCode,
            this.colDirsID,
            this.colDirsIdPrice,
            this.colPersons});
            this.listRooms.FullRowSelect = true;
            this.listRooms.Location = new System.Drawing.Point(12, 12);
            this.listRooms.MultiSelect = false;
            this.listRooms.Name = "listRooms";
            this.listRooms.Size = new System.Drawing.Size(470, 289);
            this.listRooms.TabIndex = 0;
            this.listRooms.UseCompatibleStateImageBehavior = false;
            this.listRooms.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 124;
            // 
            // colRoomCode
            // 
            this.colRoomCode.Text = "Lodgit Kürzel";
            this.colRoomCode.Width = 74;
            // 
            // colDirsID
            // 
            this.colDirsID.Text = "DirsID";
            this.colDirsID.Width = 42;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(389, 69);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "Speichern";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNew.Location = new System.Drawing.Point(326, 307);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(75, 23);
            this.cmdNew.TabIndex = 1;
            this.cmdNew.Text = "Neu";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // groupEdit
            // 
            this.groupEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupEdit.Controls.Add(this.textPersons);
            this.groupEdit.Controls.Add(this.label5);
            this.groupEdit.Controls.Add(this.textDirsIdPrice);
            this.groupEdit.Controls.Add(this.label4);
            this.groupEdit.Controls.Add(this.textDirsID);
            this.groupEdit.Controls.Add(this.textRoomCode);
            this.groupEdit.Controls.Add(this.cmdSave);
            this.groupEdit.Controls.Add(this.textName);
            this.groupEdit.Controls.Add(this.label3);
            this.groupEdit.Controls.Add(this.label2);
            this.groupEdit.Controls.Add(this.label1);
            this.groupEdit.Enabled = false;
            this.groupEdit.Location = new System.Drawing.Point(12, 336);
            this.groupEdit.Name = "groupEdit";
            this.groupEdit.Size = new System.Drawing.Size(470, 100);
            this.groupEdit.TabIndex = 3;
            this.groupEdit.TabStop = false;
            this.groupEdit.Text = "Erstellen/Bearbeiten";
            // 
            // textDirsID
            // 
            this.textDirsID.Location = new System.Drawing.Point(99, 71);
            this.textDirsID.Name = "textDirsID";
            this.textDirsID.Size = new System.Drawing.Size(96, 20);
            this.textDirsID.TabIndex = 6;
            // 
            // textRoomCode
            // 
            this.textRoomCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textRoomCode.Location = new System.Drawing.Point(99, 45);
            this.textRoomCode.Name = "textRoomCode";
            this.textRoomCode.Size = new System.Drawing.Size(96, 20);
            this.textRoomCode.TabIndex = 5;
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(99, 19);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(365, 20);
            this.textName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lodgit Kürzel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "DirsID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bezeichnung:";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Location = new System.Drawing.Point(407, 307);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdEdit.TabIndex = 2;
            this.cmdEdit.Text = "Bearbeiten";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(407, 442);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "Schließen";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // colDirsIdPrice
            // 
            this.colDirsIdPrice.Text = "DirsID für Preis";
            this.colDirsIdPrice.Width = 83;
            // 
            // colPersons
            // 
            this.colPersons.Text = "Standart Personenzahl";
            this.colPersons.Width = 119;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "DirsID für Preis:";
            // 
            // textDirsIdPrice
            // 
            this.textDirsIdPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textDirsIdPrice.Location = new System.Drawing.Point(287, 71);
            this.textDirsIdPrice.Name = "textDirsIdPrice";
            this.textDirsIdPrice.Size = new System.Drawing.Size(96, 20);
            this.textDirsIdPrice.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Stardart Personenzahl:";
            // 
            // textPersons
            // 
            this.textPersons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textPersons.Location = new System.Drawing.Point(321, 45);
            this.textPersons.Name = "textPersons";
            this.textPersons.Size = new System.Drawing.Size(143, 20);
            this.textPersons.TabIndex = 11;
            // 
            // formConfigRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(494, 477);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.groupEdit);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.listRooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formConfigRooms";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Zimmer-Einstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formConfigRooms_FormClosing);
            this.groupEdit.ResumeLayout(false);
            this.groupEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listRooms;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.GroupBox groupEdit;
        private System.Windows.Forms.TextBox textDirsID;
        private System.Windows.Forms.TextBox textRoomCode;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colRoomCode;
        private System.Windows.Forms.ColumnHeader colDirsID;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ColumnHeader colDirsIdPrice;
        private System.Windows.Forms.ColumnHeader colPersons;
        private System.Windows.Forms.TextBox textDirsIdPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPersons;
        private System.Windows.Forms.Label label5;

    }
}