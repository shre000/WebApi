using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [ApiController]
 [Route("api/[Controller]")]
    public class UserDetailsController : Controller
    {
        private readonly IConfiguration _configuration;
        private UsersAPIDbContext _context;
        public UserDetailsController(IConfiguration configuration, UsersAPIDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
     
        [HttpGet]
        [Route("~/api/[Controller]/GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            var res = await _context.UserDetails.ToListAsync();
            return Ok(res);
        }

        [HttpPost]
        [Route("~/api/[Controller]/AddContact")]
        public async Task<IActionResult> AddContact(UserDetails addContactRequest)
        {
            var contact = new UserDetails()
            {
                Id = addContactRequest.Id,
                Name = addContactRequest.Name,
                Password = addContactRequest.Password,
                Email = addContactRequest.Email,
                Department = addContactRequest.Department,
            };
            await _context.UserDetails.AddAsync(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }


    }
}
