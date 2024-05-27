using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;

namespace PDF_MERGE
{
    public class PDFMerger
    {
        public void MergePDF(string newFileName, string firstPDF, string secondPDF)
        {
            using (PdfDocument one = PdfReader.Open(firstPDF, PdfDocumentOpenMode.Import))
            using (PdfDocument two = PdfReader.Open(secondPDF, PdfDocumentOpenMode.Import))
            using (PdfDocument outPdf = new PdfDocument())
            {
                CopyPages(one, outPdf);
                CopyPages(two, outPdf);

                string path = AppContext.BaseDirectory + @"/" + newFileName + ".pdf"; 
                outPdf.Save(path);
            }
        }

        public void MergePDFList(string newFileName, List<string> PDFNameList)
        {
            using (PdfDocument outPdf = new PdfDocument())
            {
                foreach (string name in PDFNameList)
                {
                    using (PdfDocument two = PdfReader.Open(name, PdfDocumentOpenMode.Import))
                    CopyPages(two, outPdf);
                }
                string path = AppContext.BaseDirectory + @"/" + newFileName + ".pdf";
                outPdf.Save(path);
            }
        }

        private void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }
    }
}
