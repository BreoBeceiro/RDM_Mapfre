using System.Runtime.InteropServices;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Oficina
{
    public string id { get; set; }

    public string tipo { get; set; }

    public string tipodeoficina { get; set; }

    public string denominacion { get; set; }

    public string ceco { get; set; }

    public string idDirTerritorial { get; set; }

    public string idDGT { get; set; }

    public string idOficinaDirecta { get; set; }

    public string idOficinaDelegada { get; set; }

    public string direccion { get; set; }

    public string localidad { get; set; }

    public string provincia { get; set; }

    public string codigoPostal { get; set; }

    public string horarioHabitual { get; set; }

    public string horarioViernes { get; set; }

    public string abiertoSabados { get; set; }

    public string horarioSabados { get; set; }

    public string periodoVerano { get; set; }

    public string horarioVerano { get; set; }

    public string horarioHabitualVerano { get; set; }

    public string horarioViernesVerano { get; set; }

    public string abiertoSabadosVerano { get; set; }

    public string horarioSabadosVerano { get; set; }

    public string telefono { get; set; }

    public string telefono2 { get; set; }

    public string telefono3 { get; set; }

    public string fax { get; set; }

    public string clave_prod { get; set; }

    public OficinaMiembros miembros { get; set; }

    public string[] text { get; set; }
}
