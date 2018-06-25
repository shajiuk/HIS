using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System;
using Xunit;
using Travco.HIS.Api;
using Travco.HIS.Model.Request.Export.HotelAvail;
using Travco.HIS.Model.Request.Export.HotelRateAmount;

namespace Travco.HIS.UnitTests
{
    public class HISExportClientTests
    {
        [Fact]
        public async void Hotel_Notification_Success()
        {
            var logger = new Mock<ILogger<HISExportClient>>();

            var request = new OTA_HotelAvailNotifRQ
            {
                AvailStatusMessages = new OTA_HotelAvailNotifRQAvailStatusMessages
                {
                    AvailStatusMessage = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage[]
                    {
                        new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage
                        {
                            BookingLimit = 5,
                            BookingLimitMessageType = "SetLimit",
                            LengthsOfStay = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStay
                            {
                                ArrivalDateBased = 1,
                                FixedPatternLength = "8",
                                LengthOfStay = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay[]
                                {
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = false,
                                        Time = 1,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = true,
                                        Time = 2,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = true,
                                        Time = 3,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = true,
                                        Time = 4,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = false,
                                        Time = 5,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = false,
                                        Time = 6,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = false,
                                        Time = 7,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = true,
                                        Time = 8,
                                        TimeUnit = "Day"
                                    }
                                }
                            },
                            RestrictionStatus = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageRestrictionStatus
                            {
                                Restriction = "Master",
                                Status = "Close"
                            },
                            StatusApplicationControl = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageStatusApplicationControl
                            {
                                End = new DateTime(2018, 1, 1),
                                InvCode = "DELUXE",
                                InvCodeApplication = "InvCode",
                                IsRoom = 1,
                                RatePlanCode = "RACK",
                                RatePlanCodeType = "RatePlanCode",
                                Start = new DateTime(2018, 1, 1)
                            }
                        }
                    },
                    HotelCode = "hotelA"
                },
                PrimaryLangID = "en",
                Target = "Production",
                TimeStamp = new DateTime(2018, 1, 1),
                Version = 1
            };

            var options = new Mock<IOptions<HISExportOptions>>();
            options.Setup(x => x.Value).Returns(new HISExportOptions
            {
                Uri = "https://fake.his.endpoint",
                Username = "TEST_UNAME",
                Password = "TEST_PWORD"
            });

