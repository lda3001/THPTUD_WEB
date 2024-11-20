using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TH_Harmic.Models;

namespace TH_Harmic.Controllers
{
    public class ProductController : Controller
    {
        private readonly Th2Context _context;
        public ProductController(Th2Context context)
        {
            _context = context;
        }

        [Route("/product/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            Console.WriteLine("vvo");
            if (id == null || _context.TbProducts == null)
            {
                return NotFound();
            }
            var product = await _context.TbProducts.Include(i => i.CategoryProduct).FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.productReview = _context.TbProductReviews.Where(i => i.ProductId == id && i.IsActive).ToList();
            ViewBag.productRelated = _context.TbProducts.Where(i => i.ProductId != id && i.CategoryProductId == product.CategoryProductId).Take(5).OrderByDescending(i => i.ProductId).ToList();
            ViewBag.productNew = _context.TbProducts.Where(m => m.IsNew).ToList();
            return View( product);
        }

    }
}
