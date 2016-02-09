namespace HolonetWinControls.Abilita
{
	partial class ControlAbilita
	{
		/// <summary> 
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Liberare le risorse in uso.
		/// </summary>
		/// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Codice generato da Progettazione componenti

		/// <summary> 
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.attitudineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.abilitaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNuovaAbilita = new System.Windows.Forms.Button();
            this.btnModificaAbilita = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNuovaLista = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.grdListe = new System.Windows.Forms.DataGridView();
            this.grdAbilita = new System.Windows.Forms.DataGridView();
            this.CdAbilita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeAbilita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescrizioneAbilita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Multiacquisto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseAvanzato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CdAttitudine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoAttitudine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.attitudineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilitaBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbilita)).BeginInit();
            this.SuspendLayout();
            // 
            // attitudineBindingSource
            // 
            this.attitudineBindingSource.DataSource = typeof(DataAccessLayer.Attitudine);
            // 
            // abilitaBindingSource
            // 
            this.abilitaBindingSource.DataSource = typeof(DataAccessLayer.Abilita);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdListe, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdAbilita, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(875, 492);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33422F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33422F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33089F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33222F));
            this.tableLayoutPanel2.Controls.Add(this.btnNuovaAbilita, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnModificaAbilita, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 448);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(867, 40);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnNuovaAbilita
            // 
            this.btnNuovaAbilita.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNuovaAbilita.Location = new System.Drawing.Point(4, 4);
            this.btnNuovaAbilita.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuovaAbilita.Name = "btnNuovaAbilita";
            this.btnNuovaAbilita.Size = new System.Drawing.Size(149, 32);
            this.btnNuovaAbilita.TabIndex = 7;
            this.btnNuovaAbilita.Text = "Nuova Abilità";
            this.btnNuovaAbilita.UseVisualStyleBackColor = true;
            this.btnNuovaAbilita.Click += new System.EventHandler(this.btnNuovaAbilita_Click);
            // 
            // btnModificaAbilita
            // 
            this.btnModificaAbilita.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnModificaAbilita.Location = new System.Drawing.Point(161, 4);
            this.btnModificaAbilita.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificaAbilita.Name = "btnModificaAbilita";
            this.btnModificaAbilita.Size = new System.Drawing.Size(149, 32);
            this.btnModificaAbilita.TabIndex = 8;
            this.btnModificaAbilita.Text = "Modifica Abilità";
            this.btnModificaAbilita.UseVisualStyleBackColor = true;
            this.btnModificaAbilita.Click += new System.EventHandler(this.btnModificaAbilita_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33422F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33422F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33089F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33222F));
            this.tableLayoutPanel3.Controls.Add(this.btnNuovaLista, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnEdit, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 219);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(867, 42);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnNuovaLista
            // 
            this.btnNuovaLista.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNuovaLista.Location = new System.Drawing.Point(4, 4);
            this.btnNuovaLista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuovaLista.Name = "btnNuovaLista";
            this.btnNuovaLista.Size = new System.Drawing.Size(149, 34);
            this.btnNuovaLista.TabIndex = 7;
            this.btnNuovaLista.Text = "Nuova Lista";
            this.btnNuovaLista.UseVisualStyleBackColor = true;
            this.btnNuovaLista.Click += new System.EventHandler(this.btnNuovaLista_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEdit.Location = new System.Drawing.Point(161, 4);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(149, 34);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Modifica Lista";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // grdListe
            // 
            this.grdListe.AllowUserToAddRows = false;
            this.grdListe.AllowUserToDeleteRows = false;
            this.grdListe.AllowUserToOrderColumns = true;
            this.grdListe.AutoGenerateColumns = false;
            this.grdListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdListe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CdAttitudine,
            this.Nome,
            this.Descrizione,
            this.TipoAttitudine});
            this.grdListe.DataSource = this.attitudineBindingSource;
            this.grdListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdListe.Location = new System.Drawing.Point(4, 4);
            this.grdListe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdListe.MultiSelect = false;
            this.grdListe.Name = "grdListe";
            this.grdListe.ReadOnly = true;
            this.grdListe.Size = new System.Drawing.Size(867, 207);
            this.grdListe.TabIndex = 0;
            this.grdListe.SelectionChanged += new System.EventHandler(this.grdListe_SelectionChanged);
            // 
            // grdAbilita
            // 
            this.grdAbilita.AllowUserToAddRows = false;
            this.grdAbilita.AllowUserToDeleteRows = false;
            this.grdAbilita.AllowUserToOrderColumns = true;
            this.grdAbilita.AutoGenerateColumns = false;
            this.grdAbilita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAbilita.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CdAbilita,
            this.NomeAbilita,
            this.DescrizioneAbilita,
            this.Multiacquisto,
            this.Costo,
            this.BaseAvanzato});
            this.grdAbilita.DataSource = this.abilitaBindingSource;
            this.grdAbilita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAbilita.Location = new System.Drawing.Point(4, 269);
            this.grdAbilita.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdAbilita.Name = "grdAbilita";
            this.grdAbilita.ReadOnly = true;
            this.grdAbilita.Size = new System.Drawing.Size(867, 171);
            this.grdAbilita.TabIndex = 1;
            // 
            // CdAbilita
            // 
            this.CdAbilita.DataPropertyName = "CdAbilita";
            this.CdAbilita.HeaderText = "CdAbilita";
            this.CdAbilita.Name = "CdAbilita";
            this.CdAbilita.ReadOnly = true;
            this.CdAbilita.Visible = false;
            // 
            // NomeAbilita
            // 
            this.NomeAbilita.DataPropertyName = "Nome";
            this.NomeAbilita.HeaderText = "Nome";
            this.NomeAbilita.Name = "NomeAbilita";
            this.NomeAbilita.ReadOnly = true;
            // 
            // DescrizioneAbilita
            // 
            this.DescrizioneAbilita.DataPropertyName = "Descrizione";
            this.DescrizioneAbilita.HeaderText = "Descrizione";
            this.DescrizioneAbilita.Name = "DescrizioneAbilita";
            this.DescrizioneAbilita.ReadOnly = true;
            // 
            // Multiacquisto
            // 
            this.Multiacquisto.DataPropertyName = "Multiacquisto";
            this.Multiacquisto.HeaderText = "Multiacquisto";
            this.Multiacquisto.Name = "Multiacquisto";
            this.Multiacquisto.ReadOnly = true;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "Costo";
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            // 
            // BaseAvanzato
            // 
            this.BaseAvanzato.DataPropertyName = "BaseAvanzato";
            this.BaseAvanzato.HeaderText = "Avanzata";
            this.BaseAvanzato.Name = "BaseAvanzato";
            this.BaseAvanzato.ReadOnly = true;
            // 
            // CdAttitudine
            // 
            this.CdAttitudine.DataPropertyName = "CdAttitudine";
            this.CdAttitudine.HeaderText = "Codice";
            this.CdAttitudine.Name = "CdAttitudine";
            this.CdAttitudine.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Descrizione
            // 
            this.Descrizione.DataPropertyName = "Descrizione";
            this.Descrizione.HeaderText = "Descrizione";
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.ReadOnly = true;
            this.Descrizione.Width = 300;
            // 
            // TipoAttitudine
            // 
            this.TipoAttitudine.DataPropertyName = "TipoAttitudine";
            this.TipoAttitudine.HeaderText = "Tipo Attitudine";
            this.TipoAttitudine.Name = "TipoAttitudine";
            this.TipoAttitudine.ReadOnly = true;
            this.TipoAttitudine.Width = 200;
            // 
            // ControlAbilita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ControlAbilita";
            this.Size = new System.Drawing.Size(875, 492);
            ((System.ComponentModel.ISupportInitialize)(this.attitudineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilitaBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbilita)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView grdListe;
		private System.Windows.Forms.BindingSource attitudineBindingSource;
		private System.Windows.Forms.DataGridView grdAbilita;
		private System.Windows.Forms.BindingSource abilitaBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn CdAbilita;
		private System.Windows.Forms.DataGridViewTextBoxColumn NomeAbilita;
		private System.Windows.Forms.DataGridViewTextBoxColumn DescrizioneAbilita;
		private System.Windows.Forms.DataGridViewTextBoxColumn Multiacquisto;
		private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
		private System.Windows.Forms.DataGridViewTextBoxColumn BaseAvanzato;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button btnNuovaLista;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnNuovaAbilita;
		private System.Windows.Forms.Button btnModificaAbilita;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdAttitudine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoAttitudine;
	}
}
