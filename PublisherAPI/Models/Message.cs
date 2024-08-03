using System.ComponentModel.DataAnnotations;

namespace PublisherAPI.Models
{
    public class Message : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? TopicMessage { get; set; }

        [Required]
        public int SubscriptionId { get; set; }

        [Required]
        public DateTime ExpiresAfter { get; set; } = DateTime.Now.AddDays(1);

        [Required]
        public string? MessageStatus { get; set; } = "NEW";

    }
}
