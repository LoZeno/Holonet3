using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;

namespace CommonBusiness.HoloDischi
{
	public class HoloDischiManager : BaseDataManager
	{
		public HoloDischiManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

		public int Count()
		{
			return (from dischi in context.HoloDisks
					select dischi).Count();
		}

		public IList<HoloDisk> GetPagedDisksList(int startPage, int pageSize)
		{
			var elencoDischi = (from dischi in context.HoloDisks
								 orderby dischi.Progressivo descending
								 select dischi).Skip(startPage).Take(pageSize);
			return elencoDischi.ToList();
		}

		public HoloDisk GetDiskFromQRCode(Guid codiceQR)
		{
			var disco = (from dischi in context.HoloDisks.Include("HoloDiskFiles")
						 where dischi.CodiceQr == codiceQR
						 select dischi).FirstOrDefault();
			return disco;
		}

		public IList<HoloDiskFile> GetFilesFromDisc(long progressivo)
		{
			var elencoDischi = from files in context.HoloDiskFiles
							   where files.Progressivo == progressivo
							   orderby files.NumeroFile ascending
							   select files;
			return elencoDischi.ToList();
		}

		public HoloDiskFile GetSingleFile(long progressivo, long numeroFile)
		{
			return (from files in context.HoloDiskFiles
					where files.Progressivo == progressivo
					&& files.NumeroFile == numeroFile
					select files).FirstOrDefault();
		}

		public HoloDisk GetDiskFromNumber(long progressivo)
		{
			return (from dischi in context.HoloDisks
					where dischi.Progressivo == progressivo
					select dischi).FirstOrDefault();
		}

		public IEnumerable<HoloDisk> GetDisksFromNumbers(List<long> progressivi)
		{
			return (from items in context.HoloDisks
					where progressivi.Contains(items.Progressivo)
					orderby items.Codice ascending
					select items);
		}

		public List<HoloDisk> GetDiskByText(string testo)
		{
			testo = testo.Trim();
			return (from files in context.HoloDiskFiles
					where files.HoloDisk.Codice.Contains(testo)
					|| files.HoloDisk.Contenuto.Contains(testo)
					|| files.NomeFile.Contains(testo)
					|| files.Contenuto.Contains(testo)
					select files.HoloDisk).Distinct().ToList();
		}

		public bool InsertNewDisk(string codice, string contenuto, long hacking)
		{
			codice = codice.Trim();
			try
			{
				var verifyExists = from dischi in context.HoloDisks
								   where dischi.Codice == codice
								   select dischi;
				if (verifyExists.Count() > 0)
				{
					return false;
				}

				HoloDisk newDisco = new HoloDisk();
				newDisco.Codice = codice;
				newDisco.Contenuto = contenuto;
				newDisco.Hacking = hacking;
				newDisco.CodiceQr = Guid.NewGuid();
				context.HoloDisks.AddObject(newDisco);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool UpdateDisk(long progressivo, string codice, string contenuto, long hacking)
		{
			codice = codice.Trim();
			try
			{
				HoloDisk disco = GetDiskFromNumber(progressivo);
				disco.Codice = codice;
				disco.Contenuto = contenuto;
				disco.Hacking = hacking;
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool InsertNewFile(long progressivoDisco, string nomeFile, string contenuto, long crypt)
		{
			nomeFile = nomeFile.Trim();
			try
			{
				var verifyIfExists = (from files in context.HoloDiskFiles
									  where files.Progressivo == progressivoDisco
									  && files.NomeFile == nomeFile
									  select files);
				if (verifyIfExists.Count() > 0)
				{
					return false;
				}

				long NewNumber = (from files in context.HoloDiskFiles
									where files.Progressivo == progressivoDisco
									orderby files.NumeroFile descending
									select files.NumeroFile).FirstOrDefault() + 1;
				HoloDiskFile newfile = new HoloDiskFile();
				newfile.Progressivo = progressivoDisco;
				newfile.NumeroFile = NewNumber;
				newfile.NomeFile = nomeFile;
				newfile.Contenuto = contenuto;
				newfile.LivelloCrypt = crypt;
				context.HoloDiskFiles.AddObject(newfile);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool UpdateFile(long progressivoDisco, long numeroFile, string nomeFile, string contenuto, long crypt)
		{
			try
			{
				HoloDiskFile file = GetSingleFile(progressivoDisco, numeroFile);
				file.NomeFile = nomeFile;
				file.Contenuto = contenuto;
				file.LivelloCrypt = crypt;
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
