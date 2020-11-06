using RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using YamlDotNet.RepresentationModel;

namespace RDM_Mapfre_API.Infrastructure.Modules
{
    public static class CSVtoXML
    {
        /// <summary>
        /// Read a reference CSV file (ListadoOficinas.csv) and fills an Oficina objects list with its content.
        /// </summary>
        /// <param name="csvLocalRoute">Local route where CSV will be found.</param>
        /// <returns>The resulting Oficina objects list.</returns>
        public static List<Oficina> readReferenceCSV(string csvLocalRoute)
        {
            List<Oficina> oficinas = new List<Oficina>();
            var myBusinessRoute = YamlReader.ReadYml("fileRoutes", "MyBusinessRoute");

            Stream file = File.OpenRead(csvLocalRoute);
            var fileReader = new StreamReader(file);

            #region "Aportaciones de Víctor"
            //TODO CHAPU PARA LEER DE LA BASE DE LA APP (COMENTADO PARA PODER DEPURAR Y VALIDAR FUNCIONALIDAD):
            //string dir = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
            //StreamReader yamlReader = new StreamReader(File.OpenRead(@"../../AppRoutes.yaml"));
            //var csvReader = new StreamReader(File.OpenRead($"{dir}{csvLocalRoute}"));
            #endregion

            var index = 0;

            while (!fileReader.EndOfStream)
            {
                var row = fileReader.ReadLine();

                if (index == 0)
                {
                    index++;
                    continue;
                }

                string[] rowValues = row.Split(';');

                var oficinaXml = OficinasReferenceRepository.createOficinaObject(rowValues);
                oficinas.Add(oficinaXml);
            }

            return oficinas;
        }

        /// <summary>
        /// Read a comparing CSV file (MyBusiness.csv) and fills an Oficina objects list with its content.
        /// </summary>
        /// <param name="csvLocalRoute"></param>
        /// <returns></returns>
        public static List<Models.ComparingCSV.Oficina> readComparingCSV(string csvLocalRoute)
        {
            List<Models.ComparingCSV.Oficina> oficinas = new List<Models.ComparingCSV.Oficina>();
            var a = YamlReader.ReadYml("fileRoutes", "MyBusinessRoute");

            Stream file = File.OpenRead(csvLocalRoute);
            var fileReader = new StreamReader(file);

            var index = 0;

            while (!fileReader.EndOfStream)
            {
                var row = fileReader.ReadLine();

                if (index == 0)
                {
                    index++;
                    continue;
                }

                string[] rowValues = row.Split(';');

                var oficinaXml = OficinasComparingRepository.createOficinaObject(rowValues);
                oficinas.Add(oficinaXml);
            }

            return oficinas;
        }

        /// <summary>
        /// Once given a Reference Oficina object list, this method gives XML format to every element of the list, then creates and
        /// writes one XML file containing the data of that Oficina object.
        /// </summary>
        /// <param name="oficinaList"></param>
        /// <returns></returns>
        public static bool writeXML(List<Oficina> oficinaList)
        {
            foreach (Oficina oficina in oficinaList)
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(Oficina));
                var xml = "";

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xsSubmit.Serialize(writer, oficina);
                        xml = sww.ToString(); 

                        //TODO: Write the resulting file wherever it must be written.
                        WriteXMLInPath(PrintXML(xml), $"c:/Users/breogan.beceirocasti/Desktop/FicherosGenerados/{oficina.codigoTienda}.xml");
                    }
                }
                
            }

            return true;
        }

        /// <summary>
        /// Once given a Comparing Oficina object list, this method gives XML format to every element of the list, then creates and
        /// writes one XML file containing the data of that Oficina object.
        /// </summary>
        /// <param name="oficinaList"></param>
        /// <returns></returns>
        public static bool writeXML(List<Models.ComparingCSV.Oficina> oficinaList)
        {
            foreach (Models.ComparingCSV.Oficina oficina in oficinaList)
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(Models.ComparingCSV.Oficina));
                var xml = "";

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xsSubmit.Serialize(writer, oficina);
                        xml = sww.ToString();

                        //TODO: Write the resulting file wherever it must be written.
                        WriteXMLInPath(PrintXML(xml), $"c:/Users/breogan.beceirocasti/Desktop/FicherosGenerados/{oficina.id}.xml");
                    }
                }

            }

            return true;
        }

        /// <summary>
        /// Generates a XML formatted string.
        /// </summary>
        /// <param name="xml">Unformatted xml string.</param>
        /// <returns>The XML formatted string.</returns>
        private static string PrintXML(string xml)
        {
            string result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(xml);

                writer.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                string formattedXml = sReader.ReadToEnd();

                result = formattedXml;
            }
            catch (XmlException e)
            {
                var _ = e.Message;
            }

            mStream.Close();
            writer.Close();

            return result;
        }

        private static void WriteXMLInPath(string Text,string path)
        {
            File.WriteAllText(path, Text);
        }
    }
}

