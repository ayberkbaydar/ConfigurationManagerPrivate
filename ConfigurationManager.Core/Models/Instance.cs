namespace ConfigurationManager.Core.Models
{
    public class Instance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public File SystemFile { get; set; }
        //public int SystemFileId { get; set; }
        public ICollection<File> ConfigFiles { get; set; }
        public File SystemFile { get; set; }
        public int SystemFileId { get; set; }
        //public List<File> ConfigFile { get; set; }
        //public List<Environment> Environment { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
