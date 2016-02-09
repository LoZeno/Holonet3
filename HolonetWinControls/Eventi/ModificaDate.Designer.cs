namespace HolonetWinControls.Eventi
{
	partial class ModificaDate
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
            this.txtNomeEvento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grdGiorni = new System.Windows.Forms.DataGridView();
            this.CodiceEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGiorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntiAssegnatiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoGiornoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventoGiorniBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.mstxPunti = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtOraFg = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtOraInGioco = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnCancella = new System.Windows.Forms.Button();
            this.txtCosto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdGiorni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventoGiorniBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 2;
            // 
            // txtNomeEvento
            // 
            this.txtNomeEvento.Location = new System.Drawing.Point(129, 55);
            this.txtNomeEvento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNomeEvento.Name = "txtNomeEvento";
            this.txtNomeEvento.ReadOnly = true;
            this.txtNomeEvento.Size = new System.Drawing.Size(375, 22);
            this.txtNomeEvento.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Evento:";
            // 
            // grdGiorni
            // 
            this.grdGiorni.AllowUserToAddRows = false;
            this.grdGiorni.AllowUserToDeleteRows = false;
            this.grdGiorni.AllowUserToOrderColumns = true;
            this.grdGiorni.AutoGenerateColumns = false;
            this.grdGiorni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGiorni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodiceEvento,
            this.DataGiorno,
            this.puntiAssegnatiDataGridViewTextBoxColumn,
            this.costoGiornoDataGridViewTextBoxColumn});
            this.grdGiorni.DataSource = this.eventoGiorniBindingSource;
            this.grdGiorni.Location = new System.Drawing.Point(21, 87);
            this.grdGiorni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdGiorni.MultiSelect = false;
            this.grdGiorni.Name = "grdGiorni";
            this.grdGiorni.ReadOnly = true;
            this.grdGiorni.Size = new System.Drawing.Size(485, 176);
            this.grdGiorni.TabIndex = 9;
            this.grdGiorni.SelectionChanged += new System.EventHandler(this.grdGiorni_SelectionChanged);
            // 
            // CodiceEvento
            // 
            this.CodiceEvento.DataPropertyName = "CdEvento";
            this.CodiceEvento.HeaderText = "CdEvento";
            this.CodiceEvento.Name = "CodiceEvento";
            this.CodiceEvento.ReadOnly = true;
            this.CodiceEvento.Visible = false;
            // 
            // DataGiorno
            // 
            this.DataGiorno.DataPropertyName = "DataGiorno";
            this.DataGiorno.HeaderText = "Giorno";
            this.DataGiorno.Name = "DataGiorno";
            this.DataGiorno.ReadOnly = true;
            // 
            // puntiAssegnatiDataGridViewTextBoxColumn
            // 
            this.puntiAssegnatiDataGridViewTextBoxColumn.DataPropertyName = "PuntiAssegnati";
            this.puntiAssegnatiDataGridViewTextBoxColumn.HeaderText = "Punti";
            this.puntiAssegnatiDataGridViewTextBoxColumn.Name = "puntiAssegnatiDataGridViewTextBoxColumn";
            this.puntiAssegnatiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoGiornoDataGridViewTextBoxColumn
            // 
            this.costoGiornoDataGridViewTextBoxColumn.DataPropertyName = "CostoGiorno";
            this.costoGiornoDataGridViewTextBoxColumn.HeaderText = "Costo";
            this.costoGiornoDataGridViewTextBoxColumn.Name = "costoGiornoDataGridViewTextBoxColumn";
            this.costoGiornoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eventoGiorniBindingSource
            // 
            this.eventoGiorniBindingSource.DataSource = typeof(DataAccessLayer.EventoGiorni);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Modifica date evento";
            // 
            // mstxPunti
            // 
            this.mstxPunti.Location = new System.Drawing.Point(107, 274);
            this.mstxPunti.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mstxPunti.Mask = "99999";
            this.mstxPunti.Name = "mstxPunti";
            this.mstxPunti.Size = new System.Drawing.Size(281, 22);
            this.mstxPunti.TabIndex = 25;
            this.mstxPunti.ValidatingType = typeof(int);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 278);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 17);
            this.label11.TabIndex = 24;
            this.label11.Text = "PX:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 346);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "FuoriGioco:";
            // 
            // dtOraFg
            // 
            this.dtOraFg.CustomFormat = "HH:mm";
            this.dtOraFg.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtOraFg.Location = new System.Drawing.Point(107, 338);
            this.dtOraFg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtOraFg.Name = "dtOraFg";
            this.dtOraFg.ShowUpDown = true;
            this.dtOraFg.Size = new System.Drawing.Size(301, 22);
            this.dtOraFg.TabIndex = 28;
            this.dtOraFg.Value = new System.DateTime(2012, 9, 26, 2, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 314);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "InGioco:";
            // 
            // dtOraInGioco
            // 
            this.dtOraInGioco.CustomFormat = "HH:mm";
            this.dtOraInGioco.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtOraInGioco.Location = new System.Drawing.Point(107, 306);
            this.dtOraInGioco.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtOraInGioco.Name = "dtOraInGioco";
            this.dtOraInGioco.ShowUpDown = true;
            this.dtOraInGioco.Size = new System.Drawing.Size(301, 22);
            this.dtOraInGioco.TabIndex = 26;
            this.dtOraInGioco.Value = new System.DateTime(2012, 9, 26, 10, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 374);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 17);
            this.label10.TabIndex = 30;
            this.label10.Text = "Costo:";
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(21, 410);
            this.btnSalva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(137, 28);
            this.btnSalva.TabIndex = 32;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Location = new System.Drawing.Point(368, 410);
            this.btnAnnulla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(137, 28);
            this.btnAnnulla.TabIndex = 33;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnCancella
            // 
            this.btnCancella.Location = new System.Drawing.Point(192, 410);
            this.btnCancella.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancella.Name = "btnCancella";
            this.btnCancella.Size = new System.Drawing.Size(137, 28);
            this.btnCancella.TabIndex = 34;
            this.btnCancella.Text = "Elimina Giorno";
            this.btnCancella.UseVisualStyleBackColor = true;
            this.btnCancella.Click += new System.EventHandler(this.btnCancella_Click);
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(107, 374);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(301, 22);
            this.txtCosto.TabIndex = 35;
            // 
            // ModificaDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 464);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.btnCancella);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtOraFg);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtOraInGioco);
            this.Controls.Add(this.mstxPunti);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdGiorni);
            this.Controls.Add(this.txtNomeEvento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ModificaDate";
            this.Text = "ModificaDate";
            ((System.ComponentModel.ISupportInitialize)(this.grdGiorni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventoGiorniBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNomeEvento;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView grdGiorni;
		private System.Windows.Forms.BindingSource eventoGiorniBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn CodiceEvento;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataGiorno;
		private System.Windows.Forms.DataGridViewTextBoxColumn puntiAssegnatiDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn costoGiornoDataGridViewTextBoxColumn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MaskedTextBox mstxPunti;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker dtOraFg;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtOraInGioco;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnCancella;
        private System.Windows.Forms.TextBox txtCosto;
	}
}