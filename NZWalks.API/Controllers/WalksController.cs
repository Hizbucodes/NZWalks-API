using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly NZWalksDbContext _context;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, NZWalksDbContext dbContext, IWalkRepository walkRepository)
        {
            this._mapper = mapper;
            this._context = dbContext;
            this.walkRepository = walkRepository;
        }

        // CREATE Walk
        // POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {        
            // Map DTO to Domain Model - AddWalkRequestDto -> Walk Domain
            var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        // Get All Walks
        // GET: /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy,[FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walkDomain = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            // Map Domain Model to DTO
            var walkDto = _mapper.Map<List<WalkDto>>(walkDomain);

            return Ok(walkDto);
        }

        // Get Walk by Id
        [HttpGet]
        [Route("${id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetWalkByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        // Update Walk
        [HttpPut]
        [Route("${id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, UpdateRequestWalkDto updateRequestWalkDto)
        {

            

            var walkDomainModel = _mapper.Map<Walk>(updateRequestWalkDto);

            walkDomainModel = await walkRepository.UpdateWalkAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpDelete]
        [Route("${id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
          var deletedWalkDomainModel =  await walkRepository.DeleteWalkByIdAsync(id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            var deletedWalkDto = _mapper.Map<WalkDto>(deletedWalkDomainModel);

            return Ok(deletedWalkDto);
        }
    }
}
