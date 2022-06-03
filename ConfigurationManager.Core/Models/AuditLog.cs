namespace ConfigurationManager.Core.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime ModifiedDate { get; set; }
        public User ModifiedBy { get; set; }
    }
}
