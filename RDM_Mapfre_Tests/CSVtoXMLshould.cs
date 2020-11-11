using RDM_Mapfre_API.Infrastructure.Models.ReferenceCSV;
using RDM_Mapfre_API.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDM_Mapfre_Tests
{
    public class CSVtoXMLshould
    {
        [Fact]
        public void Test_ReadReferenceCSV()
        {
            string csvLocalRoute = "";
            List<Oficina> oficinas = new List<Oficina>();

            Assert.Equal(oficinas, CSVtoXML.readReferenceCSV(csvLocalRoute));
        }

        [Fact]
        public void Test_ReadComparingCSV()
        {
            string csvLocalRoute = "";

            CSVtoXML.readComparingCSV(csvLocalRoute);
        }
    }
}
