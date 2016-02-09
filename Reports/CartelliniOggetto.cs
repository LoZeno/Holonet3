using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reports.BaseDocuments;
using DataAccessLayer;
using iTextSharp.text;
using HolonetQrCode;
using iTextSharp.text.pdf;

namespace Reports
{
	public class CartelliniOggetto : DocumentoCartellini<NewOggetti>
	{
        Random rand;
		BaseFont bfTimes;
		Font font;
		Font boldFont;
		Font normalFont;
		Font smallBoldFont;

        public CartelliniOggetto(string pathToSave, IList<NewOggetti> elementsToPrint)
			:base(pathToSave, elementsToPrint)
		{
            rand = new Random((int)DateTime.Now.Ticks);
			bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
			font = new Font(bfTimes, 9, Font.NORMAL, BaseColor.BLACK);
			boldFont = new Font(bfTimes, 9, Font.BOLD, BaseColor.BLACK);
			normalFont = new Font(bfTimes, 8, Font.NORMAL, BaseColor.BLACK);
			smallBoldFont = new Font(bfTimes, 8, Font.BOLD, BaseColor.BLACK);
		}

		protected override iTextSharp.text.pdf.PdfPCell AddRowLeftItem<T>(T item)
		{
            NewOggetti oggetto = item as NewOggetti;
            PdfPCell cella = NewBorderedCell();
            cella.HorizontalAlignment = Element.ALIGN_CENTER;

            Paragraph par = new Paragraph(oggetto.TipoOggetti.Descrizione, font);
            par.Alignment = Element.ALIGN_CENTER;
            cella.AddElement(par);

            par = new Paragraph(oggetto.Nome, boldFont);
            par.Alignment = Element.ALIGN_CENTER;
			par.ExtraParagraphSpace = 5;
            cella.AddElement(par);

			//par = new Paragraph("==", normalFont);
			//par.Alignment = Element.ALIGN_CENTER;
			//cella.AddElement(par);
            
            int codesAvailable = oggetto.CodiciQrs.Count;
            int codeSelected = rand.Next(codesAvailable);
            CodiciQr codice = oggetto.CodiciQrs.Skip(codeSelected).FirstOrDefault();
            //Guid codiceUnico = (from codes in oggetto.CodiciQrs
            //                    where codes.Progressivo == codeSelected
            //                    select codes.Codice).FirstOrDefault();
            Guid codiceUnico = codice.Codice;
            Image qrCode = Image.GetInstance(CodeManager.GetPictureFromGuid(codiceUnico), BaseColor.WHITE);
            qrCode.Alignment = Image.ALIGN_CENTER;
            qrCode.ScalePercent(60, 60);
            cella.AddElement(qrCode);
			
			//----LOGO
            logo.ScalePercent(3, 3);
            cella.AddElement(logo);
            return cella;
		}

		protected override iTextSharp.text.pdf.PdfPCell AddRowRightItem<T>(T item)
		{
            NewOggetti oggetto = item as NewOggetti;

            PdfPCell cella = NewBorderedCell();
            cella.HorizontalAlignment = Element.ALIGN_LEFT;

			cella.AddElement(new Paragraph("Descrizione:", smallBoldFont));
			if (!string.IsNullOrWhiteSpace(oggetto.Descrizione))
			{
				cella.AddElement(new Paragraph(oggetto.Descrizione.Replace("<br />", "\n"), normalFont));
			}
			cella.AddElement(new Paragraph("Effetto:", smallBoldFont));
            if (!string.IsNullOrWhiteSpace(oggetto.Effetto))
            {
                cella.AddElement(new Paragraph(oggetto.Effetto.Replace("<br />", "\n"), normalFont));
            }
			if (oggetto.NumeroCariche.HasValue && oggetto.NumeroCariche > 0)
			{
                Paragraph par = new Paragraph();
                par.Add(new Phrase("Numero di cariche: ", smallBoldFont));
                par.Add(new Phrase(oggetto.NumeroCariche.ToString(), normalFont));
                cella.AddElement(par);
			}
            if (oggetto.DataScadenza.HasValue)
            {
                Paragraph par = new Paragraph();
                par.Add(new Phrase("Scadenza: ", smallBoldFont));
                par.Add(new Phrase(oggetto.DataScadenza.Value.Date.ToString(), normalFont));
                cella.AddElement(par);
            }
            PdfPTable bottom = InsertProperty();
            bottom.HorizontalAlignment = Element.ALIGN_BOTTOM;
            cella.AddElement(bottom);
            return cella;
		}
	}
}
