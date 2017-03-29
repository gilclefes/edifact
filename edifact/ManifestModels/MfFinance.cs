using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactViewer.ManifestModels
{
    public class MfFinance
    {
        public string MonetaryType { get; set; }
        public string MonetaryCurrency { get; set; }
        public decimal MonetaryAmount { get; set; }

        public string DocumentNo { get; set; }
     
    }
}
