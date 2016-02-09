namespace HolonetWinControls.Infezioni
{
    partial class AggiungiInfezione
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstInfezioni = new System.Windows.Forms.ListBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.infezioneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.infezioneBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Seleziona Infezione";
            // 
            // lstInfezioni
            // 
            this.lstInfezioni.DataSource = this.infezioneBindingSource;
            this.lstInfezioni.DisplayMember = "Nome";
            this.lstInfezioni.FormattingEnabled = true;
            this.lstInfezioni.ItemHeight = 16;
            this.lstInfezioni.Location = new System.Drawing.Point(18, 42);
            this.lstInfezioni.Margin = new System.Windows.Forms.Padding(4);
            this.lstInfezioni.Name = "lstInfezioni";
            this.lstInfezioni.Size = new System.Drawing.Size(271, 164);
            this.lstInfezioni.TabIndex = 10;
            this.lstInfezioni.ValueMember = "Progressivo";
            this.lstInfezioni.SelectedValueChanged += new System.EventHandler(this.lstInfezioni_SelectedValueChanged);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(18, 214);
            this.txtDescrizione.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(271, 86);
            this.txtDescrizione.TabIndex = 11;
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(18, 312);
            this.btnAggiungi.Margin = new System.Windows.Forms.Padding(4);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(271, 28);
            this.btnAggiungi.TabIndex = 12;
            this.btnAggiungi.Text = "Aggiungi Infezione";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // infezioneBindingSource
            // 
            this.infezioneBindingSource.DataSource = typeof(DataAccessLayer.Infezione);
            // 
            // AggiungiInfezione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 353);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.lstInfezioni);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AggiungiInfezione";
            this.Text = "AggiungiInfezione";
            ((System.ComponentModel.ISupportInitialize)(this.infezioneBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstInfezioni;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.BindingSource infezioneBindingSource;
    }
}