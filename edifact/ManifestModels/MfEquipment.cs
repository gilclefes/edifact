using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.ManifestModels
{
    public class MfEquipment
    {
        public string EquipmentTypeCode { get; set; }
        public string EquipmentCode { get; set; }
        public string EquipmentSize { get; set; }
        public string EquipmentFullStatusCode { get; set; }

        public string seal { get; set; }

        public string DocumentNo { get; set; }

       // public List<Measurement> EquipmentMeasureList { get; set; }
 
    }
}
