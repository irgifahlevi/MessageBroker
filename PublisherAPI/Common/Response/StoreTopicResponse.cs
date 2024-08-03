using PublisherAPI.Models;

namespace PublisherAPI.Common.Response
{
    public class StoreTopicResponse : BaseResponse
    {
        public Topic Item { get; set; }
    }
}
