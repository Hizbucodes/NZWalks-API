﻿using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true);
        Task<Walk?> GetWalkByIdAsync(Guid id);
        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);

        Task<Walk?> DeleteWalkByIdAsync(Guid id);
    }
}
