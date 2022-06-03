namespace ConfigurationManager.Core.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
