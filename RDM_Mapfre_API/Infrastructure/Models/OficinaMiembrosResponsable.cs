[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OficinaMiembrosResponsable
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
}
