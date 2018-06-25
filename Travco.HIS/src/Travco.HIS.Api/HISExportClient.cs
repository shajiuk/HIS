using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Travco.HIS.Model.Request.Export.HotelAvail;
using Travco.HIS.Model.Request.Export.HotelRateAmount;
using Travco.HIS.Model.Response.Export.HotelAvail;
using Travco.HIS.Model.Response.Export.HotelRateAmount;

namespace Travco.HIS.Api
{
    public class HISExportClient : IHISExportClient
    {
        private readonly IOptions<HISExportOptions> _options;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private readonly Random _rand;

        public HISExportClient(IOptions<HISExportOptions> options, ILogger<HISExportClient> logger, HttpClient httpClient)
        {
            _options = options;
            _logger = logger;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.Uri);
            _rand = new Random();
        }

        public async Task<HotelAvailNotifRS> SendHotel(OTA_HotelAvailNotifRQ request, string id = null)
        {
            if (id == null)
                id = GetId();

            //using (var f = new System.IO.FileStream(String.Format("{0}_{1}.xml", request.GetType().Name, id), FileMode.Create))
            //{
            //    var foo = Serialise(request);
            //    f.Write(foo, 0, foo.Length);
            //}

            HotelAvailNotifRQ envelope = new HotelAvailNotifRQ
            {
                Header = new Model.EnvelopeHeader
                {
                    Interface = new Model.Interface
                    {
                        ChannelIdentifierId = "HIS_TOKYO_IIJ_XML4H",
                        Version = "2011B",
                        Interface1 = "VACATION QUICK CONNECT XML 4 OTA",
                        ComponentInfo = new Model.InterfaceComponentInfo
                        {
                            User = _options.Value.Username,
                            Pwd = _options.Value.Password,
                            ComponentType = "Hotel"
                        }
                    }
                },
                Body = new Model.Request.Export.HotelAvail.EnvelopeBody
                {
                    RequestId = id,
                    Transaction = "HotelAvailNotifRQ",
                    OTA_HotelAvailNotifRQ = request
                }
            };

            try
            {
                var response = await Send<HotelAvailNotifRS>("", envelope);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Hotel export");
                return null;
            }
        }

        public async Task<HotelRateAmountNotifRS> SendRates(OTA_HotelRateAmountNotifRQ request, string id = null)
        {
            if (id == null)
                id = GetId();

            //using (var f = new System.IO.FileStream(String.Format("{0}_{1}.xml", request.GetType().Name, id), FileMode.Create))
            //{
            //    var foo = Serialise(request);
            //    f.Write(foo, 0, foo.Length);
            //}

            HotelRateAmountNotifRQ envelope = new HotelRateAmountNotifRQ
            {
                Header = new Model.EnvelopeHeader
                {
                    Interface = new Model.Interface
                    {
                        ChannelIdentifierId = "HIS_TOKYO_IIJ_XML4H",
                        Version = "2011B",
                        Interface1 = "VACATION QUICK CONNECT XML 4 OTA",
                        ComponentInfo = new Model.InterfaceComponentInfo
                        {
                            User = _options.Value.Username,
                            Pwd = _options.Value.Password,
                            ComponentType = "Hotel"
                        }
                    }
                },
                Body = new Model.Request.Export.HotelRateAmount.EnvelopeBody
                {
                    RequestId = id,
                    Transaction = "HotelRateAmountNotifRQ",
                    OTA_HotelRateAmountNotifRQ = request
                }
            };

            try
            {
                var response = await Send<HotelRateAmountNotifRS>("", envelope);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Rate export");
                return null;
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        private async Task<T> Send<T>(string path, object envelope)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, path);
            message.Content = new ByteArrayContent(Serialise(envelope));
            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/soap+xml");
            var response = await _httpClient.SendAsync(message);

            var deserialiser = new XmlSerializer(typeof(T));
            var resultStream = response.Content.ReadAsStreamAsync().Result;

            var resultBody = new byte[resultStream.Length];
            resultStream.Read(resultBody, 0, Convert.ToInt32(resultStream.Length));
            _logger.LogInformation($"Response content: {Encoding.UTF8.GetString(resultBody)}");
            resultStream.Position = 0;

            var result = (T)Convert.ChangeType(deserialiser.Deserialize(resultStream), typeof(T));
            return result;
        }

        private byte[] Serialise<T>(T o)
        {
            var serialiser = new XmlSerializer(o.GetType());
            using (var stream = new MemoryStream())
            {
                var xmlSettings = new XmlWriterSettings
                {
                    Encoding = new System.Text.UTF8Encoding(false),
                    Indent = false
                };
                using (var writer = XmlWriter.Create(stream, xmlSettings))
                {
                    serialiser.Serialize(writer, o);
                    stream.Position = 0;
                    byte[] result = new byte[stream.Length];
                    stream.Read(result, 0, result.Length);
                    writer.Close();
                    _logger.LogInformation($"Serialised: {Encoding.UTF8.GetString(result)}");
                    return result;
                }
            }
        }

        private string GetId()
        {
            return DateTime.UtcNow.ToString("yyyyMMddHHmmss") + _rand.Next(100000000, 999999999).ToString();
        }
    }

    public class HISExportOptions
    {
        public string Uri { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }
    }

    public interface IHISExportClient
    {
        void Dispose();
        Task<HotelAvailNotifRS> SendHotel(OTA_HotelAvailNotifRQ request, string id = null);
        Task<HotelRateAmountNotifRS> SendRates(OTA_HotelRateAmountNotifRQ request, string id = null);
    }
}
