using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using YamlDotNet.RepresentationModel;

namespace RDM_Mapfre_API.Infrastructure.Modules
{
    public static class CSVtoXML
    {
        //Métodos para comparar los CSVs y obtener las listas de oficinas (de alta, de baja y de modificación).

        /// <summary>
        /// Read a CSV file and fills an Oficina objects list with its content.
        /// </summary>
        /// <param name="csvLocalRoute">Local route where CSV will be found.</param>
        /// <returns>The resulting Oficina objects list.</returns>
        public static List<Oficina> readCSV(string csvLocalRoute)
        {
            List<Oficina> oficinas = new List<Oficina>();

            Stream file = File.OpenRead($"C:\\Users\\breogan.beceirocasti\\Desktop\\RDM\\MyBusiness_21072020.csv");
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

                var oficinaXml = OficinasRepository.createOficinaObject(rowValues);
                oficinas.Add(oficinaXml);
            }

            return oficinas;
        }

        /// <summary>
        /// Lee un fichero CSV ubicado en el equipo y genera un XML con los datos del CSV en la ruta indicada.
        /// </summary>
        /// <param name="xmlCreationRoute">Ruta local en la que se creará el documento XML resultante.</param>
        public static void writeXML(List<Oficina> offices, string xmlCreationRoute)
        {
            XmlWriter xmlWriter = XmlWriter.Create(xmlCreationRoute);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("oficina");

            foreach(Oficina office in offices) 
            { 
                //office = OficinasRepository.createOficinaObject(fields);

                xmlWriter.WriteStartElement("codigoOficina");
                xmlWriter.WriteElementString("codigo", office.id);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionOficina");
                xmlWriter.WriteElementString("denominacion", office.denominacion);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoCeco");
                xmlWriter.WriteElementString("ceco", office.codCeco);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoOficinaDirecta");
                xmlWriter.WriteElementString("oficinaDirecta", office.codOficinaDirecta);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoOficinaDelegada");
                xmlWriter.WriteElementString("oficinaDelegada", office.codOficinaDelegada);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoDT");
                xmlWriter.WriteElementString("codDT", office.codDirTerritorial);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionDT");
                xmlWriter.WriteElementString("denomDT", office.denominacionDirTerritorial);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoDGT");
                xmlWriter.WriteElementString("codDGT", office.codDGT);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionDGT");
                xmlWriter.WriteElementString("denomDGT", office.denominacionDGT);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoSubcentral");
                xmlWriter.WriteElementString("codSubcentral", office.codSubcentral);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionSubcentral");
                xmlWriter.WriteElementString("denomSubcentral", office.denominacionSubcentral);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("claveProduccion");
                xmlWriter.WriteElementString("claveProd", office.claveProduccion);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codTipoOficina");
                xmlWriter.WriteElementString("codTipoOf", office.codTipo);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionTipoOficina");
                xmlWriter.WriteElementString("denomTipo", office.denominacionTipo);
                xmlWriter.WriteEndElement();

                //DIRECCIÓN...
                xmlWriter.WriteStartElement("codigoTipoVia");
                xmlWriter.WriteElementString("codTipoVia", office.codTipoVia);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionTipoVia");
                xmlWriter.WriteElementString("denomTipoVia", office.denominacionTipoVia);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionVia");
                xmlWriter.WriteElementString("denomVia", office.denominacionVia);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("numeroVia");
                xmlWriter.WriteElementString("numVia", office.numeroVia);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("complementoDenominacionVia");
                xmlWriter.WriteElementString("compDenomVia", office.complementoDenominacionVia);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("codigoPostal");
                xmlWriter.WriteElementString("codPostal", office.codigoPostal);
                xmlWriter.WriteEndElement();

                 //PROVINCIA...
                xmlWriter.WriteStartElement("codigoProvincia");
                xmlWriter.WriteElementString("codProvincia", office.codProvincia);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionProvincia");
                xmlWriter.WriteElementString("denomProvincia", office.denominacionProvincia);
                xmlWriter.WriteEndElement();

                //LOCALIDAD...
                xmlWriter.WriteStartElement("codigoLocalidad");
                xmlWriter.WriteElementString("codLocalidad", office.codLocalidad);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("denominacionLocalidad");
                xmlWriter.WriteElementString("denomLocalidad", office.denominacionLocalidad);
                xmlWriter.WriteEndElement();

                //TELÉFONOS...
                xmlWriter.WriteStartElement("telefonosOficina1");
                xmlWriter.WriteElementString("tlfsOficina1", office.telefonosOficina1);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("telefonosOficina2");
                xmlWriter.WriteElementString("tlfsOficina2", office.telefonosOficina2);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("telefonosOficina3");
                xmlWriter.WriteElementString("tlfsOficina3", office.telefonosOficina3);
                xmlWriter.WriteEndElement();

                //FAX/CORREO...
                xmlWriter.WriteStartElement("faxOficina");
                xmlWriter.WriteElementString("fax", office.fax);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("emailOficina");
                xmlWriter.WriteElementString("email", office.email);
                xmlWriter.WriteEndElement();

                //HORARIOS:
                xmlWriter.WriteStartElement("horarioNormalW");
                xmlWriter.WriteElementString("horaNormalW", office.horarioNormalW);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioNormalV");
                xmlWriter.WriteElementString("horaNormalV", office.horarioNormalV);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("indHorarioNormalS");
                xmlWriter.WriteElementString("indHoraNormalS", office.indHorarioNormalS);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioNormalS");
                xmlWriter.WriteElementString("horaNormalS", office.horarioNormalS);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioVeranoW");
                xmlWriter.WriteElementString("horaVeranoW", office.horarioVeranoW);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioVeranoV");
                xmlWriter.WriteElementString("horaVeranoV", office.horarioVeranoV);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("indHorarioVeranoS");
                xmlWriter.WriteElementString("indHoraVeranoS", office.indHorarioVeranoS);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioVeranoS");
                xmlWriter.WriteElementString("horarioVeranoS", office.horarioVeranoS);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("periodoVeranoSN");
                xmlWriter.WriteElementString("perVeranoSN", office.periodoVeranoSN);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("periodoInicioVerano");
                xmlWriter.WriteElementString("perInicioVerano", office.periodoInicioVerano);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("periodoFinVerano");
                xmlWriter.WriteElementString("perFinVerano", office.periodoFinVerano);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioObservaciones");
                xmlWriter.WriteElementString("horaObservaciones", office.horarioObservaciones);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("horarioObservacionesVerano");
                xmlWriter.WriteElementString("horaObservacionesVerano", office.horarioObservacionesVerano);
                xmlWriter.WriteEndElement();

                //TODO: Create XML tags for every Responsable/Miembro object property in:

                //RESPONSABLE1...
                xmlWriter.WriteStartElement("responsable");
                xmlWriter.WriteElementString("responsble", office.miembros.responsables.ElementAt(0).ToString());
                xmlWriter.WriteEndElement();

                //RESPONSABLE2...
                xmlWriter.WriteStartElement("responsable");
                xmlWriter.WriteElementString("responsble", office.miembros.responsables.ElementAt(1).ToString());
                xmlWriter.WriteEndElement();

                //MIEMBRO1...
                xmlWriter.WriteStartElement("miembro");
                xmlWriter.WriteElementString("", office.miembros.miembros.ElementAt(0).ToString());
                xmlWriter.WriteEndElement();

                //MIEMBRO2...
                xmlWriter.WriteStartElement("miembro");
                xmlWriter.WriteElementString("", office.miembros.miembros.ElementAt(1).ToString());
                xmlWriter.WriteEndElement();

                //MIEMBRO3...
                xmlWriter.WriteStartElement("miembro");
                xmlWriter.WriteElementString("", office.miembros.miembros.ElementAt(2).ToString());
                xmlWriter.WriteEndElement();

                //MIEMBRO4...
                xmlWriter.WriteStartElement("miembro");
                xmlWriter.WriteElementString("", office.miembros.miembros.ElementAt(3).ToString());
                xmlWriter.WriteEndElement();

                //MIEMBRO5...
                xmlWriter.WriteStartElement("miembro");
                xmlWriter.WriteElementString("", office.miembros.miembros.ElementAt(4).ToString());
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
        }
    }
}

