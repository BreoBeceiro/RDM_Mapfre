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
            //TODO: Files routes will be recovered from 'AppRoutes.yaml':
            List<Oficina> oficinas = CSVtoXML.readCSV(csvRoute);
            CSVtoXML.writeXML(oficinas, @"C:\Users\breogan.beceirocasti\Desktop\PruebaEscritura.xml");

            return Ok();
        }
    }
}
