namespace College.Domain.Models
{
    public class BaseEntity
    {
        public Guid AlternativeId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
