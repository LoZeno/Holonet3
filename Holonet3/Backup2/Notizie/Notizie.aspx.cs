using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using HolonetWebControls;
using CommonBusiness.Notizie;
using CommonBusiness.Personaggi;
using System.Text;

namespace Holonet3.Notizie
{
	public partial class Notizie : HolonetPage
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

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			//Il pezzo seguente è necessario per far funzionare jScrollPane con gli update panels
			StringBuilder str = new StringBuilder();
			str.Append(@"var myheight = $('#tblContent').height();");
			str.Append(@"myheight = (myheight * 70) / 100;");
			str.Append(@"myheight = parseInt(myheight);");
			str.Append(@"$('.scroll-pane').css('height', myheight + 'px');");
			str.Append(@"$('.scroll-pane').jScrollPane({ showArrows: true });");
			ScriptManager.RegisterStartupScript(Page, this.Page.GetType(), "testingloader", str.ToString(), true);

			str = new StringBuilder();
			str.Append(@"debugger;");
			str.Append(@"var myheight = $('#headerNews').height();");
			str.Append(@"myheight = (myheight * 80) / 100;");
			str.Append(@"myheight = parseInt(myheight);");
			str.Append(@"$('#facePicture').css('height', myheight + 'px');");
			ScriptManager.RegisterStartupScript(Page, this.Page.GetType(), "resizepicture", str.ToString(), true);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Rete"] != null)
			{
				

				if (!IsPostBack)
				{
                    this.Page.Header.Title = "NOTIZIE";
					int numeroRete = int.Parse(Session["Rete"].ToString());

					NotizieManager manager = new NotizieManager(DatabaseContext);

					//var elencoNotizie = (from notizie in DatabaseContext.Notizias
					//                        where notizie.Rete == numeroRete
					//                        where notizie.DataFine >= DateTime.Today
					//                        where notizie.DataCreazione <= DateTime.Today
					//                        orderby notizie.DataCreazione
					//                        select notizie.NumeroNotizia).Distinct();
					DateTime dataOdierna = DateTime.Now;
					var elencoNotizie = manager.GetActiveNewsIndexes(numeroRete, dataOdierna);

					PosizioneLettura = 0;
                    if (elencoNotizie.Count() > 0)
                    {
                        NewsCollection = elencoNotizie.ToArray();
						panelNotizie.Visible = true;
						ShowNotizia();                        }
                    else
                    {
						panelNotizie.Visible = false;
                    }
					
				}
			}
		}

		private void ShowNotizia()
		{
			if (PosizioneLettura < 0)
			{
				PosizioneLettura = 0;
			}
			if (PosizioneLettura >= NewsCollection.Length)
			{
				PosizioneLettura = NewsCollection.Length -1;
			}
			if (PosizioneLettura < NewsCollection.Length)
			{
				long numNotizia = NewsCollection[PosizioneLettura];
				NotizieManager newsManager = new NotizieManager(DatabaseContext);
				PersonaggiManagerNew characterManager = new PersonaggiManagerNew(DatabaseContext);
				//var notizia = (from notizie in DatabaseContext.Notizias
				//                where notizie.NumeroNotizia == numNotizia
				//                select notizie).First();
				Notizia notizia = newsManager.GetSingleNewsItem(numNotizia);
				//var persAutore = (from personaggio in DatabaseContext.Personaggios
				//                    where personaggio.NumeroPG == notizia.Autore
				//                    select personaggio).First();
				Personaggio persAutore = characterManager.GetCharacterByNumber(notizia.Autore.Value);
				lblAutore.Text = persAutore.Nome;
				lblDataNotizia.Text = notizia.DataCreazione.ToString();
				lblTitoloNotizia.Text = notizia.Titolo;
				lblTestoNotizia.Text = notizia.Testo;

				//Ora imposto un'immagine di cronista a caso
				Random randomizer = new Random();
				int immagineCronista = randomizer.Next(1, 33);
				facePicture.ImageUrl = "~/Images/Volti/" + immagineCronista.ToString() + ".jpg";
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
	}
}