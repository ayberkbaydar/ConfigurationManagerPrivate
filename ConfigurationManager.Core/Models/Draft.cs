namespace ConfigurationManager.Core.Models
{
    public class Draft
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public FileVersion FileVersion { get; set; }
        public int FileVersionId { get; set; }
        public ICollection<ParameterValue> Values { get; set; }
        
    }
}
