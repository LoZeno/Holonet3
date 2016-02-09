using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using Reports.BaseDocuments;
using iTextSharp.text.pdf;
using iTextSharp.text;
using HolonetQrCode;

namespace Reports
{
    public class CartelliniIngredienti : DocumentoCartellini<NewSostanze>
    {
        Random rand;
        BaseFont bfTimes;
        Font boldfontlarge;
        Font boldFont;
        Font normalFont;

        public CartelliniIngredienti(string pathToSave, IList<NewSostanze> elementsToPrint)
			:base(pathToSave, elementsToPrint)
		{
            rand = new Random((int)DateTime.Now.Ticks);
			bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
			boldfontlarge = new Font(bfTimes, 9, Font.BOLD, BaseColor.BLACK);
			boldFont = new Font(bfTimes, 8, Font.BOLD, BaseColor.BLACK);
			normalFont = new Font(bfTimes, 8, Font.NORMAL, BaseColor.BLACK);
		}

        protected override iTextSharp.text.pdf.PdfPCell AddRowLeftItem<T>(T item)
        {
            NewSostanze sostanza = item as NewSostanze;

            PdfPCell cella = NewBorderedCell();
            cella.HorizontalAlignment = Element.ALIGN_LEFT;
            Paragraph centerTitle = new Paragraph(sostanza.TipoSostanze.Descrizione, boldFont);
            centerTitle.Alignment = Element.ALIGN_CENTER;
            cella.AddElement(centerTitle);
            cella.AddElement(new Paragraph("Descrizione:", boldFont));
            if (!string.IsNullOrWhiteSpace(sostanza.Descrizione))
            {
                cella.AddElement(new Paragraph(sostanza.Descrizione.Replace("<br />", "\n"), normalFont));
            }
            if (sostanza.DataScadenza.HasValue)
            {
                cella.AddElement(new Paragraph("Scadenza:", boldFont));
                cella.AddElement(new Paragraph(sostanza.DataScadenza.Value.Date.ToString(), normalFont));
            }

            cella.AddElement(InsertProperty());
            return cella;
        }

        protected override iTextSharp.text.pdf.PdfPCell AddRowRightItem<T>(T item)
        {
            NewSostanze sostanza = item as NewSostanze;
            PdfPCell cella = NewBorderedCell();
            cella.HorizontalAlignment = Element.ALIGN_CENTER;

            //----INDICAZIONE CHE E' UN INGREDIENTE
            Paragraph par = new Paragraph("INGREDIENTE", boldfontlarge);
            par.Alignment = Element.ALIGN_CENTER;
            cella.AddElement(par);

            //----NOME DELL'INGREDIENTE
            par = new Paragraph(sostanza.Nome, boldfontlarge);
            par.Alignment = Element.ALIGN_CENTER;
			par.ExtraParagraphSpace = 5;
            cella.AddElement(par);

            //----CODICE QR
            int codesAvailable = sostanza.CodiciQrs.Count;
            int codeSelected = rand.Next(codesAvailable);
            CodiciQr codice = sostanza.CodiciQrs.Skip(codeSelected).FirstOrDefault();

            Guid codiceUnico = codice.Codice;
            Image qrCode = Image.GetInstance(CodeManager.GetPictureFromGuid(codiceUnico), BaseColor.WHITE);
            qrCode.Alignment = Image.ALIGN_CENTER;
            qrCode.ScalePercent(60, 60);
            cella.AddElement(qrCode);

            //----MODO USO
            par = new Paragraph(sostanza.ModoUso, boldfontlarge);
            par.Alignment = Element.ALIGN_CENTER;
            cella.AddElement(par);

            return cella;
        }
    }
}
