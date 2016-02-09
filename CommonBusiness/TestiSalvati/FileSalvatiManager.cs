using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;

namespace CommonBusiness.TestiSalvati
{
	public class FileSalvatiManager : BaseDataManager
	{
		public FileSalvatiManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

		public bool SaveIncomingMessage(long numeroPg, Missione messaggio)
		{
			try
			{
				MessaggioSalvato messageToSave = new MessaggioSalvato();
				messageToSave.Hacking = messaggio.LivelloHacking;
				messageToSave.NumeroPG = numeroPg;
				messageToSave.Provenienza = "Messaggi";
				messageToSave.Titolo = messaggio.Titolo;

				StringBuilder content = new StringBuilder();
				content.AppendLine("DA: " + messaggio.Personaggio.Nome + "<br/>");
				content.AppendLine("Data: " + messaggio.DataCreazione + "<br/>");
				content.AppendLine("<br/>");
				content.Append(messaggio.Testo);
				messageToSave.Contenuto = content.ToString();

				context.AddToMessaggioSalvatoes(messageToSave);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SaveOutgoingMessage(long numeroPg, Missione messaggio)
		{
			try
			{
				MessaggioSalvato messageToSave = new MessaggioSalvato();
				messageToSave.Hacking = messaggio.LivelloHacking;
				messageToSave.NumeroPG = numeroPg;
				messageToSave.Provenienza = "Messaggi";
				messageToSave.Titolo = messaggio.Titolo;

				StringBuilder content = new StringBuilder();
				content.AppendLine("INVIATO A: ");
				foreach (PostaInArrivo destinatario in messaggio.PostaInArrivoes)
				{
					content.Append(destinatario.Personaggio.Nome + "; ");
				}
				content.AppendLine("<br/>");
				content.AppendLine("Data: " + messaggio.DataCreazione + "<br/>");
				content.AppendLine("<br/>");
				content.Append(messaggio.Testo);
				messageToSave.Contenuto = content.ToString();

				context.AddToMessaggioSalvatoes(messageToSave);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
