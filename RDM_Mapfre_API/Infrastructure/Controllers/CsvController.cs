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
        public IActionResult ConverteCVStoXMLs(string csvRoute)
        {
            //TO DO: Las rutas de los ficheros se almacenarán en el archivo 'AppRoutes.yaml':
            CSVtoXML.writeXML(@"C:\Users\breogan.beceirocasti\Desktop\PruebaEscritura.xml");

            return Ok();
        }
    }
}
