using Microsoft.AspNetCore.Mvc;
using Registration_Page_Task.Business.Interfaces;
using Registration_Page_Task.Models;

namespace Registration_Page_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _service;

        // Constructor injection of registration service
        public RegistrationController(IRegistrationService service) => _service = service;

        // Get all users
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        // Get user by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            return user == null ? NotFound("User not found") : Ok(user);
        }

        // Create new user
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Registrations reg)
        {
            if (await _service.CreateAsync(reg)) return Ok("User created");
            return BadRequest("Creation failed");
        }

        // Update existing user
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Registrations reg)
        {
            var result = await _service.UpdateAsync(reg);
            if (result) return Ok("User updated");
            return BadRequest("Update failed");
        }

        // Delete user by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.DeleteAsync(id))
                return Ok("User deleted");

            return NotFound("User not found");
        }
    }
}
