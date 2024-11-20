using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TH_Harmic.Models;

namespace TH_Harmic.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly Th2Context _context;

        public ProductViewComponent(Th2Context context)
        {

            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items= _context.TbProducts.Include(m=>m.CategoryProduct).Where(m=>(bool)m.IsActive).Where(m=>m.IsNew);
            return await Task.FromResult<IViewComponentResult>(View(items.OrderByDescending(m=>m.ProductId).ToList()));
        }
    }
}
