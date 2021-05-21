using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SoftNETProject.Data;

namespace SoftNETProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly SoftNETProjectContext _context;

        public CategoriesController(SoftNETProjectContext context, ILogger<CategoriesController> logger)
        {
            _logger = logger;
            _context = context;
        }

        private bool CategoryCheck(int? id)
        {
            try
            {
                return _context.Category.Any(e => e.Id == id);
            }
            catch (Exception exception)
            {
                    _logger.LogError(exception.Message);
                    throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            try
            {
                return await _context.Category.ToListAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            try
            {
                Category category = await _context.Category.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                return category;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryCheck(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError("PUT Category Failed to save changes");
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            try
            {
                _context.Category.Add(category);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCategory", new { id = category.Id }, category);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _context.Category.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                _context.Category.Remove(category);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }
    }
}
