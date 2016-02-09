using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HolonetManager.BaseClasses;
using DataAccessLayer;
using CommonBusiness.OggettiManager;
using CommonBusiness.Sostanze;

namespace HolonetManager
{
    public partial class MainForm : BaseManagerForm
    {
        public MainForm()
        {
            InitializeComponent();
            try
            {
                LoadTabControl();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n \r\n Inner Exception: " + error.InnerException);
            }

        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LoadTabControl()
        {
            foreach (var control in tabContainer.SelectedTab.Controls)
            {
                if (control is BaseManagerUserControl)
                {
                    ((BaseManagerUserControl)control).LoadData();
                }
            }
        }

        private void tabContainer_Selected(object sender, TabControlEventArgs e)
        {
            LoadTabControl();
        }
    }
}
