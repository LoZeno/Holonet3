namespace HolonetWinControls.Eventi
{
	partial class AggiungiElementoAEvento
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
			this.label2 = new System.Windows.Forms.Label();
			this.radItem = new System.Windows.Forms.RadioButton();
			this.radSubstance = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbTipo = new System.Windows.Forms.ComboBox();
			this.grdElementi = new System.Windows.Forms.DataGridView();
			this.newElementiBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnSalva = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.numCopie = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.grdElementi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.newElementiBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCopie)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(273, 24);
			this.label2.TabIndex = 13;
			this.label2.Text = "Seleziona un Oggetto/Sostanza";
			// 
			// radItem
			// 
			this.radItem.AutoSize = true;
			this.radItem.Checked = true;
			this.radItem.Location = new System.Drawing.Point(16, 37);
			this.radItem.Name = "radItem";
			this.radItem.Size = new System.Drawing.Size(59, 17);
			this.radItem.TabIndex = 14;
			this.radItem.TabStop = true;
			this.radItem.Text = "Oggetti";
			this.radItem.UseVisualStyleBackColor = true;
			this.radItem.CheckedChanged += new System.EventHandler(this.radItem_CheckedChanged);
			// 
			// radSubstance
			// 
			this.radSubstance.AutoSize = true;
			this.radSubstance.Location = new System.Drawing.Point(97, 37);
			this.radSubstance.Name = "radSubstance";
			this.radSubstance.Size = new System.Drawing.Size(69, 17);
			this.radSubstance.TabIndex = 15;
			this.radSubstance.TabStop = true;
			this.radSubstance.Text = "Sostanze";
			this.radSubstance.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Tipo:";
			// 
			// cmbTipo
			// 
			this.cmbTipo.FormattingEnabled = true;
			this.cmbTipo.Location = new System.Drawing.Point(53, 58);
			this.cmbTipo.Name = "cmbTipo";
			this.cmbTipo.Size = new System.Drawing.Size(548, 21);
			this.cmbTipo.TabIndex = 17;
			this.cmbTipo.SelectedValueChanged += new System.EventHandler(this.cmbTipo_SelectedValueChanged);
			// 
			// grdElementi
			// 
			this.grdElementi.AllowUserToAddRows = false;
			this.grdElementi.AllowUserToDeleteRows = false;
			this.grdElementi.AllowUserToOrderColumns = true;
			this.grdElementi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdElementi.Location = new System.Drawing.Point(12, 85);
			this.grdElementi.MultiSelect = false;
			this.grdElementi.Name = "grdElementi";
			this.grdElementi.ReadOnly = true;
			this.grdElementi.Size = new System.Drawing.Size(589, 300);
			this.grdElementi.TabIndex = 18;
			this.grdElementi.SelectionChanged += new System.EventHandler(this.grdElementi_SelectionChanged);
			// 
			// newElementiBindingSource
			// 
			this.newElementiBindingSource.DataSource = typeof(DataAccessLayer.NewElementi);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(500, 422);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(101, 23);
			this.btnAnnulla.TabIndex = 24;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// btnSalva
			// 
			this.btnSalva.Location = new System.Drawing.Point(12, 422);
			this.btnSalva.Name = "btnSalva";
			this.btnSalva.Size = new System.Drawing.Size(101, 23);
			this.btnSalva.TabIndex = 23;
			this.btnSalva.Text = "Salva";
			this.btnSalva.UseVisualStyleBackColor = true;
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(326, 393);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(148, 13);
			this.label3.TabIndex = 22;
			this.label3.Text = "Numero di copie da stampare:";
			// 
			// numCopie
			// 
			this.numCopie.Location = new System.Drawing.Point(480, 391);
			this.numCopie.Name = "numCopie";
			this.numCopie.Size = new System.Drawing.Size(120, 20);
			this.numCopie.TabIndex = 21;
			// 
			// AggiungiElementoAEvento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(613, 463);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnSalva);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numCopie);
			this.Controls.Add(this.grdElementi);
			this.Controls.Add(this.cmbTipo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.radSubstance);
			this.Controls.Add(this.radItem);
			this.Controls.Add(this.label2);
			this.Name = "AggiungiElementoAEvento";
			this.Text = "Oggetti e Sostanze";
			((System.ComponentModel.ISupportInitialize)(this.grdElementi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.newElementiBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCopie)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radItem;
		private System.Windows.Forms.RadioButton radSubstance;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbTipo;
		private System.Windows.Forms.DataGridView grdElementi;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numCopie;
		private System.Windows.Forms.BindingSource newElementiBindingSource;
	}
}