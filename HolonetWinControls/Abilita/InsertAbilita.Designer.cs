namespace HolonetWinControls.Abilita
{
	partial class InsertAbilita
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMultiAcquisto = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mstxCosto = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkAvanzato = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inserisci Abilita";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Location = new System.Drawing.Point(205, 379);
            this.btnAnnulla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(107, 28);
            this.btnAnnulla.TabIndex = 42;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(16, 379);
            this.btnSalva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(113, 28);
            this.btnSalva.TabIndex = 41;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(105, 91);
            this.txtDescr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescr.Size = new System.Drawing.Size(205, 178);
            this.txtDescr.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "Descrizione:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(105, 59);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(205, 22);
            this.txtNome.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Nome:";
            // 
            // chkMultiAcquisto
            // 
            this.chkMultiAcquisto.AutoSize = true;
            this.chkMultiAcquisto.Location = new System.Drawing.Point(105, 278);
            this.chkMultiAcquisto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMultiAcquisto.Name = "chkMultiAcquisto";
            this.chkMultiAcquisto.Size = new System.Drawing.Size(18, 17);
            this.chkMultiAcquisto.TabIndex = 43;
            this.chkMultiAcquisto.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 278);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 44;
            this.label2.Text = "Multiacqui.";
            // 
            // mstxCosto
            // 
            this.mstxCosto.Location = new System.Drawing.Point(105, 303);
            this.mstxCosto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mstxCosto.Mask = "999";
            this.mstxCosto.Name = "mstxCosto";
            this.mstxCosto.Size = new System.Drawing.Size(205, 22);
            this.mstxCosto.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 306);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "Costo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 335);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 48;
            this.label6.Text = "Avanzata:";
            // 
            // chkAvanzato
            // 
            this.chkAvanzato.AutoSize = true;
            this.chkAvanzato.Location = new System.Drawing.Point(105, 335);
            this.chkAvanzato.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAvanzato.Name = "chkAvanzato";
            this.chkAvanzato.Size = new System.Drawing.Size(18, 17);
            this.chkAvanzato.TabIndex = 47;
            this.chkAvanzato.UseVisualStyleBackColor = true;
            // 
            // InsertAbilita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 434);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkAvanzato);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mstxCosto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkMultiAcquisto);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "InsertAbilita";
            this.Text = "InsertAbilita";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.TextBox txtDescr;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkMultiAcquisto;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MaskedTextBox mstxCosto;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkAvanzato;
	}
}