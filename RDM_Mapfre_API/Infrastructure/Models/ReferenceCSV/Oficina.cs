using System.Collections.Generic;
using System.Runtime.InteropServices;

//  CSV A COMPARAR --> MyBusiness.csv

namespace RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV
{
    public class Oficina
    {
        public string id { get; set; }

        public string denominacion { get; set; }

        public string ceco { get; set; }

        public string idOficinaDirecta { get; set; }

        public string idOficinaDelegada { get; set; }

        public string idDirTerritorial { get; set; }

        public string denominacionDirTerritorial { get; set; } // NO SE TIENE QUE REFLEJAR EN EL XML?? (PÁGINA 8 DEL DOCUMENTO DE Mapfre)

        public string idDGT { get; set; }

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


        public static bool operator ==(Models.ComparingCSV.Oficina comparingOficina, Models.ReferenceCSV.Oficina referenceOficina)
        {
            if (referenceOficina.id != comparingOficina.id)
            {
                return false;
            }

            if (referenceOficina.ceco != comparingOficina.ceco)
            {
                return false;
            }

            if (referenceOficina.idOficinaDirecta != comparingOficina.idOficinaDirecta)
            {
                return false;
            }

            if (referenceOficina.idOficinaDelegada != comparingOficina.idOficinaDelegada)
            {
                return false;
            }

            if (referenceOficina.idDGT != comparingOficina.idDGT)
            {
                return false;
            }

            if (referenceOficina.idDirTerritorial != comparingOficina.idDirTerritorial)
            {
                return false;
            }

            if (referenceOficina.fax != comparingOficina.fax)
            {
                return false;
            }

            if (referenceOficina.denominacionLocalidad != comparingOficina.denominacionLocalidad)
            {
                //OJO!! PUEDE NO SER LO MISMO
                return false;
            }

            return true;
        }

        public static bool operator !=(Models.ComparingCSV.Oficina comparingOficina, Models.ReferenceCSV.Oficina referenceOficina)
        {
            if (referenceOficina.id != comparingOficina.id)
            {
                return true;
            }

            if (referenceOficina.ceco != comparingOficina.ceco)
            {
                return true;
            }

            if (referenceOficina.idOficinaDirecta != comparingOficina.idOficinaDirecta)
            {
                return true;
            }

            if (referenceOficina.idOficinaDelegada != comparingOficina.idOficinaDelegada)
            {
                return true;
            }

            if (referenceOficina.idDGT != comparingOficina.idDGT)
            {
                return true;
            }

            if (referenceOficina.idDirTerritorial != comparingOficina.idDirTerritorial)
            {
                return true;
            }

            if (referenceOficina.fax != comparingOficina.fax)
            {
                return true;
            }

            if (referenceOficina.denominacionLocalidad != comparingOficina.denominacionLocalidad)
            {
                //OJO!! PUEDE NO SER LO MISMO
                return true;
            }

            return false;
        }
    }

}