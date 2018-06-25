namespace HIS.Models.Request
{
    public class HISHotel<T, U> where T : class
                                where U : class
    {
        EnvelopeHeader Header { get; set; }
        EnvelopeBody<T, U> Body { get; set; }

    }



}


