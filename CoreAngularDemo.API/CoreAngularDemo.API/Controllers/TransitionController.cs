using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.BLL.Factories;
using CoreAngularDemo.BLL.Services.Interfaces;

namespace CoreAngularDemo.API.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [Authorize(Roles = "ADMIN,ENGINEER,ANALYST")]
    public class CoreAngularDemoionController : FilterController<CoreAngularDemoionDTO>
    {
        private readonly ICoreAngularDemoionService _CoreAngularDemoionService;

        public CoreAngularDemoionController(IServiceFactory serviceFactory, IFilterServiceFactory filterServiceFactory)
            : base(filterServiceFactory)
        {
            _CoreAngularDemoionService = serviceFactory.CoreAngularDemoionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] uint offset = 0, uint amount = 1000)
        {
            return Json(await _CoreAngularDemoionService.GetRangeAsync(offset, amount));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Json(await _CoreAngularDemoionService.GetAsync(id));
        }

        [HttpGet("/search")]
        public async Task<IActionResult> Get([FromQuery] string search)
        {
            return Json( await _CoreAngularDemoionService.SearchAsync(search));
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([FromBody] CoreAngularDemoionDTO CoreAngularDemoionDto)
        {
            return CreatedAtAction(nameof(Create), await _CoreAngularDemoionService.CreateAsync(CoreAngularDemoionDto));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update(int id, [FromBody] CoreAngularDemoionDTO CoreAngularDemoionDto)
        {
            CoreAngularDemoionDto.Id = id;
            return Json(await _CoreAngularDemoionService.UpdateAsync(CoreAngularDemoionDto));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(int id)
        {
            await _CoreAngularDemoionService.DeleteAsync(id);
            return NoContent();
        }
    }
}