using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Holonet3.Utilities;
using DataAccessLayer;
using HolonetWebControls;
using CommonBusiness.Personaggi;
using System.Text;
using CommonBusiness.Rete;
using CommonBusiness.Notizie;

namespace Holonet3.Informatica
{
	public partial class Informatica : HolonetPage, ICryptable, IHackablePage
	{
		private int protectionLevel
		{
			get
			{
				object obj = ViewState["protectionLevel"];
				if (obj != null)
				{
					return (int)obj;
				}
				return 0;
			}
			set
			{
				ViewState["protectionLevel"] = value;
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

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnEncrypt.Click += new EventHandler(btnEncrypt_Click);
            btnHack.Click += new EventHandler(btnHack_Click);
            btnPublish.Click += new EventHandler(btnPublish_Click);

            cmbRete.SelectedIndexChanged += new EventHandler(cmbRete_SelectedIndexChanged);
        }

        void cmbRete_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageViews.SetActiveView(viewRemoto);
        }

        void btnPublish_Click(object sender, EventArgs e)
        {
            svuotaPubblicazione();
            PageViews.SetActiveView(viewNotizie);
        }

        private void svuotaPubblicazione()
        {
            txtOggetto.Text = string.Empty;
            txtTesto.Text = string.Empty;
            calScadenza.SelectedDate = DateTime.Today.AddDays(1);
        }

        void btnHack_Click(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
            Hacked = false;
            hackControl.Carica();
            PageViews.SetActiveView(viewHackRete);
        }

        void btnEncrypt_Click(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
            PageViews.SetActiveView(viewCrypt);
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            if (LoggedCharacter != null)
            {
                PersonaggiManagerNew manager = new PersonaggiManagerNew(DatabaseContext);
                Personaggio currentCharacter = manager.GetCharacterByNumber(LoggedCharacter.NumeroPG);
                lblNomeProprietario.Text = currentCharacter.Titolo + " " + currentCharacter.Nome;
                int protection = currentCharacter.LivelloProtezione;
                lblLevel.Text = protection.ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
			if (!IsPostBack)
			{
                PageViews.SetActiveView(viewEmpty);
                ReteManager networkManager = new ReteManager(DatabaseContext);
                cmbRete.DataValueField = "Key";
                cmbRete.DataTextField = "Value";
                cmbRete.DataSource = networkManager.GetNetworksForCombo();
                cmbRete.DataBind();
#if !DEBUG
                PersonaggiManagerNew manager = new PersonaggiManagerNew(DatabaseContext);

                if (!manager.HasSkill(LoggedCharacter.NumeroPG, 177))
                {
                    btnPublish.Visible = false;
                }
                if (!manager.HasSkill(LoggedCharacter.NumeroPG, 9) && !manager.HasSkill(LoggedCharacter.NumeroPG, 122))
                {
                    btnHack.Visible = false;
                }
#endif
            }
		}

		#region ICryptable Members

		public void OnCrypting(long crypterLevel)
		{
			if (LoggedCharacter != null)
			{
				using (HolonetEntities context = new HolonetEntities())
				{
#warning dovrei salvarmi il codice per ricaricare il personaggio dal context, invece di ricaricarlo dalla sessione. Aggiustare!
					Personaggio loadedCharacter = (Personaggio)Session["Personaggio"];

					Personaggio currentCharacter = (from characters in context.Personaggios
										where characters.NumeroPG == loadedCharacter.NumeroPG
										select characters).First();

					if (crypterLevel >= currentCharacter.LivelloCrittazione)
					{
						currentCharacter.LivelloCrittazione = crypterLevel;
						currentCharacter.UltimaCrittazione = DateTime.Now;
						context.SaveChanges();
					}
					//int protection = 0;
					//if (currentCharacter.Hacker.HasValue)
					//{
					//    protection += (int)currentCharacter.Hacker;
					//}
					//protection += (int)currentCharacter.LivelloCrittazione;
					//lblLevel.Text = protection.ToString();
					lblLevel.Text = currentCharacter.Protezione.ToString();
				}
                Page_Load(this, new EventArgs());
			}
		}

		public void OnDecryptSuccess(long crypterAccount)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region ICryptable Members

		public long Crypted
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		#endregion

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
            int reteScelta = int.Parse(cmbRete.SelectedValue);
            Session["HackingRete"] = reteScelta;
            switch (reteScelta)
            {
                case 0:
                    Session["TemaHacking"] = "TemaBlu";
                    break;
                case 1:
                    Session["TemaHacking"] = "TemaRosso";
                    break;
                case 2:
                    Session["TemaHacking"] = "TemaVerde";
                    break;
                case 3:
                    Session["TemaHacking"] = "TemaGiallo";
                    break;
                default:
                    break;
            }
            
            frameHack.Attributes["src"] = ResolveUrl("~/Hacking/NewHackedNetwork.aspx");
            PageViews.SetActiveView(viewRemoto);
        }

        public void OnHackedFailure(long hackerAccount)
        {
            hackControl.Carica();
            PageViews.SetActiveView(viewHackRete);
        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            NotizieManager manager = new NotizieManager(DatabaseContext);
            manager.SendNews(txtOggetto.Text.Trim(), txtTesto.Text.Trim(), DateTime.Now, calScadenza.SelectedDate, Rete, LoggedCharacter.NumeroPG, LoggedCharacter.LivelloCrittazione);
            DatabaseContext.SaveChanges();
            lblSuccess.Visible = true;
            PageViews.SetActiveView(viewEmpty);
        }
    }
}