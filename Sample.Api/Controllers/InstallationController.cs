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
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InstallationController : ControllerBase
    {
        private readonly ILogger<InstallationController> _logger;
        private IInstallationAppService _InstallationService;

        public InstallationController(ILogger<InstallationController> logger, IInstallationAppService InstallationService)
        {
            _logger = logger;
            _InstallationService = InstallationService;
        }

        [HttpGet("")]
        [Authorize(Roles = "MA00001,AD99999")]
        [ProducesResponseType((200), Type = typeof(List<InstallationVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_InstallationService.FindAll());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "MA00001,AD99999")]
        [ProducesResponseType((200), Type = typeof(InstallationVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var Installation = _InstallationService.FindByID(id);
            if (Installation == null) return NotFound();
            return Ok(Installation);
        }

        [HttpPost]
        [Authorize(Roles = "AD99999")]
        [ProducesResponseType((200), Type = typeof(InstallationVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create([FromBody] InstallationVO Installation)
        {
            if (Installation == null) return BadRequest();
            return Ok(_InstallationService.Create(Installation));
        }

        [HttpPut]
        [Authorize(Roles = "AD99999")]
        [ProducesResponseType((200), Type = typeof(InstallationVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Update([FromBody] InstallationVO Installation)
        {
            if (Installation == null) return BadRequest();
            return Ok(_InstallationService.Update(Installation));
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "AD99999")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _InstallationService.Delete(id);
            return NoContent();
        }
    }
}
