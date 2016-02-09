using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reports.BaseDocuments;
using DataAccessLayer;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Reports
{
	public class CartelliniAbilitaAvanzate : DocumentoCartellini<Personaggio>
	{
		private BaseFont bfTimes;
		private Font smallfont;
		private Font largeFont;
		private Font boldFont;
		private Font smallboldFont;
		private Font smallItalic;
		private Font mediumFont;
		private Font mediumBoldFont;

		public CartelliniAbilitaAvanzate(string pathToSave, IList<Personaggio> elementsToPrint)
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

		protected PdfPCell NewBorderedVariableCell()
		{
			PdfPCell cell = new PdfPCell();
			cell.BorderWidth = 1;
			cell.BorderColor = BaseColor.BLACK;
			cell.HorizontalAlignment = 0;
			cell.MinimumHeight = 60;
			return cell;
		}

		protected override iTextSharp.text.pdf.PdfPCell AddRowLeftItem<T>(T item)
		{
			Personaggio personaggio = item as Personaggio;
			var skillsOwned = from abilita in personaggio.AbilitaPersonaggios
							  where abilita.Abilita.BaseAvanzato == 1
							  orderby abilita.Abilita.Nome ascending
							  select abilita;
			PdfPCell cella = NewBorderedVariableCell();
			Paragraph par; 
			foreach (var singleSkill in skillsOwned)
			{
				par = new Paragraph();
				par.Alignment = Element.ALIGN_LEFT;
				par.SetLeading((float)0.2, (float)1);
				Phrase NomeAbilita = new Phrase(singleSkill.Abilita.Nome + ": ", smallboldFont);
				par.Add(NomeAbilita);
				Phrase TestoAbilita = new Phrase(singleSkill.Abilita.Descrizione, smallItalic);
				par.Add(TestoAbilita);
				cella.AddElement(par);
			}

			return cella;
		}

		protected override iTextSharp.text.pdf.PdfPCell AddRowRightItem<T>(T item)
		{
			Personaggio personaggio = item as Personaggio;
			PdfPCell cella = NewBorderedVariableCell();
			cella.HorizontalAlignment = Element.ALIGN_CENTER;

			Paragraph par = new Paragraph("Numero SW: " + personaggio.NumeroSW.ToString() + " ---", smallfont);
			par.Alignment = Element.ALIGN_LEFT;
			Phrase frase = new Phrase("Numero PG: " + personaggio.NumeroPG.ToString(), smallfont);
			par.Add(frase);
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
			par = new Paragraph("sintesi abilità avanzate".ToUpper(), largeFont);
			par.Alignment = Element.ALIGN_CENTER;
			cella.AddElement(par);
			cella.AddElement(InsertProperty());
			return cella;
		}
	}
}
