namespace ConfigurationManager.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Draft Draft { get; set; }
        //public List<File> FileAuthorization { get; set; }
        //public List<Section> SectionAuthorization { get; set; }
        public Instance Instance { get; set; }
        public int? InstanceId { get; set; }
        public Type Type { get; set; }
        public int TypeId { get; set; }
    }
}
