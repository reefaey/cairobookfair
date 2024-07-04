using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        [HttpPost]
        // admin allowed to register users >> if yes >> choose their role from dropdown list >> must reflect on register e.p??????
        public async Task<ActionResult> Add(string roleName)  // should ask for authority of this role????
        {

            IdentityRole role = new IdentityRole();
            role.Name = roleName;
            try
            {
                await roleManager.CreateAsync(role);
                return Ok(role);
            }
            catch (Exception ex)
            {
                //return new GeneralResponse()
                //{
                //    IsSuccess = false,
                //    Data = null,
                //    Message = "Error on adding role"
                //};

                return BadRequest(ex.Message);
            }
        }
    }        
}
