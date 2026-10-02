using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopierClone.API.Data;
using ShopierClone.API.Entities;

namespace ShopierClone.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // 1. Tüm Ürünleri Listele (GET: api/products)
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    // 2. Yeni Ürün Ekle (POST: api/products)
    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Ürün başarıyla veritabanına eklendi!", product });
    }
}