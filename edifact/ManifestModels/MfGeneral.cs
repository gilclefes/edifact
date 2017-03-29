using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.ManifestModels
{
    public class MfGeneral
    {
        public string Sender { get; set; }
        public string Receipient { get; set; }
        public string Version { get; set; }
        public DateTime CreationDate { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string DocumentNumber { get; set; }
        public string MessageType { get; set; }
     
       //private List<MfCargo> MfCargoList { get; set; }
       //private List<MfDates> MfDateList { get; set; }
       //private List<MfEquipment> MfEquipmentList { get; set; }
       //private List<MfFinance> MfFinanceList { get; set; }
       //private List<MfLocation> MfLocationList { get; set; }
       //private List<MfParty> MfPartyList { get; set; }
       //private List<MfReference> MfReferenceList { get; set; }
       //private List<MfTransport> MfTransportList { get; set; }
    }
}
