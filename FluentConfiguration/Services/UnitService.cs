using FluentConfiguration.Data;
using FluentConfiguration.Dtos;
using FluentConfiguration.Model;
using Microsoft.EntityFrameworkCore;

namespace FluentConfiguration.Services
{
    public class UnitService
    {
        private readonly MyDbContext _myDb;

        public UnitService(MyDbContext myDb)
        {
            _myDb = myDb;
        }


        public async Task<Units?> GetByIdAsync(Guid id)
        {

            return await _myDb.Units.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<IEnumerable<UnitSummary>> GetAllAsync()
        {
            return await _myDb.Units.Select(x => new UnitSummary
            {
                Id = x.Id,
                Price = x.Price,
                UnitType = x.UnitType,
                UnitSize = x.UnitSize,
                Amenitys = x.GetAmenitys()
            }).ToListAsync();
        }

        public async Task Upsert(Units unit)
        {
            var entity = await _myDb.Units.FindAsync(unit.Id);
            if (entity == null)
            {
                _myDb.Units.Add(unit);
        
            }
            else
            {
                _myDb.Entry(entity).CurrentValues.SetValues(unit);
            }
            _myDb.SaveChanges();

        }
    }
}
