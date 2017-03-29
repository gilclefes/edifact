using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Edifact;
using Edifact.SpecifiedSegments;
using EdifactViewer.ManifestModels;
using EdifactViewer.Utils;

namespace EdifactViewer
{
    public static class ManifestReader
    {

        public static ManifestDetail GetManifestDetails(ReaderResult reader)
        {
            string currentType="";
            MfCargo currentCargo = null;
            MfReference currentReference = null;
            MfEquipment currentEquipment=null;
            bool inFtxMode = true;
            GisSegment currentGis = null;
            PciSegment currentPis = null;


            var manifestDetail = new ManifestDetail
            {
                MfGeneral = new MfGeneral(),
                MfCargoList = new List<MfCargo>(),
                MfDateList = new List<MfDates>(),
                MfEquipmentList = new List<MfEquipment>(),
                MfFinanceList = new List<MfFinance>(),
                MfLocationList = new List<MfLocation>(),
                MfPartyList = new List<MfParty>(),
                MfReferenceList = new List<MfReference>(),
                MfTransportList = new List<MfTransport>(),
                MfEquipmentMeasureList =  new List<MfEquipmentMeasurement>(),
                 MfCargoMeasureList = new List<MfCargoMeasurement>()
            };

            if (reader.Segments.Count < 4)
                return manifestDetail;

            foreach (var segment in reader.Segments)
            {

                switch (segment.Tag)
                {
                    case "UNB":
                        var unb = (UnbSegment)segment;
                        manifestDetail.MfGeneral.CreationDate = unb.Date;
                        manifestDetail.MfGeneral.Receipient = unb.receipient;
                        manifestDetail.MfGeneral.Sender = unb.sender;
                        manifestDetail.MfGeneral.Version = unb.version;
                        break;

                    case "BGM":
                        var bgm = (BgmSegment)segment;
                        manifestDetail.MfGeneral.MessageType = bgm.MessageType;
                        manifestDetail.MfGeneral.DocumentName = bgm.DocumentName;
                        manifestDetail.MfGeneral.DocumentNumber = bgm.DocumentNumber;
                        manifestDetail.MfGeneral.DocumentType = bgm.CodeType;
                        break;
                    case "DTM":
                        var dtm = (DtmSegment)segment;
                        var mfDate = new MfDates
                        {
                            DateType = dtm.DateType,
                            DateValue = dtm.Date,
                            DocumentNo = currentReference != null ? currentReference.ReferenceValue : ""
                        };
                        manifestDetail.MfDateList.Add(mfDate);
                        break;
                    case "EQD":
                        currentType = "EQ";
                        var eqd = (EqdSegment)segment;
                        var mfEquipment = new MfEquipment
                        {
                            EquipmentCode = eqd.EquipmentCode,
                            EquipmentFullStatusCode = eqd.EquipmentFullStatusCode,
                            EquipmentSize = eqd.EquipmentSize,
                            EquipmentTypeCode = eqd.EquipmentTypeCode,
                            DocumentNo = currentReference != null ? currentReference.ReferenceValue : ""
                        };
                       // manifestDetail.MfEquipmentList.Add(mfEquipment);
                        currentEquipment = mfEquipment;
                        break;
                    case "GID":
                        currentType = "CA";//ca is for cargo and eq is for equipment
                        var gid = (GidSegment)segment;
                        var mfCargo = new MfCargo
                        {                              
                            ItemNo = gid.ItemNo,
                            ItemCode = RandomGenerator.GetUniqueKey(12),
                            PackageQuantity = gid.PackageQuantity,
                            PackageType = gid.PackageType,
                            DocumentNo = currentReference != null ? currentReference.ReferenceValue : "",
                            PackageStatus = currentPis!=null?currentPis.PakacgeStatus:"1",
                            MarksAndNumbers = currentPis!=null ?currentPis.MarksandNumbers1:""
                            //CargoMeasureList = new List<Measurement>()
                           
                        };
                        inFtxMode = false;
                        currentCargo = mfCargo;
                        break;

                    case "FTX":            
                        var ftx = (FtxSegment)segment;
                        if (currentCargo != null)
                        {
                            if (ftx.CodeType == "AAA" && inFtxMode==false)
                            {
                                inFtxMode = true;
                                currentCargo.ItemName = ftx.TextValue + ftx.TextValue1;
                                manifestDetail.MfCargoList.Add(currentCargo);
                               // currentCargo = null;
                            }
                         
                        }
                                            
                        break;
                    case "SEL":
                        var sel = (SelSegment)segment;
                        if (currentEquipment != null)
                        {
                            currentEquipment.seal = sel.SealValue;
                            manifestDetail.MfEquipmentList.Add(currentEquipment);

                        }

                        break;
                    case "LOC":
                        var loc = (LocSegment)segment;
                        var mfLocation = new MfLocation
                        {
                         LocationCode = loc.LocationCode,
                         LocationCodeType = loc.CodeType,
                         LocationName = loc.LocationName,
                         DocumentNo = currentReference != null ? currentReference.ReferenceValue : ""
                        };
                        manifestDetail.MfLocationList.Add(mfLocation);
                        break;
                    case "MEA":

                        var mea = (MeaSegment)segment;
                        if (currentType.Equals("CA", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (currentCargo != null)
                            {
                                var mfCargomeasure = new MfCargoMeasurement
                                {
                                    ItemCode =currentCargo.ItemCode,
                                    MeasurementAttributeCode = mea.MeasurementAttributeCode,
                                    MeasurementCode = mea.MeasurementCode,
                                    MeasurementUnitCode = mea.MeasurementUnitCode,
                                    MeasurementValue = mea.MeasurementValue
                                  
                                };
                                manifestDetail.MfCargoMeasureList.Add(mfCargomeasure);
                            }
                          
                        
                        }
                        else if (currentType.Equals("EQ", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (currentEquipment != null)
                            {
                                var mfEquipmentMeasurement = new MfEquipmentMeasurement
                                {
                                    EquipmentCode = currentEquipment.EquipmentCode,
                                    MeasurementAttributeCode = mea.MeasurementAttributeCode,
                                    MeasurementCode = mea.MeasurementCode,
                                    MeasurementUnitCode = mea.MeasurementUnitCode,
                                    MeasurementValue = mea.MeasurementValue

                                };
                                manifestDetail.MfEquipmentMeasureList.Add(mfEquipmentMeasurement);
                            }
                        }
                        
                        break;
                    case "MOA":
                        var moa = (MoaSegment)segment;                      
                        var mfFinance = new MfFinance
                        {
                            MonetaryAmount = moa.MonetaryAmount,
                            MonetaryCurrency = moa.MonetaryCurrency,
                            MonetaryType = moa.MonetaryType,
                            DocumentNo = currentReference != null ? currentReference.ReferenceValue : ""
                        };
                        manifestDetail.MfFinanceList.Add(mfFinance);
                        break;
                    case "NAD":
                        var nad = (NadSegment)segment;
                        var mfParty = new MfParty
                        {
                            PartyAddress = nad.Address1 + nad.Address2 + nad.Address3,
                            PartyCity = nad.City,
                            PartyCountryCode = nad.CountryCode,
                            PartyName = nad.Name1 + nad.Name2,
                            PartyType = nad.NadType ,
                            DocumentNo = currentReference!=null? currentReference.ReferenceValue:""
                        };
                        manifestDetail.MfPartyList.Add(mfParty);
                        break;
                    case "RFF":
                        var rff = (RffSegment)segment;
                        var mfReference = new MfReference
                        {
                            ReferenceType = rff.QualifierCode,
                            ReferenceValue = rff.Identifier ,
                            ProcessIndicator = currentGis!=null?currentGis.ProcessIndicator:"23",
                        };
                        manifestDetail.MfReferenceList.Add(mfReference);
                        currentReference = mfReference;
                        break;

                    case "TDT":
                        var tdt = (TdtSegment)segment;
                        var mfTransport = new MfTransport
                        {
                            CarrierCode = tdt.CarrierCode,
                            CarrierName = tdt.CarrierName,
                            ModeOfTransport = tdt.ModeOfTransport,
                            TransportStageCodeType = tdt.TransportStageCodeType
                         
                        };
                        manifestDetail.MfTransportList.Add(mfTransport);
                        break;

                    case "GIS":
                        var gis = (GisSegment)segment;
                        currentGis = gis;
                        //var mfTransport = new MfTransport
                        //{
                        //    CarrierCode = tdt.CarrierCode,
                        //    CarrierName = tdt.CarrierName,
                        //    ModeOfTransport = tdt.ModeOfTransport,
                        //    TransportStageCodeType = tdt.TransportStageCodeType

                        //};
                        //manifestDetail.MfTransportList.Add(mfTransport);
                        break;
                    case "PCI":
                        var pci = (PciSegment)segment;
                        currentPis = pci;
                        //var mfTransport = new MfTransport
                        //{
                        //    CarrierCode = tdt.CarrierCode,
                        //    CarrierName = tdt.CarrierName,
                        //    ModeOfTransport = tdt.ModeOfTransport,
                        //    TransportStageCodeType = tdt.TransportStageCodeType

                        //};
                        //manifestDetail.MfTransportList.Add(mfTransport);
                        break;
                    default:
                        break;

                }
              
            }

            return manifestDetail;
        }
    }
}
