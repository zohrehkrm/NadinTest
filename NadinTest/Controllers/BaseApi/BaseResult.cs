namespace NadinTest.Controllers.BaseApi
{
    public class BaseResult
    {
        public object Data {  get; set; }
        public Status status { get; set; }
        public string Massage { get; set; }
    }

    public enum Status
    {
        Success = 1,
        Failed = 2
    }
}
