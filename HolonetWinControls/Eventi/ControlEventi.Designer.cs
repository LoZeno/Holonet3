namespace HolonetManager.Eventi
{
    partial class ControlEventi
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.grpData = new System.Windows.Forms.GroupBox();
			this.tablePan = new System.Windows.Forms.TableLayoutPanel();
			this.grdGiorni = new System.Windows.Forms.DataGridView();
			this.CdEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGiorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.oraInGiocoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.oraFuoriGiocoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.puntiAssegnatiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CostoGiorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.eventoGiorniBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnIscrivi = new System.Windows.Forms.Button();
			this.btnDate = new System.Windows.Forms.Button();
			this.grdPersonaggi = new System.Windows.Forms.DataGridView();
			this.lblGiorni = new System.Windows.Forms.Label();
			this.lblIscritti = new System.Windows.Forms.Label();
			this.grdEventi = new System.Windows.Forms.DataGridView();
			this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Titolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Chiuso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.PuntiAssegnati = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Incasso = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.eventoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnNewEvent = new System.Windows.Forms.Button();
			this.lnkBack = new System.Windows.Forms.LinkLabel();
			this.btnStampaIscritti = new System.Windows.Forms.Button();
			this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.numeroSWDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.giocatoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.eventoGiorniPersonaggioBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lnkForward = new System.Windows.Forms.LinkLabel();
			this.btnAggiungiGiorno = new System.Windows.Forms.Button();
			this.btnGestionePunti = new System.Windows.Forms.Button();
			this.grpData.SuspendLayout();
			this.tablePan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdGiorni)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.eventoGiorniBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdPersonaggi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdEventi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.eventoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.eventoGiorniPersonaggioBindingSource)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpData
			// 
			this.grpData.Controls.Add(this.tablePan);
			this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpData.Location = new System.Drawing.Point(2, 222);
			this.grpData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.grpData.Name = "grpData";
			this.grpData.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.grpData.Size = new System.Drawing.Size(652, 176);
			this.grpData.TabIndex = 1;
			this.grpData.TabStop = false;
			this.grpData.Text = "Dati Evento";
			// 
			// tablePan
			// 
			this.tablePan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tablePan.ColumnCount = 2;
			this.tablePan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tablePan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tablePan.Controls.Add(this.grdGiorni, 0, 1);
			this.tablePan.Controls.Add(this.btnIscrivi, 1, 2);
			this.tablePan.Controls.Add(this.btnDate, 0, 2);
			this.tablePan.Controls.Add(this.grdPersonaggi, 1, 1);
			this.tablePan.Controls.Add(this.lblGiorni, 0, 0);
			this.tablePan.Controls.Add(this.lblIscritti, 1, 0);
			this.tablePan.Location = new System.Drawing.Point(0, 18);
			this.tablePan.Name = "tablePan";
			this.tablePan.RowCount = 3;
			this.tablePan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.00813F));
			this.tablePan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.99187F));
			this.tablePan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tablePan.Size = new System.Drawing.Size(652, 158);
			this.tablePan.TabIndex = 8;
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
            this.oraInGiocoDataGridViewTextBoxColumn,
            this.oraFuoriGiocoDataGridViewTextBoxColumn,
            this.puntiAssegnatiDataGridViewTextBoxColumn,
            this.CostoGiorno});
			this.grdGiorni.DataSource = this.eventoGiorniBindingSource;
			this.grdGiorni.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdGiorni.Location = new System.Drawing.Point(3, 20);
			this.grdGiorni.Name = "grdGiorni";
			this.grdGiorni.ReadOnly = true;
			this.grdGiorni.Size = new System.Drawing.Size(320, 107);
			this.grdGiorni.TabIndex = 7;
			this.grdGiorni.SelectionChanged += new System.EventHandler(this.grdGiorni_SelectionChanged);
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
			dataGridViewCellStyle1.Format = "d";
			dataGridViewCellStyle1.NullValue = null;
			this.DataGiorno.DefaultCellStyle = dataGridViewCellStyle1;
			this.DataGiorno.HeaderText = "Giorno";
			this.DataGiorno.Name = "DataGiorno";
			this.DataGiorno.ReadOnly = true;
			// 
			// oraInGiocoDataGridViewTextBoxColumn
			// 
			this.oraInGiocoDataGridViewTextBoxColumn.DataPropertyName = "OraInGioco";
			dataGridViewCellStyle2.Format = "t";
			dataGridViewCellStyle2.NullValue = null;
			this.oraInGiocoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.oraInGiocoDataGridViewTextBoxColumn.HeaderText = "Ora IG";
			this.oraInGiocoDataGridViewTextBoxColumn.Name = "oraInGiocoDataGridViewTextBoxColumn";
			this.oraInGiocoDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// oraFuoriGiocoDataGridViewTextBoxColumn
			// 
			this.oraFuoriGiocoDataGridViewTextBoxColumn.DataPropertyName = "OraFuoriGioco";
			dataGridViewCellStyle3.Format = "t";
			dataGridViewCellStyle3.NullValue = null;
			this.oraFuoriGiocoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
			this.oraFuoriGiocoDataGridViewTextBoxColumn.HeaderText = "Ora FG";
			this.oraFuoriGiocoDataGridViewTextBoxColumn.Name = "oraFuoriGiocoDataGridViewTextBoxColumn";
			this.oraFuoriGiocoDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// puntiAssegnatiDataGridViewTextBoxColumn
			// 
			this.puntiAssegnatiDataGridViewTextBoxColumn.DataPropertyName = "PuntiAssegnati";
			this.puntiAssegnatiDataGridViewTextBoxColumn.HeaderText = "PX";
			this.puntiAssegnatiDataGridViewTextBoxColumn.Name = "puntiAssegnatiDataGridViewTextBoxColumn";
			this.puntiAssegnatiDataGridViewTextBoxColumn.ReadOnly = true;
			this.puntiAssegnatiDataGridViewTextBoxColumn.Width = 50;
			// 
			// CostoGiorno
			// 
			this.CostoGiorno.DataPropertyName = "CostoGiorno";
			dataGridViewCellStyle4.Format = "C2";
			dataGridViewCellStyle4.NullValue = null;
			this.CostoGiorno.DefaultCellStyle = dataGridViewCellStyle4;
			this.CostoGiorno.HeaderText = "Costo per giorno";
			this.CostoGiorno.Name = "CostoGiorno";
			this.CostoGiorno.ReadOnly = true;
			this.CostoGiorno.Width = 150;
			// 
			// eventoGiorniBindingSource
			// 
			this.eventoGiorniBindingSource.DataSource = typeof(DataAccessLayer.EventoGiorni);
			// 
			// btnIscrivi
			// 
			this.btnIscrivi.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnIscrivi.Location = new System.Drawing.Point(329, 133);
			this.btnIscrivi.Name = "btnIscrivi";
			this.btnIscrivi.Size = new System.Drawing.Size(109, 22);
			this.btnIscrivi.TabIndex = 5;
			this.btnIscrivi.Text = "Iscrivi Personaggio";
			this.btnIscrivi.UseVisualStyleBackColor = true;
			this.btnIscrivi.Click += new System.EventHandler(this.btnIscrivi_Click);
			// 
			// btnDate
			// 
			this.btnDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnDate.Location = new System.Drawing.Point(3, 133);
			this.btnDate.Name = "btnDate";
			this.btnDate.Size = new System.Drawing.Size(90, 22);
			this.btnDate.TabIndex = 6;
			this.btnDate.Text = "Modifica Date";
			this.btnDate.UseVisualStyleBackColor = true;
			this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
			// 
			// grdPersonaggi
			// 
			this.grdPersonaggi.AllowUserToAddRows = false;
			this.grdPersonaggi.AllowUserToDeleteRows = false;
			this.grdPersonaggi.AllowUserToOrderColumns = true;
			this.grdPersonaggi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdPersonaggi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdPersonaggi.Location = new System.Drawing.Point(328, 19);
			this.grdPersonaggi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.grdPersonaggi.Name = "grdPersonaggi";
			this.grdPersonaggi.ReadOnly = true;
			this.grdPersonaggi.RowTemplate.Height = 24;
			this.grdPersonaggi.Size = new System.Drawing.Size(322, 109);
			this.grdPersonaggi.TabIndex = 2;
			// 
			// lblGiorni
			// 
			this.lblGiorni.AutoSize = true;
			this.lblGiorni.Location = new System.Drawing.Point(2, 0);
			this.lblGiorni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblGiorni.Name = "lblGiorni";
			this.lblGiorni.Size = new System.Drawing.Size(74, 13);
			this.lblGiorni.TabIndex = 1;
			this.lblGiorni.Text = "Giorni Evento:";
			// 
			// lblIscritti
			// 
			this.lblIscritti.AutoSize = true;
			this.lblIscritti.Location = new System.Drawing.Point(328, 0);
			this.lblIscritti.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblIscritti.Name = "lblIscritti";
			this.lblIscritti.Size = new System.Drawing.Size(90, 13);
			this.lblIscritti.TabIndex = 3;
			this.lblIscritti.Text = "Personaggi Iscritti";
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
            this.Data,
            this.Chiuso,
            this.PuntiAssegnati,
            this.Costo,
            this.Descrizione,
            this.Incasso});
			this.grdEventi.DataSource = this.eventoBindingSource;
			this.grdEventi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdEventi.Location = new System.Drawing.Point(2, 2);
			this.grdEventi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.grdEventi.MultiSelect = false;
			this.grdEventi.Name = "grdEventi";
			this.grdEventi.ReadOnly = true;
			this.grdEventi.RowTemplate.Height = 24;
			this.grdEventi.Size = new System.Drawing.Size(652, 176);
			this.grdEventi.TabIndex = 0;
			this.grdEventi.DataSourceChanged += new System.EventHandler(this.grdEventi_DataSourceChanged);
			this.grdEventi.SelectionChanged += new System.EventHandler(this.grdEventi_SelectionChanged);
			// 
			// Numero
			// 
			this.Numero.DataPropertyName = "CdEvento";
			dataGridViewCellStyle5.Format = "N0";
			dataGridViewCellStyle5.NullValue = null;
			this.Numero.DefaultCellStyle = dataGridViewCellStyle5;
			this.Numero.HeaderText = "Numero";
			this.Numero.Name = "Numero";
			this.Numero.ReadOnly = true;
			this.Numero.Width = 50;
			// 
			// Titolo
			// 
			this.Titolo.DataPropertyName = "TitoloEvento";
			this.Titolo.HeaderText = "Titolo";
			this.Titolo.Name = "Titolo";
			this.Titolo.ReadOnly = true;
			this.Titolo.Width = 200;
			// 
			// Data
			// 
			this.Data.DataPropertyName = "DataEvento";
			dataGridViewCellStyle6.Format = "d";
			dataGridViewCellStyle6.NullValue = null;
			this.Data.DefaultCellStyle = dataGridViewCellStyle6;
			this.Data.HeaderText = "Data";
			this.Data.Name = "Data";
			this.Data.ReadOnly = true;
			// 
			// Chiuso
			// 
			this.Chiuso.DataPropertyName = "Chiuso";
			this.Chiuso.HeaderText = "Chiuso";
			this.Chiuso.Name = "Chiuso";
			this.Chiuso.ReadOnly = true;
			// 
			// PuntiAssegnati
			// 
			this.PuntiAssegnati.DataPropertyName = "PuntiAssegnati";
			dataGridViewCellStyle7.Format = "N0";
			dataGridViewCellStyle7.NullValue = null;
			this.PuntiAssegnati.DefaultCellStyle = dataGridViewCellStyle7;
			this.PuntiAssegnati.HeaderText = "PX totali";
			this.PuntiAssegnati.Name = "PuntiAssegnati";
			this.PuntiAssegnati.ReadOnly = true;
			// 
			// Costo
			// 
			this.Costo.DataPropertyName = "Costo";
			dataGridViewCellStyle8.Format = "C2";
			dataGridViewCellStyle8.NullValue = null;
			this.Costo.DefaultCellStyle = dataGridViewCellStyle8;
			this.Costo.HeaderText = "Costo Intero";
			this.Costo.Name = "Costo";
			this.Costo.ReadOnly = true;
			this.Costo.Width = 120;
			// 
			// Descrizione
			// 
			this.Descrizione.DataPropertyName = "Descrizione";
			this.Descrizione.HeaderText = "Descrizione";
			this.Descrizione.Name = "Descrizione";
			this.Descrizione.ReadOnly = true;
			this.Descrizione.Width = 400;
			// 
			// Incasso
			// 
			this.Incasso.DataPropertyName = "Incasso";
			this.Incasso.HeaderText = "Incasso";
			this.Incasso.Name = "Incasso";
			this.Incasso.ReadOnly = true;
			// 
			// eventoBindingSource
			// 
			this.eventoBindingSource.DataSource = typeof(DataAccessLayer.Evento);
			// 
			// btnNewEvent
			// 
			this.btnNewEvent.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnNewEvent.Location = new System.Drawing.Point(3, 3);
			this.btnNewEvent.Name = "btnNewEvent";
			this.btnNewEvent.Size = new System.Drawing.Size(91, 28);
			this.btnNewEvent.TabIndex = 2;
			this.btnNewEvent.Text = "Nuovo Evento";
			this.btnNewEvent.UseVisualStyleBackColor = true;
			this.btnNewEvent.Click += new System.EventHandler(this.btnNewEvent_Click);
			// 
			// lnkBack
			// 
			this.lnkBack.AutoSize = true;
			this.lnkBack.Dock = System.Windows.Forms.DockStyle.Right;
			this.lnkBack.Location = new System.Drawing.Point(464, 0);
			this.lnkBack.Name = "lnkBack";
			this.lnkBack.Size = new System.Drawing.Size(73, 34);
			this.lnkBack.TabIndex = 4;
			this.lnkBack.TabStop = true;
			this.lnkBack.Text = "Precedenti 50";
			this.lnkBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBack_LinkClicked);
			// 
			// btnStampaIscritti
			// 
			this.btnStampaIscritti.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnStampaIscritti.Location = new System.Drawing.Point(219, 3);
			this.btnStampaIscritti.Name = "btnStampaIscritti";
			this.btnStampaIscritti.Size = new System.Drawing.Size(102, 28);
			this.btnStampaIscritti.TabIndex = 5;
			this.btnStampaIscritti.Text = "Stampa Cartellini";
			this.btnStampaIscritti.UseVisualStyleBackColor = true;
			this.btnStampaIscritti.Click += new System.EventHandler(this.btnStampaIscritti_Click);
			// 
			// nomeDataGridViewTextBoxColumn
			// 
			this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
			this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
			this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
			this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// numeroSWDataGridViewTextBoxColumn
			// 
			this.numeroSWDataGridViewTextBoxColumn.DataPropertyName = "NumeroSW";
			this.numeroSWDataGridViewTextBoxColumn.HeaderText = "NumeroSW";
			this.numeroSWDataGridViewTextBoxColumn.Name = "numeroSWDataGridViewTextBoxColumn";
			this.numeroSWDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// giocatoreDataGridViewTextBoxColumn
			// 
			this.giocatoreDataGridViewTextBoxColumn.DataPropertyName = "Giocatore";
			this.giocatoreDataGridViewTextBoxColumn.HeaderText = "Giocatore";
			this.giocatoreDataGridViewTextBoxColumn.Name = "giocatoreDataGridViewTextBoxColumn";
			this.giocatoreDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// eventoGiorniPersonaggioBindingSource
			// 
			this.eventoGiorniPersonaggioBindingSource.DataSource = typeof(DataAccessLayer.EventoGiorniPersonaggio);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.grdEventi, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.grpData, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(656, 400);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 6;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.Controls.Add(this.btnNewEvent, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lnkForward, 5, 0);
			this.tableLayoutPanel2.Controls.Add(this.lnkBack, 4, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnStampaIscritti, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnAggiungiGiorno, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnGestionePunti, 3, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 183);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(650, 34);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// lnkForward
			// 
			this.lnkForward.AutoSize = true;
			this.lnkForward.Dock = System.Windows.Forms.DockStyle.Left;
			this.lnkForward.Location = new System.Drawing.Point(543, 0);
			this.lnkForward.Name = "lnkForward";
			this.lnkForward.Size = new System.Drawing.Size(60, 34);
			this.lnkForward.TabIndex = 3;
			this.lnkForward.TabStop = true;
			this.lnkForward.Text = "Prossimi 50";
			this.lnkForward.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForward_LinkClicked);
			// 
			// btnAggiungiGiorno
			// 
			this.btnAggiungiGiorno.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnAggiungiGiorno.Location = new System.Drawing.Point(111, 3);
			this.btnAggiungiGiorno.Name = "btnAggiungiGiorno";
			this.btnAggiungiGiorno.Size = new System.Drawing.Size(98, 28);
			this.btnAggiungiGiorno.TabIndex = 6;
			this.btnAggiungiGiorno.Text = "Aggiungi Giorno";
			this.btnAggiungiGiorno.UseVisualStyleBackColor = true;
			this.btnAggiungiGiorno.Click += new System.EventHandler(this.btnAggiungiGiorno_Click);
			// 
			// btnGestionePunti
			// 
			this.btnGestionePunti.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnGestionePunti.Location = new System.Drawing.Point(326, 2);
			this.btnGestionePunti.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnGestionePunti.Name = "btnGestionePunti";
			this.btnGestionePunti.Size = new System.Drawing.Size(91, 30);
			this.btnGestionePunti.TabIndex = 7;
			this.btnGestionePunti.Text = "Pagamenti e PX";
			this.btnGestionePunti.UseVisualStyleBackColor = true;
			this.btnGestionePunti.Click += new System.EventHandler(this.btnGestionePunti_Click);
			// 
			// ControlEventi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "ControlEventi";
			this.Size = new System.Drawing.Size(656, 400);
			this.grpData.ResumeLayout(false);
			this.tablePan.ResumeLayout(false);
			this.tablePan.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdGiorni)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.eventoGiorniBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdPersonaggi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdEventi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.eventoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.eventoGiorniPersonaggioBindingSource)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEventi;
		private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Label lblGiorni;
		private System.Windows.Forms.Label lblIscritti;
        private System.Windows.Forms.BindingSource eventoBindingSource;
		private System.Windows.Forms.Button btnNewEvent;
		private System.Windows.Forms.LinkLabel lnkBack;
		private System.Windows.Forms.Button btnDate;
		private System.Windows.Forms.Button btnIscrivi;
		private System.Windows.Forms.BindingSource eventoGiorniBindingSource;
		private System.Windows.Forms.DataGridView grdGiorni;
		private System.Windows.Forms.TableLayoutPanel tablePan;
        private System.Windows.Forms.Button btnStampaIscritti;
		private System.Windows.Forms.BindingSource eventoGiorniPersonaggioBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn numeroSWDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn giocatoreDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridView grdPersonaggi;
		private System.Windows.Forms.DataGridViewTextBoxColumn CdEvento;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataGiorno;
		private System.Windows.Forms.DataGridViewTextBoxColumn oraInGiocoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn oraFuoriGiocoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn puntiAssegnatiDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn CostoGiorno;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.LinkLabel lnkForward;
		private System.Windows.Forms.Button btnAggiungiGiorno;
        private System.Windows.Forms.Button btnGestionePunti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chiuso;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuntiAssegnati;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Incasso;
    }
}
