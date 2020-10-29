[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OficinaMiembros
{
    public OficinaMiembrosResponsable responsable { get; set; }

    public OficinaMiembrosMiembro miembro { get; set; }
}
