namespace HotelAddInApp
{
    partial class formConfigDirs
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
            this.label1 = new System.Windows.Forms.Label();
            this.textKnr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.checkFlag = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.checkAutoRead = new System.Windows.Forms.CheckBox();
            this.buttonSelectHotel = new System.Windows.Forms.Button();
            this.textBreakfast = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kundennummer:";
            // 
            // textKnr
            // 
            this.textKnr.Location = new System.Drawing.Point(102, 39);
            this.textKnr.Name = "textKnr";
            this.textKnr.Size = new System.Drawing.Size(156, 20);
            this.textKnr.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bitte geben Sie hier die Dirs21-Zugangsdaten ein.";
            // 
            // textPwd
            // 
            this.textPwd.Location = new System.Drawing.Point(102, 65);
            this.textPwd.Name = "textPwd";
            this.textPwd.Size = new System.Drawing.Size(157, 20);
            this.textPwd.TabIndex = 4;
            this.textPwd.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Passwort:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(184, 241);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(102, 241);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // checkFlag
            // 
            this.checkFlag.AutoSize = true;
            this.checkFlag.Location = new System.Drawing.Point(102, 117);
            this.checkFlag.Name = "checkFlag";
            this.checkFlag.Size = new System.Drawing.Size(80, 17);
            this.checkFlag.TabIndex = 7;
            this.checkFlag.Text = "Flag setzen";
            this.checkFlag.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ausgabepfad:";
            // 
            // textOutput
            // 
            this.textOutput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textOutput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textOutput.Location = new System.Drawing.Point(103, 91);
            this.textOutput.Name = "textOutput";
            this.textOutput.Size = new System.Drawing.Size(156, 20);
            this.textOutput.TabIndex = 9;
            // 
            // checkAutoRead
            // 
            this.checkAutoRead.AutoSize = true;
            this.checkAutoRead.Location = new System.Drawing.Point(103, 140);
            this.checkAutoRead.Name = "checkAutoRead";
            this.checkAutoRead.Size = new System.Drawing.Size(126, 17);
            this.checkAutoRead.TabIndex = 10;
            this.checkAutoRead.Text = "Automatisch einlesen";
            this.checkAutoRead.UseVisualStyleBackColor = true;
            // 
            // buttonSelectHotel
            // 
            this.buttonSelectHotel.Location = new System.Drawing.Point(102, 200);
            this.buttonSelectHotel.Name = "buttonSelectHotel";
            this.buttonSelectHotel.Size = new System.Drawing.Size(156, 23);
            this.buttonSelectHotel.TabIndex = 11;
            this.buttonSelectHotel.Text = "Hotel auswählen";
            this.buttonSelectHotel.UseVisualStyleBackColor = true;
            this.buttonSelectHotel.Click += new System.EventHandler(this.buttonSelectHotel_Click);
            // 
            // textBreakfast
            // 
            this.textBreakfast.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBreakfast.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textBreakfast.Location = new System.Drawing.Point(102, 174);
            this.textBreakfast.Name = "textBreakfast";
            this.textBreakfast.Size = new System.Drawing.Size(156, 20);
            this.textBreakfast.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Frühstückspreis:";
            // 
            // formConfigDirs
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(271, 276);
            this.ControlBox = false;
            this.Controls.Add(this.textBreakfast);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSelectHotel);
            this.Controls.Add(this.checkAutoRead);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkFlag);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textKnr);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formConfigDirs";
            this.Text = "Dirs21-Einstellungen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textKnr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox checkFlag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.CheckBox checkAutoRead;
        private System.Windows.Forms.Button buttonSelectHotel;
        private System.Windows.Forms.TextBox textBreakfast;
        private System.Windows.Forms.Label label5;
    }
}