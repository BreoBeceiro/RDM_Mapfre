using RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDM_Mapfre_API.Infrastructure.Modules
{
    public static class OficinasReferenceRepository
    {
        /// <summary>
        /// Declare and initialize one Reference Oficina object instance giving an array of strings.
        /// </summary>
        /// <param name="values">Input array which values will be transfered to the Oficina object.</param>
        /// <returns>The initialized Oficina object.</returns>
        public static Oficina createOficinaObject(string[] values)
        {
            Oficina office = new Oficina()
            {
                codigoTienda = values[0],
                nombreEmpresa = values[1],
                categoriaPrincipal = values[2],
                direccionLinea1 = values[3],
                direccionLinea2 = values[4],
                direccionLinea3 = values[5],
                direccionLinea4 = values[6],
                direccionLinea5 = values[7],
                municipio = values[8],
                areaAdministrativa = values[9],
                pais = values[10],
                codigoPostal = values[11],
                telefonoPrincipal = values[12],
                fax = values[13],
                horarioLunes = values[14],
                horarioMartes = values[15],
                horarioMiercoles = values[16],
                horarioJueves = values[17],
                horarioViernes = values[18],
                horarioSabado = values[19],
                periodoVerano = values[20],
                abiertoSabados = values[21],

                miembro1 = new Miembro()
                {
                    nombre = values[22],
                    nuuma = values[23],
                    perfil = values[24],
                    email = values[25]
                },

                miembro2 = new Miembro()
                {
                    nombre = values[26],
                    nuuma = values[27],
                    perfil = values[28],
                    email = values[29]
                },

                otrosTelefonos = values[30],
                horarioEspecial = values[31],
                desdeLaEmpresa = values[32],
                fechaDeApertura = values[33],
                fotoDePerfil = values[34],
                fotoDePortada = values[35],
                otrasFotos = values[36],
                fotoPreferida = values[37],
                latitud = values[38],
                longitud = values[39],
                sitioWeb = values[40],
                idDGT = values[41],
                idDirTerritorial = values[42],
                idOficinaDirecta = values[43],
                idOficinaDelegada = values[44],
                ceco = values[45]
            };

            return office;
        }

        /// <summary>
        /// Go over the Oficina objects list collecting the ids in a new list.
        /// </summary>
        /// <param name="offices">The Oficina objects list whose ids will be collected.</param>
        /// <returns>A list of string which are the Oficinas id.</returns>
        public static List<string> getOficinasId(List<Models.ReferenceCSV.Oficina> offices)
        {
            List<string> idList = new List<string>();

            foreach (Models.ReferenceCSV.Oficina office in offices)
            {
                idList.Add(office.codigoTienda);
            }

            return idList;
        }

        /// <summary>
        /// Find an Oficina object according to a given id.
        /// </summary>
        /// <param name="offices">Oficina objects list where the expected Oficina is placed.</param>
        /// <param name="_id">The single identificator of the Oficina object that want to be recovered.</param>
        /// <returns>The Oficina object once found or NULL if it was not (or if an exception took place).</returns>
        public static Models.ReferenceCSV.Oficina getOficinaById(List<Models.ReferenceCSV.Oficina> offices, string _id)
        {
            Models.ReferenceCSV.Oficina foundOficina = null;

            try
            {
                foreach (var office in offices)
                {
                    if (office.codigoTienda == _id)
                    {
                        foundOficina = office;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                var _ = e.Message;
                foundOficina = null;
            }

            return foundOficina;
        }
    }
}
