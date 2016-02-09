using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using HolonetWebControls;
using Holonet3.Utilities;

namespace Holonet3.CartellaPersonale
{
    public partial class FilePersonali : HolonetPage, Holonet3.CartellaPersonale.IFilePersonali, ICryptable
    {
        public MessaggioSalvato FileDaMostrare
        {
            get
            {
                object obj = ViewState["FileDaMostrare"];
                if (obj != null)
                {
                    return (MessaggioSalvato)obj;
                }
                return null;
            }
            set
            {
                ViewState["FileDaMostrare"] = value;
            }
        }

		//protected void Page_PreInit(object sender, EventArgs e)
		//{
		//    if (Session["Tema"] != null)
		//    {
		//        Page.Theme = Session["Tema"].ToString();
		//    }
		//    else
		//    {
		//        Page.Theme = "TemaBlu";
		//    }
		//}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LoggedCharacter != null)
                {
                    CaricaElencoFiles();
                }
            }
        }

        protected void CaricaElencoFiles()
        {
            panWriteFile.Visible = false;
            panelShowFile.Visible = false;
            Personaggio character = (Personaggio)Session["Personaggio"];
            List<MessaggioSalvato> elenco;
            using (HolonetEntities context = new HolonetEntities())
            {
                var filesSalvati = (from elements in context.MessaggioSalvatoes
                                    where elements.NumeroPG == character.NumeroPG
                                    select elements).OrderByDescending(elm => elm.Progressivo);
                
                elenco = filesSalvati.ToList();
            }
			listaFiles.refCharacter = character;
            listaFiles.Visible = true;
            listaFiles.Files = elenco;
            listaFiles.Carica();
        }

        protected void btnCrea_Click(object sender, EventArgs e)
        {
            listaFiles.Visible = false;
            panelShowFile.Visible = false;
            panWriteFile.Visible = true;
            txtOggetto.Text = string.Empty;
            txtTesto.Text = string.Empty;
        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            Personaggio character = (Personaggio)Session["Personaggio"];
            using (HolonetEntities context = new HolonetEntities())
            {
                MessaggioSalvato message = new MessaggioSalvato();
                message.NumeroPG = character.NumeroPG;
				message.LivelloCrittazione = Crypted;
                message.Contenuto = txtTesto.Text.Replace("\n", "<br/>");
                message.Provenienza = "SAVEDFILE";
                message.Titolo = txtOggetto.Text.Trim();
                context.AddToMessaggioSalvatoes(message);
                context.SaveChanges();
            }
            panWriteFile.Visible = false;
			Crypted = 0;
            CaricaElencoFiles();
        }

        public void MostraFile()
        {
            if (FileDaMostrare != null)
            {
                panelShowFile.Visible = true;
                lblTitolo.Text = FileDaMostrare.Titolo;
                lblTesto.Text = FileDaMostrare.Contenuto;
            }
        }

		#region ICryptable Members

		public long Crypted
		{
			get
			{
				object obj = ViewState["Crypted"];
				if (obj != null)
				{
					return (long)obj;
				}
				return 0;
			}
			set
			{
				ViewState["Crypted"] = value;
			}
		}

		public void OnCrypting(long crypterLevel)
		{
			Crypted = crypterLevel;
		}

		public void OnDecryptSuccess(long crypterAccount)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}