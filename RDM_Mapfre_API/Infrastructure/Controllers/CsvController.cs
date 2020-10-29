﻿using System;
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
            //TO DO: Añadir acceso a fichero por medio de fichero provisional.
            CSVtoXML.csvToXML(@"C:\Users\breogan.beceirocasti\Desktop\RDM\OFICINAS_20200603.csv");

            return Ok();
        }
    }
}
