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
	public class CartelliniDatapad : DocumentoCartellini<HoloDisk>
	{
		BaseFont bfTimes;
		Font font;
		Font boldFont;
		Font normalFont;
		Font smallBoldFont;

		public CartelliniDatapad(string pathToSave, IList<HoloDisk> elementsToPrint)
			:base(pathToSave, elementsToPrint)
		{
			bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
			font = new Font(bfTimes, 9, Font.NORMAL, BaseColor.BLACK);
			boldFont = new Font(bfTimes, 9, Font.BOLD, BaseColor.BLACK);
			normalFont = new Font(bfTimes, 8, Font.NORMAL, BaseColor.BLACK);
			smallBoldFont = new Font(bfTimes, 8, Font.BOLD, BaseColor.BLACK);
		}

		protected override iTextSharp.text.pdf.PdfPCell AddRowLeftItem<T>(T item)
		{
			HoloDisk oggetto = item as HoloDisk;
			PdfPCell cella = NewBorderedCell();
			cella.HorizontalAlignment = Element.ALIGN_CENTER;

			Paragraph par = new Paragraph("DATAPAD", font);
			par.Alignment = Element.ALIGN_CENTER;
			cella.AddElement(par);

			par = new Paragraph(oggetto.Codice, boldFont);
			par.Alignment = Element.ALIGN_CENTER;
			par.ExtraParagraphSpace = 5;
			cella.AddElement(par);

			Image qrCode = Image.GetInstance(CodeManager.GetPictureFromGuid(oggetto.CodiceQr), BaseColor.WHITE);
			qrCode.Alignment = Image.ALIGN_CENTER;
			qrCode.ScalePercent(60, 60);
			cella.AddElement(qrCode);

			//----LOGO
			logo.ScalePercent(4, 4);
			cella.AddElement(logo);
			return cella;
		}

		protected override iTextSharp.text.pdf.PdfPCell AddRowRightItem<T>(T item)
		{
			PdfPCell cella = NewBorderedCell();
			cella.HorizontalAlignment = Element.ALIGN_LEFT;
			cella.VerticalAlignment = Element.ALIGN_BOTTOM;
			PdfPTable bottom = InsertProperty();
			bottom.HorizontalAlignment = Element.ALIGN_BOTTOM;
			cella.AddElement(bottom);
			return cella;
		}
	}
}
