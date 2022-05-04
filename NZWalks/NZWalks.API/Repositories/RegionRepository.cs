using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
            var region = await nZWalksDbContext.Regions.FirstOrDefaultAsync(f => f.Id == Id);
            if (region == null)
            {
                return null;
            }
            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid Id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(f => f.Id == Id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var region1 = await nZWalksDbContext.Regions.FirstOrDefaultAsync(f => f.Id == id);
            region1.Area = region.Area;
            region1.Code = region.Code;
            region1.Name = region.Name;
            region1.Population = region.Population;
            region1.Lat = region.Lat;
            region1.Long = region.Long;
            nZWalksDbContext.Regions.Update(region1);
            await nZWalksDbContext.SaveChangesAsync();
            return region1;
        }
    }
}
