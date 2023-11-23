using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogAppAPI.Models;
using CatalogAppAPI.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace CatalogAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleDetailController : ControllerBase
    {
        private readonly ArticleDetailContext _context;

        public ArticleDetailController(ArticleDetailContext context)
        {
            _context = context;
        }

        // GET: api/ArticleDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDetail>>> GetArticleDetails()
        {
            return await _context.ArticleDetails.ToListAsync();
        }

        // GET: api/ArticleDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDetail>> GetArticleDetail(int id)
        {
            var articleDetail = await _context.ArticleDetails.FindAsync(id);

            if (articleDetail == null)
            {
                return NotFound();
            }

            return articleDetail;
        }

        // PUT: api/ArticleDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleDetail(int id, ArticleDetail articleDetail)
        {
            if (id != articleDetail.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(articleDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return Ok(await _context.ArticleDetails.ToListAsync());
        }

        // POST: api/ArticleDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticleDetail>> PostArticleDetail(ArticleDetail articleDetail)
        {
            _context.ArticleDetails.Add(articleDetail);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetArticleDetail", new { id = articleDetail.ArticleId }, articleDetail);
            return Ok(await _context.ArticleDetails.ToListAsync());
        }

        // DELETE: api/ArticleDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleDetail(int id)
        {
            var articleDetail = await _context.ArticleDetails.FindAsync(id);
            if (articleDetail == null)
            {
                return NotFound();
            }

            _context.ArticleDetails.Remove(articleDetail);
            await _context.SaveChangesAsync();

            //return NoContent();
            return Ok(await _context.ArticleDetails.ToListAsync());
        }

        private bool ArticleDetailExists(int id)
        {
            return _context.ArticleDetails.Any(e => e.ArticleId == id);
        }
    }
}
