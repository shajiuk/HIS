using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using Travco.Helpers.HIS;
using Travco.HIS.Model.Request.HotelDescriptiveInfo;
using Travco.HIS.Model.Response.HotelDescriptiveInfo;
using Travco.HIS.Model.Response.Error.SearchAvailability;
using Travco.HIS.Model.Request.HotelAvail;
using Travco.HIS.Model.Response.HotelAvail;
using Travco.HIS.Model.Request.Export.HotelRateAmount;
using Travco.HIS.Model.Response.Export.HotelRateAmount;
using Xunit;

namespace Travco.HIS.UnitTests
{
    public class ValidationTests
    {
        #region HotelRateAmountNotif

        [Fact]
        public void Validate_HotelRateAmountNotifRQ()
        {
            var request = new HotelRateAmountNotifRQ
            {
                Header = new Model.EnvelopeHeader
                {
                    Interface = new Model.Interface
                    {
                        ChannelIdentifierId = "HIS_VACATION_XML4H",
                        ComponentInfo = new Model.InterfaceComponentInfo
                        {
                            ComponentType = "Hotel",
                            Pwd = "Vacation1016",
                            User = "Vacation"
                        },
                        Interface1 = "VACATION QUICK CONNECT XML 4 OTA",
                        Version = "2011B"
                    }
                },
                Body = new Model.Request.Export.HotelRateAmount.EnvelopeBody
                {
                    OTA_HotelRateAmountNotifRQ = new OTA_HotelRateAmountNotifRQ
                    {
                        RateAmountMessages = new OTA_HotelRateAmountNotifRQRateAmountMessages
                        {
                            HotelCode = "YYG",
                            RateAmountMessage = new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessage[1]
                            {
                                new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessage
                                {
                                    Rates = new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRate[1]
                                    {
                                        new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRate
                                        {
                                            BaseByGuestAmts = new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRateBaseByGuestAmt[1]
                                            {
                                                new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRateBaseByGuestAmt
                                                {
                                                    AgeQualifyingCode = 1,
                                                    AmountAfterTax = 1000,
                                                    AmountBeforeTax = 900,
                                                    CurrencyCode = "GBP",
                                                    DecimalPlaces = 2,
                                                    NumberOfGuests = 1
                                                }
                                            },
                                            NumberOfUnits = 1, // we can apparently use 0 here, but not according to the spec
                                            RateTimeUnit = "Day",
                                            UnitMultiplier = 1
                                        }
                                    },
                                    StatusApplicationControl = new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageStatusApplicationControl
                                    {
                                        End = DateTime.UtcNow.AddMonths(1),
                                        InvCode = "INV_CODE", // variable
                                        InvCodeApplication = "InvCode",
                                        IsRoom = 0,
                                        RatePlanCode = "RatePlanCode",
                                        RatePlanCodeType = "RatePlanCode",
                                        Start = DateTime.UtcNow
                                    }
                                }
                            }
                        },
                        PrimaryLangID = "en",
                        Target = "Test",
                        TimeStamp = DateTime.UtcNow,
                        Version = 1.000m
                    },
                    RequestId = "REQUEST_ID",
                    Transaction = "HotelRateAmountNotifRQ"
                }
            };

            var xml = request.Body.OTA_HotelRateAmountNotifRQ.SerializeToXML();
            Dump(xml, "OTA_HotelRateAmountNotifRQ.xml");
            Validate(xml, "Schemas/FS_OTA_HotelRateAmountNotifRQ.xsd");
        }

