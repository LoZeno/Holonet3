namespace HolonetWinControls.Notizie
{
	partial class CreaNotizia
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.txtOggetto = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbAutore = new System.Windows.Forms.ComboBox();
			this.personaggioBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.txtTesto = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbFazione = new System.Windows.Forms.ComboBox();
			this.reteBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label5 = new System.Windows.Forms.Label();
			this.dtCreazione = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.dtFine = new System.Windows.Forms.DateTimePicker();
			this.numHacking = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.btnSalva = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.personaggioBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reteBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHacking)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 24);
			this.label1.TabIndex = 4;
			this.label1.Text = "Scrivi Notizia";
			// 
			// txtOggetto
			// 
			this.txtOggetto.Location = new System.Drawing.Point(96, 37);
			this.txtOggetto.MaxLength = 60;
			this.txtOggetto.Name = "txtOggetto";
			this.txtOggetto.Size = new System.Drawing.Size(279, 20);
			this.txtOggetto.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Titolo:";
			// 
			// cmbAutore
			// 
			this.cmbAutore.DataSource = this.personaggioBindingSource;
			this.cmbAutore.DisplayMember = "Nome";
			this.cmbAutore.FormattingEnabled = true;
			this.cmbAutore.Location = new System.Drawing.Point(96, 64);
			this.cmbAutore.Name = "cmbAutore";
			this.cmbAutore.Size = new System.Drawing.Size(279, 21);
			this.cmbAutore.TabIndex = 7;
			this.cmbAutore.ValueMember = "NumeroPG";
			// 
			// personaggioBindingSource
			// 
			this.personaggioBindingSource.DataSource = typeof(DataAccessLayer.Personaggio);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Autore";
			// 
			// txtTesto
			// 
			this.txtTesto.Location = new System.Drawing.Point(96, 92);
			this.txtTesto.Multiline = true;
			this.txtTesto.Name = "txtTesto";
			this.txtTesto.Size = new System.Drawing.Size(279, 184);
			this.txtTesto.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 95);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Testo:";
			// 
			// cmbFazione
			// 
			this.cmbFazione.DataSource = this.reteBindingSource;
			this.cmbFazione.DisplayMember = "Fazione";
			this.cmbFazione.FormattingEnabled = true;
			this.cmbFazione.Location = new System.Drawing.Point(96, 283);
			this.cmbFazione.Name = "cmbFazione";
			this.cmbFazione.Size = new System.Drawing.Size(279, 21);
			this.cmbFazione.TabIndex = 11;
			this.cmbFazione.ValueMember = "NumeroRete";
			// 
			// reteBindingSource
			// 
			this.reteBindingSource.DataSource = typeof(DataAccessLayer.Rete);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 286);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Fazione:";
			// 
			// dtCreazione
			// 
			this.dtCreazione.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			this.dtCreazione.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtCreazione.Location = new System.Drawing.Point(96, 311);
			this.dtCreazione.Name = "dtCreazione";
			this.dtCreazione.Size = new System.Drawing.Size(279, 20);
			this.dtCreazione.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 317);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Inizio:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 343);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Fine:";
			// 
			// dtFine
			// 
			this.dtFine.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			this.dtFine.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFine.Location = new System.Drawing.Point(96, 337);
			this.dtFine.Name = "dtFine";
			this.dtFine.Size = new System.Drawing.Size(279, 20);
			this.dtFine.TabIndex = 15;
			// 
			// numHacking
			// 
			this.numHacking.Location = new System.Drawing.Point(96, 364);
			this.numHacking.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numHacking.Name = "numHacking";
			this.numHacking.Size = new System.Drawing.Size(120, 20);
			this.numHacking.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 366);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(50, 13);
			this.label8.TabIndex = 18;
			this.label8.Text = "Hacking:";
			// 
			// btnSalva
			// 
			this.btnSalva.Location = new System.Drawing.Point(16, 398);
			this.btnSalva.Name = "btnSalva";
			this.btnSalva.Size = new System.Drawing.Size(75, 23);
			this.btnSalva.TabIndex = 19;
			this.btnSalva.Text = "Salva";
			this.btnSalva.UseVisualStyleBackColor = true;
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(126, 398);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 20;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// CreaNotizia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(387, 440);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnSalva);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.numHacking);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dtFine);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dtCreazione);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cmbFazione);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTesto);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbAutore);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtOggetto);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CreaNotizia";
			this.Text = "CreaNotizia";
			((System.ComponentModel.ISupportInitialize)(this.personaggioBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reteBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHacking)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtOggetto;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbAutore;
		private System.Windows.Forms.BindingSource personaggioBindingSource;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTesto;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbFazione;
		private System.Windows.Forms.BindingSource reteBindingSource;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtCreazione;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dtFine;
		private System.Windows.Forms.NumericUpDown numHacking;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.Button btnAnnulla;
	}
}