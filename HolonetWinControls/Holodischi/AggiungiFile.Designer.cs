namespace HolonetWinControls.Holodischi
{
	partial class AggiungiFile
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
			this.numCrypt = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.txtContenuto = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNomeFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numCrypt)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(292, 327);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 19;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// btnSalva
			// 
			this.btnSalva.Location = new System.Drawing.Point(17, 327);
			this.btnSalva.Name = "btnSalva";
			this.btnSalva.Size = new System.Drawing.Size(75, 23);
			this.btnSalva.TabIndex = 18;
			this.btnSalva.Text = "Salva";
			this.btnSalva.UseVisualStyleBackColor = true;
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			// 
			// numCrypt
			// 
			this.numCrypt.Location = new System.Drawing.Point(124, 292);
			this.numCrypt.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numCrypt.Name = "numCrypt";
			this.numCrypt.Size = new System.Drawing.Size(55, 20);
			this.numCrypt.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 294);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(105, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Livello di criptazione:";
			// 
			// txtContenuto
			// 
			this.txtContenuto.Location = new System.Drawing.Point(16, 133);
			this.txtContenuto.Multiline = true;
			this.txtContenuto.Name = "txtContenuto";
			this.txtContenuto.Size = new System.Drawing.Size(353, 153);
			this.txtContenuto.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 117);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Contenuto del File:";
			// 
			// txtNomeFile
			// 
			this.txtNomeFile.Location = new System.Drawing.Point(16, 67);
			this.txtNomeFile.Name = "txtNomeFile";
			this.txtNomeFile.Size = new System.Drawing.Size(353, 20);
			this.txtNomeFile.TabIndex = 13;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Nome del file:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 24);
			this.label1.TabIndex = 11;
			this.label1.Text = "Inserisci File";
			// 
			// AggiungiFile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(381, 370);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnSalva);
			this.Controls.Add(this.numCrypt);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtContenuto);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtNomeFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AggiungiFile";
			this.Text = "AggiungiFile";
			((System.ComponentModel.ISupportInitialize)(this.numCrypt)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.NumericUpDown numCrypt;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtContenuto;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNomeFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}