            var requestBody = new StringBuilder();
            var httpHandler = new Mock<HttpMessageHandler>();
            httpHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(SUCCESS_HOTEL_RESPONSE) })
                .Callback(async (HttpRequestMessage x, CancellationToken c) => {
                    var content = await x.Content.ReadAsStringAsync();
                    requestBody.Append(content);
                });
            var http = new HttpClient(httpHandler.Object);

            HISExportClient client = new HISExportClient(options.Object, logger.Object, http);
            var response = await client.SendHotel(request, "TEST_ID");

            Assert.Equal(EXPECTED_HOTEL_REQUEST, requestBody.ToString());
            Assert.NotNull(response);
            Assert.NotNull(response.Body.OTA_HotelAvailNotifRS.Success);
            Assert.Null(response.Body.OTA_HotelAvailNotifRS.Errors);

            var foo = response.Body.OTA_HotelAvailNotifRS.Success;
        }


        [Fact]
        public async void Hotel_Notification_Errors()
        {
            var logger = new Mock<ILogger<HISExportClient>>();

            var request = new OTA_HotelAvailNotifRQ
            {
                AvailStatusMessages = new OTA_HotelAvailNotifRQAvailStatusMessages
                {
                    AvailStatusMessage = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage[]
                    {
                        new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage
                        {
                            BookingLimit = 5,
                            BookingLimitMessageType = "SetLimit",
                            LengthsOfStay = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStay
                            {
                                ArrivalDateBased = 1,
                                FixedPatternLength = "8",
                                LengthOfStay = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay[]
                                {
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = false,
                                        Time = 1,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = true,
                                        Time = 2,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = true,
                                        Time = 3,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = true,
                                        Time = 4,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = false,
                                        Time = 5,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = false,
                                        Time = 6,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = false,
                                        Time = 7,
                                        TimeUnit = "Day"
                                    },
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay {
                                        MinMaxMessageType = "FullPatternLOS",
                                        OpenStatusIndicator = true,
                                        Time = 8,
                                        TimeUnit = "Day"
                                    }
                                }
                            },
                            RestrictionStatus = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageRestrictionStatus
                            {
                                Restriction = "Master",
                                Status = "Close"
                            },
                            StatusApplicationControl = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageStatusApplicationControl
                            {
                                End = new DateTime(2018, 1, 1),
                                InvCode = "DELUXE",
                                InvCodeApplication = "InvCode",
                                IsRoom = 1,
                                RatePlanCode = "RACK",
                                RatePlanCodeType = "RatePlanCode",
                                Start = new DateTime(2018, 1, 1)
                            }
                        }
                    },
                    HotelCode = "hotelA"
                },
                PrimaryLangID = "en",
                Target = "Production",
                TimeStamp = new DateTime(2018, 1, 1),
                Version = 1
            };

            var options = new Mock<IOptions<HISExportOptions>>();
            options.Setup(x => x.Value).Returns(new HISExportOptions
            {
                Uri = "https://fake.his.endpoint",
                Username = "TEST_UNAME",
                Password = "TEST_PWORD"
            });

            var requestBody = new StringBuilder();
            var httpHandler = new Mock<HttpMessageHandler>();
            httpHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(ERROR_HOTEL_RESPONSE) })
                .Callback(async (HttpRequestMessage x, CancellationToken c) => {
                    var content = await x.Content.ReadAsStringAsync();
                    requestBody.Append(content);
                });
            var http = new HttpClient(httpHandler.Object);

            HISExportClient client = new HISExportClient(options.Object, logger.Object, http);
            var response = await client.SendHotel(request, "TEST_ID");

            Assert.Equal(EXPECTED_HOTEL_REQUEST, requestBody.ToString());
            Assert.NotNull(response);
            Assert.Null(response.Body.OTA_HotelAvailNotifRS.Success);
            Assert.NotNull(response.Body.OTA_HotelAvailNotifRS.Errors);
            Assert.Single(response.Body.OTA_HotelAvailNotifRS.Errors);
            Assert.Equal(450, response.Body.OTA_HotelAvailNotifRS.Errors[0].Code);
            Assert.Equal(3, response.Body.OTA_HotelAvailNotifRS.Errors[0].Type);
            Assert.Equal(" Unable to process this request. ", response.Body.OTA_HotelAvailNotifRS.Errors[0].ShortText);


            var foo = response.Body.OTA_HotelAvailNotifRS.Success;
        }

        const string EXPECTED_HOTEL_REQUEST = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"http://schemas.xmlsoap.org/soap/envelope/\"><Header><Interface ChannelIdentifierId=\"HIS_TOKYO_IIJ_XML4H\" Version=\"2011B\" Interface=\"VACATION QUICK CONNECT XML 4 OTA\" xmlns=\"http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/\"><ComponentInfo User=\"TEST_UNAME\" Pwd=\"TEST_PWORD\" ComponentType=\"Hotel\" /></Interface></Header><Body RequestId=\"TEST_ID\" Transaction=\"HotelAvailNotifRQ\"><OTA_HotelAvailNotifRQ Target=\"Production\" Version=\"1\" PrimaryLangID=\"en\" TimeStamp=\"2018-01-01T00:00:00\" xmlns=\"http://www.opentravel.org/OTA/2003/05\"><AvailStatusMessages HotelCode=\"hotelA\"><AvailStatusMessage BookingLimit=\"5\" BookingLimitMessageType=\"SetLimit\"><StatusApplicationControl Start=\"2018-01-01\" End=\"2018-01-01\" RatePlanCode=\"RACK\" InvCode=\"DELUXE\" IsRoom=\"1\" InvCodeApplication=\"InvCode\" RatePlanCodeType=\"RatePlanCode\" /><RestrictionStatus Restriction=\"Master\" Status=\"Close\" /><LengthsOfStay ArrivalDateBased=\"1\" FixedPatternLength=\"8\"><LengthOfStay MinMaxMessageType=\"FullPatternLOS\" TimeUnit=\"Day\" Time=\"1\" OpenStatusIndicator=\"false\" /><LengthOfStay MinMaxMessageType=\"FullPatternLOS\" TimeUnit=\"Day\" Time=\"2\" OpenStatusIndicator=\"true\" /><LengthOfStay MinMaxMessageType=\"FullPatternLOS\" TimeUnit=\"Day\" Time=\"3\" OpenStatusIndicator=\"true\" /><LengthOfStay MinMaxMessageType=\"FullPatternLOS\" TimeUnit=\"Day\" Time=\"4\" OpenStatusIndicator=\"true\" /><LengthOfStay MinMaxMessageType=\"FullPatternLOS\" TimeUnit=\"Day\" Time=\"5\" OpenStatusIndicator=\"false\" /><LengthOfStay MinMaxMessageType=\"FullPatternLOS\" TimeUnit=\"Day\" Time=\"6\" OpenStatusIndicator=\"false\" /><LengthOfStay MinMaxMessageType=\"FullPatternLOS\" TimeUnit=\"Day\" Time=\"7\" OpenStatusIndicator=\"false\" /><LengthOfStay MinMaxMessageType=\"FullPatternLOS\" TimeUnit=\"Day\" Time=\"8\" OpenStatusIndicator=\"true\" /></LengthsOfStay></AvailStatusMessage></AvailStatusMessages></OTA_HotelAvailNotifRQ></Body></Envelope>";
        const string SUCCESS_HOTEL_RESPONSE = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><soap-env:Envelope xmlns:soap-env=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap-env:Header><Interface ChannelIdentifierId=\"HIS_TOKYO_IIJ_XML4H\" Version=\"2011B\" Interface=\"VACATION QUICK CONNECT XML 4 OTA\" xmlns=\"http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/\"><ComponentInfo User=\"his\" Pwd=\"******\" ComponentType=\"Hotel\" /></Interface></soap-env:Header><soap-env:Body RequestId=\"2014121813010017221518\" Transaction=\"HotelAvailNotifRS\"><OTA_HotelAvailNotifRS xmlns=\"http://www.opentravel.org/OTA/2003/05\" TimeStamp=\"2012-0902T15:01:34+02:00\" Version=\"1.000\" PrimaryLangID=\"en\"><Success/></OTA_HotelAvailNotifRS></soap-env:Body></soap-env:Envelope>";
        const string ERROR_HOTEL_RESPONSE = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><soap-env:Envelope xmlns:soap-env=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap-env:Header><Interface ChannelIdentifierId=\"HIS_TOKYO_IIJ_XML4H\" Version=\"2011B\" Interface=\"VACATION QUICK CONNECT XML 4 OTA\" xmlns=\"http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/\"><ComponentInfo User=\"his\" Pwd=\"******\" ComponentType=\"Hotel\" /></Interface></soap-env:Header><soap-env:Body RequestId=\"2014121813010017221518\" Transaction=\"HotelAvailNotifRS\"><OTA_HotelAvailNotifRS xmlns=\"http://www.opentravel.org/OTA/2003/05\" TimeStamp=\"2012-0902T15:01:34+02:00\" Version=\"1.000\" PrimaryLangID=\"en\"><Errors><Error Language=\"en-us\" Type=\"3\" ShortText=\" Unable to process this request. \" Code=\"450\">Unable to process this request at this time.</Error></Errors></OTA_HotelAvailNotifRS></soap-env:Body></soap-env:Envelope>";
    }
}
