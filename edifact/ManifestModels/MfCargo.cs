using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.ManifestModels
{
   public class MfCargo
    {
       public string ItemNo { get; set; }

       public string ItemCode { get; set; }
       public string PackageType { get; set; }
       public int PackageQuantity { get; set; }
       public string ItemName { get; set; }

       public string DocumentNo { get; set; }

       public string MarksAndNumbers { get; set; }

       public string PackageStatus { get; set; }
     //  public List<Measurement> CargoMeasureList { get; set; }
 
    }
}
