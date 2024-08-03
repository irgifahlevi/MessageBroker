namespace PublisherAPI.Models
{
    public class BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public int RowStatus { get; set; }
    }
}
