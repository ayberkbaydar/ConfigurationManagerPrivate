namespace ConfigurationManager.Core.Models
{
    public class Environment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cluster Cluster { get; set; }
        public int ClusterId { get; set; }
    }
}
