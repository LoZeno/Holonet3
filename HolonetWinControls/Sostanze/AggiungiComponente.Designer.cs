namespace HolonetWinControls.Sostanze
{
	partial class AggiungiComponente
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
            this.lstComponenti = new System.Windows.Forms.ListBox();
            this.txtEffetto = new System.Windows.Forms.TextBox();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoSostanza = new System.Windows.Forms.ComboBox();
            this.tipoSostanzeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tipoSostanzeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lstComponenti
            // 
            this.lstComponenti.FormattingEnabled = true;
            this.lstComponenti.ItemHeight = 16;
            this.lstComponenti.Location = new System.Drawing.Point(12, 72);
            this.lstComponenti.Margin = new System.Windows.Forms.Padding(4);
            this.lstComponenti.Name = "lstComponenti";
            this.lstComponenti.Size = new System.Drawing.Size(271, 196);
            this.lstComponenti.TabIndex = 9;
            this.lstComponenti.SelectedValueChanged += new System.EventHandler(this.lstComponenti_SelectedValueChanged);
            // 
            // txtEffetto
            // 
            this.txtEffetto.Location = new System.Drawing.Point(12, 284);
            this.txtEffetto.Margin = new System.Windows.Forms.Padding(4);
            this.txtEffetto.Multiline = true;
            this.txtEffetto.Name = "txtEffetto";
            this.txtEffetto.ReadOnly = true;
            this.txtEffetto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEffetto.Size = new System.Drawing.Size(271, 63);
            this.txtEffetto.TabIndex = 8;
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(12, 355);
            this.btnAggiungi.Margin = new System.Windows.Forms.Padding(4);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(272, 28);
            this.btnAggiungi.TabIndex = 7;
            this.btnAggiungi.Text = "Aggiungi alla lista";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seleziona Componente";
            // 
            // cmbTipoSostanza
            // 
            this.cmbTipoSostanza.DataSource = this.tipoSostanzeBindingSource;
            this.cmbTipoSostanza.DisplayMember = "Descrizione";
            this.cmbTipoSostanza.FormattingEnabled = true;
            this.cmbTipoSostanza.Location = new System.Drawing.Point(75, 36);
            this.cmbTipoSostanza.Name = "cmbTipoSostanza";
            this.cmbTipoSostanza.Size = new System.Drawing.Size(209, 24);
            this.cmbTipoSostanza.TabIndex = 11;
            this.cmbTipoSostanza.ValueMember = "Progressivo";
            this.cmbTipoSostanza.SelectedValueChanged += new System.EventHandler(this.cmbTipoSostanza_SelectedValueChanged);
            // 
            // tipoSostanzeBindingSource
            // 
            this.tipoSostanzeBindingSource.DataSource = typeof(DataAccessLayer.TipoSostanze);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tipo:";
            // 
            // AggiungiComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 395);
            this.Controls.Add(this.cmbTipoSostanza);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstComponenti);
            this.Controls.Add(this.txtEffetto);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AggiungiComponente";
            this.Text = "AggiungiComponente";
            ((System.ComponentModel.ISupportInitialize)(this.tipoSostanzeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lstComponenti;
		private System.Windows.Forms.TextBox txtEffetto;
		private System.Windows.Forms.Button btnAggiungi;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoSostanza;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource tipoSostanzeBindingSource;
	}
}