        [Fact]
        public void Validate_HotelRateAmountNotifRS()
        {
            var response = new HotelRateAmountNotifRS
            {
                Header = new Model.EnvelopeHeader
                {
                    Interface = new Model.Interface
                    {
                        ChannelIdentifierId = "HIS_VACATION_XML4H",
                        ComponentInfo = new Model.InterfaceComponentInfo
                        {
                            ComponentType = "Hotel",
                            Pwd = "Vacation1016",
                            User = "Vacation"
                        },
                        Interface1 = "VACATION QUICK CONNECT XML 4 OTA",
                        Version = "2011B"
                    }
                },
                Body = new Model.Response.Export.HotelRateAmount.EnvelopeBody
                {
                    OTA_HotelRateAmountNotifRS = new OTA_HotelRateAmountNotifRS
                    {
                        Success = new object(),
                        PrimaryLangID = "en",
                        Target = "Test",
                        TimeStamp = DateTime.UtcNow.ToString("o"),
                        Version = 1.000m
                    },
                    RequestId = "RESPONSE_ID",
                    Transaction = "HotelRateAmountNotifRS"
                }
            };

            var xml = response.Body.OTA_HotelRateAmountNotifRS.SerializeToXML();
            Dump(xml, "OTA_HotelRateAmountNotifRS.xml");
            Validate(xml, "Schemas/FS_OTA_HotelRateAmountNotifRS.xsd");
        }

        #endregion

        #region HotelDescriptiveInfo

        [Fact]
        public void Validate_HotelDescriptiveInfoRQ()
        {
            var request = new HotelDescriptiveInfoReq
            {
                Header = new Model.Request.HotelDescriptiveInfo.EnvelopeHeader
                {
                    Interface = new Model.Request.HotelDescriptiveInfo.Interface
                    {
                        ChannelIdentifierId = "HIS_VACATION_XML4H",
                        ComponentInfo = new Model.Request.HotelDescriptiveInfo.InterfaceComponentInfo
                        {
                            ComponentType = "Hotel",
                            Pwd = "Vacation1016",
                            User = "Vacation"
                        },
                        Interface1 = "VACATION QUICK CONNECT XML 4 OTA",
                        Version = "2011B"
                    }
                },
                Body = new Model.Request.HotelDescriptiveInfo.EnvelopeBody
                {
                    OTA_HotelDescriptiveInfoRQ = new OTA_HotelDescriptiveInfoRQ
                    {
                        EchoToken = "2018052316425628998",
                        HotelDescriptiveInfos = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfos
                        {
                            HotelDescriptiveInfo = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfo
                            {
                                AffiliationInfo = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoAffiliationInfo { SendDistribSystems = true },
                                AreaInfo = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoAreaInfo { SendRefPoints = true },
                                ContactInfo = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoContactInfo { SendData = false },
                                HotelInfo = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoHotelInfo { SendData = false },
                                HotelCode = "YYG"
                            }
                        },
                        PrimaryLangID = "en",
                        Target = "Test",
                        TimeStamp = DateTime.UtcNow,
                        Version = 1.000m
                    },
                    RequestId = "REQUEST_ID",
                    Transaction = "HotelDescriptiveInfoRQ"
                }
            };

            var xml = request.Body.OTA_HotelDescriptiveInfoRQ.SerializeToXML();
            Dump(xml, "OTA_HotelDescriptiveInfoRQ.xml");
            Validate(xml, "Schemas/FS_OTA_HotelDescriptiveInfoRQ.xsd");
        }

