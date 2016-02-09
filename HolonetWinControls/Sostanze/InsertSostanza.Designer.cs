namespace HolonetWinControls.Sostanze
{
	partial class InsertSostanza
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
			this.cmbTipo = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.lblCloneWarning = new System.Windows.Forms.Label();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnSalva = new System.Windows.Forms.Button();
			this.mstxEfficacia = new System.Windows.Forms.MaskedTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.calScadenza = new System.Windows.Forms.MonthCalendar();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbDisponibilita = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.mstxCosto = new System.Windows.Forms.MaskedTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtEffetto = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbModoUso = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// cmbTipo
			// 
			this.cmbTipo.FormattingEnabled = true;
			this.cmbTipo.Location = new System.Drawing.Point(423, 294);
			this.cmbTipo.Name = "cmbTipo";
			this.cmbTipo.Size = new System.Drawing.Size(199, 21);
			this.cmbTipo.TabIndex = 55;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(321, 297);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(31, 13);
			this.label9.TabIndex = 54;
			this.label9.Text = "Tipo:";
			// 
			// lblCloneWarning
			// 
			this.lblCloneWarning.AutoSize = true;
			this.lblCloneWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCloneWarning.ForeColor = System.Drawing.Color.Red;
			this.lblCloneWarning.Location = new System.Drawing.Point(15, 55);
			this.lblCloneWarning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCloneWarning.Name = "lblCloneWarning";
			this.lblCloneWarning.Size = new System.Drawing.Size(414, 13);
			this.lblCloneWarning.TabIndex = 53;
			this.lblCloneWarning.Text = "Modifica ciò che va cambiato rispetto all\'oggetto originale e premi salva";
			this.lblCloneWarning.Visible = false;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(114, 422);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(80, 23);
			this.btnAnnulla.TabIndex = 52;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// btnSalva
			// 
			this.btnSalva.Location = new System.Drawing.Point(15, 422);
			this.btnSalva.Name = "btnSalva";
			this.btnSalva.Size = new System.Drawing.Size(92, 23);
			this.btnSalva.TabIndex = 51;
			this.btnSalva.Text = "Salva Sostanza";
			this.btnSalva.UseVisualStyleBackColor = true;
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			// 
			// mstxEfficacia
			// 
			this.mstxEfficacia.Location = new System.Drawing.Point(423, 270);
			this.mstxEfficacia.Mask = "990";
			this.mstxEfficacia.Name = "mstxEfficacia";
			this.mstxEfficacia.Size = new System.Drawing.Size(199, 20);
			this.mstxEfficacia.TabIndex = 50;
			this.mstxEfficacia.Text = "1";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(318, 273);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(94, 13);
			this.label8.TabIndex = 49;
			this.label8.Text = "Valore di efficacia:";
			// 
			// calScadenza
			// 
			this.calScadenza.Location = new System.Drawing.Point(423, 95);
			this.calScadenza.Name = "calScadenza";
			this.calScadenza.TabIndex = 48;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(318, 95);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(93, 13);
			this.label7.TabIndex = 47;
			this.label7.Text = "Data di scadenza:";
			// 
			// cmbDisponibilita
			// 
			this.cmbDisponibilita.FormattingEnabled = true;
			this.cmbDisponibilita.Location = new System.Drawing.Point(113, 377);
			this.cmbDisponibilita.Name = "cmbDisponibilita";
			this.cmbDisponibilita.Size = new System.Drawing.Size(199, 21);
			this.cmbDisponibilita.TabIndex = 46;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 380);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 13);
			this.label6.TabIndex = 45;
			this.label6.Text = "Disponibilità:";
			// 
			// mstxCosto
			// 
			this.mstxCosto.Location = new System.Drawing.Point(113, 346);
			this.mstxCosto.Mask = "999999999";
			this.mstxCosto.Name = "mstxCosto";
			this.mstxCosto.Size = new System.Drawing.Size(199, 20);
			this.mstxCosto.TabIndex = 44;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 349);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(37, 13);
			this.label5.TabIndex = 43;
			this.label5.Text = "Costo:";
			// 
			// txtEffetto
			// 
			this.txtEffetto.Location = new System.Drawing.Point(113, 241);
			this.txtEffetto.Multiline = true;
			this.txtEffetto.Name = "txtEffetto";
			this.txtEffetto.Size = new System.Drawing.Size(199, 99);
			this.txtEffetto.TabIndex = 42;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 241);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 41;
			this.label4.Text = "Effetto:";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(113, 123);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(199, 99);
			this.txtDescrizione.TabIndex = 40;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 123);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 39;
			this.label3.Text = "Descrizione:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 13);
			this.label2.TabIndex = 38;
			this.label2.Text = "Nome della sost.:";
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(113, 95);
			this.txtNome.MaxLength = 30;
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(199, 20);
			this.txtNome.TabIndex = 37;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(11, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(195, 24);
			this.label1.TabIndex = 36;
			this.label1.Text = "Inserisci Dati Sostanza";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(318, 327);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 13);
			this.label10.TabIndex = 56;
			this.label10.Text = "Modo d\'uso:";
			// 
			// cmbModoUso
			// 
			this.cmbModoUso.FormattingEnabled = true;
			this.cmbModoUso.Location = new System.Drawing.Point(423, 324);
			this.cmbModoUso.Name = "cmbModoUso";
			this.cmbModoUso.Size = new System.Drawing.Size(199, 21);
			this.cmbModoUso.TabIndex = 57;
			// 
			// InsertSostanza
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 464);
			this.Controls.Add(this.cmbModoUso);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.cmbTipo);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.lblCloneWarning);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnSalva);
			this.Controls.Add(this.mstxEfficacia);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.calScadenza);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cmbDisponibilita);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.mstxCosto);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtEffetto);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtNome);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "InsertSostanza";
			this.Text = "InsertSostanza";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbTipo;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblCloneWarning;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.MaskedTextBox mstxEfficacia;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.MonthCalendar calScadenza;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmbDisponibilita;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.MaskedTextBox mstxCosto;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtEffetto;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cmbModoUso;
	}
}