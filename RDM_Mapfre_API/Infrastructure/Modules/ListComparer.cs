using RDM_Mapfre_API.Infrastructure.Models.ComparingCSV;
using RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Oficina = RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV.Oficina;

namespace RDM_Mapfre_API.Infrastructure.Modules
{
    public static class ListComparer
    {
        //Inyectar listas por constructor.

        //AL EDITAR LOS FICHEROS csv PARA LAS PRUEBAS, A VECES SE PIERDE EL FORMATO, CON LO QUE EL ARCHIVO SE LEE PERO NO SE CONVIERTE A ARRAY, PUES
        //  EL CARACTER SEPARADOR DEJA DE SER ';', DE MODO QUE SE PRODUCE UNA EXCEPCIÓN AL INSTANCIAR EL OBJETO EN OficinasComparingRepository.

        /// <summary>
        /// Compare two lists in order to determine if they contain the same elements acording to their IDs. This method verifies that the existing
        /// elements in the reference list are also present in the comparing list.
        /// </summary>
        /// <param name="referenceList">Reference list with which comparing list will be contrasted.</param>
        /// <param name="comparingList">Comparing list that may have different objects than the reference list.</param>
        /// <returns>TRUE if both lists got the same elements, FALSE if not.</returns>
        public static bool checkIfListsAreEqual(List<Models.ReferenceCSV.Oficina> referenceList, List<Models.ComparingCSV.Oficina> comparingList)
        {
            List<string> referenceListIDs = OficinasReferenceRepository.getOficinasId(referenceList);
            List<string> comparingListIDs = OficinasComparingRepository.getOficinasId(comparingList);

            foreach (string officeID in referenceListIDs)
            {
                if (!comparingListIDs.Contains(officeID))
                {
                    //Si un solo ID de la lista de referencia no se encuentra en la de comparación, se puede determinar que las listas no son iguales.
                    return false;
                    
                }
            }

            return true;
        }

        /// <summary>
        /// Find all the elements in 'referenceList' that does not exist in 'comparingList'.
        /// </summary>
        /// <param name="referenceList">Reference list with which comparing list will be contrasted.</param>
        /// <param name="comparingList">The list that might have new elements.</param>
        /// <returns>A list with those new elements.</returns>
        public static List<Models.ComparingCSV.Oficina> getNewElements(List<Models.ReferenceCSV.Oficina> referenceList, List<Models.ComparingCSV.Oficina> comparingList)
        {
            List<string> referenceListIDs = OficinasReferenceRepository.getOficinasId(referenceList);
            List<string> comparingListIDs = OficinasComparingRepository.getOficinasId(comparingList);
            List<Models.ComparingCSV.Oficina> newOffices = new List<Models.ComparingCSV.Oficina>();

            foreach (string officeID in comparingListIDs)
            {
                if (!referenceListIDs.Contains(officeID))
                {
                    //Si un ID de la lista de comparación no se encuentra en la de referencia, el objeto que tenga ese ID debe guardarse en una nueva 
                    //  lista para generar con ella, posteriormente, un XML.
                    newOffices.Add(OficinasComparingRepository.getOficinaById(comparingList, officeID));
                }
            }

            return newOffices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="referenceList"></param>
        /// <param name="comparingList"></param>
        /// <returns></returns>
        public static List<Oficina> checkIfComparingListHasModifiedElements(List<Oficina> referenceList, List<Models.ComparingCSV.Oficina> comparingList)
        {
            //BASTA CON QUE HAYA UN SOLO ATRIBUTO MODIFICADO PARA QUE ESE OBJETO TENGA QUE IR A LA LISTA DE OBJETOS MODIFICADOS.
            List<Oficina> modifiedOficinas = new List<Oficina>();

            //1.Recorres las listas de oficinas recogiendo los IDs:
            List<string> referenceListIDs = OficinasReferenceRepository.getOficinasId(referenceList);
            List<string> comparingListIDs = OficinasComparingRepository.getOficinasId(comparingList);
    
            foreach (var referenceOfficeId in referenceListIDs)
            {
                //2.Recorriendo la lista de IDs, se utiliza el identificador en cada iteracción para obtener el objeto de las dos listas:
                Oficina referenceOficina = OficinasReferenceRepository.getOficinaById(referenceList, referenceOfficeId);
                Models.ComparingCSV.Oficina comparingOficina = OficinasComparingRepository.getOficinaById(comparingList, referenceOfficeId);

                //If any of the objects comes NULL, its 'id' property was not found, so iteration is avoided:
                if (referenceOficina == null || comparingOficina == null)
                {
                    continue;
                }

                if (referenceOficina != comparingOficina)
                {
                    modifiedOficinas.Add(referenceOficina);
                }
            }

            return modifiedOficinas;
        }

        //FALTA EL MÉTODO DE ELEMENTOS ELIMINADOS.
    }
}