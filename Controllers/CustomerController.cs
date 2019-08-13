using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoLoanWebAPI.Models;

namespace VideoLoanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly VideoLoanContext _context;

        public CustomerController(VideoLoanContext context)
        {
            _context = context;
        }

        [EnableCors("MyCors")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [EnableCors("MyCors")]
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomer(int id)
        {
            var result = _context.Customers.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return await result;
            }
        }

        [EnableCors("MyCors")]
        [HttpPost]
        public async Task<ActionResult<CustomerModel>> AddCustomer(CustomerModel model)
        {
            _context.Customers.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = model.ID }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerData(int id, CustomerModel model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}