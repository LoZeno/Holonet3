namespace HolonetWinControls.Holodischi
{
	partial class CreaDatapad
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
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.txtContenuto = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numHacking = new System.Windows.Forms.NumericUpDown();
			this.btnSalva = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numHacking)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(219, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Inserisci Dati del Datapad";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(250, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Nome del datapad (COMPARE SUL CARTELLINO)";
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(16, 67);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(353, 20);
			this.txtCodice.TabIndex = 4;
			// 
			// txtContenuto
			// 
			this.txtContenuto.Location = new System.Drawing.Point(16, 133);
			this.txtContenuto.Multiline = true;
			this.txtContenuto.Name = "txtContenuto";
			this.txtContenuto.Size = new System.Drawing.Size(353, 45);
			this.txtContenuto.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 117);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(354, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Contenuto del datapad (una sintesi, NON COMPARE SUL CARTELLINO)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 199);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Livello di Hacking:";
			// 
			// numHacking
			// 
			this.numHacking.Location = new System.Drawing.Point(112, 197);
			this.numHacking.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numHacking.Name = "numHacking";
			this.numHacking.Size = new System.Drawing.Size(55, 20);
			this.numHacking.TabIndex = 8;
			// 
			// btnSalva
			// 
			this.btnSalva.Location = new System.Drawing.Point(16, 232);
			this.btnSalva.Name = "btnSalva";
			this.btnSalva.Size = new System.Drawing.Size(75, 23);
			this.btnSalva.TabIndex = 9;
			this.btnSalva.Text = "Salva";
			this.btnSalva.UseVisualStyleBackColor = true;
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(291, 232);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 10;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// CreaDatapad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(391, 271);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnSalva);
			this.Controls.Add(this.numHacking);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtContenuto);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtCodice);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CreaDatapad";
			this.Text = "CreaDatapad";
			((System.ComponentModel.ISupportInitialize)(this.numHacking)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.TextBox txtContenuto;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numHacking;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.Button btnAnnulla;
	}
}