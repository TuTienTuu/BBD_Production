using BBD_Production_New.Data;
using BBD_Production_New.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BBD_Production_New.Controllers
{
    public class ProductionPlanController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductionPlanController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(DateTime? date)
        {
            IEnumerable<ProductionPlan> data = await _context.ProductionPlans.ToListAsync();
            //TempData["ResultOk"] = "Tạo kế hoạch mới thành công";
            ViewData["Title"] = "Danh sách lệnh sản xuất";
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductionPlan model)
        {
            if (ModelState.IsValid)
            {
                await _context.ProductionPlans.AddAsync(model);
                await _context.SaveChangesAsync();
                TempData["ResultOk"] = "Tạo kế hoạch thành công";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid productionPlanId)
        {
            if (productionPlanId == null || productionPlanId == Guid.Empty)
            {
                return NotFound();
            }

            var productionPlan =await _context.ProductionPlans.FirstOrDefaultAsync(x => x.ProductionPlanId == productionPlanId);
            if (productionPlan == null)
            {
                return NotFound();
            }
            else
            {
                return View(productionPlan);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductionPlan model)
        {
            if (ModelState.IsValid)
            {
                _context.ProductionPlans.Update(model);
                await _context.SaveChangesAsync();
                TempData["ResultOk"] = "Cập nhật kế hoạch thành công !";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid productionPlanId)
        {
            if (productionPlanId == null || productionPlanId == Guid.Empty)
            {
                return NotFound();
            }
            var data = await _context.ProductionPlans.FirstOrDefaultAsync(x=>x.ProductionPlanId == productionPlanId);

            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmp(Guid productionPlanId)
        {
            var data = await _context.ProductionPlans.FirstOrDefaultAsync(x=>x.ProductionPlanId == productionPlanId);
            if (data == null)
            {
                return NotFound();
            }
            _context.ProductionPlans.Remove(data);
            _context.SaveChanges();
            TempData["ResultOk"] = "Xóa kế hoạch thành công";
            return RedirectToAction("Index");
        }
    }
}
