namespace ConfigurationManager.Core.Models
{
    public class File
    {
        public int Id { get; set; }
        //public Template Template { get; set; }
        //public int TemplateId { get; set; }
        public ICollection<FileVersion> Versions { get; set; }
        public Instance Instance { get; set; }
        public int InstanceId { get; set; }
    }
}
