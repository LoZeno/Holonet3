using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using CommonBusiness.Personaggi;

namespace Holonet3.Utilities
{
	public enum hackables
	{
		account,
		holodisk,
		notizia,
		rubrica,
		missioni,
		altro,
		nulla,
		files,
	}

    public static class HackingEngine
    {
        public static bool TentativoHacking(long livelloHacker, long livelloDifficolta)
        {
            bool res = false;

            long chances = 10 + (livelloHacker * 20);
            chances -= (livelloDifficolta * 10);
            if (chances < 1)
            {
                chances = 1;
            }
            Random randomizer = new Random();
            int tentativo = randomizer.Next(0, 99);
            if (tentativo <= chances)
            {
                res = true;
            }

            return res;
        }
		//Metodi per controllare se l'hacking non è bloccato da tentativi precedenti
        public static bool AbilitatoHackingAccount(long numeroAccount, long hacker)
        {
            bool res = false;
            using (HolonetEntities context = new HolonetEntities())
            {
                var tentativi = (from t in context.AccountHackings
                                 where t.NumeroPGAccount == numeroAccount
                                 where t.NumeroPGHacker == hacker
                                 select t).OrderByDescending(tent => tent.DataTentativo);
                if (tentativi.Count() == 0)
                {
                    res = true;
                }
                else
                {
                    var tentativoRecente = tentativi.First();
                    if (DateTime.Now > ((DateTime)tentativoRecente.DataTentativo).AddMinutes(8))
                    {
                        res = true;
                    }
                    else
                    {
                        if (tentativoRecente.Riuscito == 1)
                        {
                            res = true;
                        }
                    }
                }
            }

            return res;
        }

        public static bool AbilitatoMissioneHacking(long missione, long hacker)
        {
            bool res = false;
            using (HolonetEntities context = new HolonetEntities())
            {
                var tentativi = (from t in context.MissioneHackings
                                 where t.NumeroMissione == missione
                                 where t.NumeroPG == hacker
                                 select t).OrderByDescending(tent => tent.DataTentativo);
                if (tentativi.Count() == 0)
                {
                    res = true;
                }
                else
                {
                    var tentativoRecente = tentativi.First();
                    if (tentativoRecente.DataTentativo < DateTime.Now.AddMinutes(8))
                    {
                        res = true;
                    }
                    else
                    {
                        if (tentativoRecente.Riuscito == 1)
                        {
                            res = true;
                        }
                    }
                }
            }

            return res;
        }

        public static bool AbilitatoNotiziaHacking(long notizia, long hacker)
        {
            bool res = false;
            using (HolonetEntities context = new HolonetEntities())
            {
                PersonaggiManagerNew manager = new PersonaggiManagerNew(context);
                if (manager.HasSkill(hacker, 177))
                {
                    var tentativi = (from t in context.NotiziaHackings
                                     where t.NumeroNotizia == notizia
                                     where t.NumeroPG == hacker
                                     select t).OrderByDescending(tent => tent.DataTentativo);
                    if (tentativi.Count() == 0)
                    {
                        res = true;
                    }
                    else
                    {
                        var tentativoRecente = tentativi.First();
                        if (tentativoRecente.DataTentativo < DateTime.Now.AddMinutes(8))
                        {
                            res = true;
                        }
                        else
                        {
                            if (tentativoRecente.Riuscito == 1)
                            {
                                res = true;
                            }
                        }
                    }
                }
            }

            return res;
        }

		public static bool AbilitatoHolodiskHacking(long progressivoDisco, long hacker)
		{
			bool res = false;
			using (HolonetEntities context = new HolonetEntities())
			{
				var tentativi = (from t in context.HoloDiskHackings
								 where t.ProgressivoDisco == progressivoDisco
								 where t.NumeroPGHacker == hacker
								 select t).OrderByDescending(tent => tent.DataTentativo);
				if (tentativi.Count() == 0)
				{
					res = true;
				}
				else
				{
					var tentativoRecente = tentativi.First();
					if (tentativoRecente.DataTentativo < DateTime.Now.AddMinutes(8))
					{
						res = true;
					}
					else
					{
						if (tentativoRecente.Riuscito == 1)
						{
							res = true;
						}
					}
				}
			}

			return res;
		}
		//Metodi per registrare i tentativi precedenti
		public static void RegistraHackingAccount(long account, long hacker, bool successo)
		{
			using (HolonetEntities context = new HolonetEntities())
			{
				long numeroTentativo = 0;

				var tentativiPrecedenti = (from trials in context.AccountHackings
										   where trials.NumeroPGAccount == account
										   where trials.NumeroPGHacker == hacker
										   select trials.NumeroTentativo);
				if (tentativiPrecedenti.Count() > 0)
				{
					long ultimoTentativo = tentativiPrecedenti.Max();
					numeroTentativo = ultimoTentativo + 1;
				}

				AccountHacking tentativoDaRegistrare = new AccountHacking();
				tentativoDaRegistrare.NumeroPGAccount = account;
				tentativoDaRegistrare.NumeroPGHacker = hacker;
				tentativoDaRegistrare.NumeroTentativo = numeroTentativo;
				tentativoDaRegistrare.Riuscito = successo ? 1 : 0;
				tentativoDaRegistrare.DataTentativo = DateTime.Now;

				context.AddToAccountHackings(tentativoDaRegistrare);
				context.SaveChanges();
			}
		}

		public static void RegistraHackingMissione(long numeroMissione, long hacker, bool successo)
		{
			using (HolonetEntities context = new HolonetEntities())
			{
				var ultimoProgressivo = (from trials in context.MissioneHackings
										 select trials.Progressivo).Max();

				MissioneHacking tentativoDaRegistrare = new MissioneHacking();
				tentativoDaRegistrare.Progressivo = ultimoProgressivo + 1;
				tentativoDaRegistrare.NumeroPG = hacker;
				tentativoDaRegistrare.NumeroMissione = numeroMissione;
				tentativoDaRegistrare.Riuscito = successo ? 1 : 0;
				tentativoDaRegistrare.DataTentativo = DateTime.Now;

				context.AddToMissioneHackings(tentativoDaRegistrare);
				context.SaveChanges();
			}
		}

		public static void RegistraHackingFile(long progressivo, long hacker, bool successo)
		{
			using (HolonetEntities context = new HolonetEntities())
			{
				//var ultimoProgressivo = (from trials in context.
				//                         select trials.Progressivo).Max();

				//MissioneHacking tentativoDaRegistrare = new MissioneHacking();
				//tentativoDaRegistrare.Progressivo = ultimoProgressivo + 1;
				//tentativoDaRegistrare.NumeroPG = hacker;
				//tentativoDaRegistrare.NumeroMissione = numeroMissione;
				//tentativoDaRegistrare.Riuscito = successo ? 1 : 0;
				//tentativoDaRegistrare.DataTentativo = DateTime.Now;

				//context.AddToMissioneHackings(tentativoDaRegistrare);
				//context.SaveChanges();
			}
		}
    }
}