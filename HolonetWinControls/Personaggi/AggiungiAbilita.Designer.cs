namespace HolonetWinControls.Personaggi
{
	partial class AggiungiAbilita
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
            this.cmbAttitudine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFreePoints = new System.Windows.Forms.TextBox();
            this.numVolte = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSpecifiche = new System.Windows.Forms.TextBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.grdAbilita = new System.Windows.Forms.DataGridView();
            this.abilitaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CdAbilita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseAvanzatoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrizioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.multiacquistoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numVolte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbilita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilitaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAttitudine
            // 
            this.cmbAttitudine.FormattingEnabled = true;
            this.cmbAttitudine.Location = new System.Drawing.Point(16, 112);
            this.cmbAttitudine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbAttitudine.Name = "cmbAttitudine";
            this.cmbAttitudine.Size = new System.Drawing.Size(592, 24);
            this.cmbAttitudine.TabIndex = 0;
            this.cmbAttitudine.SelectedValueChanged += new System.EventHandler(this.cmbAttitudine_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 67;
            this.label1.Text = "Acquista Abilità";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 17);
            this.label2.TabIndex = 68;
            this.label2.Text = "Seleziona una lista di Attitudine";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 17);
            this.label3.TabIndex = 70;
            this.label3.Text = "Seleziona un\'abilità dall\'elenco:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 340);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 17);
            this.label4.TabIndex = 71;
            this.label4.Text = "Numero di volte di acquisto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 72;
            this.label5.Text = "Punti disponibili:";
            // 
            // txtFreePoints
            // 
            this.txtFreePoints.Location = new System.Drawing.Point(229, 49);
            this.txtFreePoints.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFreePoints.Name = "txtFreePoints";
            this.txtFreePoints.ReadOnly = true;
            this.txtFreePoints.Size = new System.Drawing.Size(132, 22);
            this.txtFreePoints.TabIndex = 73;
            // 
            // numVolte
            // 
            this.numVolte.Enabled = false;
            this.numVolte.Location = new System.Drawing.Point(261, 337);
            this.numVolte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numVolte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVolte.Name = "numVolte";
            this.numVolte.Size = new System.Drawing.Size(100, 22);
            this.numVolte.TabIndex = 74;
            this.numVolte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 388);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 17);
            this.label6.TabIndex = 75;
            this.label6.Text = "Specifiche (es. Gruppo della Forza):";
            // 
            // txtSpecifiche
            // 
            this.txtSpecifiche.Enabled = false;
            this.txtSpecifiche.Location = new System.Drawing.Point(15, 430);
            this.txtSpecifiche.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSpecifiche.Name = "txtSpecifiche";
            this.txtSpecifiche.Size = new System.Drawing.Size(593, 22);
            this.txtSpecifiche.TabIndex = 76;
            // 
            // btnSalva
            // 
            this.btnSalva.Enabled = false;
            this.btnSalva.Location = new System.Drawing.Point(15, 481);
            this.btnSalva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(100, 28);
            this.btnSalva.TabIndex = 77;
            this.btnSalva.Text = "Compra";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Location = new System.Drawing.Point(508, 481);
            this.btnAnnulla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(100, 28);
            this.btnAnnulla.TabIndex = 78;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
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
            this.nomeDataGridViewTextBoxColumn,
            this.costoDataGridViewTextBoxColumn,
            this.baseAvanzatoDataGridViewTextBoxColumn,
            this.descrizioneDataGridViewTextBoxColumn,
            this.multiacquistoDataGridViewTextBoxColumn});
            this.grdAbilita.DataSource = this.abilitaBindingSource;
            this.grdAbilita.Location = new System.Drawing.Point(15, 161);
            this.grdAbilita.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdAbilita.MultiSelect = false;
            this.grdAbilita.Name = "grdAbilita";
            this.grdAbilita.ReadOnly = true;
            this.grdAbilita.Size = new System.Drawing.Size(593, 155);
            this.grdAbilita.TabIndex = 79;
            this.grdAbilita.SelectionChanged += new System.EventHandler(this.grdAbilita_SelectionChanged);
            // 
            // abilitaBindingSource
            // 
            this.abilitaBindingSource.DataSource = typeof(DataAccessLayer.Abilita);
            // 
            // CdAbilita
            // 
            this.CdAbilita.DataPropertyName = "CdAbilita";
            this.CdAbilita.HeaderText = "Codice";
            this.CdAbilita.Name = "CdAbilita";
            this.CdAbilita.ReadOnly = true;
            this.CdAbilita.Visible = false;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeDataGridViewTextBoxColumn.Width = 210;
            // 
            // costoDataGridViewTextBoxColumn
            // 
            this.costoDataGridViewTextBoxColumn.DataPropertyName = "Costo";
            this.costoDataGridViewTextBoxColumn.HeaderText = "Costo";
            this.costoDataGridViewTextBoxColumn.Name = "costoDataGridViewTextBoxColumn";
            this.costoDataGridViewTextBoxColumn.ReadOnly = true;
            this.costoDataGridViewTextBoxColumn.Width = 50;
            // 
            // baseAvanzatoDataGridViewTextBoxColumn
            // 
            this.baseAvanzatoDataGridViewTextBoxColumn.DataPropertyName = "BaseAvanzato";
            this.baseAvanzatoDataGridViewTextBoxColumn.HeaderText = "Avanz.";
            this.baseAvanzatoDataGridViewTextBoxColumn.Name = "baseAvanzatoDataGridViewTextBoxColumn";
            this.baseAvanzatoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descrizioneDataGridViewTextBoxColumn
            // 
            this.descrizioneDataGridViewTextBoxColumn.DataPropertyName = "Descrizione";
            this.descrizioneDataGridViewTextBoxColumn.HeaderText = "Descrizione";
            this.descrizioneDataGridViewTextBoxColumn.Name = "descrizioneDataGridViewTextBoxColumn";
            this.descrizioneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // multiacquistoDataGridViewTextBoxColumn
            // 
            this.multiacquistoDataGridViewTextBoxColumn.DataPropertyName = "Multiacquisto";
            this.multiacquistoDataGridViewTextBoxColumn.HeaderText = "Multi";
            this.multiacquistoDataGridViewTextBoxColumn.Name = "multiacquistoDataGridViewTextBoxColumn";
            this.multiacquistoDataGridViewTextBoxColumn.ReadOnly = true;
            this.multiacquistoDataGridViewTextBoxColumn.Width = 20;
            // 
            // AggiungiAbilita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 524);
            this.Controls.Add(this.grdAbilita);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.txtSpecifiche);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numVolte);
            this.Controls.Add(this.txtFreePoints);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAttitudine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AggiungiAbilita";
            this.Text = "Aggiungi Abilità";
            ((System.ComponentModel.ISupportInitialize)(this.numVolte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbilita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilitaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbAttitudine;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFreePoints;
		private System.Windows.Forms.NumericUpDown numVolte;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtSpecifiche;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.DataGridView grdAbilita;
        private System.Windows.Forms.BindingSource abilitaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdAbilita;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseAvanzatoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrizioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn multiacquistoDataGridViewTextBoxColumn;
	}
}