        [Fact]
        public void Validate_HotelDescriptiveInfoRS()
        {
            var response = new HotelDescriptiveInfoRes
            {
                Header = new Model.Response.HotelDescriptiveInfo.EnvelopeHeader
                {
                    Interface = new Model.Response.HotelDescriptiveInfo.Interface 
                    {
                        ChannelIdentifierId = "HIS_VACATION_XML4H",
                        ComponentInfo = new Model.Response.HotelDescriptiveInfo.InterfaceComponentInfo
                        {
                            ComponentType = "Hotel",
                            Pwd = "Vacation1016",
                            User = "Vacation"
                        },
                        Interface1 = "VACATION QUICK CONNECT XML 4 OTA",
                        Version = "2011B"
                    }
                },
                Body = new Model.Response.HotelDescriptiveInfo.EnvelopeBody
                {
                    OTA_HotelDescriptiveInfoRS = new OTA_HotelDescriptiveInfoRS
                    {
                        EchoToken = "2018052316425628998",
                        HotelDescriptiveContents = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContents
                        {
                            HotelDescriptiveContent = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContent
                            {
                                HotelCode = "YYG",
                                TPA_Extensions = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_Extensions
                                {
                                    TPA_Extension = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_Extension
                                    {
                                        Extension = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension>
                                        {
                                            new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension
                                            {
                                                Name = "InterfaceSetup",
                                                Item = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem>
                                                {
                                                    new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem
                                                    {
                                                        Key = "Mapping_Rateplan",
                                                        Value = "0093",
                                                        Text = "0093"
                                                    }
                                                }
                                            }
                                        },
                                        ID = "VQC"
                                    }
                                }
                            }
                        },
                        PrimaryLangID = "en",
                        Success = new object(),
                        Target = "Test",
                        TimeStamp = DateTime.UtcNow,
                        Version = 1.000m
                    },
                    RequestId = "REQUEST_ID",
                    Transaction = "HotelDescriptiveInfoRS"
                }
            };

            string xml = response.Body.OTA_HotelDescriptiveInfoRS.SerializeToXML();
            Dump(xml, "OTA_HotelDescriptiveInfoRS.xml");
            Validate(xml, "Schemas/FS_OTA_HotelDescriptiveInfoRS.xsd");
        }

        #endregion

        private void Validate(string xml, string schemaFilename)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, schemaFilename);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += Settings_ValidationEventHandler;

            using (var xmlStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                using (XmlReader reader = XmlReader.Create(xmlStream, settings))
                {
                    while (reader.Read())
                    {
                        // yay!
                    }
                }
            }
        }

//        [Fact]
//        public void Helper_Test()
//        {
//            var logger = new Mock<ILogger>();

//            var response = new HotelDescriptiveInfoRes
//            {
//                Header = new Model.Response.HotelDescriptiveInfo.EnvelopeHeader
//                {

//                },
//                Body = new Model.Response.HotelDescriptiveInfo.EnvelopeBody
//                {
//                    OTA_HotelDescriptiveInfoRS = new OTA_HotelDescriptiveInfoRS
//                    {

//                    }
//                }
//            };

//            var error = new OTA_HotelAvailRSErrorsError
//            {
//                Code = "Code",
//                ShortText = "Short Text",
//                Type = 0,
//                Value = "Value"
//            };

//            string ERROR_TEMPLATE = @"<?xml version=""1.0"" encoding=""UTF-8""?>
//<soap-env:Envelope xmlns:soap-env=""http://schemas.xmlsoap.org/soap/envelope/"">
//  <soap-env:Header/>
//  <soap-env:Body RequestId=""2014092917033613018229"" Transaction=""HotelAvailRS"">
//    <OTA_HotelAvailRS xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" TimeStamp=""2014-09-29T16:03:44.3516448+08:00"" EchoToken=""2014092917033613018229"" Target=""Production"" Version=""1.000"" PrimaryLangID=""en"" xmlns=""http://www.opentravel.org/OTA/2003/05"">
//      <Errors>
//        <Error Type=""3"" ShortText=""{0}"" Code=""{1}"">{2}</Error>
//      </Errors>
//    </OTA_HotelAvailRS>
//  </soap-env:Body>
//</soap-env:Envelope>";

//            string xml = HISHelpers.ProcessErrorForModel<HotelDescriptiveInfoRes, Model.Response.Error.HotelDescriptiveInfo.ErrorResponse>(response, ERROR_TEMPLATE, error, logger.Object);
//            Dump(xml, "OTA_HotelDescriptiveInfoRS_Errors.xml");
//            Validate(xml, "Schemas/FS_OTA_HotelDescriptiveInfoRS.xsd");
//        }

        private static void Settings_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.Write("WARNING: ");
                Console.WriteLine(e.Message);
                throw new XmlSchemaValidationException(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
                throw new XmlSchemaValidationException(e.Message);
            }
        }

        private void Dump(string xml, string filename)
        {
            using (var writer = new FileStream(filename, FileMode.Create))
            {
                var b = Encoding.UTF8.GetBytes(xml);
                writer.Write(b, 0, b.Length);
            }
        }
    }
}
