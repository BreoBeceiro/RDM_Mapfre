using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// CSV DE REFERENCIA --> ListadoOficinas.csv 

namespace RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV
{
    /// <summary>
    /// Oficina object from the CSV file which will be compared with the referenceCSV Oficina object.
    /// </summary>
    public class Oficina
    {
        public string codigoTienda { get; set; }

        public string nombreEmpresa { get; set; }

        public string categoriaPrincipal { get; set; }

        public string direccionLinea1 { get; set; }

        public string direccionLinea2 { get; set; }

        public string direccionLinea3 { get; set; }

        public string direccionLinea4 { get; set; }

        public string direccionLinea5 { get; set; }

        public string municipio { get; set; }

        public string areaAdministrativa { get; set; }

        public string pais { get; set; }

        public string codigoPostal { get; set; }

        public string telefonoPrincipal { get; set; }

        public string fax { get; set; }

        public string horarioLunes { get; set; }

        public string horarioMartes { get; set; }

        public string horarioMiercoles { get; set; }

        public string horarioJueves { get; set; }

        public string horarioViernes { get; set; }

        public string horarioSabado { get; set; }

        public string periodoVerano { get; set; }

        public string abiertoSabados { get; set; }

        public Miembro miembro1 { get; set; }

        public Miembro miembro2 { get; set; }

        public string otrosTelefonos { get; set; }

        public string horarioEspecial { get; set; }

        public string desdeLaEmpresa { get; set; }

        public string fechaDeApertura { get; set; }

        public string fotoDePerfil { get; set; }

        public string fotoDePortada { get; set; }

        public string otrasFotos { get; set; }

        public string fotoPreferida { get; set; }

        public string latitud { get; set; }

        public string longitud { get; set; }

        public string sitioWeb { get; set; }

        public string idDGT { get; set; }

        public string idDirTerritorial { get; set; }

        public string idOficinaDirecta { get; set; }

        public string idOficinaDelegada { get; set; }

        public string ceco { get; set; }


        public static bool operator ==(Models.ReferenceCSV.Oficina referenceOficina, Models.ComparingCSV.Oficina comparingOficina)
        {
            return referenceOficina.codigoTienda == comparingOficina.id ? true : false;

        }

        public static bool operator !=(Models.ReferenceCSV.Oficina referenceOficina, Models.ComparingCSV.Oficina comparingOficina)
        {
            return referenceOficina.codigoTienda != comparingOficina.id ? true : false; ;
        }
    }
}
