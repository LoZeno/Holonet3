namespace HolonetWinControls.Eventi
{
	partial class AggiungiDiscoAEvento
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
			this.grdHoloDisk = new System.Windows.Forms.DataGridView();
			this.Progressivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Contenuto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.holoDiskBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.numCopie = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSalva = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.lnkPrevious = new System.Windows.Forms.LinkLabel();
			this.lnkNext = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.grdHoloDisk)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.holoDiskBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCopie)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(246, 24);
			this.label2.TabIndex = 12;
			this.label2.Text = "Seleziona un Disco/Datapad";
			// 
			// grdHoloDisk
			// 
			this.grdHoloDisk.AllowUserToAddRows = false;
			this.grdHoloDisk.AllowUserToDeleteRows = false;
			this.grdHoloDisk.AllowUserToOrderColumns = true;
			this.grdHoloDisk.AutoGenerateColumns = false;
			this.grdHoloDisk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdHoloDisk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Progressivo,
            this.Contenuto});
			this.grdHoloDisk.DataSource = this.holoDiskBindingSource;
			this.grdHoloDisk.Location = new System.Drawing.Point(13, 37);
			this.grdHoloDisk.MultiSelect = false;
			this.grdHoloDisk.Name = "grdHoloDisk";
			this.grdHoloDisk.ReadOnly = true;
			this.grdHoloDisk.Size = new System.Drawing.Size(340, 198);
			this.grdHoloDisk.TabIndex = 13;
			this.grdHoloDisk.SelectionChanged += new System.EventHandler(this.grdHoloDisk_SelectionChanged);
			// 
			// Progressivo
			// 
			this.Progressivo.DataPropertyName = "Progressivo";
			this.Progressivo.HeaderText = "Progressivo";
			this.Progressivo.Name = "Progressivo";
			this.Progressivo.ReadOnly = true;
			// 
			// Contenuto
			// 
			this.Contenuto.DataPropertyName = "Contenuto";
			this.Contenuto.HeaderText = "Contenuto";
			this.Contenuto.Name = "Contenuto";
			this.Contenuto.ReadOnly = true;
			this.Contenuto.Width = 200;
			// 
			// holoDiskBindingSource
			// 
			this.holoDiskBindingSource.DataSource = typeof(DataAccessLayer.HoloDisk);
			// 
			// numCopie
			// 
			this.numCopie.Location = new System.Drawing.Point(233, 279);
			this.numCopie.Name = "numCopie";
			this.numCopie.Size = new System.Drawing.Size(120, 20);
			this.numCopie.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 281);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Numero di copie da stampare:";
			// 
			// btnSalva
			// 
			this.btnSalva.Location = new System.Drawing.Point(14, 310);
			this.btnSalva.Name = "btnSalva";
			this.btnSalva.Size = new System.Drawing.Size(101, 23);
			this.btnSalva.TabIndex = 16;
			this.btnSalva.Text = "Salva";
			this.btnSalva.UseVisualStyleBackColor = true;
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(253, 310);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(101, 23);
			this.btnAnnulla.TabIndex = 17;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// lnkPrevious
			// 
			this.lnkPrevious.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lnkPrevious.AutoSize = true;
			this.lnkPrevious.Location = new System.Drawing.Point(215, 238);
			this.lnkPrevious.Name = "lnkPrevious";
			this.lnkPrevious.Size = new System.Drawing.Size(73, 13);
			this.lnkPrevious.TabIndex = 18;
			this.lnkPrevious.TabStop = true;
			this.lnkPrevious.Text = "Precedenti 50";
			this.lnkPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrevious_LinkClicked);
			// 
			// lnkNext
			// 
			this.lnkNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lnkNext.AutoSize = true;
			this.lnkNext.Location = new System.Drawing.Point(294, 238);
			this.lnkNext.Name = "lnkNext";
			this.lnkNext.Size = new System.Drawing.Size(60, 13);
			this.lnkNext.TabIndex = 19;
			this.lnkNext.TabStop = true;
			this.lnkNext.Text = "Prossimi 50";
			this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
			// 
			// AggiungiDiscoAEvento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(365, 343);
			this.Controls.Add(this.lnkNext);
			this.Controls.Add(this.lnkPrevious);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnSalva);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numCopie);
			this.Controls.Add(this.grdHoloDisk);
			this.Controls.Add(this.label2);
			this.Name = "AggiungiDiscoAEvento";
			this.Text = "Holodischi e Datapad";
			((System.ComponentModel.ISupportInitialize)(this.grdHoloDisk)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.holoDiskBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCopie)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView grdHoloDisk;
		private System.Windows.Forms.BindingSource holoDiskBindingSource;
		private System.Windows.Forms.NumericUpDown numCopie;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.LinkLabel lnkPrevious;
		private System.Windows.Forms.LinkLabel lnkNext;
		private System.Windows.Forms.DataGridViewTextBoxColumn Progressivo;
		private System.Windows.Forms.DataGridViewTextBoxColumn Contenuto;

	}
}