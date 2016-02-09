using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using HolonetWebControls;

namespace Holonet3.LaboratorioChimico
{
    public partial class LaboratorioChimico : HolonetPage
    {
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
                    Personaggio character = (Personaggio)Session["Personaggio"];
                    IQueryable<AbilitaPersonaggio> ricerca;
                    int CanUse = 0;
                    using (HolonetEntities context = new HolonetEntities())
                    {
                        ricerca = (from abilita in context.AbilitaPersonaggios
                                   where abilita.NumeroPG == character.NumeroPG
                                   where abilita.CdAbilita == 1
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
            lblRisultato.Text = "Attendere: Sintetizzazione in corso...";
        }

        public void SvuotaControlli()
        {
            lblRisultato.Text = string.Empty;
            txtCodice1.Text = string.Empty;
            txtCodice2.Text = string.Empty;
            txtCodice3.Text = string.Empty;
            txtCodice4.Text = string.Empty;
            txtCodice5.Text = string.Empty;
        }

        protected void TimerTick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;

            string codice = txtCodice1.Text.Trim();
            Ingredienti ricettaDaVerificare = null;
            Sostanze sostanza;

            using (HolonetEntities context = new HolonetEntities())
            {
				var sostanze = (from substances in context.Sostanzes
								where substances.CodiceSostanza == codice
								select substances);
				if (sostanze.Count() > 0)
				{
					sostanza = sostanze.First();
					long progressivoIngrediente = sostanza.Progressivo;

					var ricette = (from receipts in context.Ingredientis
								   where receipts.ProgressivoIngrediente == progressivoIngrediente
								   select receipts);
					//Secondo Ingrediente
					codice = txtCodice2.Text.Trim();
					sostanze = (from substances in context.Sostanzes
									where substances.CodiceSostanza == codice
									select substances);

					if (sostanze.Count() > 0)
					{
						sostanza = sostanze.First();
						List<Ingredienti> ricettevalide = new List<Ingredienti>();
						foreach (var possibileRicetta in ricette)
						{
							var esiste = (from receipts in context.Ingredientis
										  where receipts.ProgressivoSostanza == possibileRicetta.ProgressivoSostanza
										  where receipts.ProgressivoIngrediente == sostanza.Progressivo
										  select receipts).Count();
							if (esiste > 0)
							{
								ricettevalide.Add(possibileRicetta);
							}
						}
						if (ricettevalide.Count == 1)
						{
							ricettaDaVerificare = ricettevalide[0];
						}
						else if (ricettevalide.Count > 1)
						{
							//Terzo Ingrediente
							codice = txtCodice3.Text.Trim();
							sostanze = (from substances in context.Sostanzes
									where substances.CodiceSostanza == codice
									select substances);
							List<Ingredienti> ricettevalide2 = new List<Ingredienti>();
							if (sostanze.Count() > 0)
							{
								sostanza = sostanze.First();
								
								foreach (var possibileRicetta in ricettevalide)
								{
									var esiste = (from receipts in context.Ingredientis
										  where receipts.ProgressivoSostanza == possibileRicetta.ProgressivoSostanza
										  where receipts.ProgressivoIngrediente == sostanza.Progressivo
										  select receipts).Count();
									if (esiste > 0)
									{
										ricettevalide2.Add(possibileRicetta);
									}
								}
							}
							if (ricettevalide2.Count == 1)
							{
								ricettaDaVerificare = ricettevalide2[0];
							}
							else if (ricettevalide2.Count > 1)
							{
								//quarto ingrediente
								codice = txtCodice4.Text.Trim();
								List<Ingredienti> ricettevalide3 = new List<Ingredienti>();
								sostanze = (from substances in context.Sostanzes
									where substances.CodiceSostanza == codice
									select substances);
								if (sostanze.Count() > 0)
								{
									sostanza = sostanze.First();
									foreach (var possibileRicetta in ricettevalide2)
									{
										var esiste = (from receipts in context.Ingredientis
										  where receipts.ProgressivoSostanza == possibileRicetta.ProgressivoSostanza
										  where receipts.ProgressivoIngrediente == sostanza.Progressivo
										  select receipts).Count();
										if (esiste > 0)
										{
											ricettevalide3.Add(possibileRicetta);
										}
									}
									if (ricettevalide3.Count == 1)
									{
										ricettaDaVerificare = ricettevalide3[0];
									}
									else if(ricettevalide3.Count > 1)
									{
										//quinto ingrediente
										codice = txtCodice5.Text.Trim();
										List<Ingredienti> ricettevalide4 = new List<Ingredienti>();
										sostanze = (from substances in context.Sostanzes
													where substances.CodiceSostanza == codice
													select substances);
										if (sostanze.Count() > 0)
										{
											sostanza = sostanze.First();
											foreach (var possibileRicetta in ricettevalide3)
											{
												var esiste = (from receipts in context.Ingredientis
															  where receipts.ProgressivoSostanza == possibileRicetta.ProgressivoSostanza
															  where receipts.ProgressivoIngrediente == sostanza.Progressivo
															  select receipts).Count();
												if (esiste > 0)
												{
													ricettevalide4.Add(possibileRicetta);
												}
											}
											if (ricettevalide4.Count > 0)
											{
												ricettaDaVerificare = ricettevalide4[0];
											}
										}
									}
								}
							}
						}
					}
				}
				if (ricettaDaVerificare == null)
				{
					lblRisultato.Text = "La combinazione di sostanze non ha dato risultati rilevanti";
				}
				else
				{
					bool sintesiEffettuata = true;
					sostanza = (from substance in context.Sostanzes
									where substance.Progressivo == ricettaDaVerificare.ProgressivoSostanza
									select substance).First();
					if (!sostanza.Ingredientis1.IsLoaded)
					{
						sostanza.Ingredientis1.Load();
					}
					//verifico che gli ingredienti ci siano tutti
					IEnumerable<Ingredienti> elencoIngredienti = sostanza.Ingredientis1.AsEnumerable();
					long?[] codiciIngredienti = new long?[elencoIngredienti.Count()];
					int i = 0;
					foreach (var item in elencoIngredienti)
					{
						codiciIngredienti[i] = item.ProgressivoIngrediente;
						i++;
					}

					if (codiciIngredienti.Length == 5)
					{
						if (string.IsNullOrEmpty(txtCodice5.Text.Trim()))
						{
							sintesiEffettuata = false;
						}
						else
						{
							var ingrediente5 = (from substance in context.Sostanzes
												where substance.CodiceSostanza == txtCodice5.Text.Trim()
												select substance).First();
							if (!codiciIngredienti.Contains(ingrediente5.Progressivo))
							{
								sintesiEffettuata = false;
							}
						}
					}
					if (codiciIngredienti.Length >= 4 && sintesiEffettuata)
					{
						if (string.IsNullOrWhiteSpace(txtCodice4.Text.Trim()))
						{
							sintesiEffettuata = false;
						}
						else
						{
							var ingrediente4 = (from substance in context.Sostanzes
												where substance.CodiceSostanza == txtCodice4.Text.Trim()
												select substance).First();
							if (!codiciIngredienti.Contains(ingrediente4.Progressivo))
							{
								sintesiEffettuata = false;
							}
						}
					}
					if (codiciIngredienti.Length >= 3 && sintesiEffettuata)
					{
						if (string.IsNullOrWhiteSpace(txtCodice3.Text.Trim()))
						{
							sintesiEffettuata = false;
						}
						else
						{
							var ingrediente3 = (from substance in context.Sostanzes
												where substance.CodiceSostanza == txtCodice3.Text.Trim()
												select substance).First();
							if (!codiciIngredienti.Contains(ingrediente3.Progressivo))
							{
								sintesiEffettuata = false;
							}
						}
					}
					if (codiciIngredienti.Length >= 2 && sintesiEffettuata)
					{
						if (string.IsNullOrWhiteSpace(txtCodice2.Text.Trim()))
						{
							sintesiEffettuata = false;
						}
						else
						{
							var ingrediente2 = (from substance in context.Sostanzes
												where substance.CodiceSostanza == txtCodice2.Text.Trim()
												select substance).First();
							if (!codiciIngredienti.Contains(ingrediente2.Progressivo))
							{
								sintesiEffettuata = false;
							}
						}
					}
					if (sintesiEffettuata)
					{
						if (string.IsNullOrWhiteSpace(txtCodice1.Text.Trim()))
						{
							sintesiEffettuata = false;
						}
						else
						{
							var ingrediente1 = (from substance in context.Sostanzes
												where substance.CodiceSostanza == txtCodice1.Text.Trim()
												select substance).First();
							if (!codiciIngredienti.Contains(ingrediente1.Progressivo))
							{
								sintesiEffettuata = false;
							}
						}
					}
					if (sintesiEffettuata && (sostanza.Tipo == 1 || sostanza.Tipo == 0))
					{
						lblRisultato.Text = "<h2>Nuova sostanza sintetizzata!</h2> <h3>NOME: " + sostanza.Nome + ";<br> EFFETTO: " + sostanza.Effetto + ";<br> VALORE EFFICACIA: " + sostanza.ValoreEfficacia + ";<br> CODICE: " + sostanza.CodiceSostanza + "</h3>";
					}
					else
					{
						lblRisultato.Text = "La combinazione di sostanze non ha dato risultati rilevanti";
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