using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.ManifestModels
{
    public class ManifestDetail
    {
        public MfGeneral MfGeneral { get; set; }

        public List<MfCargo> MfCargoList { get; set; }
        public List<MfDates> MfDateList { get; set; }
        public List<MfEquipment> MfEquipmentList { get; set; }
        public List<MfFinance> MfFinanceList { get; set; }
        public List<MfLocation> MfLocationList { get; set; }
        public List<MfParty> MfPartyList { get; set; }
        public List<MfReference> MfReferenceList { get; set; }
        public List<MfTransport> MfTransportList { get; set; }
        public List<MfEquipmentMeasurement> MfEquipmentMeasureList { get; set; }
        public List<MfCargoMeasurement> MfCargoMeasureList { get; set; }
    }
}
