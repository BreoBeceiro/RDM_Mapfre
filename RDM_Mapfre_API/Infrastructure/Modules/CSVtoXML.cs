using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace RDM_Mapfre_API.Infrastructure.Modules
{
    public static class CSVtoXML
    {
        public static void csvToXML(string csvLocalRoute)
        {
            //TODO CHAPU PARA LEER DE LA BASE DE LA APP
            string dir = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");

            using (var fileReader = new StreamReader(File.OpenRead($"{dir}{csvLocalRoute}")))
            {
                List<Oficina> oficinas = new List<Oficina>();

                while (!fileReader.EndOfStream)
                {
                    var row = fileReader.ReadLine();

                    string[] rowValues = row.Split(';');

                    var oficinaXml = OficinasRepository.createOficina(rowValues);
                    oficinas.Add(oficinaXml);

                    Console.WriteLine(rowValues);
                }
            }

            var i = 0;
        }





        //XML generado con tipos primitivos:
        public static void arrayToXML_Primal(string[] matrix, string xmlCreationRoute)
        {
            XmlWriter xmlWriter = XmlWriter.Create(xmlCreationRoute);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("oficina");

            foreach (string row in matrix)
            {
                xmlWriter.WriteStartElement("codigoOficina");
                xmlWriter.WriteElementString("codigo", row[0].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionOficina");
                xmlWriter.WriteElementString("denominacion", row[1].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoCeco");
                xmlWriter.WriteElementString("ceco", row[2].ToString());
                xmlWriter.WriteEndElement();

                //... Hasta 55
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
        }

        //XML generado con objetos:
        public static void arrayToXML_Object(string xmlCreationRoute)
        {
            XmlWriter xmlWriter = XmlWriter.Create(xmlCreationRoute);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("oficina");



            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
        }
    }
}
