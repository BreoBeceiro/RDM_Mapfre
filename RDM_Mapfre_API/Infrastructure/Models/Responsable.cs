[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class Responsable
{
    [System.Xml.Serialization.XmlElementAttribute("codResp", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("email", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("nombre", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("nuuma", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("perfil", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public string[] items { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType[] itemsElementName { get; set; }

    public string codigo { get; set; }

    public string nombre { get; set; }

    public string nuuma { get; set; }

    public string perfil { get; set; }

    public string email { get; set; }
}
