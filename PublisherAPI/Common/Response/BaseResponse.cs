namespace PublisherAPI.Common.Response
{
    public abstract class BaseResponse
    {
        public string Message { get; set; }
        public bool Acknowledge { get; set; }
    }
}
