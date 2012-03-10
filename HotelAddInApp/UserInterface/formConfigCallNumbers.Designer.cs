namespace HotelAddInApp
{
    partial class formConfigCallNumbers
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.groupEdit = new System.Windows.Forms.GroupBox();
            this.textPhone = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdNew = new System.Windows.Forms.Button();
            this.listRooms = new System.Windows.Forms.ListView();
            this.colNumber = new System.Windows.Forms.ColumnHeader();
            this.colPhone = new System.Windows.Forms.ColumnHeader();
            this.groupEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(291, 394);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "Schließen";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Location = new System.Drawing.Point(291, 267);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdEdit.TabIndex = 2;
            this.cmdEdit.Text = "Bearbeiten";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // groupEdit
            // 
            this.groupEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupEdit.Controls.Add(this.textPhone);
            this.groupEdit.Controls.Add(this.cmdSave);
            this.groupEdit.Controls.Add(this.textDescription);
            this.groupEdit.Controls.Add(this.label3);
            this.groupEdit.Controls.Add(this.label1);
            this.groupEdit.Enabled = false;
            this.groupEdit.Location = new System.Drawing.Point(12, 296);
            this.groupEdit.Name = "groupEdit";
            this.groupEdit.Size = new System.Drawing.Size(354, 76);
            this.groupEdit.TabIndex = 3;
            this.groupEdit.TabStop = false;
            this.groupEdit.Text = "Erstellen/Bearbeiten";
            // 
            // textPhone
            // 
            this.textPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textPhone.Location = new System.Drawing.Point(99, 45);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(167, 20);
            this.textPhone.TabIndex = 5;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(272, 43);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "Speichern";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // textDescription
            // 
            this.textDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textDescription.Location = new System.Drawing.Point(99, 19);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(248, 20);
            this.textDescription.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nebenstelle:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bezeichnung:";
            // 
            // cmdNew
            // 
            this.cmdNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNew.Location = new System.Drawing.Point(210, 267);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(75, 23);
            this.cmdNew.TabIndex = 1;
            this.cmdNew.Text = "Neu";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // listRooms
            // 
            this.listRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listRooms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumber,
            this.colPhone});
            this.listRooms.FullRowSelect = true;
            this.listRooms.Location = new System.Drawing.Point(12, 12);
            this.listRooms.MultiSelect = false;
            this.listRooms.Name = "listRooms";
            this.listRooms.Size = new System.Drawing.Size(354, 249);
            this.listRooms.TabIndex = 0;
            this.listRooms.UseCompatibleStateImageBehavior = false;
            this.listRooms.View = System.Windows.Forms.View.Details;
            // 
            // colNumber
            // 
            this.colNumber.Text = "Zimmer-Bezeichnung";
            this.colNumber.Width = 175;
            // 
            // colPhone
            // 
            this.colPhone.Text = "Nebenstellen-Nummer";
            this.colPhone.Width = 150;
            // 
            // formConfigCallNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(378, 429);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.groupEdit);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.listRooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formConfigCallNumbers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Zimmermummern-Einstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formConfigRooms_FormClosing);
            this.groupEdit.ResumeLayout(false);
            this.groupEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.GroupBox groupEdit;
        private System.Windows.Forms.TextBox textPhone;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.ListView listRooms;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colPhone;
    }
}