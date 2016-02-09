namespace HolonetWinControls.Sostanze
{
	partial class ControlSostanze
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdSostanze = new System.Windows.Forms.DataGridView();
            this.Progressivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModoUso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effetto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValoreEfficacia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataScadenza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newSostanzeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClona = new System.Windows.Forms.Button();
            this.btnStampa = new System.Windows.Forms.Button();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkPrevious = new System.Windows.Forms.LinkLabel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkMultiplePrint = new System.Windows.Forms.CheckBox();
            this.grdIngredienti = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEliminaComponente = new System.Windows.Forms.Button();
            this.btnAggiungiComponente = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoSostanza = new System.Windows.Forms.ComboBox();
            this.tipoSostanzeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSostanze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newSostanzeBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIngredienti)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoSostanzeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grdSostanze, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grdIngredienti, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.52045F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.47955F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1261, 695);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grdSostanze
            // 
            this.grdSostanze.AllowUserToAddRows = false;
            this.grdSostanze.AllowUserToDeleteRows = false;
            this.grdSostanze.AllowUserToOrderColumns = true;
            this.grdSostanze.AutoGenerateColumns = false;
            this.grdSostanze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSostanze.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Progressivo,
            this.Nome,
            this.Descrizione,
            this.ModoUso,
            this.effetto,
            this.ValoreEfficacia,
            this.Tipo,
            this.Costo,
            this.DataScadenza});
            this.grdSostanze.DataSource = this.newSostanzeBindingSource;
            this.grdSostanze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSostanze.Location = new System.Drawing.Point(4, 44);
            this.grdSostanze.Margin = new System.Windows.Forms.Padding(4);
            this.grdSostanze.Name = "grdSostanze";
            this.grdSostanze.ReadOnly = true;
            this.grdSostanze.Size = new System.Drawing.Size(1253, 298);
            this.grdSostanze.TabIndex = 0;
            this.grdSostanze.SelectionChanged += new System.EventHandler(this.grdSostanze_SelectionChanged);
            // 
            // Progressivo
            // 
            this.Progressivo.DataPropertyName = "Progressivo";
            this.Progressivo.HeaderText = "Progressivo";
            this.Progressivo.Name = "Progressivo";
            this.Progressivo.ReadOnly = true;
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
            // 
            // ModoUso
            // 
            this.ModoUso.DataPropertyName = "ModoUso";
            this.ModoUso.HeaderText = "Modo d\'Uso";
            this.ModoUso.Name = "ModoUso";
            this.ModoUso.ReadOnly = true;
            this.ModoUso.Width = 150;
            // 
            // effetto
            // 
            this.effetto.DataPropertyName = "Effetto";
            this.effetto.HeaderText = "Effetto";
            this.effetto.Name = "effetto";
            this.effetto.ReadOnly = true;
            // 
            // ValoreEfficacia
            // 
            this.ValoreEfficacia.DataPropertyName = "ValoreEfficacia";
            this.ValoreEfficacia.HeaderText = "Valore di Efficacia";
            this.ValoreEfficacia.Name = "ValoreEfficacia";
            this.ValoreEfficacia.ReadOnly = true;
            this.ValoreEfficacia.Width = 160;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "Costo";
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            // 
            // DataScadenza
            // 
            this.DataScadenza.DataPropertyName = "DataScadenza";
            this.DataScadenza.HeaderText = "Data Scadenza";
            this.DataScadenza.Name = "DataScadenza";
            this.DataScadenza.ReadOnly = true;
            this.DataScadenza.Width = 140;
            // 
            // newSostanzeBindingSource
            // 
            this.newSostanzeBindingSource.DataSource = typeof(DataAccessLayer.NewSostanze);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel2.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClona, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnStampa, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lnkNext, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lnkPrevious, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEdit, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 350);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1253, 38);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.Location = new System.Drawing.Point(4, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Aggiungi Sost.";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClona
            // 
            this.btnClona.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClona.Location = new System.Drawing.Point(137, 4);
            this.btnClona.Margin = new System.Windows.Forms.Padding(4);
            this.btnClona.Name = "btnClona";
            this.btnClona.Size = new System.Drawing.Size(125, 30);
            this.btnClona.TabIndex = 2;
            this.btnClona.Text = "Copia Sost.";
            this.btnClona.UseVisualStyleBackColor = true;
            this.btnClona.Click += new System.EventHandler(this.btnClona_Click);
            // 
            // btnStampa
            // 
            this.btnStampa.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStampa.Location = new System.Drawing.Point(270, 4);
            this.btnStampa.Margin = new System.Windows.Forms.Padding(4);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(132, 30);
            this.btnStampa.TabIndex = 3;
            this.btnStampa.Text = "Stampa Sostanze";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // lnkNext
            // 
            this.lnkNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lnkNext.AutoSize = true;
            this.lnkNext.Location = new System.Drawing.Point(1168, 10);
            this.lnkNext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(81, 17);
            this.lnkNext.TabIndex = 5;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "Prossimi 50";
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // lnkPrevious
            // 
            this.lnkPrevious.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lnkPrevious.AutoSize = true;
            this.lnkPrevious.Location = new System.Drawing.Point(1060, 10);
            this.lnkPrevious.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkPrevious.Name = "lnkPrevious";
            this.lnkPrevious.Size = new System.Drawing.Size(96, 17);
            this.lnkPrevious.TabIndex = 4;
            this.lnkPrevious.TabStop = true;
            this.lnkPrevious.Text = "Precedenti 50";
            this.lnkPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrevious_LinkClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEdit.Location = new System.Drawing.Point(416, 2);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(132, 34);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Modifica Sost.";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkMultiplePrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(564, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 30);
            this.panel1.TabIndex = 7;
            // 
            // chkMultiplePrint
            // 
            this.chkMultiplePrint.AutoSize = true;
            this.chkMultiplePrint.Location = new System.Drawing.Point(3, 6);
            this.chkMultiplePrint.Name = "chkMultiplePrint";
            this.chkMultiplePrint.Size = new System.Drawing.Size(323, 21);
            this.chkMultiplePrint.TabIndex = 0;
            this.chkMultiplePrint.Text = "Stampa copie multiple (solo per selez. singola)";
            this.chkMultiplePrint.UseVisualStyleBackColor = true;
            // 
            // grdIngredienti
            // 
            this.grdIngredienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIngredienti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIngredienti.Location = new System.Drawing.Point(4, 396);
            this.grdIngredienti.Margin = new System.Windows.Forms.Padding(4);
            this.grdIngredienti.Name = "grdIngredienti";
            this.grdIngredienti.Size = new System.Drawing.Size(1253, 247);
            this.grdIngredienti.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnEliminaComponente, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAggiungiComponente, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 651);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1253, 40);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btnEliminaComponente
            // 
            this.btnEliminaComponente.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEliminaComponente.Location = new System.Drawing.Point(630, 4);
            this.btnEliminaComponente.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminaComponente.Name = "btnEliminaComponente";
            this.btnEliminaComponente.Size = new System.Drawing.Size(129, 32);
            this.btnEliminaComponente.TabIndex = 2;
            this.btnEliminaComponente.Text = "Elimina Compon.";
            this.btnEliminaComponente.UseVisualStyleBackColor = true;
            this.btnEliminaComponente.Click += new System.EventHandler(this.btnEliminaComponente_Click);
            // 
            // btnAggiungiComponente
            // 
            this.btnAggiungiComponente.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAggiungiComponente.Location = new System.Drawing.Point(4, 4);
            this.btnAggiungiComponente.Margin = new System.Windows.Forms.Padding(4);
            this.btnAggiungiComponente.Name = "btnAggiungiComponente";
            this.btnAggiungiComponente.Size = new System.Drawing.Size(163, 32);
            this.btnAggiungiComponente.TabIndex = 0;
            this.btnAggiungiComponente.Text = "Aggiungi Componente";
            this.btnAggiungiComponente.UseVisualStyleBackColor = true;
            this.btnAggiungiComponente.Click += new System.EventHandler(this.btnAggiungiComponente_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbTipoSostanza);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1255, 34);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(853, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ricerca:";
            // 
            // cmbTipoSostanza
            // 
            this.cmbTipoSostanza.DataSource = this.tipoSostanzeBindingSource;
            this.cmbTipoSostanza.DisplayMember = "Descrizione";
            this.cmbTipoSostanza.FormattingEnabled = true;
            this.cmbTipoSostanza.Location = new System.Drawing.Point(287, 4);
            this.cmbTipoSostanza.Name = "cmbTipoSostanza";
            this.cmbTipoSostanza.Size = new System.Drawing.Size(209, 24);
            this.cmbTipoSostanza.TabIndex = 1;
            this.cmbTipoSostanza.ValueMember = "Progressivo";
            this.cmbTipoSostanza.SelectedValueChanged += new System.EventHandler(this.cmbTipoSostanza_SelectedValueChanged);
            // 
            // tipoSostanzeBindingSource
            // 
            this.tipoSostanzeBindingSource.DataSource = typeof(DataAccessLayer.TipoSostanze);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(921, 1);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(329, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seleziona tipo di sostanza da visualizzare:";
            // 
            // ControlSostanze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ControlSostanze";
            this.Size = new System.Drawing.Size(1261, 695);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSostanze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newSostanzeBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIngredienti)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoSostanzeBindingSource)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView grdSostanze;
		private System.Windows.Forms.DataGridViewTextBoxColumn Progressivo;
		private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
		private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione;
		private System.Windows.Forms.DataGridViewTextBoxColumn ModoUso;
		private System.Windows.Forms.DataGridViewTextBoxColumn effetto;
		private System.Windows.Forms.DataGridViewTextBoxColumn ValoreEfficacia;
		private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
		private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataScadenza;
		private System.Windows.Forms.BindingSource newSostanzeBindingSource;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnClona;
		private System.Windows.Forms.Button btnStampa;
		private System.Windows.Forms.LinkLabel lnkNext;
		private System.Windows.Forms.LinkLabel lnkPrevious;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.DataGridView grdIngredienti;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button btnAggiungiComponente;
		private System.Windows.Forms.Button btnEliminaComponente;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbTipoSostanza;
        private System.Windows.Forms.BindingSource tipoSostanzeBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkMultiplePrint;

	}
}
