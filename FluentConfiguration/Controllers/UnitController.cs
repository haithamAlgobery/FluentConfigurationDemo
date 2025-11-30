using FluentConfiguration.Dtos;
using FluentConfiguration.Model;
using FluentConfiguration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FluentConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly UnitService _unitService;

        public UnitController(UnitService unitService)
        {
            _unitService = unitService;
        }
        [HttpPut("{houceId:guid}/houce")]
        public async Task<IActionResult> UpdateHouce(Guid houceId,HouceUpdateDto request)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(request));


            if (await _unitService.GetByIdAsync(houceId) is not House houce)
                return NotFound();

            houce.ConfigurAmenitys<HouseAmenities>(opi =>
            {
                opi.NumberOfBedrooms = request.NumberOfBedrooms;
                opi.HasGarge=request.HasGarge;
            });

           await _unitService.Upsert(houce);

            return NoContent();
        }
        [HttpPut("{officeId:guid}/office")]
        public async Task<IActionResult> UpdateOffice(Guid officeId, OfficeUpdateDto request)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(request));


            if (await _unitService.GetByIdAsync(officeId) is not Office office)
                return NotFound();

            office.ConfigurAmenitys<OfficeAmenities>(opi =>
            {
                opi.NumberOfWorkspaces = request.NumberOfWorkspaces;
                opi.HasConferenceRoom = request.HasConferenceRoom;
            });

            await _unitService.Upsert(office);

            return NoContent();
        }

        [HttpPut("{apartmentId:guid}/apartment")]
        public async Task<IActionResult> UpdatApartment(Guid apartmentId, ApartmentUpdateDto request)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(request));


            if (await _unitService.GetByIdAsync(apartmentId) is not Apartment apartment)
                return NotFound();

            apartment.ConfigurAmenitys<ApartmentAmenities>(opi =>
            {
                opi.FloorNumber = request.FloorNumber;
                opi.HasBalcony = request.HasBalcony;
            });


            await _unitService.Upsert(apartment);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitService.GetAllAsync());
        }


        [HttpPost]
        public async Task<IActionResult> CreateTestData()
        {
            for (int i = 1; i <= 3; i++)
            {
                await _unitService.Upsert(new House
                {
                    Id = Guid.NewGuid(),
                    Price = 5000 + i,
                    UnitSize = $"{150 + i * 10} m",
                    HouseAmenities = new HouseAmenities
                    {
                        NumberOfBedrooms = i + 2,
                        HasGarge = i % 2
                    }
                });

                await _unitService.Upsert(new Office
                {
                    Id = Guid.NewGuid(),
                    Price = 7000 + i,
                    UnitSize = $"{100 + i * 20} m",
                    OfficeAmenities = new OfficeAmenities
                    {
                        NumberOfWorkspaces = 2 + i,
                        HasConferenceRoom = i % 2 == 0
                    }
                });

                await _unitService.Upsert(new Apartment
                {
                    Id = Guid.NewGuid(),
                    Price = 6000 + i,
                    UnitSize = $"{90 + i * 15} m",
                    ApartmentAmenities = new ApartmentAmenities
                    {
                        FloorNumber = i,
                        HasBalcony = i % 2 == 1
                    }
                });
            }

            return Ok("3 items for each type created!");
        }


    }
}
