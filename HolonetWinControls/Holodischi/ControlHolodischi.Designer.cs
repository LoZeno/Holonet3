namespace HolonetWinControls.Holodischi
{
	partial class ControlHolodischi
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNuovoDisco = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lnkPrevious = new System.Windows.Forms.LinkLabel();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.btnStampa = new System.Windows.Forms.Button();
            this.grdDischi = new System.Windows.Forms.DataGridView();
            this.Progressivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contenuto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hackingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holoDiskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdFiles = new System.Windows.Forms.DataGridView();
            this.NumeroFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contenutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LivelloCrypt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holoDiskFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEditFile = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDischi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holoDiskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holoDiskFileBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grdDischi, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdFiles, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(875, 492);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.37867F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.37867F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.37533F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.06667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.37867F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.37867F));
            this.tableLayoutPanel3.Controls.Add(this.btnNuovoDisco, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnEdit, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lnkPrevious, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.lnkNext, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnStampa, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 237);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(867, 42);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnNuovoDisco
            // 
            this.btnNuovoDisco.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNuovoDisco.Location = new System.Drawing.Point(4, 4);
            this.btnNuovoDisco.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuovoDisco.Name = "btnNuovoDisco";
            this.btnNuovoDisco.Size = new System.Drawing.Size(107, 34);
            this.btnNuovoDisco.TabIndex = 7;
            this.btnNuovoDisco.Text = "Nuovo Giocatore";
            this.btnNuovoDisco.UseVisualStyleBackColor = true;
            this.btnNuovoDisco.Click += new System.EventHandler(this.btnNuovoDisco_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEdit.Location = new System.Drawing.Point(119, 4);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 34);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Modifica Giocatore";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lnkPrevious
            // 
            this.lnkPrevious.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lnkPrevious.AutoSize = true;
            this.lnkPrevious.Location = new System.Drawing.Point(646, 12);
            this.lnkPrevious.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkPrevious.Name = "lnkPrevious";
            this.lnkPrevious.Size = new System.Drawing.Size(96, 17);
            this.lnkPrevious.TabIndex = 11;
            this.lnkPrevious.TabStop = true;
            this.lnkPrevious.Text = "Precedenti 50";
            // 
            // lnkNext
            // 
            this.lnkNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lnkNext.AutoSize = true;
            this.lnkNext.Location = new System.Drawing.Point(782, 12);
            this.lnkNext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(81, 17);
            this.lnkNext.TabIndex = 12;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "Prossimi 50";
            // 
            // btnStampa
            // 
            this.btnStampa.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStampa.Location = new System.Drawing.Point(234, 4);
            this.btnStampa.Margin = new System.Windows.Forms.Padding(4);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(104, 34);
            this.btnStampa.TabIndex = 13;
            this.btnStampa.Text = "Stampa";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // grdDischi
            // 
            this.grdDischi.AllowUserToAddRows = false;
            this.grdDischi.AllowUserToDeleteRows = false;
            this.grdDischi.AllowUserToOrderColumns = true;
            this.grdDischi.AutoGenerateColumns = false;
            this.grdDischi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDischi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Progressivo,
            this.Codice,
            this.Contenuto,
            this.hackingDataGridViewTextBoxColumn});
            this.grdDischi.DataSource = this.holoDiskBindingSource;
            this.grdDischi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDischi.Location = new System.Drawing.Point(4, 44);
            this.grdDischi.Margin = new System.Windows.Forms.Padding(4);
            this.grdDischi.Name = "grdDischi";
            this.grdDischi.ReadOnly = true;
            this.grdDischi.Size = new System.Drawing.Size(867, 185);
            this.grdDischi.TabIndex = 0;
            this.grdDischi.SelectionChanged += new System.EventHandler(this.grdDischi_SelectionChanged);
            // 
            // Progressivo
            // 
            this.Progressivo.DataPropertyName = "Progressivo";
            this.Progressivo.HeaderText = "Progressivo";
            this.Progressivo.Name = "Progressivo";
            this.Progressivo.ReadOnly = true;
            // 
            // Codice
            // 
            this.Codice.DataPropertyName = "Codice";
            this.Codice.HeaderText = "Titolo";
            this.Codice.Name = "Codice";
            this.Codice.ReadOnly = true;
            // 
            // Contenuto
            // 
            this.Contenuto.DataPropertyName = "Contenuto";
            this.Contenuto.HeaderText = "Contenuto";
            this.Contenuto.Name = "Contenuto";
            this.Contenuto.ReadOnly = true;
            // 
            // hackingDataGridViewTextBoxColumn
            // 
            this.hackingDataGridViewTextBoxColumn.DataPropertyName = "Hacking";
            this.hackingDataGridViewTextBoxColumn.HeaderText = "Hacking";
            this.hackingDataGridViewTextBoxColumn.Name = "hackingDataGridViewTextBoxColumn";
            this.hackingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // holoDiskBindingSource
            // 
            this.holoDiskBindingSource.DataSource = typeof(DataAccessLayer.HoloDisk);
            // 
            // grdFiles
            // 
            this.grdFiles.AllowUserToAddRows = false;
            this.grdFiles.AllowUserToDeleteRows = false;
            this.grdFiles.AllowUserToOrderColumns = true;
            this.grdFiles.AutoGenerateColumns = false;
            this.grdFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroFile,
            this.NomeFile,
            this.contenutoDataGridViewTextBoxColumn,
            this.LivelloCrypt});
            this.grdFiles.DataSource = this.holoDiskFileBindingSource;
            this.grdFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFiles.Location = new System.Drawing.Point(4, 287);
            this.grdFiles.Margin = new System.Windows.Forms.Padding(4);
            this.grdFiles.MultiSelect = false;
            this.grdFiles.Name = "grdFiles";
            this.grdFiles.ReadOnly = true;
            this.grdFiles.Size = new System.Drawing.Size(867, 153);
            this.grdFiles.TabIndex = 1;
            // 
            // NumeroFile
            // 
            this.NumeroFile.DataPropertyName = "NumeroFile";
            this.NumeroFile.HeaderText = "File";
            this.NumeroFile.Name = "NumeroFile";
            this.NumeroFile.ReadOnly = true;
            // 
            // NomeFile
            // 
            this.NomeFile.DataPropertyName = "NomeFile";
            this.NomeFile.HeaderText = "Nome File";
            this.NomeFile.Name = "NomeFile";
            this.NomeFile.ReadOnly = true;
            // 
            // contenutoDataGridViewTextBoxColumn
            // 
            this.contenutoDataGridViewTextBoxColumn.DataPropertyName = "Contenuto";
            this.contenutoDataGridViewTextBoxColumn.HeaderText = "Contenuto";
            this.contenutoDataGridViewTextBoxColumn.Name = "contenutoDataGridViewTextBoxColumn";
            this.contenutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // LivelloCrypt
            // 
            this.LivelloCrypt.DataPropertyName = "LivelloCrypt";
            this.LivelloCrypt.HeaderText = "LivelloCrypt";
            this.LivelloCrypt.Name = "LivelloCrypt";
            this.LivelloCrypt.ReadOnly = true;
            // 
            // holoDiskFileBindingSource
            // 
            this.holoDiskFileBindingSource.DataSource = typeof(DataAccessLayer.HoloDiskFile);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnEditFile, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAddFile, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 448);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(867, 40);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnEditFile
            // 
            this.btnEditFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditFile.Location = new System.Drawing.Point(437, 4);
            this.btnEditFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditFile.Name = "btnEditFile";
            this.btnEditFile.Size = new System.Drawing.Size(143, 32);
            this.btnEditFile.TabIndex = 9;
            this.btnEditFile.Text = "Modifica File";
            this.btnEditFile.UseVisualStyleBackColor = true;
            this.btnEditFile.Click += new System.EventHandler(this.btnEditFile_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddFile.Location = new System.Drawing.Point(4, 4);
            this.btnAddFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(143, 32);
            this.btnAddFile.TabIndex = 8;
            this.btnAddFile.Text = "Crea File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 34);
            this.panel1.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(648, 4);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 22);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(580, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ricerca:";
            // 
            // ControlHolodischi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ControlHolodischi";
            this.Size = new System.Drawing.Size(875, 492);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDischi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holoDiskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holoDiskFileBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView grdDischi;
		private System.Windows.Forms.DataGridViewTextBoxColumn Progressivo;
		private System.Windows.Forms.DataGridViewTextBoxColumn Codice;
		private System.Windows.Forms.DataGridViewTextBoxColumn Contenuto;
		private System.Windows.Forms.DataGridViewTextBoxColumn hackingDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource holoDiskBindingSource;
		private System.Windows.Forms.DataGridView grdFiles;
		private System.Windows.Forms.BindingSource holoDiskFileBindingSource;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button btnNuovoDisco;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.LinkLabel lnkPrevious;
		private System.Windows.Forms.LinkLabel lnkNext;
		private System.Windows.Forms.DataGridViewTextBoxColumn NumeroFile;
		private System.Windows.Forms.DataGridViewTextBoxColumn NomeFile;
		private System.Windows.Forms.DataGridViewTextBoxColumn contenutoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn LivelloCrypt;
		private System.Windows.Forms.Button btnStampa;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnEditFile;
		private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Panel panel1;
	}
}
