namespace ConfigurationManager.Core.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BaseParameter> Items { get; set; }
    }
}
