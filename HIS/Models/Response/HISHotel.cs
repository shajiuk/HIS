namespace HIS.Models
{
    public class HISHotel<T, U> where T : class
                                where U : class
    {
        EnvelopeHeader<T> Header { get; set; }
        EnvelopeBody<T, U> Body { get; set; }

    }



}


