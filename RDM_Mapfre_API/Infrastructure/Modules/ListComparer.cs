using RDM_Mapfre_API.Infrastructure.Models.ComparingCSV;
using RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using OficinaReference = RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV.Oficina;
using OficinaComparing = RDM_Mapfre_API.Infrastructure.Models.ComparingCSV.Oficina;

namespace RDM_Mapfre_API.Infrastructure.Modules
{
    public static class ListComparer
    {
        //LAS LISTAS DE REFERENCIA Y COMPARACIÓN SE INICIALIZAN EN CADA MÉTODO. DEBERÍAN INICIALIZARSE EXTERNAMENTE ÚNICAMENTE UNA VEZ PARA LUEGO
        //  UTILIZARSE EN CADA MÉTODO.

        /// <summary>
        /// Compare two lists in order to determine if they contain the same elements acording to their IDs. This method verifies that the existing
        /// elements in the reference list are also present in the comparing list.
        /// </summary>
        /// <param name="referenceList">Reference list with which comparing list will be contrasted.</param>
        /// <param name="comparingList">Comparing list that may have different objects than the reference list.</param>
        /// <returns>TRUE if both lists got the same elements, FALSE if not.</returns>
        public static bool checkIfListsGotSameOficinas(List<OficinaReference> referenceList, List<OficinaComparing> comparingList)
        {
            List<string> referenceListIDs = OficinasReferenceRepository.getOficinasId(referenceList);
            List<string> comparingListIDs = OficinasComparingRepository.getOficinasId(comparingList);

            foreach (string officeID in referenceListIDs)
            {
                if (!comparingListIDs.Contains(officeID))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Find and get all the Oficina objects in 'comparingList' that does not exist in 'referenceList'.
        /// </summary>
        /// <param name="referenceList">Reference list with which comparing list will be contrasted.</param>
        /// <param name="comparingList">The list that might have new elements.</param>
        /// <returns>A list with those new elements.</returns>
        public static List<OficinaComparing> getNewOficinas(List<OficinaReference> referenceList, List<OficinaComparing> comparingList)
        {
            List<string> referenceListIDs = OficinasReferenceRepository.getOficinasId(referenceList);
            List<string> comparingListIDs = OficinasComparingRepository.getOficinasId(comparingList);
            List<OficinaComparing> newOffices = new List<OficinaComparing>();

            foreach (string officeID in comparingListIDs)
            {
                if (!referenceListIDs.Contains(officeID))
                {
                    newOffices.Add(OficinasComparingRepository.getOficinaById(comparingList, officeID));
                }
            }

            return newOffices;
        }

        /// <summary>
        /// Find and get all the Oficina objects in 'referenceList' that does not exist in 'comparingList'.
        /// </summary>
        /// <param name="referenceList">Reference list with which comparing list will be contrasted.</param>
        /// <param name="comparingList">The list that might have deleted elements.</param>
        /// <returns></returns>
        public static List<OficinaReference> getDeletedOficinas(List<OficinaReference> referenceList, List<OficinaComparing> comparingList)
        {
            List<string> referenceListIDs = OficinasReferenceRepository.getOficinasId(referenceList);
            List<string> comparingListIDs = OficinasComparingRepository.getOficinasId(comparingList);
            List<OficinaReference> deletedOffices = new List<OficinaReference>();

            foreach (string officeID in referenceListIDs)
            {
                if (!comparingListIDs.Contains(officeID))
                {
                    deletedOffices.Add(OficinasReferenceRepository.getOficinaById(referenceList, officeID));
                }
            }

            return deletedOffices;
        }

        /// <summary>
        /// Compare two list looking for differences between every object and its correspondent object in the other one, then adds it to a resulting
        /// list of modified Oficinas.
        /// </summary>
        /// <param name="referenceList">Oficina objects list which is used as reference list.</param>
        /// <param name="comparingList">Oficina objects list which objects are compared with the other list's in order to find differences between
        /// their attributes.</param>
        /// <returns></returns>
        public static List<OficinaReference> checkIfComparingListHasModifiedOficinas(List<OficinaReference> referenceList, List<OficinaComparing> comparingList)
        {
            //BASTA CON QUE HAYA UN SOLO ATRIBUTO MODIFICADO PARA QUE ESE OBJETO TENGA QUE IR A LA LISTA DE OBJETOS MODIFICADOS.
            List<OficinaReference> modifiedOficinas = new List<OficinaReference>();

            //1.Recorres las listas de oficinas recogiendo los IDs:
            List<string> referenceListIDs = OficinasReferenceRepository.getOficinasId(referenceList);
            List<string> comparingListIDs = OficinasComparingRepository.getOficinasId(comparingList);
    
            foreach (var referenceOfficeId in referenceListIDs)
            {
                //2.Recorriendo la lista de IDs, se utiliza el identificador en cada iteracción para obtener el objeto de las dos listas:
                OficinaReference referenceOficina = OficinasReferenceRepository.getOficinaById(referenceList, referenceOfficeId);
                OficinaComparing comparingOficina = OficinasComparingRepository.getOficinaById(comparingList, referenceOfficeId);

                //If any of the objects comes NULL, its 'id' property was not found, so iteration is avoided:
                if (ReferenceEquals(null, referenceOficina) || ReferenceEquals(null, comparingOficina))
                {
                    continue;
                }

                //COMPARAR LOS PARES DE ATRIBUTOS DE LOS DOS OBJETOS...
            }

            return modifiedOficinas;
        }
    }
}