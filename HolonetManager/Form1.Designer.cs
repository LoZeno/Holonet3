namespace HolonetManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tabPersonaggi = new System.Windows.Forms.TabPage();
            this.controlPersonaggi1 = new HolonetWinControls.Personaggi.ControlPersonaggi();
            this.tbAbilita = new System.Windows.Forms.TabPage();
            this.controlAbilita1 = new HolonetWinControls.Abilita.ControlAbilita();
            this.tabEventi = new System.Windows.Forms.TabPage();
            this.controlEventi1 = new HolonetManager.Eventi.ControlEventi();
            this.tabMessaggi = new System.Windows.Forms.TabPage();
            this.controlMessaggi1 = new HolonetWinControls.Messaggi.ControlMessaggi();
            this.tabNotizie = new System.Windows.Forms.TabPage();
            this.controlNotizie1 = new HolonetWinControls.Notizie.ControlNotizie();
            this.tbOggetti = new System.Windows.Forms.TabPage();
            this.controlOggetti1 = new HolonetWinControls.Oggetti.ControlOggetti();
            this.tbSostanze = new System.Windows.Forms.TabPage();
            this.controlSostanze1 = new HolonetWinControls.Sostanze.ControlSostanze();
            this.tabHolodischi = new System.Windows.Forms.TabPage();
            this.controlHolodischi1 = new HolonetWinControls.Holodischi.ControlHolodischi();
            this.tabInfezioni = new System.Windows.Forms.TabPage();
            this.controlInfezioni1 = new HolonetWinControls.Infezioni.ControlInfezioni();
            this.tabPrintManager = new System.Windows.Forms.TabPage();
            this.controlStampeEventi1 = new HolonetWinControls.Eventi.ControlStampeEventi();
            this.menuStrip1.SuspendLayout();
            this.tabContainer.SuspendLayout();
            this.tabPersonaggi.SuspendLayout();
            this.tbAbilita.SuspendLayout();
            this.tabEventi.SuspendLayout();
            this.tabMessaggi.SuspendLayout();
            this.tabNotizie.SuspendLayout();
            this.tbOggetti.SuspendLayout();
            this.tbSostanze.SuspendLayout();
            this.tabHolodischi.SuspendLayout();
            this.tabInfezioni.SuspendLayout();
            this.tabPrintManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1045, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // tabContainer
            // 
            this.tabContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabContainer.Controls.Add(this.tabPersonaggi);
            this.tabContainer.Controls.Add(this.tbAbilita);
            this.tabContainer.Controls.Add(this.tabEventi);
            this.tabContainer.Controls.Add(this.tabMessaggi);
            this.tabContainer.Controls.Add(this.tabNotizie);
            this.tabContainer.Controls.Add(this.tbOggetti);
            this.tabContainer.Controls.Add(this.tbSostanze);
            this.tabContainer.Controls.Add(this.tabHolodischi);
            this.tabContainer.Controls.Add(this.tabInfezioni);
            this.tabContainer.Controls.Add(this.tabPrintManager);
            this.tabContainer.Location = new System.Drawing.Point(0, 32);
            this.tabContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(1044, 650);
            this.tabContainer.TabIndex = 1;
            this.tabContainer.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabContainer_Selected);
            // 
            // tabPersonaggi
            // 
            this.tabPersonaggi.Controls.Add(this.controlPersonaggi1);
            this.tabPersonaggi.Location = new System.Drawing.Point(4, 25);
            this.tabPersonaggi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPersonaggi.Name = "tabPersonaggi";
            this.tabPersonaggi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPersonaggi.Size = new System.Drawing.Size(1036, 621);
            this.tabPersonaggi.TabIndex = 0;
            this.tabPersonaggi.Text = "Giocatori & Personaggi";
            this.tabPersonaggi.UseVisualStyleBackColor = true;
            // 
            // controlPersonaggi1
            // 
            this.controlPersonaggi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPersonaggi1.Location = new System.Drawing.Point(3, 2);
            this.controlPersonaggi1.Margin = new System.Windows.Forms.Padding(5);
            this.controlPersonaggi1.Name = "controlPersonaggi1";
            this.controlPersonaggi1.Size = new System.Drawing.Size(1030, 617);
            this.controlPersonaggi1.TabIndex = 0;
            // 
            // tbAbilita
            // 
            this.tbAbilita.Controls.Add(this.controlAbilita1);
            this.tbAbilita.Location = new System.Drawing.Point(4, 25);
            this.tbAbilita.Margin = new System.Windows.Forms.Padding(4);
            this.tbAbilita.Name = "tbAbilita";
            this.tbAbilita.Padding = new System.Windows.Forms.Padding(4);
            this.tbAbilita.Size = new System.Drawing.Size(1036, 621);
            this.tbAbilita.TabIndex = 3;
            this.tbAbilita.Text = "Liste & Abilità";
            this.tbAbilita.UseVisualStyleBackColor = true;
            // 
            // controlAbilita1
            // 
            this.controlAbilita1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlAbilita1.Location = new System.Drawing.Point(4, 4);
            this.controlAbilita1.Margin = new System.Windows.Forms.Padding(5);
            this.controlAbilita1.Name = "controlAbilita1";
            this.controlAbilita1.Size = new System.Drawing.Size(1028, 613);
            this.controlAbilita1.TabIndex = 0;
            // 
            // tabEventi
            // 
            this.tabEventi.Controls.Add(this.controlEventi1);
            this.tabEventi.Location = new System.Drawing.Point(4, 25);
            this.tabEventi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabEventi.Name = "tabEventi";
            this.tabEventi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabEventi.Size = new System.Drawing.Size(1036, 621);
            this.tabEventi.TabIndex = 2;
            this.tabEventi.Text = "Eventi";
            this.tabEventi.UseVisualStyleBackColor = true;
            // 
            // controlEventi1
            // 
            this.controlEventi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlEventi1.Location = new System.Drawing.Point(3, 2);
            this.controlEventi1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.controlEventi1.Name = "controlEventi1";
            this.controlEventi1.Size = new System.Drawing.Size(1030, 617);
            this.controlEventi1.TabIndex = 0;
            // 
            // tabMessaggi
            // 
            this.tabMessaggi.Controls.Add(this.controlMessaggi1);
            this.tabMessaggi.Location = new System.Drawing.Point(4, 25);
            this.tabMessaggi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMessaggi.Name = "tabMessaggi";
            this.tabMessaggi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMessaggi.Size = new System.Drawing.Size(1036, 621);
            this.tabMessaggi.TabIndex = 1;
            this.tabMessaggi.Text = "Messaggi";
            this.tabMessaggi.UseVisualStyleBackColor = true;
            // 
            // controlMessaggi1
            // 
            this.controlMessaggi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlMessaggi1.Location = new System.Drawing.Point(3, 2);
            this.controlMessaggi1.Margin = new System.Windows.Forms.Padding(5);
            this.controlMessaggi1.Name = "controlMessaggi1";
            this.controlMessaggi1.Size = new System.Drawing.Size(1030, 617);
            this.controlMessaggi1.TabIndex = 0;
            // 
            // tabNotizie
            // 
            this.tabNotizie.Controls.Add(this.controlNotizie1);
            this.tabNotizie.Location = new System.Drawing.Point(4, 25);
            this.tabNotizie.Margin = new System.Windows.Forms.Padding(4);
            this.tabNotizie.Name = "tabNotizie";
            this.tabNotizie.Padding = new System.Windows.Forms.Padding(4);
            this.tabNotizie.Size = new System.Drawing.Size(1036, 621);
            this.tabNotizie.TabIndex = 7;
            this.tabNotizie.Text = "Notizie";
            this.tabNotizie.UseVisualStyleBackColor = true;
            // 
            // controlNotizie1
            // 
            this.controlNotizie1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlNotizie1.Location = new System.Drawing.Point(4, 4);
            this.controlNotizie1.Margin = new System.Windows.Forms.Padding(5);
            this.controlNotizie1.Name = "controlNotizie1";
            this.controlNotizie1.Size = new System.Drawing.Size(1028, 613);
            this.controlNotizie1.TabIndex = 0;
            // 
            // tbOggetti
            // 
            this.tbOggetti.Controls.Add(this.controlOggetti1);
            this.tbOggetti.Location = new System.Drawing.Point(4, 25);
            this.tbOggetti.Margin = new System.Windows.Forms.Padding(4);
            this.tbOggetti.Name = "tbOggetti";
            this.tbOggetti.Padding = new System.Windows.Forms.Padding(4);
            this.tbOggetti.Size = new System.Drawing.Size(1036, 621);
            this.tbOggetti.TabIndex = 4;
            this.tbOggetti.Text = "Oggetti & Componenti";
            this.tbOggetti.UseVisualStyleBackColor = true;
            // 
            // controlOggetti1
            // 
            this.controlOggetti1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlOggetti1.Location = new System.Drawing.Point(4, 4);
            this.controlOggetti1.Margin = new System.Windows.Forms.Padding(5);
            this.controlOggetti1.Name = "controlOggetti1";
            this.controlOggetti1.Size = new System.Drawing.Size(1028, 613);
            this.controlOggetti1.TabIndex = 0;
            // 
            // tbSostanze
            // 
            this.tbSostanze.Controls.Add(this.controlSostanze1);
            this.tbSostanze.Location = new System.Drawing.Point(4, 25);
            this.tbSostanze.Margin = new System.Windows.Forms.Padding(4);
            this.tbSostanze.Name = "tbSostanze";
            this.tbSostanze.Padding = new System.Windows.Forms.Padding(4);
            this.tbSostanze.Size = new System.Drawing.Size(1036, 621);
            this.tbSostanze.TabIndex = 5;
            this.tbSostanze.Text = "Sostanze & Ingredienti";
            this.tbSostanze.UseVisualStyleBackColor = true;
            // 
            // controlSostanze1
            // 
            this.controlSostanze1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlSostanze1.Location = new System.Drawing.Point(4, 4);
            this.controlSostanze1.Margin = new System.Windows.Forms.Padding(5);
            this.controlSostanze1.Name = "controlSostanze1";
            this.controlSostanze1.Size = new System.Drawing.Size(1028, 613);
            this.controlSostanze1.TabIndex = 0;
            // 
            // tabHolodischi
            // 
            this.tabHolodischi.Controls.Add(this.controlHolodischi1);
            this.tabHolodischi.Location = new System.Drawing.Point(4, 25);
            this.tabHolodischi.Margin = new System.Windows.Forms.Padding(4);
            this.tabHolodischi.Name = "tabHolodischi";
            this.tabHolodischi.Padding = new System.Windows.Forms.Padding(4);
            this.tabHolodischi.Size = new System.Drawing.Size(1036, 621);
            this.tabHolodischi.TabIndex = 6;
            this.tabHolodischi.Text = "DataPad & Holodisk";
            this.tabHolodischi.UseVisualStyleBackColor = true;
            // 
            // controlHolodischi1
            // 
            this.controlHolodischi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlHolodischi1.Location = new System.Drawing.Point(4, 4);
            this.controlHolodischi1.Margin = new System.Windows.Forms.Padding(5);
            this.controlHolodischi1.Name = "controlHolodischi1";
            this.controlHolodischi1.Size = new System.Drawing.Size(1028, 613);
            this.controlHolodischi1.TabIndex = 0;
            // 
            // tabInfezioni
            // 
            this.tabInfezioni.Controls.Add(this.controlInfezioni1);
            this.tabInfezioni.Location = new System.Drawing.Point(4, 25);
            this.tabInfezioni.Name = "tabInfezioni";
            this.tabInfezioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfezioni.Size = new System.Drawing.Size(1036, 621);
            this.tabInfezioni.TabIndex = 8;
            this.tabInfezioni.Text = "Infezioni";
            this.tabInfezioni.UseVisualStyleBackColor = true;
            // 
            // controlInfezioni1
            // 
            this.controlInfezioni1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlInfezioni1.Location = new System.Drawing.Point(3, 3);
            this.controlInfezioni1.Name = "controlInfezioni1";
            this.controlInfezioni1.Size = new System.Drawing.Size(1030, 615);
            this.controlInfezioni1.TabIndex = 0;
            // 
            // tabPrintManager
            // 
            this.tabPrintManager.Controls.Add(this.controlStampeEventi1);
            this.tabPrintManager.Location = new System.Drawing.Point(4, 25);
            this.tabPrintManager.Name = "tabPrintManager";
            this.tabPrintManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrintManager.Size = new System.Drawing.Size(1036, 621);
            this.tabPrintManager.TabIndex = 9;
            this.tabPrintManager.Text = "Gestione Stampe Eventi";
            this.tabPrintManager.UseVisualStyleBackColor = true;
            // 
            // controlStampeEventi1
            // 
            this.controlStampeEventi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlStampeEventi1.Location = new System.Drawing.Point(3, 3);
            this.controlStampeEventi1.Name = "controlStampeEventi1";
            this.controlStampeEventi1.Size = new System.Drawing.Size(1030, 615);
            this.controlStampeEventi1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 692);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(898, 593);
            this.Name = "MainForm";
            this.Text = "Gestione Holonet";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabContainer.ResumeLayout(false);
            this.tabPersonaggi.ResumeLayout(false);
            this.tbAbilita.ResumeLayout(false);
            this.tabEventi.ResumeLayout(false);
            this.tabMessaggi.ResumeLayout(false);
            this.tabNotizie.ResumeLayout(false);
            this.tbOggetti.ResumeLayout(false);
            this.tbSostanze.ResumeLayout(false);
            this.tabHolodischi.ResumeLayout(false);
            this.tabInfezioni.ResumeLayout(false);
            this.tabPrintManager.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tabPersonaggi;
        private System.Windows.Forms.TabPage tabMessaggi;
		private System.Windows.Forms.TabPage tabEventi;
		private Eventi.ControlEventi controlEventi1;
		private System.Windows.Forms.TabPage tbAbilita;
		private System.Windows.Forms.TabPage tbOggetti;
		private HolonetWinControls.Personaggi.ControlPersonaggi controlPersonaggi1;
		private HolonetWinControls.Oggetti.ControlOggetti controlOggetti1;
		private System.Windows.Forms.TabPage tbSostanze;
		private HolonetWinControls.Sostanze.ControlSostanze controlSostanze1;
        private System.Windows.Forms.TabPage tabHolodischi;
		private HolonetWinControls.Abilita.ControlAbilita controlAbilita1;
		private HolonetWinControls.Holodischi.ControlHolodischi controlHolodischi1;
		private HolonetWinControls.Messaggi.ControlMessaggi controlMessaggi1;
		private System.Windows.Forms.TabPage tabNotizie;
		private HolonetWinControls.Notizie.ControlNotizie controlNotizie1;
        private System.Windows.Forms.TabPage tabInfezioni;
        private HolonetWinControls.Infezioni.ControlInfezioni controlInfezioni1;
        private System.Windows.Forms.TabPage tabPrintManager;
        private HolonetWinControls.Eventi.ControlStampeEventi controlStampeEventi1;
    }
}

