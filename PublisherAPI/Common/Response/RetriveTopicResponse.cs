using PublisherAPI.Models;

namespace PublisherAPI.Common.Response
{
    public class RetriveTopicResponse : BaseResponse
    {
        public List<Topic> Items { get; set; }
    }
}
