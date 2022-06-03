namespace ConfigurationManager.Core.Models
{
    public class FileVersion
    {
        public int Id { get; set; }
        public string Version { get; set; }
        //public List<ParameterValue> Values { get; set; }
        //public AuditLog Audit { get; set; }
        //public int AuditId { get; set; }
        //public Draft Draft { get; set; }
        //public int DraftId { get; set; }
        public File File { get; set; }
        public int? FileId { get; set; }
        public Draft Draft { get; set; }
    }
}
