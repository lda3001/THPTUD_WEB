using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TH_Harmic.Models;

namespace TH_Harmic.Controllers
{
    public class BlogController : Controller
    {
        private readonly Th2Context _context;
        public BlogController(Th2Context context)
        {
            _context = context;
        }

        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbBlogs == null)
            {
                return NotFound();
            }
            var blog = await _context.TbBlogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id).ToList();
            ViewBag.productNew = _context.TbProducts.Where(m => m.IsNew).ToList();
            return View(blog);
        }
    }
}

