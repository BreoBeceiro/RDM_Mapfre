using System.Collections.Generic;

namespace RDM_Mapfre_API.Infrastructure.Models.ComparingCSV
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Miembros
    {
        public List<Responsable> responsables { get; set; }

        public List<Miembro> miembros { get; set; }
    }

}