using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using HolonetWebControls;
using System.Text;
using CommonBusiness.Notizie;
using Holonet3.Utilities;

namespace Holonet3.Hacking
{
	public partial class HackedNews : HolonetPage, IHackablePage
	{
		protected long[] NewsCollection
		{
			get
			{
				if (ViewState["NewsCollection"] != null)
				{
					return (long[])ViewState["NewsCollection"];
				}
				return new long[0];
			}
			set
			{
				ViewState["NewsCollection"] = value;
			}
		}

        private int reteHack
        {
            get
            {
                object obj = Session["HackingRete"];
                if (obj != null)
                {
                    return (int)obj;
                }
                obj = Session["Rete"];
                if (obj != null)
                {
                    return (int)obj;
                }
                return 0;
            }
        }

		protected int PosizioneLettura
		{
			get
			{
				if (ViewState["PosizioneLettura"] != null)
				{
					return (int)ViewState["PosizioneLettura"];
				}
				return -1;
			}
			set
			{
				ViewState["PosizioneLettura"] = value;
			}
		}

		protected override void Page_PreInit(object sender, EventArgs e)
		{
			if (Session["TemaHacking"] != null)
			{
				Page.Theme = Session["TemaHacking"].ToString();
			}
			else
			{
				Page.Theme = "TemaBlu";
			}
		}

		private long livelloHacking
		{
			get
			{
				object obj = ViewState["LivelloHacking"];
				if (obj != null)
				{
					return (long)obj;
				}
				return 0;
			}
			set
			{
				ViewState["LivelloHacking"] = value;
			}
		}

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            //Il pezzo seguente è necessario per far funzionare jScrollPane con gli update panels
            StringBuilder str = new StringBuilder();
            str.Append(@"var myheight = $(window).height();");
            str.Append(@"myheight = (myheight * 70) / 100;");
            str.Append(@"myheight = parseInt(myheight);");
            str.Append(@"$('.scroll-pane').css('height', myheight + 'px');");
            str.Append(@"$('.scroll-pane').jScrollPane({ showArrows: true });");
            ScriptManager.RegisterStartupScript(Page, this.Page.GetType(), "testingloader", str.ToString(), true);
        }

		protected void Page_Load(object sender, EventArgs e)
		{
			((SiteMaster)this.Page.Master).FindControl("NavigationMenu").Visible = false;
			if (!IsPostBack)
			{
                pageViews.SetActiveView(viewNotizia);
				long accountInfranto = (long)Session["AccountInfranto"];

				var account = (from personaggio in DatabaseContext.Personaggios
								where personaggio.NumeroPG == accountInfranto
								select personaggio).First();

				lblNomeProprietario.Text = account.Nome;
				if (account.Hacker.HasValue && account.Hacker > 1)
				{
					livelloHacking = (long)account.Hacker;
				}
				else
				{
					livelloHacking = 1;
				}

				//caricamento notizie
                int numeroRete = reteHack;
                NotizieManager manager = new NotizieManager(DatabaseContext);
                var elencoNotizie = manager.GetActiveNewsIndexes(numeroRete, DateTime.Now);
				
				if (elencoNotizie.Count() > 0)
				{
					NewsCollection = elencoNotizie.ToArray();
					tblContent.Visible = true;
				}
				else
				{
					tblContent.Visible = false;
				}
				PosizioneLettura = 0;
				ShowNotizia();
			}
		}

		private void ShowNotizia()
		{
			if (PosizioneLettura >= NewsCollection.Length)
			{
				PosizioneLettura = NewsCollection.Length - 1;
			}
            if (PosizioneLettura < 0)
            {
                PosizioneLettura = 0;
            }
			if (PosizioneLettura < NewsCollection.Length)
			{

				long numNotizia = NewsCollection[PosizioneLettura];
				var notizia = (from notizie in DatabaseContext.Notizias
								where notizie.NumeroNotizia == numNotizia
								select notizie).First();
				var persAutore = (from personaggio in DatabaseContext.Personaggios
									where personaggio.NumeroPG == notizia.Autore
									select personaggio).First();
				lblAutore.Text = persAutore.Nome;
				lblDataNotizia.Text = notizia.DataCreazione.ToString();
				lblTitoloNotizia.Text = notizia.Titolo;
				lblTestoNotizia.Text = notizia.Testo;
				
			}
		}

		protected void btnPrecedente_Click(object sender, EventArgs e)
		{
			PosizioneLettura--;
			ShowNotizia();
		}

		protected void btnProssima_Click(object sender, EventArgs e)
		{
			PosizioneLettura++;
			ShowNotizia();
		}

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            NotizieManager manager = new NotizieManager(DatabaseContext);
            Notizia elementToEdit = manager.GetSingleNewsItem(NewsCollection[PosizioneLettura]);
            hackControl.LivelloHacking = elementToEdit.LivelloHacking;
            hackControl.IdentificatoreElemento = NewsCollection[PosizioneLettura];
            hackControl.Carica();
            pageViews.SetActiveView(viewHacking);
        }

        public bool Hacked
        {
            get
            {
                object obj = ViewState["Hacked"];
                if (obj != null)
                {
                    return (bool)obj;
                }
                return false;
            }
            set
            {
                ViewState["Hacked"] = value;
            }
        }

        public void OnHackedSuccess(long hackerAccount)
        {
            pageViews.SetActiveView(viewEditor);
            NotizieManager manager = new NotizieManager(DatabaseContext);
            Notizia elementToEdit = manager.GetSingleNewsItem(NewsCollection[PosizioneLettura]);
            txtOggetto.Text = elementToEdit.Titolo;
            txtTesto.Text = elementToEdit.Testo;
        }

        public void OnHackedFailure(long hackerAccount)
        {
            this.Hacked = false;
            pageViews.SetActiveView(viewNotizia);
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            PosizioneLettura = 0;
            pageViews.SetActiveView(viewNotizia);
            ShowNotizia();
        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            NotizieManager manager = new NotizieManager(DatabaseContext);
            Notizia elementToEdit = manager.GetSingleNewsItem(NewsCollection[PosizioneLettura]);
            manager.UpdateNews(elementToEdit.NumeroNotizia, txtOggetto.Text.Trim(), txtTesto.Text.Trim(), elementToEdit.DataCreazione, elementToEdit.DataFine, elementToEdit.Rete, elementToEdit.Autore.Value, elementToEdit.LivelloHacking);
            DatabaseContext.SaveChanges();
            pageViews.SetActiveView(viewNotizia);
            ShowNotizia();
        }
    }
}