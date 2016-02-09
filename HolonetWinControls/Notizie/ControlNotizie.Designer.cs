namespace HolonetWinControls.Notizie
{
	partial class ControlNotizie
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
			this.label3 = new System.Windows.Forms.Label();
			this.grdNotizie = new System.Windows.Forms.DataGridView();
			this.NumeroNotizia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Titolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataCreazione = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataFine = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.notiziaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cmbFazione = new System.Windows.Forms.ComboBox();
			this.reteBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dtVisualizzazione = new System.Windows.Forms.DateTimePicker();
			this.txtTesto = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnNuovaNotizia = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.chkAll = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdNotizie)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.notiziaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reteBindingSource)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
			this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.grdNotizie, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cmbFazione, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtTesto, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(656, 400);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(323, 206);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Testo:";
			// 
			// grdNotizie
			// 
			this.grdNotizie.AllowUserToAddRows = false;
			this.grdNotizie.AllowUserToDeleteRows = false;
			this.grdNotizie.AllowUserToOrderColumns = true;
			this.grdNotizie.AutoGenerateColumns = false;
			this.grdNotizie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdNotizie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroNotizia,
            this.Titolo,
            this.DataCreazione,
            this.DataFine});
			this.grdNotizie.DataSource = this.notiziaBindingSource;
			this.grdNotizie.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdNotizie.Location = new System.Drawing.Point(3, 3);
			this.grdNotizie.MultiSelect = false;
			this.grdNotizie.Name = "grdNotizie";
			this.grdNotizie.ReadOnly = true;
			this.tableLayoutPanel1.SetRowSpan(this.grdNotizie, 3);
			this.grdNotizie.Size = new System.Drawing.Size(285, 344);
			this.grdNotizie.TabIndex = 0;
			this.grdNotizie.SelectionChanged += new System.EventHandler(this.grdNotizie_SelectionChanged);
			// 
			// NumeroNotizia
			// 
			this.NumeroNotizia.DataPropertyName = "NumeroNotizia";
			this.NumeroNotizia.HeaderText = "Numero";
			this.NumeroNotizia.Name = "NumeroNotizia";
			this.NumeroNotizia.ReadOnly = true;
			// 
			// Titolo
			// 
			this.Titolo.DataPropertyName = "Titolo";
			this.Titolo.HeaderText = "Titolo";
			this.Titolo.Name = "Titolo";
			this.Titolo.ReadOnly = true;
			// 
			// DataCreazione
			// 
			this.DataCreazione.DataPropertyName = "DataCreazione";
			this.DataCreazione.HeaderText = "Da:";
			this.DataCreazione.Name = "DataCreazione";
			this.DataCreazione.ReadOnly = true;
			// 
			// DataFine
			// 
			this.DataFine.DataPropertyName = "DataFine";
			this.DataFine.HeaderText = "A:";
			this.DataFine.Name = "DataFine";
			this.DataFine.ReadOnly = true;
			// 
			// notiziaBindingSource
			// 
			this.notiziaBindingSource.DataSource = typeof(DataAccessLayer.Notizia);
			// 
			// cmbFazione
			// 
			this.cmbFazione.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cmbFazione.DataSource = this.reteBindingSource;
			this.cmbFazione.DisplayMember = "Fazione";
			this.cmbFazione.FormattingEnabled = true;
			this.cmbFazione.Location = new System.Drawing.Point(366, 8);
			this.cmbFazione.Name = "cmbFazione";
			this.cmbFazione.Size = new System.Drawing.Size(183, 21);
			this.cmbFazione.TabIndex = 1;
			this.cmbFazione.ValueMember = "NumeroRete";
			this.cmbFazione.SelectedValueChanged += new System.EventHandler(this.cmbFazione_SelectedValueChanged);
			// 
			// reteBindingSource
			// 
			this.reteBindingSource.DataSource = typeof(DataAccessLayer.Rete);
			// 
			// dtVisualizzazione
			// 
			this.dtVisualizzazione.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.dtVisualizzazione.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			this.dtVisualizzazione.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtVisualizzazione.Location = new System.Drawing.Point(0, 3);
			this.dtVisualizzazione.Name = "dtVisualizzazione";
			this.dtVisualizzazione.Size = new System.Drawing.Size(183, 20);
			this.dtVisualizzazione.TabIndex = 2;
			this.dtVisualizzazione.ValueChanged += new System.EventHandler(this.dtVisualizzazione_ValueChanged);
			// 
			// txtTesto
			// 
			this.txtTesto.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtTesto.Location = new System.Drawing.Point(366, 79);
			this.txtTesto.Multiline = true;
			this.txtTesto.Name = "txtTesto";
			this.txtTesto.Size = new System.Drawing.Size(287, 268);
			this.txtTesto.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.chkAll);
			this.panel1.Controls.Add(this.dtVisualizzazione);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(366, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(287, 32);
			this.panel1.TabIndex = 4;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnEdit);
			this.panel2.Controls.Add(this.btnNuovaNotizia);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(366, 353);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(287, 44);
			this.panel2.TabIndex = 5;
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(104, 4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(94, 23);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Modifica Notizia";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnNuovaNotizia
			// 
			this.btnNuovaNotizia.Location = new System.Drawing.Point(4, 4);
			this.btnNuovaNotizia.Name = "btnNuovaNotizia";
			this.btnNuovaNotizia.Size = new System.Drawing.Size(94, 23);
			this.btnNuovaNotizia.TabIndex = 0;
			this.btnNuovaNotizia.Text = "Nuova Notizia";
			this.btnNuovaNotizia.UseVisualStyleBackColor = true;
			this.btnNuovaNotizia.Click += new System.EventHandler(this.btnNuovaNotizia_Click);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(313, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Fazione:";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(327, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Data:";
			// 
			// chkAll
			// 
			this.chkAll.AutoSize = true;
			this.chkAll.Location = new System.Drawing.Point(190, 5);
			this.chkAll.Name = "chkAll";
			this.chkAll.Size = new System.Drawing.Size(86, 17);
			this.chkAll.TabIndex = 3;
			this.chkAll.Text = "Tutte le date";
			this.chkAll.UseVisualStyleBackColor = true;
			this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
			// 
			// ControlNotizie
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "ControlNotizie";
			this.Size = new System.Drawing.Size(656, 400);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdNotizie)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.notiziaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reteBindingSource)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView grdNotizie;
		private System.Windows.Forms.DataGridViewTextBoxColumn NumeroNotizia;
		private System.Windows.Forms.DataGridViewTextBoxColumn Titolo;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataCreazione;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataFine;
		private System.Windows.Forms.BindingSource notiziaBindingSource;
		private System.Windows.Forms.ComboBox cmbFazione;
		private System.Windows.Forms.DateTimePicker dtVisualizzazione;
		private System.Windows.Forms.TextBox txtTesto;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnNuovaNotizia;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.BindingSource reteBindingSource;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.CheckBox chkAll;
	}
}
