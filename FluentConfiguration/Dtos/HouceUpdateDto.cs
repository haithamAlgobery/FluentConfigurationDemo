
using FluentConfiguration.Inter;

namespace FluentConfiguration.Dtos
{
    public class HouceUpdateDto
    {
        public int NumberOfBedrooms { get; set; }
        public int HasGarge { get; set; }
    }
    public class OfficeUpdateDto 
    {
        public int NumberOfWorkspaces { get; set; }
        public bool HasConferenceRoom { get; set; }
    }
    public class ApartmentUpdateDto: IAmenity
    {
        public int FloorNumber { get; set; }
        public bool HasBalcony { get; set; }
    }


}
