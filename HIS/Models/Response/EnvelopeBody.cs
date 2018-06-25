namespace HIS.Models.Response
{
    public class EnvelopeBody<T, U> : IEnvelopeBody
    {

        public int Debug { get; set; }

        public U OTA_HotelAvailRQ { get; set; }

        public string RequestId { get; set; }

        public string Transaction { get; set; }
    }



}


