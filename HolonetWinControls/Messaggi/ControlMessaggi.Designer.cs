namespace HolonetWinControls.Messaggi
{
	partial class ControlMessaggi
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.txtTesto = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtDestinatari = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkShowAll = new System.Windows.Forms.CheckBox();
			this.cmbSelezionaDestinatario = new System.Windows.Forms.ComboBox();
			this.personaggioBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnRispondi = new System.Windows.Forms.Button();
			this.btnNuovo = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.grdMessaggi = new System.Windows.Forms.DataGridView();
			this.NumeroMissione = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nomeMandanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.titoloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataCreazioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.attivaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.livelloCrittazioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.missioneBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.lnkNext = new System.Windows.Forms.LinkLabel();
			this.lnkPrevious = new System.Windows.Forms.LinkLabel();
			this.missioneBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.personaggioBindingSource)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMessaggi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.missioneBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.missioneBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(656, 400);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.txtTesto, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 3);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(232, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(421, 394);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// txtTesto
			// 
			this.txtTesto.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtTesto.Location = new System.Drawing.Point(3, 42);
			this.txtTesto.Multiline = true;
			this.txtTesto.Name = "txtTesto";
			this.txtTesto.ReadOnly = true;
			this.txtTesto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTesto.Size = new System.Drawing.Size(415, 230);
			this.txtTesto.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtDestinatari);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 278);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(415, 72);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Destinatari";
			// 
			// txtDestinatari
			// 
			this.txtDestinatari.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDestinatari.Location = new System.Drawing.Point(3, 16);
			this.txtDestinatari.Multiline = true;
			this.txtDestinatari.Name = "txtDestinatari";
			this.txtDestinatari.ReadOnly = true;
			this.txtDestinatari.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDestinatari.Size = new System.Drawing.Size(409, 53);
			this.txtDestinatari.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkShowAll);
			this.groupBox2.Controls.Add(this.cmbSelezionaDestinatario);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(415, 33);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Seleziona destinatario:";
			// 
			// chkShowAll
			// 
			this.chkShowAll.AutoSize = true;
			this.chkShowAll.Checked = true;
			this.chkShowAll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowAll.Location = new System.Drawing.Point(7, 15);
			this.chkShowAll.Name = "chkShowAll";
			this.chkShowAll.Size = new System.Drawing.Size(82, 17);
			this.chkShowAll.TabIndex = 1;
			this.chkShowAll.Text = "Mostra Tutti";
			this.chkShowAll.UseVisualStyleBackColor = true;
			this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
			// 
			// cmbSelezionaDestinatario
			// 
			this.cmbSelezionaDestinatario.DataSource = this.personaggioBindingSource;
			this.cmbSelezionaDestinatario.DisplayMember = "Nome";
			this.cmbSelezionaDestinatario.Enabled = false;
			this.cmbSelezionaDestinatario.FormattingEnabled = true;
			this.cmbSelezionaDestinatario.Location = new System.Drawing.Point(102, 12);
			this.cmbSelezionaDestinatario.Name = "cmbSelezionaDestinatario";
			this.cmbSelezionaDestinatario.Size = new System.Drawing.Size(288, 21);
			this.cmbSelezionaDestinatario.TabIndex = 0;
			this.cmbSelezionaDestinatario.ValueMember = "NumeroPG";
			this.cmbSelezionaDestinatario.SelectedValueChanged += new System.EventHandler(this.cmbSelezionaDestinatario_SelectedValueChanged);
			// 
			// personaggioBindingSource
			// 
			this.personaggioBindingSource.DataSource = typeof(DataAccessLayer.Personaggio);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnRispondi);
			this.groupBox3.Controls.Add(this.btnNuovo);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(3, 356);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(415, 35);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			// 
			// btnRispondi
			// 
			this.btnRispondi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRispondi.Location = new System.Drawing.Point(145, 12);
			this.btnRispondi.Name = "btnRispondi";
			this.btnRispondi.Size = new System.Drawing.Size(106, 23);
			this.btnRispondi.TabIndex = 1;
			this.btnRispondi.Text = "Risp. Messaggio";
			this.btnRispondi.UseVisualStyleBackColor = true;
			this.btnRispondi.Click += new System.EventHandler(this.btnRispondi_Click);
			// 
			// btnNuovo
			// 
			this.btnNuovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNuovo.Location = new System.Drawing.Point(0, 12);
			this.btnNuovo.Name = "btnNuovo";
			this.btnNuovo.Size = new System.Drawing.Size(106, 23);
			this.btnNuovo.TabIndex = 0;
			this.btnNuovo.Text = "Nuovo Messaggio";
			this.btnNuovo.UseVisualStyleBackColor = true;
			this.btnNuovo.Click += new System.EventHandler(this.btnNuovo_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.linkLabel1);
			this.groupBox4.Controls.Add(this.grdMessaggi);
			this.groupBox4.Controls.Add(this.lnkNext);
			this.groupBox4.Controls.Add(this.lnkPrevious);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new System.Drawing.Point(3, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(223, 394);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Elenco";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(95, 373);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(44, 13);
			this.linkLabel1.TabIndex = 8;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Refresh";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// grdMessaggi
			// 
			this.grdMessaggi.AllowUserToAddRows = false;
			this.grdMessaggi.AllowUserToDeleteRows = false;
			this.grdMessaggi.AllowUserToOrderColumns = true;
			this.grdMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grdMessaggi.AutoGenerateColumns = false;
			this.grdMessaggi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdMessaggi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroMissione,
            this.nomeMandanteDataGridViewTextBoxColumn,
            this.titoloDataGridViewTextBoxColumn,
            this.dataCreazioneDataGridViewTextBoxColumn,
            this.attivaDataGridViewTextBoxColumn,
            this.livelloCrittazioneDataGridViewTextBoxColumn});
			this.grdMessaggi.DataSource = this.missioneBindingSource1;
			this.grdMessaggi.Location = new System.Drawing.Point(6, 15);
			this.grdMessaggi.MultiSelect = false;
			this.grdMessaggi.Name = "grdMessaggi";
			this.grdMessaggi.ReadOnly = true;
			this.grdMessaggi.Size = new System.Drawing.Size(211, 355);
			this.grdMessaggi.TabIndex = 7;
			this.grdMessaggi.SelectionChanged += new System.EventHandler(this.grdMessaggi_SelectionChanged);
			// 
			// NumeroMissione
			// 
			this.NumeroMissione.DataPropertyName = "NumeroMissione";
			this.NumeroMissione.HeaderText = "NumeroMissione";
			this.NumeroMissione.Name = "NumeroMissione";
			this.NumeroMissione.ReadOnly = true;
			this.NumeroMissione.Visible = false;
			// 
			// nomeMandanteDataGridViewTextBoxColumn
			// 
			this.nomeMandanteDataGridViewTextBoxColumn.DataPropertyName = "NomeMandante";
			this.nomeMandanteDataGridViewTextBoxColumn.HeaderText = "NomeMandante";
			this.nomeMandanteDataGridViewTextBoxColumn.Name = "nomeMandanteDataGridViewTextBoxColumn";
			this.nomeMandanteDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// titoloDataGridViewTextBoxColumn
			// 
			this.titoloDataGridViewTextBoxColumn.DataPropertyName = "Titolo";
			this.titoloDataGridViewTextBoxColumn.HeaderText = "Titolo";
			this.titoloDataGridViewTextBoxColumn.Name = "titoloDataGridViewTextBoxColumn";
			this.titoloDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// dataCreazioneDataGridViewTextBoxColumn
			// 
			this.dataCreazioneDataGridViewTextBoxColumn.DataPropertyName = "DataCreazione";
			dataGridViewCellStyle1.Format = "G";
			dataGridViewCellStyle1.NullValue = null;
			this.dataCreazioneDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.dataCreazioneDataGridViewTextBoxColumn.HeaderText = "Data";
			this.dataCreazioneDataGridViewTextBoxColumn.Name = "dataCreazioneDataGridViewTextBoxColumn";
			this.dataCreazioneDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// attivaDataGridViewTextBoxColumn
			// 
			this.attivaDataGridViewTextBoxColumn.DataPropertyName = "Attiva";
			this.attivaDataGridViewTextBoxColumn.HeaderText = "Attiva";
			this.attivaDataGridViewTextBoxColumn.Name = "attivaDataGridViewTextBoxColumn";
			this.attivaDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// livelloCrittazioneDataGridViewTextBoxColumn
			// 
			this.livelloCrittazioneDataGridViewTextBoxColumn.DataPropertyName = "LivelloCrittazione";
			this.livelloCrittazioneDataGridViewTextBoxColumn.HeaderText = "Crypt.";
			this.livelloCrittazioneDataGridViewTextBoxColumn.Name = "livelloCrittazioneDataGridViewTextBoxColumn";
			this.livelloCrittazioneDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// missioneBindingSource1
			// 
			this.missioneBindingSource1.DataSource = typeof(DataAccessLayer.Missione);
			// 
			// lnkNext
			// 
			this.lnkNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lnkNext.AutoSize = true;
			this.lnkNext.Location = new System.Drawing.Point(157, 373);
			this.lnkNext.Name = "lnkNext";
			this.lnkNext.Size = new System.Drawing.Size(60, 13);
			this.lnkNext.TabIndex = 6;
			this.lnkNext.TabStop = true;
			this.lnkNext.Text = "Prossimi 50";
			this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
			// 
			// lnkPrevious
			// 
			this.lnkPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lnkPrevious.AutoSize = true;
			this.lnkPrevious.Location = new System.Drawing.Point(6, 373);
			this.lnkPrevious.Name = "lnkPrevious";
			this.lnkPrevious.Size = new System.Drawing.Size(73, 13);
			this.lnkPrevious.TabIndex = 5;
			this.lnkPrevious.TabStop = true;
			this.lnkPrevious.Text = "Precedenti 50";
			this.lnkPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrevious_LinkClicked);
			// 
			// missioneBindingSource
			// 
			this.missioneBindingSource.DataSource = typeof(DataAccessLayer.Missione);
			// 
			// ControlMessaggi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "ControlMessaggi";
			this.Size = new System.Drawing.Size(656, 400);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.personaggioBindingSource)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMessaggi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.missioneBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.missioneBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TextBox txtTesto;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtDestinatari;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkShowAll;
		private System.Windows.Forms.ComboBox cmbSelezionaDestinatario;
		private System.Windows.Forms.BindingSource personaggioBindingSource;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnRispondi;
		private System.Windows.Forms.Button btnNuovo;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.LinkLabel lnkPrevious;
		private System.Windows.Forms.LinkLabel lnkNext;
		private System.Windows.Forms.DataGridView grdMessaggi;
		private System.Windows.Forms.BindingSource missioneBindingSource;
		private System.Windows.Forms.BindingSource missioneBindingSource1;
		private System.Windows.Forms.DataGridViewTextBoxColumn NumeroMissione;
		private System.Windows.Forms.DataGridViewTextBoxColumn nomeMandanteDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn titoloDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataCreazioneDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn attivaDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn livelloCrittazioneDataGridViewTextBoxColumn;
		private System.Windows.Forms.LinkLabel linkLabel1;
	}
}
