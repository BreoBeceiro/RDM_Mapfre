namespace RDM_Mapfre_API.Infrastructure.Models.ComparingCSV
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Responsable
    {
        public string codigo { get; set; }

        public string nombre { get; set; }

        public string nuuma { get; set; }

        public string perfil { get; set; }

        public string email { get; set; }
    }

}