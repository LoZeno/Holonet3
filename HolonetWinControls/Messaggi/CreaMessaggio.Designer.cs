namespace HolonetWinControls.Messaggi
{
	partial class CreaMessaggio
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
			this.label2 = new System.Windows.Forms.Label();
			this.cmbMittente = new System.Windows.Forms.ComboBox();
			this.personaggioBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.txtOggetto = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtMessaggio = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dtInvio = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.btnInvia = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.lstDestinatari = new System.Windows.Forms.ListBox();
			this.numCrypt = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.personaggioBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCrypt)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "Scrivi Messaggio";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Mittente:";
			// 
			// cmbMittente
			// 
			this.cmbMittente.DataSource = this.personaggioBindingSource;
			this.cmbMittente.DisplayMember = "Nome";
			this.cmbMittente.FormattingEnabled = true;
			this.cmbMittente.Location = new System.Drawing.Point(70, 37);
			this.cmbMittente.Name = "cmbMittente";
			this.cmbMittente.Size = new System.Drawing.Size(234, 21);
			this.cmbMittente.TabIndex = 5;
			this.cmbMittente.ValueMember = "NumeroPG";
			// 
			// personaggioBindingSource
			// 
			this.personaggioBindingSource.DataSource = typeof(DataAccessLayer.Personaggio);
			// 
			// txtOggetto
			// 
			this.txtOggetto.Location = new System.Drawing.Point(70, 65);
			this.txtOggetto.MaxLength = 60;
			this.txtOggetto.Name = "txtOggetto";
			this.txtOggetto.Size = new System.Drawing.Size(234, 20);
			this.txtOggetto.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Oggetto:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 95);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Messaggio:";
			// 
			// txtMessaggio
			// 
			this.txtMessaggio.Location = new System.Drawing.Point(16, 111);
			this.txtMessaggio.Multiline = true;
			this.txtMessaggio.Name = "txtMessaggio";
			this.txtMessaggio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtMessaggio.Size = new System.Drawing.Size(288, 142);
			this.txtMessaggio.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(325, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Destinatari:";
			// 
			// dtInvio
			// 
			this.dtInvio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			this.dtInvio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtInvio.Location = new System.Drawing.Point(107, 258);
			this.dtInvio.Name = "dtInvio";
			this.dtInvio.Size = new System.Drawing.Size(197, 20);
			this.dtInvio.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 265);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(85, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Data e ora invio:";
			// 
			// btnInvia
			// 
			this.btnInvia.Location = new System.Drawing.Point(16, 294);
			this.btnInvia.Name = "btnInvia";
			this.btnInvia.Size = new System.Drawing.Size(75, 23);
			this.btnInvia.TabIndex = 14;
			this.btnInvia.Text = "Invia";
			this.btnInvia.UseVisualStyleBackColor = true;
			this.btnInvia.Click += new System.EventHandler(this.btnInvia_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(107, 293);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 15;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// lstDestinatari
			// 
			this.lstDestinatari.DataSource = this.personaggioBindingSource;
			this.lstDestinatari.DisplayMember = "Nome";
			this.lstDestinatari.FormattingEnabled = true;
			this.lstDestinatari.Location = new System.Drawing.Point(328, 65);
			this.lstDestinatari.Name = "lstDestinatari";
			this.lstDestinatari.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstDestinatari.Size = new System.Drawing.Size(281, 186);
			this.lstDestinatari.TabIndex = 16;
			this.lstDestinatari.ValueMember = "NumeroPG";
			// 
			// numCrypt
			// 
			this.numCrypt.Location = new System.Drawing.Point(489, 258);
			this.numCrypt.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numCrypt.Name = "numCrypt";
			this.numCrypt.Size = new System.Drawing.Size(120, 20);
			this.numCrypt.TabIndex = 17;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(400, 264);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(62, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Criptazione:";
			// 
			// CreaMessaggio
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(621, 343);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.numCrypt);
			this.Controls.Add(this.lstDestinatari);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnInvia);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dtInvio);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtMessaggio);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtOggetto);
			this.Controls.Add(this.cmbMittente);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CreaMessaggio";
			this.Text = "CreaMessaggio";
			((System.ComponentModel.ISupportInitialize)(this.personaggioBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCrypt)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbMittente;
		private System.Windows.Forms.TextBox txtOggetto;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMessaggio;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtInvio;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnInvia;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.BindingSource personaggioBindingSource;
		private System.Windows.Forms.ListBox lstDestinatari;
		private System.Windows.Forms.NumericUpDown numCrypt;
		private System.Windows.Forms.Label label7;
	}
}