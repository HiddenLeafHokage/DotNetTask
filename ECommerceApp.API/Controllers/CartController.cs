using ECommerceApp.Domain.Entities;
using ECommerceApp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly AppDbContext _context;

    public CartController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Cart
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartItem>>> GetCart()
    {
        var cartItems = await _context.CartItems
            .Include(c => c.Product)
            .ToListAsync();

        return Ok(cartItems);
    }

    // POST: api/Cart
    [HttpPost]
    public async Task<ActionResult> AddToCart([FromBody] CartItem item)
    {
        var product = await _context.Products.FindAsync(item.ProductId);
        if (product == null)
            return NotFound("Product not found");

        var existingItem = await _context.CartItems
            .FirstOrDefaultAsync(c => c.ProductId == item.ProductId);

        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            _context.CartItems.Add(item);
        }

        await _context.SaveChangesAsync();
        return Ok();
    }

    // PUT: api/Cart/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateQuantity(int id, [FromBody] int quantity)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item == null)
            return NotFound();

        item.Quantity = quantity;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/Cart/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveFromCart(int id)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item == null)
            return NotFound();

        _context.CartItems.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
