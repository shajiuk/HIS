namespace Travco.HIS.Model
{
    public interface IHISHeaderInfo
    {
        string RequestId { get; set; }
        string Transaction { get; set; }
        string EchoToken { get; set; }
        string Target { get; set; }
        string PrimaryLangID { get; set; }
    }
}