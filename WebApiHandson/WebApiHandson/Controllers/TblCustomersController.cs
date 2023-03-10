using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiHandson.Models;

namespace WebApiHandson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCustomersController : ControllerBase
    {
        private readonly WebApiHandsonContext _context;

        public TblCustomersController(WebApiHandsonContext context)
        {
            _context = context;
        }

        // GET: api/TblCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCustomer>>> GetTblCustomers()
        {
          if (_context.TblCustomers == null)
          {
              return NotFound();
          }
            return await _context.TblCustomers.ToListAsync();
        }

        // GET: api/TblCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomer>> GetTblCustomer(int id)
        {
          if (_context.TblCustomers == null)
          {
              return NotFound();
          }
            var tblCustomer = await _context.TblCustomers.FindAsync(id);

            if (tblCustomer == null)
            {
                return NotFound();
            }

            return tblCustomer;
        }

        // PUT: api/TblCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCustomer(int id, TblCustomer tblCustomer)
        {
            if (id != tblCustomer.CustId)
            {
                return BadRequest();
            }

            _context.Entry(tblCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerExists(id))
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

        // POST: api/TblCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCustomer>> PostTblCustomer(TblCustomer tblCustomer)
        {
          if (_context.TblCustomers == null)
          {
              return Problem("Entity set 'WebApiHandsonContext.TblCustomers'  is null.");
          }
            _context.TblCustomers.Add(tblCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCustomer", new { id = tblCustomer.CustId }, tblCustomer);
        }

        // DELETE: api/TblCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCustomer(int id)
        {
            if (_context.TblCustomers == null)
            {
                return NotFound();
            }
            var tblCustomer = await _context.TblCustomers.FindAsync(id);
            if (tblCustomer == null)
            {
                return NotFound();
            }

            _context.TblCustomers.Remove(tblCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCustomerExists(int id)
        {
            return (_context.TblCustomers?.Any(e => e.CustId == id)).GetValueOrDefault();
        }
    }
}
