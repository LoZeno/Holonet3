using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;
using DataAccessLayer;

namespace Holonet3.LaboratorioTecnico
{
    public partial class CreazioneOggetti : HolonetPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LoggedCharacter != null)
                {
                    Personaggio character = (Personaggio)Session["Personaggio"];
                    IQueryable<AbilitaPersonaggio> ricerca;
                    int CanUse = 0;
                    using (HolonetEntities context = new HolonetEntities())
                    {
                        ricerca = (from abilita in context.AbilitaPersonaggios
                                   where abilita.NumeroPG == character.NumeroPG
                                   where abilita.CdAbilita == 13
                                   select abilita);
                        CanUse = ricerca.Count();
                    }
                    if (CanUse <= 0)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        Timer1.Interval = 60000;
                    }
                }
            }
        }

        protected void btnIdentifica(object sender, EventArgs e)
        {
            Timer1.Interval = 60000;
            Timer1.Enabled = true;
            lblRisultato.Text = "Attendere: Assemblaggio in corso...";
        }

        public void SvuotaControlli()
        {
            lblRisultato.Text = string.Empty;
            txtCodice1.Text = string.Empty;
            txtCodice2.Text = string.Empty;
            txtCodice3.Text = string.Empty;
            txtCodice4.Text = string.Empty;
            txtCodice5.Text = string.Empty;
            txtCodice6.Text = string.Empty;
            txtCodice7.Text = string.Empty;
        }

        protected void TimerTick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;

            string codice = txtCodice1.Text.Trim();
            Costruzione progettoDaVerificare = null;
            Oggetti oggetto;

            using (HolonetEntities context = new HolonetEntities())
            {
                var componenti = (from objects in context.Oggettis
                                where objects.CodiceOggetto == codice
                                select objects);
                if (componenti.Count() > 0)
                {
                    oggetto = componenti.First();
                    long progressivoComponente = oggetto.Progressivo;

                    var progetti = (from projects in context.Costruziones
                                   where projects.ProgressivoMateriale == progressivoComponente
                                   select projects);
                    //Secondo Ingrediente
                    codice = txtCodice2.Text.Trim();
                    componenti = (from objects in context.Oggettis
                                  where objects.CodiceOggetto == codice
                                  select objects);

                    if (componenti.Count() > 0)
                    {
                        oggetto = componenti.First();
                        List<Costruzione> progettiValidi = new List<Costruzione>();
                        foreach (var possibileProgetto in progetti)
                        {
                            var esiste = (from projects in context.Costruziones
                                          where projects.ProgressivoOggetto == possibileProgetto.ProgressivoOggetto
                                          where projects.ProgressivoMateriale == oggetto.Progressivo
                                          select projects).Count();
                            if (esiste > 0)
                            {
                                progettiValidi.Add(possibileProgetto);
                            }
                        }
                        if (progettiValidi.Count == 1)
                        {
                            progettoDaVerificare = progettiValidi[0];
                        }
                        else if (progettiValidi.Count > 1)
                        {
                            //Terzo Ingrediente
                            codice = txtCodice3.Text.Trim();
                            componenti = (from objects in context.Oggettis
                                        where objects.CodiceOggetto == codice
                                        select objects);
                            List<Costruzione> progettiValidi2 = new List<Costruzione>();
                            if (componenti.Count() > 0)
                            {
                                oggetto = componenti.First();

                                foreach (var possibileProgetto in progettiValidi)
                                {
                                    var esiste = (from projects in context.Costruziones
                                                  where projects.ProgressivoOggetto == possibileProgetto.ProgressivoOggetto
                                                  where projects.ProgressivoMateriale == oggetto.Progressivo
                                                  select projects).Count();
                                    if (esiste > 0)
                                    {
                                        progettiValidi2.Add(possibileProgetto);
                                    }
                                }
                            }
                            if (progettiValidi2.Count == 1)
                            {
                                progettoDaVerificare = progettiValidi2[0];
                            }
                            else if (progettiValidi2.Count > 1)
                            {
                                //quarto ingrediente
                                codice = txtCodice4.Text.Trim();
                                List<Costruzione> progettiValidi3 = new List<Costruzione>();
                                componenti = (from objects in context.Oggettis
                                              where objects.CodiceOggetto == codice
                                              select objects);
                                if (componenti.Count() > 0)
                                {
                                    oggetto = componenti.First();
                                    foreach (var possibileProgetto in progettiValidi)
                                    {
                                        var esiste = (from projects in context.Costruziones
                                                      where projects.ProgressivoOggetto == possibileProgetto.ProgressivoOggetto
                                                      where projects.ProgressivoMateriale == oggetto.Progressivo
                                                      select projects).Count();
                                        if (esiste > 0)
                                        {
                                            progettiValidi3.Add(possibileProgetto);
                                        }
                                    }
                                    if (progettiValidi3.Count == 1)
                                    {
                                        progettoDaVerificare = progettiValidi3[0];
                                    }
                                    else if (progettiValidi3.Count > 1)
                                    {
                                        //quinto ingrediente
                                        codice = txtCodice5.Text.Trim();
                                        List<Costruzione> progettiValidi4 = new List<Costruzione>();
                                        componenti = (from objects in context.Oggettis
                                                      where objects.CodiceOggetto == codice
                                                      select objects);
                                        if (componenti.Count() > 0)
                                        {
                                            oggetto = componenti.First();
                                            foreach (var possibileProgetto in progettiValidi3)
                                            {
                                                var esiste = (from projects in context.Costruziones
                                                              where projects.ProgressivoOggetto == possibileProgetto.ProgressivoOggetto
                                                              where projects.ProgressivoMateriale == oggetto.Progressivo
                                                              select projects).Count();
                                                if (esiste > 0)
                                                {
                                                    progettiValidi4.Add(possibileProgetto);
                                                }
                                            }
                                            if (progettiValidi4.Count == 1)
                                            {
                                                progettoDaVerificare = progettiValidi4[0];
                                            }
                                            else if (progettiValidi4.Count > 1)
                                            {
                                                //sesto ingrediente
                                                codice = txtCodice6.Text.Trim();
                                                List<Costruzione> progettiValidi5 = new List<Costruzione>();
                                                componenti = (from objects in context.Oggettis
                                                              where objects.CodiceOggetto == codice
                                                              select objects);
                                                if (componenti.Count() > 0)
                                                {
                                                    oggetto = componenti.First();
                                                    foreach (var possibileProgetto in progettiValidi3)
                                                    {
                                                        var esiste = (from projects in context.Costruziones
                                                                      where projects.ProgressivoOggetto == possibileProgetto.ProgressivoOggetto
                                                                      where projects.ProgressivoMateriale == oggetto.Progressivo
                                                                      select projects).Count();
                                                        if (esiste > 0)
                                                        {
                                                            progettiValidi5.Add(possibileProgetto);
                                                        }
                                                    }
                                                    if (progettiValidi5.Count == 1)
                                                    {
                                                        progettoDaVerificare = progettiValidi5[0];
                                                    }
                                                    else if (progettiValidi5.Count > 1)
                                                    {
                                                        //settimo ingrediente
                                                        codice = txtCodice6.Text.Trim();
                                                        List<Costruzione> progettiValidi6 = new List<Costruzione>();
                                                        componenti = (from objects in context.Oggettis
                                                                      where objects.CodiceOggetto == codice
                                                                      select objects);
                                                        if (componenti.Count() > 0)
                                                        {
                                                            oggetto = componenti.First();
                                                            foreach (var possibileProgetto in progettiValidi3)
                                                            {
                                                                var esiste = (from projects in context.Costruziones
                                                                              where projects.ProgressivoOggetto == possibileProgetto.ProgressivoOggetto
                                                                              where projects.ProgressivoMateriale == oggetto.Progressivo
                                                                              select projects).Count();
                                                                if (esiste > 0)
                                                                {
                                                                    progettiValidi6.Add(possibileProgetto);
                                                                }
                                                            }
                                                            if (progettiValidi6.Count > 0)
                                                            {
                                                                progettoDaVerificare = progettiValidi6[0];
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (progettoDaVerificare == null)
                {
                    lblRisultato.Text = "Non è stato trovato un sistema per assemblare gli oggetti presentati";
                }
                else
                {
                    bool assemblato = true;
                    oggetto = (from objects in context.Oggettis
                               where objects.Progressivo == progettoDaVerificare.ProgressivoOggetto
                               select objects).First();
                    if (!oggetto.Costruziones_1.IsLoaded)
                    {
                        oggetto.Costruziones_1.Load();
                    }
                    //verifico che gli ingredienti ci siano tutti
                    IEnumerable<Costruzione> elencoComponenti = oggetto.Costruziones_1.AsEnumerable();
                    long?[] codiciComponenti = new long?[elencoComponenti.Count()];
                    int i = 0;
                    foreach (var item in elencoComponenti)
                    {
                        codiciComponenti[i] = item.ProgressivoMateriale;
                        i++;
                    }
                    if (codiciComponenti.Length == 7)
                    {
                        if (string.IsNullOrEmpty(txtCodice7.Text.Trim()))
                        {
                            assemblato = false;
                        }
                        else
                        {
                            var componente7 = (from component in context.Oggettis
                                               where component.CodiceOggetto == txtCodice7.Text.Trim()
                                               select component).First();
                            if (!codiciComponenti.Contains(componente7.Progressivo))
                            {
                                assemblato = false;
                            }
                        }
                    }
                    if (codiciComponenti.Length >= 6 && assemblato)
                    {
                        if (string.IsNullOrEmpty(txtCodice6.Text.Trim()))
                        {
                            assemblato = false;
                        }
                        else
                        {
                            var componente6 = (from component in context.Oggettis
                                               where component.CodiceOggetto == txtCodice6.Text.Trim()
                                               select component).First();
                            if (!codiciComponenti.Contains(componente6.Progressivo))
                            {
                                assemblato = false;
                            }
                        }
                    }
                    if (codiciComponenti.Length >= 5 && assemblato)
                    {
                        if (string.IsNullOrEmpty(txtCodice5.Text.Trim()))
                        {
                            assemblato = false;
                        }
                        else
                        {
                            var componente5 = (from component in context.Oggettis
                                                where component.CodiceOggetto == txtCodice5.Text.Trim()
                                                select component).First();
                            if (!codiciComponenti.Contains(componente5.Progressivo))
                            {
                                assemblato = false;
                            }
                        }
                    }
                    if (codiciComponenti.Length >= 4 && assemblato)
                    {
                        if (string.IsNullOrWhiteSpace(txtCodice4.Text.Trim()))
                        {
                            assemblato = false;
                        }
                        else
                        {
                            var componente4 = (from component in context.Oggettis
                                               where component.CodiceOggetto == txtCodice4.Text.Trim()
                                               select component).First();
                            if (!codiciComponenti.Contains(componente4.Progressivo))
                            {
                                assemblato = false;
                            }
                        }
                    }
                    if (codiciComponenti.Length >= 3 && assemblato)
                    {
                        if (string.IsNullOrWhiteSpace(txtCodice3.Text.Trim()))
                        {
                            assemblato = false;
                        }
                        else
                        {
                            var componente3 = (from component in context.Oggettis
                                               where component.CodiceOggetto == txtCodice3.Text.Trim()
                                               select component).First();
                            if (!codiciComponenti.Contains(componente3.Progressivo))
                            {
                                assemblato = false;
                            }
                        }
                    }
                    if (codiciComponenti.Length >= 2 && assemblato)
                    {
                        if (string.IsNullOrWhiteSpace(txtCodice2.Text.Trim()))
                        {
                            assemblato = false;
                        }
                        else
                        {
                            var componente2 = (from component in context.Oggettis
                                               where component.CodiceOggetto == txtCodice2.Text.Trim()
                                               select component).First();
                            if (!codiciComponenti.Contains(componente2.Progressivo))
                            {
                                assemblato = false;
                            }
                        }
                    }
                    if (assemblato)
                    {
                        if (string.IsNullOrWhiteSpace(txtCodice1.Text.Trim()))
                        {
                            assemblato = false;
                        }
                        else
                        {
                            var componente1 = (from component in context.Oggettis
                                               where component.CodiceOggetto == txtCodice1.Text.Trim()
                                               select component).First();
                            if (!codiciComponenti.Contains(componente1.Progressivo))
                            {
                                assemblato = false;
                            }
                        }
                    }
                    if (assemblato)
                    {
                        lblRisultato.Text = "<h2>Assemblato nuovo oggetto!</h2> <h3>NOME: " + oggetto.Nome + ";<br> DESCRIZIONE: " + oggetto.Descrizione + ";<br> CARICHE: " + oggetto.Cariche + ";<br> CODICE: " + oggetto.CodiceOggetto + "</h3>";
                    }
                    else
                    {
                        lblRisultato.Text = "Non è stato trovato alcun modo utile di assemblare gli oggetti selezionati";
                    }
                }
            }
        }

		protected void NewSearch(object sender, EventArgs e)
		{
			SvuotaControlli();
		}
    }
}