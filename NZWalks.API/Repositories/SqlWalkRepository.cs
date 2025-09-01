using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _context;

        public SqlWalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this._context = nZWalksDbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteWalkByIdAsync(Guid id)
        {
            var existingWalk = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null) 
            {
                return null;
            }

            _context.Walks.Remove(existingWalk);
            await _context.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
        {
            var walks = _context.Walks.Include("Difficulty").Include("Region").AsQueryable();

            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            return await walks.ToListAsync();

            //return await _context.Walks.Include("Difficulty").Include("Region").ToListAsync();


        }

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
            return await _context.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingWalk = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null) 
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId  = walk.RegionId;

            await _context.SaveChangesAsync();

            return existingWalk;
        }
    }
}
