using Application.Service;
using Core.DTO;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionService.GetAllAsync();
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var region = await _regionService.GetByIdAsync(id);
            if (region == null) return NotFound();
            return Ok(region);
        }

        [HttpPost("createRegion")]
        public async Task<IActionResult> Create(RegionDTO dto)
        {
            var created = await _regionService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _regionService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
