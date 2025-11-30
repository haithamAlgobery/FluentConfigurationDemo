using FluentConfiguration.Inter;

namespace FluentConfiguration.Model
{
    public abstract class Units
    {
        public Guid Id { get; set; }
        public string UnitSize { get; set; }
        public decimal Price { get; set; }
        public string UnitType { get; set; }
        public abstract IAmenity GetAmenitys();
        public  void ConfigurAmenitys<TAmenitys>(Action<TAmenitys> confi) where TAmenitys : class ,IAmenity
        {
            ArgumentNullException.ThrowIfNull(nameof(confi));

            var amenitys = GetAmenitys() as TAmenitys;
            if (amenitys == null)
                throw new InvalidOperationException("Invaild Amenitys");

            confi(amenitys);


        }
    }

    public class ApartmentAmenities : IAmenity
    {
        public int? FloorNumber { get; set; }
        public bool? HasBalcony { get; set; }
    }

    public class HouseAmenities : IAmenity
    {
        public int? NumberOfBedrooms { get; set; }
        public int? HasGarge { get; set; }
    }


    public class House : Units
    {
        public HouseAmenities HouseAmenities { get; set; }=new ();

        public override IAmenity GetAmenitys() => HouseAmenities;
    }

    public class Apartment: Units
    {
        public ApartmentAmenities ApartmentAmenities { get; set; } = new();

        public override IAmenity GetAmenitys() => ApartmentAmenities;
    }
    public class OfficeAmenities : IAmenity
    {
        public int? NumberOfWorkspaces { get; set; }
        public bool? HasConferenceRoom { get; set; }
    }

    public class Office : Units
    {
        public OfficeAmenities OfficeAmenities { get; set; } = new();

        public override IAmenity GetAmenitys() => OfficeAmenities;
    }
}
