namespace HolonetWinControls.Personaggi
{
	partial class InsertSpecie
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
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnSalva = new System.Windows.Forms.Button();
			this.txtNuovaSpecie = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lstSpecie = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(132, 340);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 15;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// btnSalva
			// 
			this.btnSalva.Location = new System.Drawing.Point(12, 340);
			this.btnSalva.Name = "btnSalva";
			this.btnSalva.Size = new System.Drawing.Size(75, 23);
			this.btnSalva.TabIndex = 14;
			this.btnSalva.Text = "Salva";
			this.btnSalva.UseVisualStyleBackColor = true;
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			// 
			// txtNuovaSpecie
			// 
			this.txtNuovaSpecie.Location = new System.Drawing.Point(12, 221);
			this.txtNuovaSpecie.MaxLength = 60;
			this.txtNuovaSpecie.Name = "txtNuovaSpecie";
			this.txtNuovaSpecie.Size = new System.Drawing.Size(195, 20);
			this.txtNuovaSpecie.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 205);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Nuova specie:";
			// 
			// lstSpecie
			// 
			this.lstSpecie.FormattingEnabled = true;
			this.lstSpecie.Location = new System.Drawing.Point(15, 71);
			this.lstSpecie.Name = "lstSpecie";
			this.lstSpecie.Size = new System.Drawing.Size(192, 121);
			this.lstSpecie.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Specie Esistenti:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 24);
			this.label1.TabIndex = 9;
			this.label1.Text = "Nuova Specie";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(12, 261);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(195, 73);
			this.txtDescrizione.TabIndex = 16;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 245);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(95, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Descrizione breve:";
			// 
			// InsertSpecie
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(224, 375);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnSalva);
			this.Controls.Add(this.txtNuovaSpecie);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lstSpecie);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "InsertSpecie";
			this.Text = "InsertSpecie";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.TextBox txtNuovaSpecie;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lstSpecie;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label4;
	}
}