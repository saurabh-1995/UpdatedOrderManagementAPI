using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementWebAPI.Models;

namespace OrderManagementWebAPI.Controllers
{
    [EnableCors("CORS")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMastersController : ControllerBase
    {
        private readonly OrderManagementContext _context;

        public OrderMastersController()
        {
            _context = new OrderManagementContext();
        }

        // GET: api/OrderMasters
        [HttpGet]
        public IEnumerable<OrderMaster> GetOrderMaster()
        {
            return _context.OrderMaster;
        }

        // GET: api/OrderMasters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderMaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderMaster = await _context.OrderMaster.FindAsync(id);

            if (orderMaster == null)
            {
                return NotFound();
            }

            return Ok(orderMaster);
        }

        // PUT: api/OrderMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderMaster([FromRoute] int id, [FromBody] OrderMaster orderMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderMaster.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderMasters
        [HttpPost]
        public async Task<IActionResult> PostOrderMaster([FromBody] OrderMaster orderMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderMaster.Add(orderMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderMaster", new { id = orderMaster.OrderId }, orderMaster);
        }

        // DELETE: api/OrderMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderMaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderMaster = await _context.OrderMaster.FindAsync(id);
            if (orderMaster == null)
            {
                return NotFound();
            }

            _context.OrderMaster.Remove(orderMaster);
            await _context.SaveChangesAsync();

            return Ok(orderMaster);
        }

        private bool OrderMasterExists(int id)
        {
            return _context.OrderMaster.Any(e => e.OrderId == id);
        }
    }
}