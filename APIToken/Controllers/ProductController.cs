using APIToken.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace APIToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController :ControllerBase
    {

            private readonly ProductContext _context;
            public ProductController(ProductContext context)
            {
                _context = context;
            }
            [HttpGet("id")]
            public async Task<IActionResult> GetById(int id)
            {
            var product =await _context.Products.FindAsync(id);
            return product == null ? NotFound() : Ok(product);
                }
        
        [HttpGet]
        [Authorize]
            public async Task<IEnumerable<Product>> Get()
            { 
            return await _context.Products.ToListAsync();
            }

        }
}
