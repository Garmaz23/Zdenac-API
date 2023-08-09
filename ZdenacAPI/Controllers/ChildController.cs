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

        public ChildController(IChildService childService)
        {
            _childService = childService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddChild([FromBody] ChildDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _childService.AddChild(model);
                return CreatedAtAction("GetChildById", new { id = model.Id }, model);
            }
            catch (Exception ex)
            {

                return BadRequest($"An error occurred while adding the child: {ex.Message}");

            }
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

            try
            {
                await _childService.UpdateChild(id, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "An error occurred while updating the child.");
            }
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
