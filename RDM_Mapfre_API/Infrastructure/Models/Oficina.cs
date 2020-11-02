using System.Collections.Generic;
using System.Runtime.InteropServices;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Oficina
{
    public string id { get; set; }

    public string denominacion { get; set; }
    
    public string codCeco { get; set; }
    
    public string codOficinaDirecta { get; set; }
    
    public string codOficinaDelegada { get; set; }
    
    public string codDirTerritorial { get; set; }

    public string denominacionDirTerritorial { get; set; }
    
    public string codDGT { get; set; }

    public string denominacionDGT { get; set; }

    public string codSubcentral { get; set; }

    public string denominacionSubcentral { get; set; }

    public string claveProduccion { get; set; }

    public string codTipo { get; set; }

    public string denominacionTipo { get; set; }

    public string codTipoVia { get; set; }

    public string denominacionTipoVia { get; set; }

    public string denominacionVia { get; set; }

    public string numeroVia { get; set; }

    public string complementoDenominacionVia { get; set; }
    
    public string codigoPostal { get; set; }
    
    public string codProvincia { get; set; }

    public string denominacionProvincia { get; set; }

    public string codLocalidad { get; set; }

    public string denominacionLocalidad { get; set; }

    public string telefonosOficina1 { get; set; }

    public string telefonosOficina2 { get; set; }

    public string telefonosOficina3 { get; set; }

    public string fax { get; set; }

    public string email { get; set; }

    public string horarioNormalW { get; set; }

    public string horarioNormalV { get; set; }

    public string indHorarioNormalS { get; set; }

    public string horarioNormalS { get; set; }

    public string horarioVeranoW { get; set; }

    public string horarioVeranoV { get; set; }

    public string indHorarioVeranoS { get; set; }

    public string horarioVeranoS { get; set; }

    public string periodoVeranoSN { get; set; }

    public string periodoInicioVerano { get; set; }

    public string periodoFinVerano { get; set; }

    public string horarioObservaciones { get; set; }

    public string horarioObservacionesVerano { get; set; }

    public Miembros miembros { get; set; }
}
