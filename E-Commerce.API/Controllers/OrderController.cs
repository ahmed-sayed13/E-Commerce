using E_Commerce.API.Helper;
using E_Commerce.Core.DTO;
using E_Commerce.Core.Entites;
using E_Commerce.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseControllers
    {
        public OrderController(IUnitOfWork work) : base(work)
        {
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await _work.orderRepository.GetAllAsync();
                if (orders is null)
                    return BadRequest(new ResponsAPI(400));
                return Ok(orders);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _work.orderRepository.GetByIdAsync(id,o=>o.Items, o => o.UserId);
                var result = _mapper.Map<OrderDto>(order);
                if (order is null)
                    return BadRequest(new ResponsAPI(400));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add-order")]
        public async Task<IActionResult> Add(Order order)
        {
            try
            {
                await _work.orderRepository.AddAsync(order);
                return Ok(new ResponsAPI(200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponsAPI(400, ex.Message));
            }
        }
        // POST /api/orders
     /*   [HttpPost("Create-Order")]
        
        public async Task<IActionResult> CreateOrder([FromBody] AddOrderDto dto)
        {
              await _work.orderRepository.AddAsyncOrder(dto);
            var order = new Order
            {
                UserId = dto.UserId,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                Items = dto.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };
            order.TotalPrice= order.Items.Sum(i => i.Quantity * i.UnitPrice);
            await _work.orderRepository.AddAsyncOrder(dto);
            var result = _mapper.Map<OrderResponseDto>(order);
            
            if (result is null)
            {
                return BadRequest(new ResponsAPI(400));
            }
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);

        }

        // GET /api/orders
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOrders([FromQuery] int? userId)
        {
            var orders = await _work.GetOrdersAsync(userId, User);
            return Ok(orders);
        }

        // PUT /api/orders/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusDto dto)
        {
            var updated = await _orderService.UpdateOrderStatusAsync(id, dto.Status);
            if (!updated)
                return NotFound();
            return Ok(new { message = "Order status updated successfully." });
        }*/


    }
}
