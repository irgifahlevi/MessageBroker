using System.ComponentModel.DataAnnotations;

namespace PublisherAPI.Models
{
    public class Subscription : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? SubscriptionName { get; set; }

        [Required]
        public int TopicId { get; set; }
    }
}
