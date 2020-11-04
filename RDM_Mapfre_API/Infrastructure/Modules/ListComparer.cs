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
    {/*
        /// <summary>
        /// Compare two lists in order to determine if they contein the same data.
        /// </summary>
        /// <param name="list1">First list for comparing.</param>
        /// <param name="list2">Second list for comparing.</param>
        /// <returns>TRUE if lists contain same data, FALSE if not.</returns>
        public static bool checkIfListsAreEqual(List<Models.ReferenceCSV.Oficina> list1, List<Models.ComparingCSV.Oficina> list2)
        {
            List<Oficina> list3;
            bool areEqual = false;

            list3 = list1.Except(list2).ToList();

            if (list3.Count == 0)
            {
                areEqual = true;
            }

            return areEqual;
        }*/

        /// <summary>
        /// Find all the elements in 'list1' that does not exist in 'list2'.
        /// </summary>
        /// <param name="list1">The list where new elements exist.</param>
        /// <param name="list2">The list which will be compared with the other.</param>
        /// <returns>A list with those new elements.</returns>
        public static List<Oficina> checkIfListHaveNewElements(List<Models.ReferenceCSV.Oficina> list1, List<Models.ComparingCSV.Oficina> list2)
        {
            List<Oficina> newOffices = list1.Where(list1Office => !list2.Any(list2Office => list2Office.id == list1Office.codigoTienda)).ToList();

            return newOffices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static List<Oficina> checkIfListHasModifiedElements(List<Oficina> list1, List<Models.ComparingCSV.Oficina> list2)
        {
            //BASTA CON QUE HAYA UN SOLO ATRIBUTO MODIFICADO PARA QUE ESE OBJETO TENGA QUE IR A LA LISTA DE OBJETOS MODIFICADOS.
            List<Oficina> modifiedOficinas = new List<Oficina>();

            //1.Recorres las listas de oficinas recogiendo los IDs:
            List<string> list1Id = OficinasReferenceRepository.getOficinasId(list1);
            List<string> list2Id = OficinasComparingRepository.getOficinasId(list2);

            PropertyInfo[] properties = typeof(Oficina).GetProperties();
    
            foreach (var officeId in list1Id)
            {
                //2.Recorriendo la lista de IDs, se utiliza el identificador en cada iteracción para obtener el objeto de las dos listas:
                Oficina list1Oficina = OficinasReferenceRepository.getOficinaById(list1, officeId);
                Models.ComparingCSV.Oficina list2Oficina = OficinasComparingRepository.getOficinaById(list2, officeId);

                //If any of the objects comes NULL, its 'id' property was not found, so iteration is avoided:
                if (list1Oficina == null || list2Oficina == null)
                {
                    continue;
                }

                foreach (PropertyInfo property in properties)
                {
                    //Recorriendo las propiedades de los objetos, evaluamos una a una si tienen el mismo valor:

                    //OJO: ESTO AHORA NO VALE PORQUE LOS OBJETOS Oficina DE COMPARACIÓN Y REFERENCIA NO TIENEN LOS MISMOS ATRIBUTOS
                    var list1OficinaPropertyValue = property.GetValue(list1Oficina);
                    var list2OficinaPropertyValue = property.GetValue(list2Oficina);

                    //3. Comparas atributos (si una pareja de atributos tiene valores diferentes, en ese elemento ya hubo una modificación,
                    //  de modo que se añade a la lista de salida y se salta al siguiente objeto):
                    if (!list1OficinaPropertyValue.Equals(list2OficinaPropertyValue))
                    {
                        modifiedOficinas.Add(list1Oficina);
                        break;
                    }
                }
            }

            return modifiedOficinas;
        }
    }
}
