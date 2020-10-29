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
                //CODIGO OFICINA
                denominacion = values[1],
                ceco = values[2],
                idOficinaDirecta = values[3],
                idOficinaDelegada = values[4],
                //CODIGO DT,
                //DENOMINACION DT,
                idDGT = values[7],
                //DENOMINACION DGT
                //CODIGO SUBCENTRAL
                //DENOMINACION SUBCENTRAL
                clave_prod = values[11],
                //CODIGO TIPO OFICINA (en el objeto Oficina hay TIPO y TIPODEOFICINA)
                //DENOMINACION TIPO DE OFICINA
                //CODIGO TIPO VIA
                //DENOMINACION TIPO VIA
                //DENOMINACION VIA
                //NUMERO VIA
                //COMPLEMENTO DENOMINACION VIA
                codigoPostal = values[19],
                provincia = values[20],
                //DENOMINAION PROVINCIA
                localidad = values[22],
                //DENOMINACION LOCALIDAD
                //TELEFONOS OFICINA (en el objeto Oficina hay TELEFONO, TELEFONO2 y TELEFONO3)
                fax = values[25],
                //EMAIL OFICINA

                //HORARIO_NORMAL_W_M_INI
                //HORARIO_NORMAL_W_M_FIN
                //HORARIO_NORMAL_W_T_INI
                //HORARIO_NORMAL_W_T_FIN
                //HORARIO_NORMAL_V_M_INI
                //HORARIO_NORMAL_V_M_FIN
                //HORARIO_NORMAL_V_T_INI
                //HORARIO_NORMAL_V_T_FIN
                //HORARIO_NORMAL_S
                //HORARIO_NORMAL_S_INI
                //HORARIO_NORMAL_S_FIN

                //HORARIO_VERANO_W_M_INI
                //HORARIO_VERANO_W_M_FIN
                //HORARIO_VERANO_W_T_INI
                //HORARIO_VERANO_W_T_FIN
                //HORARIO_VERANO_V_M_INI
                //HORARIO_VERANO_V_M_FIN
                //HORARIO_VERANO_V_T_INI
                //HORARIO_VERANO_V_T_FIN
                //HORARIO_VERANO_S
                //HORARIO_VERANO_S_INI
                //HORARIO_VERANO_S_FIN

                //CODIGO DEL RESPONSABLE
                //NOMBRE DEL RESPONSABLE
                //NUUMA RESPONSABLE
                //PERFIL RESPONSABLE
                //EMAIL RESPONSABLE
                //LISTA DE OTROS MIEMBROS
            };

            return office;
        }
    }
}
