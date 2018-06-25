using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using Travco.Helpers.Error;

namespace Travco.Helpers.HIS
{
    [Serializable]
    public class HISStandardErrorException : Exception
    {
        public HISStandardErrorException()
        {
        }

        public HISStandardErrorException(string message) : base(message)
        {
            //var errorRes = Utils.DeserializeFromXML<ErrorResponse>(message);

            //var HIS = Utils.SerializeToXMLSOAP(errorRes, "", "", "soap-env");
            //var httpContent = new StringContent(HIS, Encoding.UTF8, "application/xml");

        }

        public HISStandardErrorException(string message, Exception inner) : base(message, inner)
        {
        }

        public HISStandardErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            
        }
    }
}
