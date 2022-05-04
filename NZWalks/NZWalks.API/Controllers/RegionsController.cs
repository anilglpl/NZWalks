using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllAsync();
            var regionsList = mapper.Map<List<RegionDto>>(regions);
            return Ok(regionsList);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _regionRepository.GetAsync(id);
            if(region == null)
            {
                return NotFound();
            }
            var regiondto = mapper.Map<RegionDto>(region);
            return Ok(regiondto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
            var addRegion = mapper.Map<Region>(addRegionRequest);
            var region = await _regionRepository.AddAsync(addRegion);
            var regionDto = mapper.Map<RegionDto>(region);
            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDto.Id }, regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regiondto = mapper.Map<RegionDto>(region);
            return Ok(regiondto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id, [FromBody] UpdateRegionRequest updateRequest)
        {

            var region = new Region();
            if (region == null)
            {
                return NotFound();
            }
            var updatedRegion = mapper.Map<UpdateRegionRequest, Region>(updateRequest,region);

            await _regionRepository.UpdateAsync(id, updatedRegion);
            return Ok(updateRequest);
        }
    }
}
