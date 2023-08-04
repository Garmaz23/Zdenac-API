using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;


namespace Zdenac_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly DataContext _context;

        public ChildController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Child>>>> GetChildren()
        {
            var ListOfChildren = await _context.Children.ToListAsync();
            var response = new ServiceResponse<List<Child>>()
            {
                Data = ListOfChildren
            };
            return Ok(response);
        }
    }
}
