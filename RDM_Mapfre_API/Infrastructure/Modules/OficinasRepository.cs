using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDM_Mapfre_API.Infrastructure.Modules
{
    public static class OficinasRepository
    {
        public static Oficina createOficina(string[] values)
        {
            Oficina office = new Oficina()
            {
                //id
                denominacion = values[1],
                codCeco = values[2],
                codOficinaDirecta = values[3],
                codOficinaDelegada = values[4],
                //codDirTerritorial,
                //denominacionDirTerritorial,
                codDGT = values[7],
                //denominacionDGT
                //codSubcentral
                //denominacionSubcentral
                claveProduccion = values[11],
                //codTipo
                //denominacionTipo
                //codTipoVia
                //denominacionTipoVia
                //denominacionVia
                //numeroVia
                //complementoDenominacionVia
                codigoPostal = values[19],
                codProvincia = values[20],
                //denominacionProvincia
                codLocalidad = values[22],
                //denominacionLocalidad
                //telefonosOficina1
                //telefonosOficina2
                //telefonosOficina3
                fax = values[25],
                //email

                //horarioNormalW
                //horarioNormalV
                //indHorarioNormalS
                //horarioNormalS
                //horarioVeranoW
                //horarioVeranoV
                //indHorarioVeranoS
                //horarioVeranoS
                //periodoVeranoSN
                //periodoInicioVerano
                //periodoFinVerano
                //horarioObservaciones
                //horarioObservacionesVerano

                //CODIGO DEL RESPONSABLE
                //NOMBRE DEL RESPONSABLE
                //NUUMA RESPONSABLE
                //PERFIL RESPONSABLE
                //EMAIL RESPONSABLE

                //CODIGO DEL RESPONSABLE2
                //NOMBRE DEL RESPONSABLE2
                //NUUMA RESPONSABLE2
                //PERFIL RESPONSABLE2
                //EMAIL RESPONSABLE2

                //NOMBRE DEL MIEMBRO1
                //NUUMA MIEMBRO1
                //PERFIL MIEMBRO1
                //EMAIL MIEMBRO1

                //NOMBRE DEL MIEMBRO2
                //NUUMA MIEMBRO2
                //PERFIL MIEMBRO2
                //EMAIL MIEMBRO2

                //NOMBRE DEL MIEMBRO3
                //NUUMA MIEMBRO3
                //PERFIL MIEMBRO3
                //EMAIL MIEMBRO3

                //NOMBRE DEL MIEMBRO4
                //NUUMA MIEMBRO4
                //PERFIL MIEMBRO4
                //EMAIL MIEMBRO4

                //NOMBRE DEL MIEMBRO5
                //NUUMA MIEMBRO5
                //PERFIL MIEMBRO5
                //EMAIL MIEMBRO5
            };

            return office;
        }
    }
}
