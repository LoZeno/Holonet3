using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HolonetManager.BaseClasses;

namespace HolonetWinControls.BaseClasses
{
    public class ToolboxManagerForm : BaseManagerForm
    {
        public ToolboxManagerForm()
            : base()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        }
    }
}
