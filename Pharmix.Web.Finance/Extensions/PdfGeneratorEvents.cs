using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Pharmix.Web.Extensions
{
    public class PdfGeneratorEvents : PdfPageEventHelper
    {
        protected string header;

        public PdfGeneratorEvents(string header)
        {
            this.header = header;
        }
        public override void OnStartPage(PdfWriter writer, Document doc)
        {
            var headerPara = new Paragraph(header, new Font(Font.FontFamily.TIMES_ROMAN, 18));
            doc.Add(headerPara);
        }

        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            var footer = new Paragraph("Page "+ writer.PageNumber, new Font(Font.FontFamily.HELVETICA, 10));
            doc.Add(footer);
        }
    }
}
