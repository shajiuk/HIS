using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Data;
using Travco.Helpers.HIS;
using Travco.HIS.Model.Request.HotelDescriptiveInfo;
using Xunit;

namespace Travco.HIS.UnitTests
{
    public class DescriptiveInfoTests
    {
        [Fact]
        public void Success_Element_Present()
        {
            var logger = new Mock<ILogger>();

            HotelDescriptiveInfoReq request = new HotelDescriptiveInfoReq
            {
                Header = new EnvelopeHeader
                {
                    Interface = new Interface
                    {
                        ChannelIdentifierId = "HIS_TOKYO_IIJ_XML4H",
                        ComponentInfo = new InterfaceComponentInfo
                        {
                            ComponentType = "Hotel",
                            Pwd = "******",
                            User = "his"
                        },
                        Interface1 = "VACATION QUICK CONNECT XML 4 OTA",
                        Version = "2011B"

                    }
                },
                Body = new Model.Request.HotelDescriptiveInfo.EnvelopeBody
                {
                    OTA_HotelDescriptiveInfoRQ = new OTA_HotelDescriptiveInfoRQ
                    {
                        HotelDescriptiveInfos = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfos
                        {
                            HotelDescriptiveInfo = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfo
                            {
                                HotelCode = "TST",
                                AffiliationInfo = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoAffiliationInfo
                                {
                                    SendDistribSystems = true
                                },
                                AreaInfo = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoAreaInfo
                                {
                                    SendRefPoints = true
                                },
                                ContactInfo = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoContactInfo
                                {
                                    SendData = true
                                },
                                HotelInfo = new OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoHotelInfo
                                {
                                    SendData = true
                                }
                            }
                        }
                    },
                    RequestId = "TEST_REQUEST_ID",
                    Transaction = "TRANSACTION_ID"
                }
            };

            DataTable data = new DataTable();
            data.Columns.Add(new DataColumn("HotelCode", typeof(string)));
            data.Columns.Add(new DataColumn("HotelName", typeof(string)));
            data.Columns.Add(new DataColumn("SubHotelCode", typeof(string)));
            data.Columns.Add(new DataColumn("HotelAddress", typeof(string)));
            data.Columns.Add(new DataColumn("CityName", typeof(string)));
            data.Columns.Add(new DataColumn("CountryName", typeof(string)));
            data.Columns.Add(new DataColumn("HotelTelephone", typeof(string)));
            data.Columns.Add(new DataColumn("HotelEmail", typeof(string)));
            data.Columns.Add(new DataColumn("CityCode", typeof(string)));
            data.Columns.Add(new DataColumn("RatePlanCode", typeof(string)));
            data.Columns.Add(new DataColumn("RatePlanName", typeof(string)));
            data.Columns.Add(new DataColumn("RoomCode", typeof(string)));
            data.Columns.Add(new DataColumn("EN_RoomName", typeof(string)));
            data.Columns.Add(new DataColumn("JP_RoomName", typeof(string)));
            data.Columns.Add(new DataColumn("RoomPax", typeof(int)));

            DataRow row = data.NewRow();
            row["HotelCode"] = "TST";
            row["HotelName"] = "Test Hotel";
            row["SubHotelCode"] = "TST";
            row["RatePlanCode"] = "0235";
            row["RatePlanName"] = "Standard-Room Only-Standard";
            row["RoomCode"] = "DWO";
            row["EN_RoomName"] = "Double Room - Room Only";
            row["JP_RoomName"] = "Awwww, hell naw";
            row["RoomPax"] = 2;
            data.Rows.Add(row);

            var response = HISHelpers.GenerateXMLFromCMS(request, logger.Object, data);
        }
    }
}
