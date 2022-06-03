namespace ConfigurationManager.Core.Models
{
    public abstract class BaseParameter
    {
        public int Id { get; set; }
        public string Defination { get; set; }
        public string Explanation { get; set; }
    }
}
