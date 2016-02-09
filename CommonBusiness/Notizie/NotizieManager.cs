using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;

namespace CommonBusiness.Notizie
{
	public class NotizieManager : BaseDataManager
	{
		public NotizieManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

		public IEnumerable<long> GetActiveNewsIndexes(long fazione, DateTime data)
		{
			return (from notizie in context.Notizias
								 where notizie.Rete == fazione
								 where notizie.DataFine >= data
								 where notizie.DataCreazione <= data
								 orderby notizie.DataCreazione
								 select notizie.NumeroNotizia).Distinct();
		}
        public IEnumerable<Notizia> GetActiveNews(long fazione, DateTime data)
        {
            return (from notizie in context.Notizias
                    where notizie.Rete == fazione
                    where notizie.DataFine >= data
                    where notizie.DataCreazione <= data
                    orderby notizie.DataCreazione
                    select notizie).ToList<Notizia>();
        }

        public NotizieModel GetActiveNewsInModel(long fazione, DateTime data)
        { 
            NotizieModel _ret = new NotizieModel();
            _ret.news = context.Notizias.Where(n => n.Rete == fazione &&
                                                            n.DataFine >= data &&
                                                            n.DataCreazione <= data)
                                                      .OrderBy(n => n.DataCreazione)
                                                      .Select(n => new NotiziaModel() 
                                                      { 
                                                        id = n.NumeroNotizia,
                                                        titolo = n.Titolo,
                                                        testo = n.Testo,
                                                        autore = n.Personaggio.Nome
                                                      }).ToList();
            return _ret;
        }
		public IList<Notizia> GetNews(long fazione, DateTime data)
		{
			var newslist = from notizie in context.Notizias
						   where notizie.Rete == fazione
						   && notizie.DataFine >= data
						   orderby notizie.DataCreazione descending
						   select notizie;
			return newslist.ToList();
		}

		public IList<Notizia> GetNews(long fazione)
		{
			var newslist = from notizie in context.Notizias
						   where notizie.Rete == fazione
						   orderby notizie.DataCreazione descending
						   select notizie;
			return newslist.ToList();
		}

		public Notizia GetSingleNewsItem(long NumeroNotizia)
		{
			return (from notizie in context.Notizias
					where notizie.NumeroNotizia == NumeroNotizia
					select notizie).FirstOrDefault();
		}

		private long GetMaxNumber()
		{
			var maxNumber = (from notizie in context.Notizias
							 select notizie.NumeroNotizia).Max();
			return maxNumber;
		}

		public bool SendNews(string titolo, string testo, DateTime inizio, DateTime fine, long rete, long autore, long hacking)
		{
			try
			{
				Notizia nuovaNotizia = new Notizia();
				nuovaNotizia.NumeroNotizia = GetMaxNumber() + 1;
				nuovaNotizia.DataCreazione = inizio;
				nuovaNotizia.DataFine = fine;
				nuovaNotizia.LivelloHacking = hacking;
				nuovaNotizia.Rete = rete;
				nuovaNotizia.Autore = autore;
				nuovaNotizia.Testo = testo.Trim().Replace("\r\n", "<br />");
				nuovaNotizia.Titolo = titolo;
				context.Notizias.AddObject(nuovaNotizia);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool UpdateNews(long progressivo, string titolo, string testo, DateTime inizio, DateTime fine, long rete, long autore, long hacking)
		{
			try
			{
				Notizia singleNewsItem = GetSingleNewsItem(progressivo);
				if (singleNewsItem != null)
				{
					singleNewsItem.DataCreazione = inizio;
					singleNewsItem.DataFine = fine;
					singleNewsItem.LivelloHacking = hacking;
					singleNewsItem.Rete = rete;
					singleNewsItem.Autore = autore;
					singleNewsItem.Testo = testo.Trim().Replace("\r\n", "<br />").Replace("\n", "<br />");
					singleNewsItem.Titolo = titolo;
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}
	}
}
