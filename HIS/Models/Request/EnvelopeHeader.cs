namespace HIS.Models.Request
{
    public class EnvelopeHeader<T> : IEnvelopeHeader
    {

        public Interface<T> Interface { get; set; }
    }



}


