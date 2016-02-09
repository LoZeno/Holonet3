namespace HolonetWinControls.Eventi
{
    partial class GestisciPartecipanti
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
			this.grdPartecipanti = new System.Windows.Forms.DataGridView();
			this.NumeroPG = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Personaggio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Giocatore = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NumeroGiorni = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Prezzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PX = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Punti = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Pagato = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Partecipato = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.partecipazioneBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.chkTuttiPagato = new System.Windows.Forms.CheckBox();
			this.chkTuttiPartecipato = new System.Windows.Forms.CheckBox();
			this.numPxBonus = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtRicavo = new System.Windows.Forms.TextBox();
			this.btnSalva = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnSalvaEChiudi = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grdPartecipanti)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.partecipazioneBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numPxBonus)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(177, 24);
			this.label1.TabIndex = 68;
			this.label1.Text = "Gestisci Partecipanti";
			// 
			// grdPartecipanti
			// 
			this.grdPartecipanti.AllowUserToAddRows = false;
			this.grdPartecipanti.AllowUserToDeleteRows = false;
			this.grdPartecipanti.AllowUserToOrderColumns = true;
			this.grdPartecipanti.AutoGenerateColumns = false;
			this.grdPartecipanti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdPartecipanti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroPG,
            this.Personaggio,
            this.Giocatore,
            this.NumeroGiorni,
            this.Prezzo,
            this.PX,
            this.Punti,
            this.Pagato,
            this.Partecipato});
			this.grdPartecipanti.DataSource = this.partecipazioneBindingSource;
			this.grdPartecipanti.Location = new System.Drawing.Point(14, 50);
			this.grdPartecipanti.Margin = new System.Windows.Forms.Padding(2);
			this.grdPartecipanti.Name = "grdPartecipanti";
			this.grdPartecipanti.RowTemplate.Height = 24;
			this.grdPartecipanti.Size = new System.Drawing.Size(435, 214);
			this.grdPartecipanti.TabIndex = 69;
			this.grdPartecipanti.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPartecipanti_CellContentClick);
			this.grdPartecipanti.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPartecipanti_CellValueChanged);
			this.grdPartecipanti.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdPartecipanti_DataBindingComplete);
			// 
			// NumeroPG
			// 
			this.NumeroPG.DataPropertyName = "NumeroPG";
			this.NumeroPG.HeaderText = "Num. PG";
			this.NumeroPG.Name = "NumeroPG";
			this.NumeroPG.ReadOnly = true;
			this.NumeroPG.Width = 50;
			// 
			// Personaggio
			// 
			this.Personaggio.DataPropertyName = "Personaggio";
			this.Personaggio.FillWeight = 140F;
			this.Personaggio.HeaderText = "Personaggio";
			this.Personaggio.Name = "Personaggio";
			this.Personaggio.ReadOnly = true;
			// 
			// Giocatore
			// 
			this.Giocatore.DataPropertyName = "Giocatore";
			this.Giocatore.HeaderText = "Giocatore";
			this.Giocatore.Name = "Giocatore";
			this.Giocatore.ReadOnly = true;
			// 
			// NumeroGiorni
			// 
			this.NumeroGiorni.DataPropertyName = "NumeroGiorni";
			this.NumeroGiorni.HeaderText = "Giorni";
			this.NumeroGiorni.Name = "NumeroGiorni";
			this.NumeroGiorni.ReadOnly = true;
			this.NumeroGiorni.Width = 50;
			// 
			// Prezzo
			// 
			this.Prezzo.DataPropertyName = "Prezzo";
			this.Prezzo.HeaderText = "Prezzo";
			this.Prezzo.Name = "Prezzo";
			this.Prezzo.ReadOnly = true;
			this.Prezzo.Width = 50;
			// 
			// PX
			// 
			this.PX.DataPropertyName = "PX";
			this.PX.HeaderText = "PX Originali";
			this.PX.Name = "PX";
			this.PX.Visible = false;
			this.PX.Width = 50;
			// 
			// Punti
			// 
			this.Punti.HeaderText = "Punti";
			this.Punti.Name = "Punti";
			this.Punti.Width = 50;
			// 
			// Pagato
			// 
			this.Pagato.DataPropertyName = "Pagato";
			this.Pagato.HeaderText = "Pagato";
			this.Pagato.Name = "Pagato";
			this.Pagato.Width = 50;
			// 
			// Partecipato
			// 
			this.Partecipato.DataPropertyName = "Partecipato";
			this.Partecipato.HeaderText = "Partecipato";
			this.Partecipato.Name = "Partecipato";
			this.Partecipato.Width = 50;
			// 
			// partecipazioneBindingSource
			// 
			this.partecipazioneBindingSource.DataSource = typeof(CommonBusiness.Eventi.Partecipazione);
			// 
			// chkTuttiPagato
			// 
			this.chkTuttiPagato.AutoSize = true;
			this.chkTuttiPagato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkTuttiPagato.Location = new System.Drawing.Point(9, 280);
			this.chkTuttiPagato.Margin = new System.Windows.Forms.Padding(2);
			this.chkTuttiPagato.Name = "chkTuttiPagato";
			this.chkTuttiPagato.Size = new System.Drawing.Size(153, 17);
			this.chkTuttiPagato.TabIndex = 70;
			this.chkTuttiPagato.Text = "Segna tutti come \"Pagato\"";
			this.chkTuttiPagato.UseVisualStyleBackColor = true;
			this.chkTuttiPagato.CheckedChanged += new System.EventHandler(this.chkTuttiPagato_CheckedChanged);
			// 
			// chkTuttiPartecipato
			// 
			this.chkTuttiPartecipato.AutoSize = true;
			this.chkTuttiPartecipato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkTuttiPartecipato.Location = new System.Drawing.Point(262, 280);
			this.chkTuttiPartecipato.Margin = new System.Windows.Forms.Padding(2);
			this.chkTuttiPartecipato.Name = "chkTuttiPartecipato";
			this.chkTuttiPartecipato.Size = new System.Drawing.Size(173, 17);
			this.chkTuttiPartecipato.TabIndex = 71;
			this.chkTuttiPartecipato.Text = "Segna tutti come \"Partecipato\"";
			this.chkTuttiPartecipato.UseVisualStyleBackColor = true;
			this.chkTuttiPartecipato.CheckedChanged += new System.EventHandler(this.chkTuttiPartecipato_CheckedChanged);
			// 
			// numPxBonus
			// 
			this.numPxBonus.Location = new System.Drawing.Point(152, 302);
			this.numPxBonus.Margin = new System.Windows.Forms.Padding(2);
			this.numPxBonus.Name = "numPxBonus";
			this.numPxBonus.Size = new System.Drawing.Size(90, 20);
			this.numPxBonus.TabIndex = 72;
			this.numPxBonus.ValueChanged += new System.EventHandler(this.numPxBonus_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 304);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 13);
			this.label2.TabIndex = 73;
			this.label2.Text = "Punti Bonus ai partecipanti:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 328);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 74;
			this.label3.Text = "Ricavo:";
			// 
			// txtRicavo
			// 
			this.txtRicavo.Location = new System.Drawing.Point(152, 326);
			this.txtRicavo.Margin = new System.Windows.Forms.Padding(2);
			this.txtRicavo.Name = "txtRicavo";
			this.txtRicavo.ReadOnly = true;
			this.txtRicavo.Size = new System.Drawing.Size(91, 20);
			this.txtRicavo.TabIndex = 75;
			// 
			// btnSalva
			// 
			this.btnSalva.Location = new System.Drawing.Point(14, 358);
			this.btnSalva.Margin = new System.Windows.Forms.Padding(2);
			this.btnSalva.Name = "btnSalva";
			this.btnSalva.Size = new System.Drawing.Size(142, 19);
			this.btnSalva.TabIndex = 76;
			this.btnSalva.Text = "Salva";
			this.btnSalva.UseVisualStyleBackColor = true;
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(307, 358);
			this.btnAnnulla.Margin = new System.Windows.Forms.Padding(2);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(142, 19);
			this.btnAnnulla.TabIndex = 77;
			this.btnAnnulla.Text = "ANNULLA";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// btnSalvaEChiudi
			// 
			this.btnSalvaEChiudi.Location = new System.Drawing.Point(160, 358);
			this.btnSalvaEChiudi.Margin = new System.Windows.Forms.Padding(2);
			this.btnSalvaEChiudi.Name = "btnSalvaEChiudi";
			this.btnSalvaEChiudi.Size = new System.Drawing.Size(142, 19);
			this.btnSalvaEChiudi.TabIndex = 78;
			this.btnSalvaEChiudi.Text = "Salva e chiudi l\'evento";
			this.btnSalvaEChiudi.UseVisualStyleBackColor = true;
			this.btnSalvaEChiudi.Click += new System.EventHandler(this.btnSalvaEChiudi_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 31);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(287, 13);
			this.label4.TabIndex = 79;
			this.label4.Text = "Elenco dei personaggi ancora in attesa di assegnazione PX";
			// 
			// GestisciPartecipanti
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(462, 392);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnSalvaEChiudi);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnSalva);
			this.Controls.Add(this.txtRicavo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numPxBonus);
			this.Controls.Add(this.chkTuttiPartecipato);
			this.Controls.Add(this.chkTuttiPagato);
			this.Controls.Add(this.grdPartecipanti);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "GestisciPartecipanti";
			this.Text = "GestisciPartecipanti";
			((System.ComponentModel.ISupportInitialize)(this.grdPartecipanti)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.partecipazioneBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numPxBonus)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdPartecipanti;
        private System.Windows.Forms.BindingSource partecipazioneBindingSource;
        private System.Windows.Forms.CheckBox chkTuttiPagato;
        private System.Windows.Forms.CheckBox chkTuttiPartecipato;
        private System.Windows.Forms.NumericUpDown numPxBonus;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRicavo;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnSalvaEChiudi;
		private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPG;
		private System.Windows.Forms.DataGridViewTextBoxColumn Personaggio;
		private System.Windows.Forms.DataGridViewTextBoxColumn Giocatore;
		private System.Windows.Forms.DataGridViewTextBoxColumn NumeroGiorni;
		private System.Windows.Forms.DataGridViewTextBoxColumn Prezzo;
		private System.Windows.Forms.DataGridViewTextBoxColumn PX;
		private System.Windows.Forms.DataGridViewTextBoxColumn Punti;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Pagato;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Partecipato;
		private System.Windows.Forms.Label label4;
    }
}