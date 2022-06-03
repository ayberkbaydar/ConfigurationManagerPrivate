namespace ConfigurationManager.Core.Models.ParameterObjects
{
    public class ComboBox : ParameterType
    {
        public int ValueId { get; set; }
        public string Value { get; set; }
        public string DefaultValue { get; set; }
    }
}
