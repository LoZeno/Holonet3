namespace HolonetWinControls.Eventi
{
	partial class IscriviGiocatore
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
			this.cmbGiocatore = new System.Windows.Forms.ComboBox();
			this.giocatoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbPersonaggio = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNomeEvento = new System.Windows.Forms.TextBox();
			this.grdGiorni = new System.Windows.Forms.DataGridView();
			this.CdEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGiorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costoGiornoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PuntiAssegnati = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.eventoGiorniBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label5 = new System.Windows.Forms.Label();
			this.btnSalva = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.giocatoreBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdGiorni)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.eventoGiorniBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbGiocatore
			// 
			this.cmbGiocatore.DataSource = this.giocatoreBindingSource;
			this.cmbGiocatore.DisplayMember = "NomeCompleto";
			this.cmbGiocatore.FormattingEnabled = true;
			this.cmbGiocatore.Location = new System.Drawing.Point(98, 74);
			this.cmbGiocatore.Name = "cmbGiocatore";
			this.cmbGiocatore.Size = new System.Drawing.Size(282, 21);
			this.cmbGiocatore.TabIndex = 0;
			this.cmbGiocatore.ValueMember = "NumeroSW";
			this.cmbGiocatore.SelectedValueChanged += new System.EventHandler(this.cmbGiocatore_SelectedValueChanged);
			// 
			// giocatoreBindingSource
			// 
			this.giocatoreBindingSource.DataSource = typeof(DataAccessLayer.Giocatore);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Iscrizione";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Giocatore:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Personaggio:";
			// 
			// cmbPersonaggio
			// 
			this.cmbPersonaggio.FormattingEnabled = true;
			this.cmbPersonaggio.Location = new System.Drawing.Point(98, 101);
			this.cmbPersonaggio.Name = "cmbPersonaggio";
			this.cmbPersonaggio.Size = new System.Drawing.Size(282, 21);
			this.cmbPersonaggio.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Evento:";
			// 
			// txtNomeEvento
			// 
			this.txtNomeEvento.Location = new System.Drawing.Point(98, 48);
			this.txtNomeEvento.Name = "txtNomeEvento";
			this.txtNomeEvento.ReadOnly = true;
			this.txtNomeEvento.Size = new System.Drawing.Size(282, 20);
			this.txtNomeEvento.TabIndex = 6;
			// 
			// grdGiorni
			// 
			this.grdGiorni.AllowUserToAddRows = false;
			this.grdGiorni.AllowUserToDeleteRows = false;
			this.grdGiorni.AllowUserToOrderColumns = true;
			this.grdGiorni.AutoGenerateColumns = false;
			this.grdGiorni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdGiorni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CdEvento,
            this.DataGiorno,
            this.costoGiornoDataGridViewTextBoxColumn,
            this.PuntiAssegnati});
			this.grdGiorni.DataSource = this.eventoGiorniBindingSource;
			this.grdGiorni.Location = new System.Drawing.Point(98, 129);
			this.grdGiorni.Name = "grdGiorni";
			this.grdGiorni.ReadOnly = true;
			this.grdGiorni.Size = new System.Drawing.Size(282, 89);
			this.grdGiorni.TabIndex = 7;
			// 
			// CdEvento
			// 
			this.CdEvento.DataPropertyName = "CdEvento";
			this.CdEvento.HeaderText = "CdEvento";
			this.CdEvento.Name = "CdEvento";
			this.CdEvento.ReadOnly = true;
			this.CdEvento.Visible = false;
			// 
			// DataGiorno
			// 
			this.DataGiorno.DataPropertyName = "DataGiorno";
			this.DataGiorno.HeaderText = "Giorno";
			this.DataGiorno.Name = "DataGiorno";
			this.DataGiorno.ReadOnly = true;
			// 
			// costoGiornoDataGridViewTextBoxColumn
			// 
			this.costoGiornoDataGridViewTextBoxColumn.DataPropertyName = "CostoGiorno";
			this.costoGiornoDataGridViewTextBoxColumn.HeaderText = "Costo";
			this.costoGiornoDataGridViewTextBoxColumn.Name = "costoGiornoDataGridViewTextBoxColumn";
			this.costoGiornoDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// PuntiAssegnati
			// 
			this.PuntiAssegnati.DataPropertyName = "PuntiAssegnati";
			this.PuntiAssegnati.HeaderText = "Punti";
			this.PuntiAssegnati.Name = "PuntiAssegnati";
			this.PuntiAssegnati.ReadOnly = true;
			// 
			// eventoGiorniBindingSource
			// 
			this.eventoGiorniBindingSource.DataSource = typeof(DataAccessLayer.EventoGiorni);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 129);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(86, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Seleziona Giorni:";
			// 
			// btnSalva
			// 
			this.btnSalva.Enabled = false;
			this.btnSalva.Location = new System.Drawing.Point(16, 239);
			this.btnSalva.Name = "btnSalva";
			this.btnSalva.Size = new System.Drawing.Size(75, 23);
			this.btnSalva.TabIndex = 9;
			this.btnSalva.Text = "Conferma";
			this.btnSalva.UseVisualStyleBackColor = true;
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(305, 239);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 10;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// IscriviGiocatore
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(397, 312);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnSalva);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.grdGiorni);
			this.Controls.Add(this.txtNomeEvento);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbPersonaggio);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbGiocatore);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "IscriviGiocatore";
			this.Text = "IscriviGiocatore";
			((System.ComponentModel.ISupportInitialize)(this.giocatoreBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdGiorni)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.eventoGiorniBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbGiocatore;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbPersonaggio;
		private System.Windows.Forms.BindingSource giocatoreBindingSource;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtNomeEvento;
		private System.Windows.Forms.DataGridView grdGiorni;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridViewTextBoxColumn CdEvento;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataGiorno;
		private System.Windows.Forms.DataGridViewTextBoxColumn costoGiornoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn PuntiAssegnati;
		private System.Windows.Forms.BindingSource eventoGiorniBindingSource;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.Button btnAnnulla;
	}
}