using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV;
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
            //TODO: Files routes will be recovered from 'AppRoutes.yaml'.

            List<Oficina> oficinas1 = CSVtoXML.readReferenceCSV($"C:\\Users\\breogan.beceirocasti\\Desktop\\RDM\\01072020_ListadoOficinas.csv");

            //List<Oficina> oficinas2 = CSVtoXML.readReferenceCSV($"C:\\Users\\breogan.beceirocasti\\Desktop\\RDM\\Ficheros\\MyBusiness_27102020.csv");
            List<Models.ComparingCSV.Oficina> oficinas2 = CSVtoXML.readComparingCSV($"C:\\Users\\breogan.beceirocasti\\Desktop\\RDM\\MyBusiness_21072020.csv");

            //CSVtoXML.writeXML(oficinas, @"C:\Users\breogan.beceirocasti\Desktop\PruebaEscritura.xml");

            //ListComparer.checkIfListsAreEqual(oficinas1, oficinas2);
            //ListComparer.checkIfListHaveNewElements(oficinas1, oficinas2);
            //ListComparer.checkIfListHasModifiedElements(oficinas1, oficinas2);
            
            //var myBusinessRoute = YamlReader.ReadYml("fileRoutes", "MyBusinessRoute");
            List<Oficina> oficinas = CSVtoXML.readReferenceCSV($"C:\\Users\\breogan.beceirocasti\\Desktop\\RDM\\01072020_ListadoOficinas.csv");
            CSVtoXML.writeXML(oficinas);

            return Ok();
        }
    }
}
