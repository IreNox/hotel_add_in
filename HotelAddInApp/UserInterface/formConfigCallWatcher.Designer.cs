namespace HotelAddInApp
{
    partial class formConfigCallWatcher
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBaudRate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboParity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboDataBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboStopBits = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboHandshake = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboPbx = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkCensorship = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(141, 396);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(222, 396);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboPort
            // 
            this.comboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Location = new System.Drawing.Point(80, 49);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(197, 21);
            this.comboPort.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Wählen Sie die zutreffenden Punkte für ihren Com-Port.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Com-Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Baud-Rate:";
            // 
            // comboBaudRate
            // 
            this.comboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBaudRate.FormattingEnabled = true;
            this.comboBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600"});
            this.comboBaudRate.Location = new System.Drawing.Point(80, 76);
            this.comboBaudRate.Name = "comboBaudRate";
            this.comboBaudRate.Size = new System.Drawing.Size(197, 21);
            this.comboBaudRate.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Parity:";
            // 
            // comboParity
            // 
            this.comboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboParity.FormattingEnabled = true;
            this.comboParity.Location = new System.Drawing.Point(80, 103);
            this.comboParity.Name = "comboParity";
            this.comboParity.Size = new System.Drawing.Size(197, 21);
            this.comboParity.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Daten-Bits:";
            // 
            // comboDataBits
            // 
            this.comboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataBits.FormattingEnabled = true;
            this.comboDataBits.Items.AddRange(new object[] {
            "7",
            "8"});
            this.comboDataBits.Location = new System.Drawing.Point(80, 130);
            this.comboDataBits.Name = "comboDataBits";
            this.comboDataBits.Size = new System.Drawing.Size(197, 21);
            this.comboDataBits.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Stop-Bits:";
            // 
            // comboStopBits
            // 
            this.comboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStopBits.FormattingEnabled = true;
            this.comboStopBits.Location = new System.Drawing.Point(80, 157);
            this.comboStopBits.Name = "comboStopBits";
            this.comboStopBits.Size = new System.Drawing.Size(197, 21);
            this.comboStopBits.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Handshake:";
            // 
            // comboHandshake
            // 
            this.comboHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHandshake.FormattingEnabled = true;
            this.comboHandshake.Location = new System.Drawing.Point(80, 184);
            this.comboHandshake.Name = "comboHandshake";
            this.comboHandshake.Size = new System.Drawing.Size(197, 21);
            this.comboHandshake.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboPort);
            this.groupBox1.Controls.Add(this.comboHandshake);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBaudRate);
            this.groupBox1.Controls.Add(this.comboStopBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboParity);
            this.groupBox1.Controls.Add(this.comboDataBits);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 212);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COM-Port";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboPbx);
            this.groupBox2.Location = new System.Drawing.Point(12, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 92);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Telefonanlage";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(9, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(268, 28);
            this.label9.TabIndex = 22;
            this.label9.Text = "Wählen Sie hier die von Ihnen verwendete Telefonanlage.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Anlage:";
            // 
            // comboPbx
            // 
            this.comboPbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPbx.FormattingEnabled = true;
            this.comboPbx.Location = new System.Drawing.Point(80, 55);
            this.comboPbx.Name = "comboPbx";
            this.comboPbx.Size = new System.Drawing.Size(197, 21);
            this.comboPbx.TabIndex = 20;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkCensorship);
            this.groupBox3.Location = new System.Drawing.Point(12, 328);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 50);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zensur";
            // 
            // checkCensorship
            // 
            this.checkCensorship.AutoSize = true;
            this.checkCensorship.Location = new System.Drawing.Point(12, 22);
            this.checkCensorship.Name = "checkCensorship";
            this.checkCensorship.Size = new System.Drawing.Size(220, 17);
            this.checkCensorship.TabIndex = 0;
            this.checkCensorship.Text = "Letzte 3 Ziffern der Rufnummer entfernen";
            this.checkCensorship.UseVisualStyleBackColor = true;
            // 
            // formConfigCallWatcher
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(309, 431);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formConfigCallWatcher";
            this.Text = "Telefonüberwachungs-Einstellungen";
            this.Load += new System.EventHandler(this.formConfigCallWatcher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBaudRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboParity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboDataBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboStopBits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboHandshake;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboPbx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkCensorship;
    }
}