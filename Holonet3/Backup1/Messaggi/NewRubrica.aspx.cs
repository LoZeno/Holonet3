using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;
using DataAccessLayer;
using CommonBusiness.Rubrica;

namespace Holonet3.Messaggi
{
	public partial class NewRubrica : HolonetPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				txtNumero.Attributes.Add("onkeypress", "return isNumberKey(event)");
				if (LoggedCharacter != null)
				{
					carica();
				}
			}
		}

		private void carica()
		{
			txtNome.Text = string.Empty;
			txtNumero.Text = string.Empty;
			Personaggio currentCharacter = this.LoggedCharacter;
			RubricaManager namesManager = new RubricaManager(DatabaseContext);
			var myRubrica = namesManager.GetContactsByCharacter(currentCharacter.NumeroPG);
			grdPeople.DataSource = myRubrica;
			grdPeople.DataBind();
		}

		protected void grdPeople_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			//Occorre RICARICARE i dati, perché il DataSource non resta in memoria dopo il postback e NON voglio metterlo in ViewState!
			grdPeople.PageIndex = e.NewPageIndex;
			carica();
		}

		protected void btnElimina_Click(object sender, EventArgs e)
		{
			Personaggio currentCharacter = this.LoggedCharacter; //carico il personaggio
			RubricaManager namesManager = new RubricaManager(DatabaseContext); //e preparo il gestore della rubrica
			foreach (GridViewRow item in grdPeople.Rows)
			{
				if (item.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkSelected = (CheckBox)(item.Cells[2].FindControl("chkCol"));
					if (chkSelected != null)
					{
						if (chkSelected.Checked)
						{
							long rubricaId = long.Parse(item.Cells[0].Text);
							namesManager.DeleteContact(currentCharacter.NumeroPG, rubricaId);
						}
					}
				}
			}
			DatabaseContext.SaveChanges();
			carica();
		}

		protected void btnSalva_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txtNumero.Text) && !string.IsNullOrWhiteSpace(txtNome.Text))
			{
				Personaggio currentCharacter = this.LoggedCharacter;
				RubricaManager namesManager = new RubricaManager(DatabaseContext);
				long contactNumber = long.Parse(txtNumero.Text.Trim());
				namesManager.AddNewContact(currentCharacter.NumeroPG, contactNumber, txtNome.Text.Trim());
				DatabaseContext.SaveChanges();
			}
			carica();
		}
	}
}