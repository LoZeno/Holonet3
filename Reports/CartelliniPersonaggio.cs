using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reports.BaseDocuments;
using iTextSharp.text.pdf;
using DataAccessLayer;
using iTextSharp.text;
using System.IO;
using HolonetQrCode;

namespace Reports
{
	public class CartelliniPersonaggio : DocumentoCartellini<Personaggio>
	{
		private BaseFont bfTimes;
		private Font smallfont;
		private Font largeFont;
		private Font boldFont;
		private Font smallboldFont;
		private Font smallItalic;
		private Font mediumFont;
		private Font mediumBoldFont;

		private long? cdEvento = null;

		public CartelliniPersonaggio(string pathToSave, IList<Personaggio> elementsToPrint)
			: base(pathToSave, elementsToPrint)
		{
			bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
			smallfont = new Font(bfTimes, 6, Font.NORMAL, BaseColor.BLACK);
			largeFont = new Font(bfTimes, 9, Font.NORMAL, BaseColor.BLACK);
			boldFont = new Font(bfTimes, 9, Font.BOLD, BaseColor.BLACK);
			smallboldFont = new Font(bfTimes, 6, Font.BOLD, BaseColor.BLACK);
			mediumFont = new Font(bfTimes, 8, Font.NORMAL, BaseColor.BLACK);
			mediumBoldFont = new Font(bfTimes, 8, Font.BOLD, BaseColor.BLACK);
			smallItalic = new Font(bfTimes, 6, Font.ITALIC, BaseColor.BLACK);
		}

		public CartelliniPersonaggio(string pathToSave, IList<Personaggio> elementsToPrint, long CdEvento)
			: this(pathToSave, elementsToPrint)
		{
			cdEvento = CdEvento;
		}

		protected override PdfPCell AddRowLeftItem<T>(T item)
		{
			Personaggio personaggio = item as Personaggio;
			PdfPCell cella = NewBorderedCell();
			cella.HorizontalAlignment = Element.ALIGN_CENTER;

			Paragraph par = new Paragraph("Numero SW: "+ personaggio.NumeroSW.ToString() + " ---", smallfont);
			par.Alignment = Element.ALIGN_LEFT;
			Phrase frase = new Phrase("Numero PG: " + personaggio.NumeroPG.ToString(), smallfont);
			par.Add(frase);
			cella.AddElement(par);
			par = new Paragraph("Giocatore: " + personaggio.Giocatore.NomeCompleto.ToUpper(), largeFont);
			par.Alignment = Element.ALIGN_CENTER;
			cella.AddElement(par);
			par = new Paragraph(personaggio.Nome, boldFont);
			par.Alignment = Element.ALIGN_CENTER;
			cella.AddElement(par);
			if (!string.IsNullOrWhiteSpace(personaggio.Titolo))
			{
				par = new Paragraph(personaggio.Titolo.ToUpper(), smallboldFont);
				par.Alignment = Element.ALIGN_CENTER;
				cella.AddElement(par);
			}
			
			//Codice QR e altri dati
			float[] columns = new float[2] { 30, 70 };
			PdfPTable innerTable = new PdfPTable(columns);
			innerTable.WidthPercentage = 100;
			PdfPCell leftcell = new PdfPCell();
			Image qrCode = Image.GetInstance(CodeManager.GetPictureFromGuid(personaggio.CodicePg), BaseColor.WHITE);
			qrCode.ScalePercent(60, 60);
			leftcell.AddElement(qrCode);
			leftcell.Border = 0;
			PdfPCell rightcell = new PdfPCell();
            par = new Paragraph("Sesso: " + personaggio.Sesso.ToUpper() + " --- Specie: " + personaggio.Specie1.Nome, largeFont);
            par.Alignment = Element.ALIGN_LEFT;
            rightcell.AddElement(par);
            par = new Paragraph("Punti esperienza: " + personaggio.Punti + "; Avanzati: " + personaggio.PuntiLiberi, mediumFont);
            par.Alignment = Element.ALIGN_LEFT;
            rightcell.AddElement(par);
			par = new Paragraph("Punti Ferita: " + personaggio.PuntiFerita(), mediumBoldFont);
			par.Alignment = Element.ALIGN_LEFT;
			rightcell.AddElement(par);
			par = new Paragraph("Robustezza: " + personaggio.Robustezza(), mediumBoldFont);
			par.Alignment = Element.ALIGN_LEFT;
			rightcell.AddElement(par);
			par = new Paragraph("Forza Mentale: " + personaggio.ForzaMentale(), mediumBoldFont);
			par.Alignment = Element.ALIGN_LEFT;
			rightcell.AddElement(par);
            if (cdEvento.HasValue)
            {
                rightcell.AddElement(insertValidity(personaggio));
            }
			rightcell.Border = 0;
			innerTable.AddCell(leftcell);
			innerTable.AddCell(rightcell);
			cella.AddElement(innerTable);
            return cella;
		}

		protected override PdfPCell AddRowRightItem<T>(T item)
		{
			Personaggio personaggio = item as Personaggio;
			PdfPCell cella = NewBorderedCell();
			cella.HorizontalAlignment = Element.ALIGN_CENTER;

			Paragraph par = new Paragraph("Password Holonet: " + personaggio.PasswordHolonet.ToLower(), smallfont);
			par.Alignment = Element.ALIGN_RIGHT;
			cella.AddElement(par);
			par = new Paragraph("Abilità".ToUpper(), mediumBoldFont);
			par.Alignment = Element.ALIGN_CENTER;
			cella.AddElement(par);
			foreach (var Attitudine in personaggio.Attitudines)
			{
                //par = new Paragraph(Attitudine.Nome + ": ", smallboldFont);
                //par.Alignment = Element.ALIGN_LEFT;
                par = new Paragraph();
                par.Alignment = Element.ALIGN_LEFT;
                par.SetLeading((float)0.2, (float)1);
                Phrase NomeAbilita = new Phrase(Attitudine.Nome + ": ", smallboldFont);
                par.Add(NomeAbilita);
				var theseSkills = from abilitaComprate in personaggio.AbilitaPersonaggios
								  where abilitaComprate.CdAttitudine == Attitudine.CdAttitudine
								  select abilitaComprate.Abilita;
				foreach (var skill in theseSkills)
				{
					Font myFont;
					if (skill.BaseAvanzato == 1)
					{
						myFont = smallItalic;
					}
					else
					{
						myFont = smallfont;
					}
					string abilita = skill.Nome.ToLower();
					var specifica = (from acquisto in skill.AbilitaPersonaggios
									where acquisto.NumeroPG == personaggio.NumeroPG
									&& acquisto.CdAbilita == skill.CdAbilita
									select acquisto.Specifiche).FirstOrDefault();
					if (!string.IsNullOrWhiteSpace(specifica))
					{
						abilita += " (" + specifica.ToLower() + ")";
					}
					Phrase frase = new Phrase(abilita + ", ", myFont);
					par.Add(frase);
				}
				cella.AddElement(par);
			}

			cella.AddElement(InsertProperty());
			return cella;
		}

		private Paragraph insertValidity(Personaggio character)
		{
			var query = (from giorni in character.EventoGiorniPersonaggios
						 where giorni.CdEvento == cdEvento.Value
						 select giorni.DataGiorno);
			var StartDate = query.Min();
			var EndDate = query.Max();

			Paragraph par = new Paragraph("Validità: " + StartDate.Date.ToString("dd/MM/yyyy") + " - " + EndDate.Date.ToString("dd/MM/yyyy"), smallItalic);
			par.Alignment = Element.ALIGN_CENTER;
			return par;
		}
	}
}
