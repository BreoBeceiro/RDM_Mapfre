using System.Collections.Generic;

namespace RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV
{
    public partial class Miembros
    {
        public List<Responsable> responsables { get; set; }

        public List<Miembro> miembros { get; set; }
    }

}