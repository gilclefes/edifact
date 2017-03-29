using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.ManifestModels
{
   public class Measurement
    {
       public string MeasurementCode { get; set; }
       public string MeasurementAttributeCode { get; set; }
       public string MeasurementUnitCode { get; set; }

       public decimal MeasurementValue { get; set; }
    }
}
