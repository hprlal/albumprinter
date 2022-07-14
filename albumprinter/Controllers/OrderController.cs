using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumPrinter.Interface;
using AlbumPrinter.Model;

namespace AlbumPrinter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService orderService;

        public OrderController(IOrderService os)
        {
            this.orderService = os;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            try
            {
                var order = orderService.GetOrder(id);
                if (order == null)
                    return NotFound();
                return Ok(order);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(Order o)
        {
            if (o.OrderId < 1 || o.Products.Count < 1 || o.Products.Any(x => x.Quantity < 1))
            {
                return BadRequest();
            }

            if (o.Products.All(x => (int)x.Type < 0 && (int)x.Type > 4))
            {
                return NotFound();
            }

            try
            {
                orderService.CreateOrder(o);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
