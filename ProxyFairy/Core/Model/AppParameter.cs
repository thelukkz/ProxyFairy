using ProxyFairy.Core.Enums;

namespace ProxyFairy.Core.Model
{
    public class AppParameter : BaseEntity
    {
        public ParameterType Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
