using Cairo_book_fair.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "AdminPolicy")]

    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorsService _visitorService;

        public VisitorsController(IVisitorsService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public IActionResult GetVisitors()
        {
            var visitors = _visitorService.GetAll();

            return Ok(visitors);
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateVisitor(int id, VisitorsDTO visitorDto)
        {
            var visitor = _visitorService.Update(id, visitorDto);

            if (visitor != null)
            {
                return Ok(visitor);
            }

            return BadRequest("Invalid ID");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(VisitorsDTO visitorDto)
        {
            var visitor = _visitorService.Add(visitorDto);

            return Ok(visitor);
        }



    }
}
