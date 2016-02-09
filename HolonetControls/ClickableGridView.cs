using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace HolonetWebControls
{
     /// <summary> 
     /// GridView che consente di selezionare una riga al click 
     /// </summary> 
     public class ClickableGridView : GridView 
     {
        /// <summary>
        /// Classe CSS per le righe in stato non "hover"
        /// </summary>
        public string RowCssClass 
        { 
            get 
            { 
                string rowClass = (string)ViewState["rowClass"]; 
                if (!string.IsNullOrEmpty(rowClass)) 
                    return rowClass; 
                else 
                    return string.Empty; 
            } 
            set 
            { 
                ViewState["rowClass"] = value; 
            }
        } 
        /// <summary>
        /// Classe CSS per le righe in "hover"
        /// </summary>
        public string HoverRowCssClass 
        { 
            get 
            { 
                string hoverRowClass = (string)ViewState["hoverRowClass"]; 
                if (!string.IsNullOrEmpty(hoverRowClass)) 
                    return hoverRowClass; 
                else 
                    return string.Empty; 
            } 
            set 
            { 
                ViewState["hoverRowClass"] = value; 
            }
        } 

        private static readonly object RowClickedEventKey = new object(); 

        public event GridViewRowClicked RowClicked; 
        protected virtual void OnRowClicked(GridViewRowClickedEventArgs e) 
        { 
            if (RowClicked != null) 
                RowClicked(this, e); 
        } 

        protected override void RaisePostBackEvent(string eventArgument) 
        { 
            if (eventArgument.StartsWith("rc")) 
            { 
                int index = Int32.Parse(eventArgument.Substring(2)); 
                GridViewRowClickedEventArgs args = new GridViewRowClickedEventArgs(Rows[index]); 
                OnRowClicked(args); 
            } 
            else 
                base.RaisePostBackEvent(eventArgument); 
        } 

        protected override void PrepareControlHierarchy() 
        { 
            base.PrepareControlHierarchy(); 

            for (int i = 0; i < Rows.Count; i++) 
            { 
                string argsData = "rc" + Rows[i].RowIndex.ToString(); 
                Rows[i].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this, argsData)); 

                if (RowCssClass != string.Empty) 
                Rows[i].Attributes.Add("onmouseout", "this.className='" + RowCssClass + "';"); 

                if (HoverRowCssClass != string.Empty) 
                Rows[i].Attributes.Add("onmouseover", "this.className='" + HoverRowCssClass + "';"); 
            } 
        }
     } 

    /// <summary>
    /// Argomenti per l'evento del click sulla riga della GridView
    /// </summary>
    public class GridViewRowClickedEventArgs : EventArgs 
    { 
        private GridViewRow _row; 

        public GridViewRowClickedEventArgs(GridViewRow aRow)
           : base() 
        { 
           _row = aRow; 
        } 
        
        public GridViewRow Row 
        { 
            get { return _row; } 
        } 
    } 

     public delegate void GridViewRowClicked(object sender, GridViewRowClickedEventArgs args); 
}
