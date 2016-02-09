using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using iTextSharp.text.pdf;
using System.Data.Objects.DataClasses;
using iTextSharp.text;

namespace Reports.BaseDocuments
{
    public abstract class DocumentoCartelliniFronteRetro<T> : DocumentoCartellini<T>
		where T : EntityObject
    {
        private PdfPTable _frontTable;

        public DocumentoCartelliniFronteRetro(string pathToSave, IList<T> elementsToPrint)
            : base(pathToSave, elementsToPrint)
        {
            _frontTable = new PdfPTable(2);
            _frontTable.WidthPercentage = 100;
        }

        protected override void FinalizeTable()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (i % 5 == 0)
                {
                    _document.Add(_frontTable);
					_document.NewPage();
                    _document.Add(_table);
					_document.NewPage();

                    _frontTable = new PdfPTable(2);
                    _frontTable.WidthPercentage = 100;

                    _table = new PdfPTable(2);
                    _table.WidthPercentage = 100;
                }
                _table.AddCell(AddRowLeftItem(elements[i]));
                _table.AddCell(AddRowRightItem(elements[i]));

                _frontTable.AddCell(AddFrontRowLeftItem(elements[i]));
                _frontTable.AddCell(AddFrontRowRightItem(elements[i]));
            }

            _document.Add(_frontTable);
			_document.NewPage();
            _document.Add(_table);
        }

        protected abstract PdfPCell AddFrontRowLeftItem<T>(T item);

        protected abstract PdfPCell AddFrontRowRightItem<T>(T item);

        protected override PdfPCell AddRowLeftItem<T>(T item)
        {
			return NewBorderedCell(); 
        }

        protected override PdfPCell AddRowRightItem<T>(T item)
        {
			return NewBorderedCell();
        }
    }
}
