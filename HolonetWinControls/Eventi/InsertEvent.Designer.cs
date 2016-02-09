namespace HolonetManager.Eventi
{
	partial class InsertEvent
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitolo = new System.Windows.Forms.TextBox();
            this.calendarGiorni = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.timepickInGioco = new System.Windows.Forms.DateTimePicker();
            this.timepickFuoriGioco = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblWarningMessage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timepickStandardIg = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.timepickStandardFg = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtPX = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inserisci Dati Evento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Titolo:";
            // 
            // txtTitolo
            // 
            this.txtTitolo.Location = new System.Drawing.Point(101, 96);
            this.txtTitolo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitolo.MaxLength = 50;
            this.txtTitolo.Name = "txtTitolo";
            this.txtTitolo.Size = new System.Drawing.Size(301, 22);
            this.txtTitolo.TabIndex = 2;
            // 
            // calendarGiorni
            // 
            this.calendarGiorni.Location = new System.Drawing.Point(101, 129);
            this.calendarGiorni.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.calendarGiorni.Name = "calendarGiorni";
            this.calendarGiorni.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Giorni:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 373);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Descrizione";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(101, 373);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(772, 121);
            this.txtDescription.TabIndex = 8;
            // 
            // timepickInGioco
            // 
            this.timepickInGioco.CustomFormat = "HH:mm";
            this.timepickInGioco.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timepickInGioco.Location = new System.Drawing.Point(569, 129);
            this.timepickInGioco.Margin = new System.Windows.Forms.Padding(4);
            this.timepickInGioco.Name = "timepickInGioco";
            this.timepickInGioco.ShowUpDown = true;
            this.timepickInGioco.Size = new System.Drawing.Size(301, 22);
            this.timepickInGioco.TabIndex = 9;
            this.timepickInGioco.Value = new System.DateTime(2012, 9, 26, 10, 0, 0, 0);
            // 
            // timepickFuoriGioco
            // 
            this.timepickFuoriGioco.CustomFormat = "HH:mm";
            this.timepickFuoriGioco.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timepickFuoriGioco.Location = new System.Drawing.Point(572, 304);
            this.timepickFuoriGioco.Margin = new System.Windows.Forms.Padding(4);
            this.timepickFuoriGioco.Name = "timepickFuoriGioco";
            this.timepickFuoriGioco.ShowUpDown = true;
            this.timepickFuoriGioco.Size = new System.Drawing.Size(301, 22);
            this.timepickFuoriGioco.TabIndex = 10;
            this.timepickFuoriGioco.Value = new System.DateTime(2012, 9, 26, 17, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(439, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ora primo InGioco";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(439, 304);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ora ultimo FG";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(773, 497);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 28);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblWarningMessage
            // 
            this.lblWarningMessage.AutoSize = true;
            this.lblWarningMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarningMessage.ForeColor = System.Drawing.Color.Red;
            this.lblWarningMessage.Location = new System.Drawing.Point(16, 54);
            this.lblWarningMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWarningMessage.Name = "lblWarningMessage";
            this.lblWarningMessage.Size = new System.Drawing.Size(149, 17);
            this.lblWarningMessage.TabIndex = 14;
            this.lblWarningMessage.Text = "lblWarningMessage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 334);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(424, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Suggerimento: premere SHIFT per selezionare più giorni alla volta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(439, 188);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "InGioco seguenti";
            // 
            // timepickStandardIg
            // 
            this.timepickStandardIg.CustomFormat = "HH:mm";
            this.timepickStandardIg.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timepickStandardIg.Location = new System.Drawing.Point(572, 183);
            this.timepickStandardIg.Margin = new System.Windows.Forms.Padding(4);
            this.timepickStandardIg.Name = "timepickStandardIg";
            this.timepickStandardIg.ShowUpDown = true;
            this.timepickStandardIg.Size = new System.Drawing.Size(301, 22);
            this.timepickStandardIg.TabIndex = 16;
            this.timepickStandardIg.Value = new System.DateTime(2012, 9, 26, 10, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(439, 250);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "FG seguenti";
            // 
            // timepickStandardFg
            // 
            this.timepickStandardFg.CustomFormat = "HH:mm";
            this.timepickStandardFg.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timepickStandardFg.Location = new System.Drawing.Point(572, 245);
            this.timepickStandardFg.Margin = new System.Windows.Forms.Padding(4);
            this.timepickStandardFg.Name = "timepickStandardFg";
            this.timepickStandardFg.ShowUpDown = true;
            this.timepickStandardFg.Size = new System.Drawing.Size(301, 22);
            this.timepickStandardFg.TabIndex = 18;
            this.timepickStandardFg.Value = new System.DateTime(2012, 9, 26, 2, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 502);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Costo Tot.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(443, 503);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "PX:";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(101, 503);
            this.txtCosto.MaxLength = 10;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(281, 22);
            this.txtCosto.TabIndex = 24;
            // 
            // txtPX
            // 
            this.txtPX.Location = new System.Drawing.Point(480, 503);
            this.txtPX.MaxLength = 10;
            this.txtPX.Name = "txtPX";
            this.txtPX.Size = new System.Drawing.Size(281, 22);
            this.txtPX.TabIndex = 25;
            // 
            // InsertEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 588);
            this.Controls.Add(this.txtPX);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.timepickStandardFg);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.timepickStandardIg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWarningMessage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timepickFuoriGioco);
            this.Controls.Add(this.timepickInGioco);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calendarGiorni);
            this.Controls.Add(this.txtTitolo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InsertEvent";
            this.Text = "InsertEvent";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTitolo;
		private System.Windows.Forms.MonthCalendar calendarGiorni;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.DateTimePicker timepickInGioco;
		private System.Windows.Forms.DateTimePicker timepickFuoriGioco;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label lblWarningMessage;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker timepickStandardIg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker timepickStandardFg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtPX;
	}
}