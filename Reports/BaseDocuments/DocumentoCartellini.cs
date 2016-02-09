using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.Objects.DataClasses;

namespace Reports.BaseDocuments
{
	public abstract class DocumentoCartellini<T> where T : EntityObject
	{
		protected IList<T> elements;

		protected Document _document;
		protected PdfPTable _table;

		protected PdfWriter _writer;

		protected Image logo;

		private PdfPTable _propertyTable;

		public DocumentoCartellini(string pathToSave, IList<T> elementsToPrint)
		{
			elements = elementsToPrint;
			_document = new Document(PageSize.A4);
			_document.SetMargins(60, 60, 20, 20);
			_writer = PdfWriter.GetInstance(_document, new FileStream(pathToSave, FileMode.Create));
			_document.Open();
			_table = new PdfPTable(2);
			_table.WidthPercentage = 100;
			logo = Image.GetInstance(InsertLogo(), BaseColor.WHITE);
			createPropertyTable();
		}

		protected PdfPCell NewBorderedCell()
		{
			PdfPCell cell = new PdfPCell();
			cell.BorderWidth = 1;
			cell.BorderColor = BaseColor.BLACK;
			cell.HorizontalAlignment = 0;
			cell.FixedHeight = 140.0f;
			return cell;
		}

        protected System.Drawing.Image InsertLogo()
        {
            return Reports.Properties.Resources.LOGO;
        }

        protected PdfPTable InsertProperty()
        {
			return _propertyTable;
        }

		//public DocumentoCartellini(string pathToSave, List<T> elementsToPrint)
		//{
		//    elements = elementsToPrint;
		//    _document = new Document(PageSize.A4);
		//    _writer = PdfWriter.GetInstance(_document, new FileStream(pathToSave, FileMode.Create));
		//    _document.Open();
		//    _table = new PdfPTable(2);
		//}

		protected abstract PdfPCell AddRowLeftItem<T>(T item);

		protected abstract PdfPCell AddRowRightItem<T>(T item);

		protected virtual void FinalizeTable()
		{
			foreach (T item in elements)
			{
				_table.AddCell(AddRowLeftItem(item));
				_table.AddCell(AddRowRightItem(item));
			}

			_document.Add(_table);
		}

		public void Save()
		{
			FinalizeTable();
			_document.Close();
		}

		private void createPropertyTable()
		{
			float[] columns = { 10, 80, 10 };
			PdfPTable bottomtable = new PdfPTable(columns);
			bottomtable.ExtendLastRow = true;
			bottomtable.WidthPercentage = 100;

			logo.ScalePercent(2, 2);
			logo.Alignment = Image.ALIGN_CENTER;
			PdfPCell leftcell = new PdfPCell(logo);
			leftcell.Border = 0;
			leftcell.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
			bottomtable.AddCell(leftcell);

			BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
			Font font = new Font(bfTimes, 4, Font.NORMAL, BaseColor.BLACK);
			PdfPCell centerCell = new PdfPCell();
			centerCell.HorizontalAlignment = Element.ALIGN_CENTER;
			centerCell.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
			Paragraph par = new Paragraph("Proprietà di SWLive.it", font);
			par.Alignment = Element.ALIGN_CENTER;
			centerCell.AddElement(par);
			par = new Paragraph("http://www.swlive.it - info@swlive.it", font);
			par.Alignment = Element.ALIGN_CENTER;
			centerCell.AddElement(par);
			par = new Paragraph("STRADA AL GABBIANO 22 NOCETO (PR)", font);
			par.Alignment = Element.ALIGN_CENTER;
			centerCell.AddElement(par);
			centerCell.Border = 0;
			bottomtable.AddCell(centerCell);
			PdfPCell rightCell = new PdfPCell(logo);
			rightCell.Border = 0;
			rightCell.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
			bottomtable.AddCell(rightCell);
			_propertyTable = bottomtable;
		}
	}
}
