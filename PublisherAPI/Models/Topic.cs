using System.ComponentModel.DataAnnotations;

namespace PublisherAPI.Models
{
    public class Topic : BaseModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? TopicName { get; set; }
    }
}
