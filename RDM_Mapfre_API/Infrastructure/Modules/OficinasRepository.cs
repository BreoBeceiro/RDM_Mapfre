using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDM_Mapfre_API.Infrastructure.Modules
{
    public static class OficinasRepository
    {
        /// <summary>
        /// Declare and initialize one Oficina object instance giving an array of strings.
        /// </summary>
        /// <param name="values">Input array which values will be transfered to the Oficina object.</param>
        /// <returns>The initialized Oficina object.</returns>
        public static Oficina createOficinaObject(string[] values)
        {
            Oficina office = new Oficina()
            {
                id = values[0],
                denominacion = values[1],
                codCeco = values[2],
                codOficinaDirecta = values[3],
                codOficinaDelegada = values[4],
                codDirTerritorial = values[5],
                denominacionDirTerritorial = values[6],
                codDGT = values[7],
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
        /// Declare and initialize one Oficina object instance giving an array of strings.
        /// </summary>
        /// <param name="values">Input array which values will be transfered to the Oficina object.</param>
        /// <returns>The initialized Oficina object.</returns>
        public static Oficina createOficinaObject_Simple(string[] values)
        {
            Oficina office = new Oficina();

            office.id = values[0];
            office.denominacion = values[1];
            office.codCeco = values[2];
            office.codOficinaDirecta = values[3];
            office.codOficinaDelegada = values[4];
            office.codDirTerritorial = values[5];
            office.denominacionDirTerritorial = values[6];
            office.codDGT = values[7];
            office.denominacionDGT = values[8];
            office.codSubcentral = values[9];
            office.denominacionSubcentral = values[10];
            office.claveProduccion = values[11];
            office.codTipo = values[12];
            office.denominacionTipo = values[13];
            office.codTipoVia = values[14];
            office.denominacionTipoVia = values[15];
            office.denominacionVia = values[16];
            office.numeroVia = values[17];
            office.complementoDenominacionVia = values[18];
            office.codigoPostal = values[19];
            office.codProvincia = values[20];
            office.denominacionProvincia = values[21];
            office.codLocalidad = values[22];
            office.denominacionLocalidad = values[23];
            office.telefonosOficina1 = values[24];
            office.telefonosOficina2 = values[25];
            office.telefonosOficina3 = values[26];
            office.fax = values[27];
            office.email = values[28];
            office.horarioNormalW = values[29];
            office.horarioNormalV = values[30];
            office.indHorarioNormalS = values[31];
            office.horarioNormalS = values[32];
            office.horarioVeranoW = values[33];
            office.horarioVeranoV = values[34];
            office.indHorarioVeranoS = values[35];
            office.horarioVeranoS = values[36];
            office.periodoVeranoSN = values[37];
            office.periodoInicioVerano = values[38];
            office.periodoFinVerano = values[39];
            office.horarioObservaciones = values[40];
            office.horarioObservacionesVerano = values[41];

            office.miembros = new Miembros()
            {
                responsables = new List<Responsable>(),
                miembros = new List<Miembro>()
            };

            Responsable responsable1 = new Responsable()
            {
                codigo = values[42],
                nombre = values[43],
                nuuma = values[44],
                perfil = values[45],
                email = values[46]
            };

            Responsable responsable2 = new Responsable()
            {
                codigo = values[47],
                nombre = values[48],
                nuuma = values[49],
                perfil = values[50],
                email = values[51]
            };

            office.miembros.responsables.Add(responsable1);
            office.miembros.responsables.Add(responsable2);

            Miembro miembro1 = new Miembro()
            {
                nombre = values[52],
                nuuma = values[53],
                perfil = values[54],
                email = values[55]
            };

            Miembro miembro2 = new Miembro()
            {
                nombre = values[56],
                nuuma = values[57],
                perfil = values[58],
                email = values[59]
            };

            Miembro miembro3 = new Miembro()
            {
                nombre = values[60],
                nuuma = values[61],
                perfil = values[62],
                email = values[63]
            };

            Miembro miembro4 = new Miembro()
            {
                nombre = values[64],
                nuuma = values[65],
                perfil = values[66],
                email = values[67]
            };

            Miembro miembro5 = new Miembro()
            {
                nombre = values[68],
                nuuma = values[69],
                perfil = values[70],
                email = values[71]
            };

            office.miembros.miembros.Add(miembro1);
            office.miembros.miembros.Add(miembro2);
            office.miembros.miembros.Add(miembro3);
            office.miembros.miembros.Add(miembro4);
            office.miembros.miembros.Add(miembro5);

            return office;
        }
    }
}
