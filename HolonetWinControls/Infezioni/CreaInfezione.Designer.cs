namespace HolonetWinControls.Infezioni
{
    partial class CreaInfezione
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
            this.label2 = new System.Windows.Forms.Label();
            this.lstInfezioni = new System.Windows.Forms.ListBox();
            this.txtDescrizioneSelezionato = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescrizioneNuovo = new System.Windows.Forms.TextBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
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
            this.label1.Size = new System.Drawing.Size(243, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Crea Nuova Infezione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Infezioni Esistenti:";
            // 
            // lstInfezioni
            // 
            this.lstInfezioni.DataSource = this.infezioneBindingSource;
            this.lstInfezioni.DisplayMember = "Nome";
            this.lstInfezioni.FormattingEnabled = true;
            this.lstInfezioni.ItemHeight = 16;
            this.lstInfezioni.Location = new System.Drawing.Point(18, 59);
            this.lstInfezioni.Margin = new System.Windows.Forms.Padding(4);
            this.lstInfezioni.Name = "lstInfezioni";
            this.lstInfezioni.Size = new System.Drawing.Size(255, 84);
            this.lstInfezioni.TabIndex = 9;
            this.lstInfezioni.ValueMember = "Progressivo";
            this.lstInfezioni.SelectedValueChanged += new System.EventHandler(this.lstInfezioni_SelectedValueChanged);
            // 
            // txtDescrizioneSelezionato
            // 
            this.txtDescrizioneSelezionato.Location = new System.Drawing.Point(18, 150);
            this.txtDescrizioneSelezionato.Multiline = true;
            this.txtDescrizioneSelezionato.Name = "txtDescrizioneSelezionato";
            this.txtDescrizioneSelezionato.ReadOnly = true;
            this.txtDescrizioneSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizioneSelezionato.Size = new System.Drawing.Size(255, 80);
            this.txtDescrizioneSelezionato.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 262);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nuova Infezione:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(18, 282);
            this.txtNome.MaxLength = 20;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(255, 22);
            this.txtNome.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 307);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Effetti:";
            // 
            // txtDescrizioneNuovo
            // 
            this.txtDescrizioneNuovo.Location = new System.Drawing.Point(18, 327);
            this.txtDescrizioneNuovo.Multiline = true;
            this.txtDescrizioneNuovo.Name = "txtDescrizioneNuovo";
            this.txtDescrizioneNuovo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizioneNuovo.Size = new System.Drawing.Size(255, 102);
            this.txtDescrizioneNuovo.TabIndex = 14;
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(18, 440);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(75, 23);
            this.btnSalva.TabIndex = 15;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Location = new System.Drawing.Point(198, 440);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 16;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // infezioneBindingSource
            // 
            this.infezioneBindingSource.DataSource = typeof(DataAccessLayer.Infezione);
            // 
            // CreaInfezione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 475);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.txtDescrizioneNuovo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescrizioneSelezionato);
            this.Controls.Add(this.lstInfezioni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreaInfezione";
            this.Text = "CreaInfezione";
            ((System.ComponentModel.ISupportInitialize)(this.infezioneBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstInfezioni;
        private System.Windows.Forms.TextBox txtDescrizioneSelezionato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescrizioneNuovo;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.BindingSource infezioneBindingSource;
    }
}