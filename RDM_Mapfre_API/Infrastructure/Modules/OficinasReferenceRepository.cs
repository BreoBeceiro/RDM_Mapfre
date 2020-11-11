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
                id = values[0],
                denominacion = values[1],
                ceco = values[2],
                idOficinaDirecta = values[3],
                idOficinaDelegada = values[4],
                idDirTerritorial = values[5],
                denominacionDirTerritorial = values[6],
                idDGT = values[7],
                denominacionDGT = values[8],
                codSubcentral = values[9],
                denominacionSubcentral = values[10],
                claveProduccion = values[11],
                codTipo = values[12],
                denominacionTipo = values[13],
                codTipoVia = values[14],
                denominacionTipoVia = values[15],
                denominacionVia = values[16],
                numeroVia = values[17],
                complementoDenominacionVia = values[18],
                codigoPostal = values[19],
                codProvincia = values[20],
                denominacionProvincia = values[21],
                codLocalidad = values[22],
                denominacionLocalidad = values[23],
                telefonosOficina1 = values[24],
                telefonosOficina2 = values[25],
                telefonosOficina3 = values[26],
                fax = values[27],
                email = values[28],

                horarioNormalW = values[29],
                horarioNormalV = values[30],
                indHorarioNormalS = values[31],
                horarioNormalS = values[32],
                horarioVeranoW = values[33],
                horarioVeranoV = values[34],
                indHorarioVeranoS = values[35],
                horarioVeranoS = values[36],
                periodoVeranoSN = values[37],
                periodoInicioVerano = values[38],
                periodoFinVerano = values[39],
                horarioObservaciones = values[40],
                horarioObservacionesVerano = values[41],

                miembros = new Miembros()
                {
                    responsables = new List<Responsable>()
                    {
                        new Responsable()
                        {
                            codigo = values[42],
                            nombre = values[43],
                            nuuma = values[44],
                            perfil = values[45],
                            email = values[46]
                        },
                        new Responsable()
                        {
                            codigo = values[47],
                            nombre = values[48],
                            nuuma = values[49],
                            perfil = values[50],
                            email = values[51]
                        }
                    },

                    miembros = new List<Miembro>()
                    {
                        new Miembro()
                        {
                            nombre = values[52],
                            nuuma = values[53],
                            perfil = values[54],
                            email = values[55]
                        },
                        new Miembro()
                        {
                            nombre = values[56],
                            nuuma = values[57],
                            perfil = values[58],
                            email = values[59]
                        },
                        new Miembro()
                        {
                            nombre = values[60],
                            nuuma = values[61],
                            perfil = values[62],
                            email = values[63]
                        },
                        new Miembro()
                        {
                            nombre = values[64],
                            nuuma = values[65],
                            perfil = values[66],
                            email = values[67]
                        },
                        new Miembro()
                        {
                            nombre = values[68],
                            nuuma = values[69],
                            perfil = values[70],
                            email = values[71]
                        }
                    }
                }
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
                idList.Add(office.id);
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
                    if (office.id == _id)
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
