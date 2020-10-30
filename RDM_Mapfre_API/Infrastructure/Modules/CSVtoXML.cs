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
        //Puede modularizarse un método readCSV() que reciba la ruta al arhivo y devuelva la colección de datos (el total de oficinas).
        //Métodos para comparar los CSVs y obtener las listas de oficinas (de alta, de baja y de modificación).
        //¿Método para obtener la ruta al fichero necesario por medio del YAML?

        //Método para probar la generación de una lista de objetos Oficina dado un CSV (se le extraerán responsabilidades):

        public static List<Oficina> csvToXML(string csvLocalRoute)
        {
            //TODO CHAPU PARA LEER DE LA BASE DE LA APP
            string dir = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");

            List<Oficina> oficinas = new List<Oficina>();

            using (var csvReader = new StreamReader(File.OpenRead($"{dir}{csvLocalRoute}")))
            {
                while (!csvReader.EndOfStream)
                {
                    var row = csvReader.ReadLine();

                    string[] rowValues = row.Split(';');

                    var oficinaXml = OficinasRepository.createOficina(rowValues);
                    oficinas.Add(oficinaXml);

                    Console.WriteLine(rowValues);
                }
            }
            return oficinas;
        }





        /// <summary>
        /// Lee un fichero CSV ubicado en el equipo y genera un XML con los datos del CSV en la ruta indicada.
        /// </summary>
        /// <param name="xmlCreationRoute">Ruta local en la que se creará el documento XML resultante.</param>
        public static void writeXML(string xmlCreationRoute)
        {
            //De este método se pueden extraer responsabilidades.

            //TODO: EJEMPLO DE LECTURA DE YAML
            var a = YamlReader.ReadYml("fileRoutes", "MyBusinessRoute");


            XmlWriter xmlWriter = XmlWriter.Create(xmlCreationRoute);
            XmlWriterSettings settings = new XmlWriterSettings();
            Stream file = File.OpenRead($"C:\\Users\\breogan.beceirocasti\\Desktop\\RDM\\MyBusiness_21072020.csv");

            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;

            var fileReader = new StreamReader(file);
            //OJO: EL PRIMER PARÁMETRO DE Create ES EL FLUJO DE SALIDA, NO EL DE ENTRADA (CORREGIR).
            //xmlWriter = XmlWriter.Create(file, settings);

            var index = 0;

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("oficina");

            while (!fileReader.EndOfStream)
            {
                if (index == 0)
                {
                    index++;
                    continue;
                }

                var row = fileReader.ReadLine();

                string[] fields = row.Split(';');

                xmlWriter.WriteStartElement("codigoOficina");
                xmlWriter.WriteElementString("codigo", fields[0].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionOficina");
                xmlWriter.WriteElementString("denominacion", fields[1].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoCeco");
                xmlWriter.WriteElementString("ceco", fields[2].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoOficinaDirecta");
                xmlWriter.WriteElementString("oficinaDirecta", fields[3].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoOficinaDelegada");
                xmlWriter.WriteElementString("oficinaDelegada", fields[4].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoDT");
                xmlWriter.WriteElementString("codDT", fields[5].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionDT");
                xmlWriter.WriteElementString("denomDT", fields[6].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoDGT");
                xmlWriter.WriteElementString("codDGT", fields[7].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionDGT");
                xmlWriter.WriteElementString("denomDGT", fields[8].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoSubcentral");
                xmlWriter.WriteElementString("codSubcentral", fields[9].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionSubcentral");
                xmlWriter.WriteElementString("denomSubcentral", fields[10].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("claveProduccion");
                xmlWriter.WriteElementString("claveProd", fields[11].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codTipoOficina");
                xmlWriter.WriteElementString("codTipoOf", fields[12].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionTipoOficina");
                xmlWriter.WriteElementString("denomTipo", fields[13].ToString());
                xmlWriter.WriteEndElement();

                //DIRECCIÓN...
                xmlWriter.WriteStartElement("codigoTipoVia");
                xmlWriter.WriteElementString("codTipoVia", fields[14].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionTipoVia");
                xmlWriter.WriteElementString("denomTipoVia", fields[15].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionVia");
                xmlWriter.WriteElementString("denomVia", fields[16].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("numeroVia");
                xmlWriter.WriteElementString("numVia", fields[17].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("complementoDenominacionVia");
                xmlWriter.WriteElementString("compDenomVia", fields[18].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoPostal");
                xmlWriter.WriteElementString("codPostal", fields[19].ToString());
                xmlWriter.WriteEndElement();

                 //PROVINCIA...
                xmlWriter.WriteStartElement("codigoProvincia");
                xmlWriter.WriteElementString("codProvincia", fields[20].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionProvincia");
                xmlWriter.WriteElementString("denomProvincia", fields[21].ToString());
                xmlWriter.WriteEndElement();

                //LOCALIDAD...
                xmlWriter.WriteStartElement("codigoLocalidad");
                xmlWriter.WriteElementString("codLocalidad", fields[22].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionLocalidad");
                xmlWriter.WriteElementString("denomLocalidad", fields[23].ToString());
                xmlWriter.WriteEndElement();

                //TELÉFONOS...
                xmlWriter.WriteStartElement("telefonosOficina1");
                xmlWriter.WriteElementString("tlfsOficina1", fields[24].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("telefonosOficina2");
                xmlWriter.WriteElementString("tlfsOficina2", fields[25].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("telefonosOficina3");
                xmlWriter.WriteElementString("tlfsOficina3", fields[26].ToString());
                xmlWriter.WriteEndElement();

                //FAX/CORREO...
                xmlWriter.WriteStartElement("faxOficina");
                xmlWriter.WriteElementString("fax", fields[27].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("emailOficina");
                xmlWriter.WriteElementString("email", fields[28].ToString());
                xmlWriter.WriteEndElement();

                //HORARIOS:
                xmlWriter.WriteStartElement("horarioNormalW");
                xmlWriter.WriteElementString("horaNormalW", fields[29].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioNormalV");
                xmlWriter.WriteElementString("horaNormalV", fields[30].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("indHorarioNormalS");
                xmlWriter.WriteElementString("indHoraNormalS", fields[31].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioNormalS");
                xmlWriter.WriteElementString("horaNormalS", fields[32].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioVeranoW");
                xmlWriter.WriteElementString("horaVeranoW", fields[33].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioVeranoV");
                xmlWriter.WriteElementString("horaVeranoV", fields[34].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("indHorarioVeranoS");
                xmlWriter.WriteElementString("indHoraVeranoS", fields[35].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioVeranoS");
                xmlWriter.WriteElementString("horarioVeranoS", fields[36].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("periodoVeranoSN");
                xmlWriter.WriteElementString("perVeranoSN", fields[37].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("periodoInicioVerano");
                xmlWriter.WriteElementString("perInicioVerano", fields[38].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("periodoFinVerano");
                xmlWriter.WriteElementString("perFinVerano", fields[39].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioObservaciones");
                xmlWriter.WriteElementString("horaObservaciones", fields[40].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioObservacionesVerano");
                xmlWriter.WriteElementString("horaObservacionesVerano", fields[41].ToString());
                xmlWriter.WriteEndElement();

                //RESPONSABLE1...

                //RESPONSABLE2...

                //MIEMBRO1...

                //MIEMBRO2...

                //MIEMBRO3...

                //MIEMBRO4...

                //MIEMBRO5...
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
        }

        //XML generado con objetos (POTENCIALMENTE OBSOLETO):
        public static void arrayToXML_Object(string xmlCreationRoute)
        {
            XmlWriter xmlWriter = XmlWriter.Create(xmlCreationRoute);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("oficina");



            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
        }

        public static bool OficinaObjectToXml(List<Oficina> ofincinaList)
        {
            foreach (Oficina oficina in ofincinaList)
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(Oficina));
                var xml = "";

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xsSubmit.Serialize(writer, oficina);
                        xml = sww.ToString(); // MI XML
                        //TODO ESCRIBIR EL XML EN LA RUTA QUE CORRESPONDA
                        WriteXMLInPath(PrintXML(xml), $"c:/ficherosOut/{oficina.id}.xml");
                    }
                }

            }

            return true;
        }

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
            catch (XmlException)
            {
                // Handle the exception
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

