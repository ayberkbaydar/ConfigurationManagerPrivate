namespace ConfigurationManager.Core.Models
{
    public class ParameterValue
    {
        public int Id { get; set; }
        public int? Value { get; set; }
        public Draft Draft { get; set; }
        public int DraftId { get; set; }
        //public Parameter Parameter { get; set; }
        //public int ParameterId { get; set; }
    }
}
