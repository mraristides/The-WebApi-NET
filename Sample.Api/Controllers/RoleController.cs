using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Application.VO;
using Sample.Application.Services;
using Sample.Hypermedia.Filters;

namespace Sample.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Authorize(Roles = "AD99999")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private IRoleAppService _RoleService;

        public RoleController(ILogger<RoleController> logger, IRoleAppService RoleService)
        {
            _logger = logger;
            _RoleService = RoleService;
        }

        [HttpGet("")]
        [ProducesResponseType((200), Type = typeof(List<RoleVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_RoleService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(RoleVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var Role = _RoleService.FindByID(id);
            if (Role == null) return NotFound();
            return Ok(Role);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(RoleVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create([FromBody] RoleVO Role)
        {
            if (Role == null) return BadRequest();
            return Ok(_RoleService.Create(Role));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(RoleVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Update([FromBody] RoleVO Role)
        {
            if (Role == null) return BadRequest();
            return Ok(_RoleService.Update(Role));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _RoleService.Delete(id);
            return NoContent();
        }
    }
}
