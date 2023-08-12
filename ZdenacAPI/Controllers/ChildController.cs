using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Zdenac_API.Models.DTOs;
using Zdenac_API.Services.Interfaces;

namespace Zdenac_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {

        private readonly IChildService _childService;
        private readonly ILogger<ChildController> _logger;

        public ChildController(IChildService childService, ILogger<ChildController> logger)
        {
            _childService = childService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddChild([FromBody] ChildDTO model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid PUT attempt in {nameof(AddChild)}");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Prosa put JEEEESSSSS");
            await _childService.AddChild(model);
            return CreatedAtAction("GetChildById", new { id = model.Id }, model);



        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _childService.DeleteChild(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ChildDTO model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await _childService.UpdateChild(id, model);
            return NoContent();


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Child>>> GetAllChildren()
        {
            var children = await _childService.GetAllChildren();
            return Ok(children);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Child>> GetChildById(int id)
        {
            var child = await _childService.GetChildById(id);

            if (child == null)
            {
                return NotFound();
            }

            return Ok(child);
        }
    }
}
