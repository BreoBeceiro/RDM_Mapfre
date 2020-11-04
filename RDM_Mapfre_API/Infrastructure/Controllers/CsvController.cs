using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RDM_Mapfre_API.Infrastructure.Modules;

namespace RDM_Mapfre_API.Infrastructure.Controllers
{
    [Route("FileHandler/")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        [HttpGet]
        [Route("CSVparser")]
        public IActionResult ConverteCSVtoXMLs(string csvRoute)
        {
            //TO DO: Las rutas de los ficheros se almacenarán en el archivo 'AppRoutes.yaml':
            var myBusinessRoute = YamlReader.ReadYml("fileRoutes", "MyBusinessRoute");
            List<Oficina> oficinas = CSVtoXML.csvToXML(myBusinessRoute.ToString());
            CSVtoXML.OficinaObjectToXml(oficinas);
            CSVtoXML.writeXML(myBusinessRoute.ToString());

            return Ok();
        }
    }
}
