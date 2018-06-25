using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Travco.Helpers.HIS;
using Travco.HIS.Model.Request.HotelDescriptiveInfo;
using Travco.HIS.Model.Response.HotelDescriptiveInfo;
using Travco.HIS.Model.Response.Error.SearchAvailability;
using Moq;
using Microsoft.Extensions.Logging;

namespace Travco.HIS.UnitTests
{
    public class HISHelperTests
    {
        [Fact]
        public void Helper_Test()
        {
            var logger = new Mock<ILogger>();

            var response = new HotelDescriptiveInfoRes
            {
                Header = new Model.Response.HotelDescriptiveInfo.EnvelopeHeader
                {

                },
                Body = new Model.Response.HotelDescriptiveInfo.EnvelopeBody
                {
                    OTA_HotelDescriptiveInfoRS = new OTA_HotelDescriptiveInfoRS
                    {
                        
                    }
                }
            };

            var error = new OTA_HotelAvailRSErrorsError
            {
                Code = "Code",
                ShortText = "Short Text",
                Type = 0,
                Value = "Value"
            };

            HISHelpers.ProcessErrorForModel<HotelDescriptiveInfoRes, Model.Response.Error.HotelDescriptiveInfo.ErrorResponse>(response, "TEST MESSAGE", error, logger.Object);
        }
    }
}
