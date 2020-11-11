using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV;
using OficinaReference = RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV.Oficina;
using OficinaComparing = RDM_Mapfre_API.Infrastructure.Models.ComparingCSV.Oficina;
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

            //List<OficinaReference> oficinasReferencia = CSVtoXML.readReferenceCSV($"C:\\Users\\breogan.beceirocasti\\Desktop\\RDM\\01072020_ListadoOficinas.csv");
            //List<OficinaComparing> oficinasComparacion = CSVtoXML.readComparingCSV($"C:\\Users\\breogan.beceirocasti\\Desktop\\RDM\\Ficheros\\MyBusiness_27102020.csv");

            List<OficinaComparing> oficinasComparacion = CSVtoXML.readComparingCSV($"C:\\Users\\breogan.beceirocasti\\Desktop\\MyBusiness.csv");
            List<OficinaReference> oficinasReferencia = CSVtoXML.readReferenceCSV($"C:\\Users\\breogan.beceirocasti\\Desktop\\ListadoOficinas.csv");

            CSVtoXML.writeXML(oficinasReferencia);

            //ListComparer.checkIfListsGotSameOficinas(oficinasReferencia, oficinasComparacion);
            //ListComparer.getNewOficinas(oficinasReferencia, oficinasComparacion);
            //ListComparer.getDeletedOficinas(oficinasReferencia, oficinasComparacion);
            //ListComparer.checkIfComparingListHasModifiedOficinas(oficinasReferencia, oficinasComparacion);
            
            //var myBusinessRoute = YamlReader.ReadYml("fileRoutes", "MyBusinessRoute");
            //List<OficinaReference> oficinas = CSVtoXML.readReferenceCSV($"C:\\Users\\breogan.beceirocasti\\Desktop\\RDM\\01072020_ListadoOficinas.csv");
            //CSVtoXML.writeXML(oficinas);

            return Ok();
        }
    }
}
