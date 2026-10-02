using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopierClone.API.Data;
using ShopierClone.API.Entities;

namespace ShopierClone.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    // 1. Yeni Sipariş Oluştur (POST: api/orders)
    [HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        // Gelen siparişi veritabanına ekliyoruz
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Siparişiniz başarıyla alındı!", orderId = order.Id, orderNumber = order });
    }

    // 2. Tüm Siparişleri Listele - Admin için (GET: api/orders)
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _context.Orders.ToListAsync();
        return Ok(orders);
    }
}