using FluentConfiguration.Inter;

namespace FluentConfiguration.Dtos
{
    public class UnitSummary
    {
        public Guid Id { get; set; }
        public string UnitSize { get; set; }
        public decimal Price { get; set; }
        public string UnitType { get; set; }
        public dynamic  Amenitys { get; set; }
    }
}
