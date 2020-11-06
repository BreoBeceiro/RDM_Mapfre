using System.Collections.Generic;
using System.Runtime.InteropServices;

//  CSV A COMPARAR --> MyBusiness.csv

namespace RDM_Mapfre_API.Infrastructure.Models.ComparingCSV
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Oficina
    {
        public string id { get; set; }

        public string denominacion { get; set; }

        public string codCeco { get; set; }

        public string codOficinaDirecta { get; set; }

        public string codOficinaDelegada { get; set; }

        public string codDirTerritorial { get; set; }

        public string denominacionDirTerritorial { get; set; }

        public string codDGT { get; set; }

        public string denominacionDGT { get; set; }

        public string codSubcentral { get; set; }

        public string denominacionSubcentral { get; set; }

        public string claveProduccion { get; set; }

        public string codTipo { get; set; }

        public string denominacionTipo { get; set; }

        public string codTipoVia { get; set; }

        public string denominacionTipoVia { get; set; }

        public string denominacionVia { get; set; }

        public string numeroVia { get; set; }

        public string complementoDenominacionVia { get; set; }

        public string codigoPostal { get; set; }

        public string codProvincia { get; set; }

        public string denominacionProvincia { get; set; }

        public string codLocalidad { get; set; }

        public string denominacionLocalidad { get; set; }

        public string telefonosOficina1 { get; set; }

        public string telefonosOficina2 { get; set; }

        public string telefonosOficina3 { get; set; }

        public string fax { get; set; }

        public string email { get; set; }

        public string horarioNormalW { get; set; }

        public string horarioNormalV { get; set; }

        public string indHorarioNormalS { get; set; }

        public string horarioNormalS { get; set; }

        public string horarioVeranoW { get; set; }

        public string horarioVeranoV { get; set; }

        public string indHorarioVeranoS { get; set; }

        public string horarioVeranoS { get; set; }

        public string periodoVeranoSN { get; set; }

        public string periodoInicioVerano { get; set; }

        public string periodoFinVerano { get; set; }

        public string horarioObservaciones { get; set; }

        public string horarioObservacionesVerano { get; set; }

        public Miembros miembros { get; set; }


        public static bool operator ==(Models.ComparingCSV.Oficina referenceOficina, Models.ReferenceCSV.Oficina comparingOficina)
        {
            if (referenceOficina.id != comparingOficina.codigoTienda)
            {
                return false;
            }
            else if (referenceOficina.codCeco != comparingOficina.ceco)
            {
                return false;
            }
            else if (referenceOficina.codOficinaDirecta != comparingOficina.idOficinaDirecta)
            {
                return false;
            }
            else if (referenceOficina.codOficinaDelegada != comparingOficina.idOficinaDelegada)
            {
                return false;
            }
            else if (referenceOficina.codDGT != comparingOficina.idDGT)
            {
                return false;
            }
            else if (referenceOficina.codDirTerritorial != comparingOficina.idDirTerritorial)
            {
                return false;
            }
            else if (referenceOficina.fax != comparingOficina.fax)
            {
                return false;
            }
            else if(referenceOficina.denominacionLocalidad != comparingOficina.municipio)
            {
                //OJO!! PUEDE NO SER LO MISMO
                return false;
            }

            return true;
        }

        public static bool operator !=(Models.ComparingCSV.Oficina referenceOficina, Models.ReferenceCSV.Oficina comparingOficina)
        {
            if (referenceOficina.id != comparingOficina.codigoTienda)
            {
                return true;
            }
            else if (referenceOficina.codCeco != comparingOficina.ceco)
            {
                return true;
            }
            else if (referenceOficina.codOficinaDirecta != comparingOficina.idOficinaDirecta)
            {
                return true;
            }
            else if (referenceOficina.codOficinaDelegada != comparingOficina.idOficinaDelegada)
            {
                return true;
            }
            else if (referenceOficina.codDGT != comparingOficina.idDGT)
            {
                return true;
            }
            else if (referenceOficina.codDirTerritorial != comparingOficina.idDirTerritorial)
            {
                return true;
            }
            else if (referenceOficina.fax != comparingOficina.fax)
            {
                return true;
            }
            else if (referenceOficina.denominacionLocalidad != comparingOficina.municipio)
            {
                //OJO!! PUEDE NO SER LO MISMO
                return true;
            }
            return false;
        }
    }

}