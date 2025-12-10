using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WpfProyectoBancoP2C
{
    public class PdfGenerator
    {
        public static void CrearPDFTransacciones(string rutaCSV, string rutaPDF)
        {
            // Crear documento PDF
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));
            doc.Open();

            // Título central bonito
            Paragraph titulo = new Paragraph(
                "Historial de Transacciones - Banco Bisa\n\n",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20)
            );
            titulo.Alignment = Element.ALIGN_CENTER;

            doc.Add(titulo);

            // Crear la tabla
            PdfPTable tabla = new PdfPTable(5); // 5 columnas
            tabla.WidthPercentage = 100;

            tabla.AddCell("Fecha");
            tabla.AddCell("Tipo");
            tabla.AddCell("Monto");
            tabla.AddCell("Saldo Final");
            tabla.AddCell("Cuenta");

            // Leer CSV
            if (File.Exists(rutaCSV))
            {
                foreach (string linea in File.ReadAllLines(rutaCSV))
                {
                    var datos = linea.Split(';');

                    foreach (var d in datos)
                        tabla.AddCell(d);
                }
            }
            else
            {
                tabla.AddCell("No existe el archivo CSV");
            }

            doc.Add(tabla);
            doc.Close();
        }
    }
}
