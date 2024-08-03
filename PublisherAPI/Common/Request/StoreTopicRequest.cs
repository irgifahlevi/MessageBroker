using System.ComponentModel.DataAnnotations;

namespace PublisherAPI.Common.Request
{
    public class StoreTopicRequest
    {
        [Required]
        public string? TopicName { get; set; }
    }
}
