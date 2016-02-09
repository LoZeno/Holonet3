namespace HolonetWinControls.Eventi
{
    partial class ControlStampeEventi
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.grpOggetti = new System.Windows.Forms.GroupBox();
			this.grdCartellini = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.grdEventi = new System.Windows.Forms.DataGridView();
			this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Titolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PuntiAssegnati = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chiusoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.eventoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lnkPrevious = new System.Windows.Forms.LinkLabel();
			this.lnkNext = new System.Windows.Forms.LinkLabel();
			this.btnStampa = new System.Windows.Forms.Button();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.btnAggiungiElemento = new System.Windows.Forms.Button();
			this.btnModificaElemento = new System.Windows.Forms.Button();
			this.grpHolodisk = new System.Windows.Forms.GroupBox();
			this.grdDischi = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.btnModificaDisco = new System.Windows.Forms.Button();
			this.btnAggiungiDisco = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.grpOggetti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCartellini)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdEventi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.eventoBindingSource)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.grpHolodisk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdDischi)).BeginInit();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.grpOggetti, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.grdEventi, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.grpHolodisk, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 4);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.25126F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.74874F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(656, 400);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// grpOggetti
			// 
			this.grpOggetti.Controls.Add(this.grdCartellini);
			this.grpOggetti.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpOggetti.Location = new System.Drawing.Point(3, 216);
			this.grpOggetti.Name = "grpOggetti";
			this.grpOggetti.Size = new System.Drawing.Size(322, 142);
			this.grpOggetti.TabIndex = 6;
			this.grpOggetti.TabStop = false;
			this.grpOggetti.Text = "Oggetti e Sostanze";
			// 
			// grdCartellini
			// 
			this.grdCartellini.AllowUserToAddRows = false;
			this.grdCartellini.AllowUserToDeleteRows = false;
			this.grdCartellini.AllowUserToOrderColumns = true;
			this.grdCartellini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdCartellini.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdCartellini.Location = new System.Drawing.Point(3, 16);
			this.grdCartellini.Margin = new System.Windows.Forms.Padding(2);
			this.grdCartellini.Name = "grdCartellini";
			this.grdCartellini.ReadOnly = true;
			this.grdCartellini.RowTemplate.Height = 24;
			this.grdCartellini.Size = new System.Drawing.Size(316, 123);
			this.grdCartellini.TabIndex = 3;
			// 
			// panel1
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(652, 28);
			this.panel1.TabIndex = 0;
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.txtSearch.Location = new System.Drawing.Point(484, 3);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(166, 20);
			this.txtSearch.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(433, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Ricerca:";
			// 
			// grdEventi
			// 
			this.grdEventi.AllowUserToAddRows = false;
			this.grdEventi.AllowUserToDeleteRows = false;
			this.grdEventi.AllowUserToOrderColumns = true;
			this.grdEventi.AutoGenerateColumns = false;
			this.grdEventi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdEventi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Titolo,
            this.DataEvento,
            this.PuntiAssegnati,
            this.Costo,
            this.chiusoDataGridViewCheckBoxColumn});
			this.tableLayoutPanel1.SetColumnSpan(this.grdEventi, 2);
			this.grdEventi.DataSource = this.eventoBindingSource;
			this.grdEventi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdEventi.Location = new System.Drawing.Point(2, 34);
			this.grdEventi.Margin = new System.Windows.Forms.Padding(2);
			this.grdEventi.Name = "grdEventi";
			this.grdEventi.ReadOnly = true;
			this.grdEventi.RowTemplate.Height = 24;
			this.grdEventi.Size = new System.Drawing.Size(652, 145);
			this.grdEventi.TabIndex = 1;
			this.grdEventi.SelectionChanged += new System.EventHandler(this.grdEventi_SelectionChanged);
			// 
			// Numero
			// 
			this.Numero.DataPropertyName = "CdEvento";
			this.Numero.HeaderText = "Numero";
			this.Numero.Name = "Numero";
			this.Numero.ReadOnly = true;
			// 
			// Titolo
			// 
			this.Titolo.DataPropertyName = "TitoloEvento";
			this.Titolo.HeaderText = "Titolo";
			this.Titolo.Name = "Titolo";
			this.Titolo.ReadOnly = true;
			this.Titolo.Width = 250;
			// 
			// DataEvento
			// 
			this.DataEvento.DataPropertyName = "DataEvento";
			dataGridViewCellStyle1.Format = "d";
			dataGridViewCellStyle1.NullValue = null;
			this.DataEvento.DefaultCellStyle = dataGridViewCellStyle1;
			this.DataEvento.HeaderText = "Data di Inizio";
			this.DataEvento.Name = "DataEvento";
			this.DataEvento.ReadOnly = true;
			this.DataEvento.Width = 200;
			// 
			// PuntiAssegnati
			// 
			this.PuntiAssegnati.DataPropertyName = "PuntiAssegnati";
			this.PuntiAssegnati.HeaderText = "PX";
			this.PuntiAssegnati.Name = "PuntiAssegnati";
			this.PuntiAssegnati.ReadOnly = true;
			// 
			// Costo
			// 
			this.Costo.DataPropertyName = "Costo";
			this.Costo.HeaderText = "Costo";
			this.Costo.Name = "Costo";
			this.Costo.ReadOnly = true;
			// 
			// chiusoDataGridViewCheckBoxColumn
			// 
			this.chiusoDataGridViewCheckBoxColumn.DataPropertyName = "Chiuso";
			this.chiusoDataGridViewCheckBoxColumn.HeaderText = "Chiuso";
			this.chiusoDataGridViewCheckBoxColumn.Name = "chiusoDataGridViewCheckBoxColumn";
			this.chiusoDataGridViewCheckBoxColumn.ReadOnly = true;
			// 
			// eventoBindingSource
			// 
			this.eventoBindingSource.DataSource = typeof(DataAccessLayer.Evento);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
			this.tableLayoutPanel2.Controls.Add(this.lnkPrevious, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.lnkNext, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnStampa, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 183);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(652, 28);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// lnkPrevious
			// 
			this.lnkPrevious.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lnkPrevious.AutoSize = true;
			this.lnkPrevious.Location = new System.Drawing.Point(490, 7);
			this.lnkPrevious.Name = "lnkPrevious";
			this.lnkPrevious.Size = new System.Drawing.Size(73, 13);
			this.lnkPrevious.TabIndex = 12;
			this.lnkPrevious.TabStop = true;
			this.lnkPrevious.Text = "Precedenti 50";
			this.lnkPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrevious_LinkClicked);
			// 
			// lnkNext
			// 
			this.lnkNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lnkNext.AutoSize = true;
			this.lnkNext.Location = new System.Drawing.Point(589, 7);
			this.lnkNext.Name = "lnkNext";
			this.lnkNext.Size = new System.Drawing.Size(60, 13);
			this.lnkNext.TabIndex = 13;
			this.lnkNext.TabStop = true;
			this.lnkNext.Text = "Prossimi 50";
			this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
			// 
			// btnStampa
			// 
			this.btnStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStampa.Location = new System.Drawing.Point(2, 2);
			this.btnStampa.Margin = new System.Windows.Forms.Padding(2);
			this.btnStampa.Name = "btnStampa";
			this.btnStampa.Size = new System.Drawing.Size(126, 24);
			this.btnStampa.TabIndex = 14;
			this.btnStampa.Text = "Stampa Cartellini";
			this.btnStampa.UseVisualStyleBackColor = true;
			this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Controls.Add(this.btnAggiungiElemento, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnModificaElemento, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 363);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(324, 35);
			this.tableLayoutPanel3.TabIndex = 4;
			// 
			// btnAggiungiElemento
			// 
			this.btnAggiungiElemento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAggiungiElemento.Location = new System.Drawing.Point(2, 2);
			this.btnAggiungiElemento.Margin = new System.Windows.Forms.Padding(2);
			this.btnAggiungiElemento.Name = "btnAggiungiElemento";
			this.btnAggiungiElemento.Size = new System.Drawing.Size(96, 31);
			this.btnAggiungiElemento.TabIndex = 0;
			this.btnAggiungiElemento.Text = "Numero Copie";
			this.btnAggiungiElemento.UseVisualStyleBackColor = true;
			this.btnAggiungiElemento.Click += new System.EventHandler(this.btnAggiungiElemento_Click);
			// 
			// btnModificaElemento
			// 
			this.btnModificaElemento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnModificaElemento.Location = new System.Drawing.Point(102, 2);
			this.btnModificaElemento.Margin = new System.Windows.Forms.Padding(2);
			this.btnModificaElemento.Name = "btnModificaElemento";
			this.btnModificaElemento.Size = new System.Drawing.Size(96, 31);
			this.btnModificaElemento.TabIndex = 1;
			this.btnModificaElemento.Text = "Elimina selez.";
			this.btnModificaElemento.UseVisualStyleBackColor = true;
			this.btnModificaElemento.Click += new System.EventHandler(this.btnModificaElemento_Click);
			// 
			// grpHolodisk
			// 
			this.grpHolodisk.Controls.Add(this.grdDischi);
			this.grpHolodisk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpHolodisk.Location = new System.Drawing.Point(331, 216);
			this.grpHolodisk.Name = "grpHolodisk";
			this.grpHolodisk.Size = new System.Drawing.Size(322, 142);
			this.grpHolodisk.TabIndex = 7;
			this.grpHolodisk.TabStop = false;
			this.grpHolodisk.Text = "Datapad e Holodischi";
			// 
			// grdDischi
			// 
			this.grdDischi.AllowUserToAddRows = false;
			this.grdDischi.AllowUserToDeleteRows = false;
			this.grdDischi.AllowUserToOrderColumns = true;
			this.grdDischi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdDischi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdDischi.Location = new System.Drawing.Point(3, 16);
			this.grdDischi.Name = "grdDischi";
			this.grdDischi.ReadOnly = true;
			this.grdDischi.Size = new System.Drawing.Size(316, 123);
			this.grdDischi.TabIndex = 0;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 3;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.Controls.Add(this.btnModificaDisco, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.btnAggiungiDisco, 0, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(331, 364);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(322, 33);
			this.tableLayoutPanel4.TabIndex = 8;
			// 
			// btnModificaDisco
			// 
			this.btnModificaDisco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnModificaDisco.Location = new System.Drawing.Point(102, 2);
			this.btnModificaDisco.Margin = new System.Windows.Forms.Padding(2);
			this.btnModificaDisco.Name = "btnModificaDisco";
			this.btnModificaDisco.Size = new System.Drawing.Size(96, 29);
			this.btnModificaDisco.TabIndex = 2;
			this.btnModificaDisco.Text = "Elimina selez.";
			this.btnModificaDisco.UseVisualStyleBackColor = true;
			this.btnModificaDisco.Click += new System.EventHandler(this.btnModificaDisco_Click);
			// 
			// btnAggiungiDisco
			// 
			this.btnAggiungiDisco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAggiungiDisco.Location = new System.Drawing.Point(2, 2);
			this.btnAggiungiDisco.Margin = new System.Windows.Forms.Padding(2);
			this.btnAggiungiDisco.Name = "btnAggiungiDisco";
			this.btnAggiungiDisco.Size = new System.Drawing.Size(96, 29);
			this.btnAggiungiDisco.TabIndex = 1;
			this.btnAggiungiDisco.Text = "Numero Copie";
			this.btnAggiungiDisco.UseVisualStyleBackColor = true;
			this.btnAggiungiDisco.Click += new System.EventHandler(this.btnAggiungiDisco_Click);
			// 
			// ControlStampeEventi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ControlStampeEventi";
			this.Size = new System.Drawing.Size(656, 400);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.grpOggetti.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdCartellini)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdEventi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.eventoBindingSource)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.grpHolodisk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdDischi)).EndInit();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdEventi;
		private System.Windows.Forms.BindingSource eventoBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.LinkLabel lnkPrevious;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuntiAssegnati;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chiusoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button btnStampa;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnAggiungiElemento;
        private System.Windows.Forms.Button btnModificaElemento;
		private System.Windows.Forms.GroupBox grpOggetti;
		private System.Windows.Forms.DataGridView grdCartellini;
		private System.Windows.Forms.GroupBox grpHolodisk;
		private System.Windows.Forms.DataGridView grdDischi;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Button btnAggiungiDisco;
		private System.Windows.Forms.Button btnModificaDisco;

    }
}
