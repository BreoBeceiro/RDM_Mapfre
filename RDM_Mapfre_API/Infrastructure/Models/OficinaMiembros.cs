[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OficinaMiembros
{
    public Responsable responsable { get; set; }

    public Miembro miembro { get; set; }
}
