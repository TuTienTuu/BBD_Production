using BBD_Production_New.Data;
using BBD_Production_New.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;

namespace BBD_Production_New.Controllers
{
    public class ProductionPlanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _config;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv;
        public ProductionPlanController(ApplicationDbContext context, IConfiguration config, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _context = context;
            _config = config;
            hostingEnv = env;
        }
        public async Task<IActionResult> Index(DateTime date)
        {
            IEnumerable<ProductionPlan> data;
            if (date == null || date.Date.ToString() == "1/1/0001 12:00:00 AM")
            {
                data = await _context.ProductionPlans.Where(x=>x.CreatedDate.Date == DateTime.Now.Date).ToListAsync();
                ViewData["Date"] = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                data = await _context.ProductionPlans.Where(x => x.CreatedDate.Date == date.Date).ToListAsync();
                ViewData["Date"] = date.Date.ToString("yyyy-MM-dd");
            }

            var importHistory = await _context.ImportHistorys.FirstOrDefaultAsync(x=>x.ImportDate.Date == DateTime.Now.Date);
            if (importHistory == null)
            {
                ViewData["IsImport"] = false;
            }
            else
            {
                ViewData["IsImport"] = true;
            }    
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

            var productionPlan = await _context.ProductionPlans.FirstOrDefaultAsync(x => x.ProductionPlanId == productionPlanId);
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
            var data = await _context.ProductionPlans.FirstOrDefaultAsync(x => x.ProductionPlanId == productionPlanId);

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
            var data = await _context.ProductionPlans.FirstOrDefaultAsync(x => x.ProductionPlanId == productionPlanId);
            if (data == null)
            {
                return NotFound();
            }
            _context.ProductionPlans.Remove(data);
            _context.SaveChanges();
            TempData["ResultOk"] = "Xóa kế hoạch thành công";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile file, CancellationToken cancellationToken)
        {
            try
            {


                if (file == null || file.Length <= 0)
                {
                    TempData["ResultOk"] = "Vui lòng chọn file để import";
                }
                else if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    TempData["ResultOk"] = "File import không đúng định dạng";
                }

                else
                {
                    var planList = new List<ProductionPlan>();
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream, cancellationToken);
                        using (var package = new ExcelPackage(stream))
                        {
                            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];

                            for (int i = 2; i <= workSheet.Dimension.Rows; i++)
                            {
                                var plan = new ProductionPlan();

                                plan.ProductionPlanId = Guid.NewGuid();
                                plan.ProductionCode = workSheet.Cells[i, 1].Value == null ? "" : workSheet.Cells[i, 1].Value.ToString();
                                plan.ProductionType = workSheet.Cells[i, 2].Value == null ? "" : workSheet.Cells[i, 2].Value.ToString();
                                plan.CustomerCode = workSheet.Cells[i, 3].Value == null ? "" : workSheet.Cells[i, 3].Value.ToString();
                                plan.CustomerName = workSheet.Cells[i, 4].Value == null ? "" : workSheet.Cells[i, 4].Value.ToString();
                                plan.POCode = workSheet.Cells[i, 5].Value == null ? "" : workSheet.Cells[i, 5].Value.ToString();
                                plan.OrderBy = workSheet.Cells[i, 6].Value == null ? "" : workSheet.Cells[i, 6].Value.ToString();
                                plan.OrderDate = workSheet.Cells[i, 7].Text == null ? DateTime.Now : DateTime.Parse(workSheet.Cells[i, 7].Text.ToString());
                                plan.DeliveryDate = workSheet.Cells[i, 8].Text == null ? DateTime.Now : DateTime.Parse(workSheet.Cells[i, 8].Text.ToString());
                                plan.ProductType = workSheet.Cells[i, 9].Value == null ? "" : workSheet.Cells[i, 9].Value.ToString();
                                plan.ProductCode = workSheet.Cells[i, 10].Value == null ? "" : workSheet.Cells[i, 10].Value.ToString();
                                plan.KnifeCode = workSheet.Cells[i, 11].Value == null ? "" : workSheet.Cells[i, 11].Value.ToString();
                                plan.KnifeSpec = workSheet.Cells[i, 12].Value == null ? "" : workSheet.Cells[i, 12].Value.ToString();
                                plan.KnifeContent = workSheet.Cells[i, 13].Value == null ? "" : workSheet.Cells[i, 13].Value.ToString();
                                plan.ProductName = workSheet.Cells[i, 14].Value == null ? "" : workSheet.Cells[i, 14].Value.ToString();
                                plan.ProductContent = workSheet.Cells[i, 15].Value == null ? "" : workSheet.Cells[i, 15].Value.ToString();
                                plan.Border = workSheet.Cells[i, 16].Value == null ? 0 : int.Parse(workSheet.Cells[i, 16].Text.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.LaminatingFilm = workSheet.Cells[i, 17].Value == null ? "" : workSheet.Cells[i, 17].Value.ToString();
                                plan.LaminatingSize = workSheet.Cells[i, 18].Value == null ? 0 : int.Parse(workSheet.Cells[i, 18].Text.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.PaperCode = workSheet.Cells[i, 19].Value == null ? "" : workSheet.Cells[i, 19].Value.ToString();
                                plan.PaperSupply = workSheet.Cells[i, 20].Value == null ? "" : workSheet.Cells[i, 20].Value.ToString();
                                plan.PaperSize = workSheet.Cells[i, 21].Value == null ? 0 : int.Parse(workSheet.Cells[i, 21].Text.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.MetterPerRoll = workSheet.Cells[i, 22].Value == null ? 0 : int.Parse(workSheet.Cells[i, 22].Text.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.StampPerRoll = workSheet.Cells[i, 23].Value == null ? 0 : int.Parse(workSheet.Cells[i, 23].Text.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.Unit = workSheet.Cells[i, 24].Value == null ? "" : workSheet.Cells[i, 24].Value.ToString();
                                plan.Quantity = workSheet.Cells[i, 25].Value == null ? 0 : float.Parse(workSheet.Cells[i, 25].Text.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.MetterPerOrder = workSheet.Cells[i, 26].Value == null ? 0 : int.Parse(workSheet.Cells[i, 26].Text.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.TotalQuantity = workSheet.Cells[i, 27].Value == null ? 0 : float.Parse(workSheet.Cells[i, 27].Text.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.TotalMetter = workSheet.Cells[i, 28].Value == null ? 0 : int.Parse(workSheet.Cells[i, 28].Text.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                //ProductedMetter = workSheet.Cells[i, 29].Text == null ? 0 : Int32.Parse(workSheet.Cells[i, 29].Value.ToString(); NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.ProductedMetter = 0;
                                plan.CorePerSheet = workSheet.Cells[i, 30].Value == null ? 0 : int.Parse(workSheet.Cells[i, 30].Text.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.Note = workSheet.Cells[i, 31].Value == null ? "" : workSheet.Cells[i, 31].Value.ToString();
                                plan.DecalMaster = workSheet.Cells[i, 32].Value == null ? "" : workSheet.Cells[i, 32].Value.ToString();
                                plan.LayoutMainCode = workSheet.Cells[i, 33].Value == null ? 0 : int.Parse(workSheet.Cells[i, 33].Text.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.LayoutCode = workSheet.Cells[i, 34].Value == null ? "" : workSheet.Cells[i, 34].Value.ToString();
                                plan.FilmCode = workSheet.Cells[i, 35].Value == null ? "" : workSheet.Cells[i, 35].Value.ToString();
                                plan.TotalProduct = workSheet.Cells[i, 36].Value == null ? 0 : int.Parse(workSheet.Cells[i, 36].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.ProductNumber = workSheet.Cells[i, 37].Value == null ? 0 : int.Parse(workSheet.Cells[i, 37].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.ColorNumber = workSheet.Cells[i, 38].Value == null ? 0 : int.Parse(workSheet.Cells[i, 38].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.NumberTiningColor = workSheet.Cells[i, 39].Value == null ? 0 : int.Parse(workSheet.Cells[i, 39].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.NumberStackColor = workSheet.Cells[i, 40].Value == null ? 0 : int.Parse(workSheet.Cells[i, 40].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.NumberRootColor = workSheet.Cells[i, 41].Value == null ? 0 : int.Parse(workSheet.Cells[i, 41].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.NumberOfStage = workSheet.Cells[i, 42].Value == null ? 0 : int.Parse(workSheet.Cells[i, 42].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.Stage_1 = workSheet.Cells[i, 43].Value == null ? "" : workSheet.Cells[i, 43].Value.ToString();
                                plan.Stage_1_Loss = workSheet.Cells[i, 44].Value == null ? 0 : float.Parse(workSheet.Cells[i, 44].Text.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.Stage_2 = workSheet.Cells[i, 45].Value == null ? "" : workSheet.Cells[i, 45].Value.ToString();
                                plan.Stage_2_Loss = workSheet.Cells[i, 46].Value == null ? 0 : float.Parse(workSheet.Cells[i, 46].Text.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.Stage_3 = workSheet.Cells[i, 47].Value == null ? "" : workSheet.Cells[i, 47].Value.ToString();
                                plan.Stage_3_Loss = workSheet.Cells[i, 48].Value == null ? 0 : float.Parse(workSheet.Cells[i, 48].Text.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.Stage_4 = workSheet.Cells[i, 49].Value == null ? "" : workSheet.Cells[i, 49].Value.ToString();
                                plan.Stage_4_Loss = workSheet.Cells[i, 50].Value == null ? 0 : float.Parse(workSheet.Cells[i, 50].Text.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.Stage_5 = workSheet.Cells[i, 51].Value == null ? "" : workSheet.Cells[i, 51].Value.ToString();
                                plan.Stage_5_Loss = workSheet.Cells[i, 52].Value == null ? 0 : float.Parse(workSheet.Cells[i, 52].Text.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.PrintSurfaceLoss = workSheet.Cells[i, 53].Value == null ? 0 : float.Parse(workSheet.Cells[i, 53].Text.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.PrintSoleLoss = workSheet.Cells[i, 54].Value == null ? 0 : float.Parse(workSheet.Cells[i, 54].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.ChangeProductLoss = workSheet.Cells[i, 55].Value == null ? 0 : float.Parse(workSheet.Cells[i, 55].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.ChangeLaminationLoss = workSheet.Cells[i, 56].Value == null ? 0 : int.Parse(workSheet.Cells[i, 56].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.LossPercent = workSheet.Cells[i, 57].Value == null ? 0 : float.Parse(workSheet.Cells[i, 57].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.LossTotal = workSheet.Cells[i, 58].Value == null ? 0 : int.Parse(workSheet.Cells[i, 58].Text.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.SplitLine = workSheet.Cells[i, 59].Value == null ? 0 : int.Parse(workSheet.Cells[i, 59].Value.ToString(), NumberStyles.AllowDecimalPoint, new CultureInfo("en-au"));
                                plan.KnifeStep = workSheet.Cells[i, 60].Value == null ? 0 : float.Parse(workSheet.Cells[i, 60].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.StampPerStep = workSheet.Cells[i, 61].Value == null ? 0 : int.Parse(workSheet.Cells[i, 61].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.With = workSheet.Cells[i, 62].Value == null ? 0 : int.Parse(workSheet.Cells[i, 62].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.NumStampHorizontail = workSheet.Cells[i, 63].Value == null ? 0 : int.Parse(workSheet.Cells[i, 63].Value.ToString(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                                plan.PrintStep = workSheet.Cells[i, 64].Value == null || workSheet.Cells[i, 64].Value.Equals("-") ? 0 : float.Parse(workSheet.Cells[i, 64].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.Core = workSheet.Cells[i, 65].Value == null ? 0 : float.Parse(workSheet.Cells[i, 65].Text.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.CoreSpec = workSheet.Cells[i, 66].Value == null ? 0 : float.Parse(workSheet.Cells[i, 66].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.LayoutName = workSheet.Cells[i, 67].Value == null ? "" : workSheet.Cells[i, 67].Value.ToString();
                                plan.LayoutPosition = workSheet.Cells[i, 68].Value == null ? "" : workSheet.Cells[i, 68].Value.ToString();
                                plan.Time_1 = workSheet.Cells[i, 69].Value == null ? 0 : float.Parse(workSheet.Cells[i, 69].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.Time_2 = workSheet.Cells[i, 70].Value == null ? 0 : float.Parse(workSheet.Cells[i, 70].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.Time_3 = workSheet.Cells[i, 71].Value == null ? 0 : float.Parse(workSheet.Cells[i, 71].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.Time_4 = workSheet.Cells[i, 72].Value == null ? 0 : float.Parse(workSheet.Cells[i, 72].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.Time_5 = workSheet.Cells[i, 73].Value == null ? 0 : float.Parse(workSheet.Cells[i, 73].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.Middle = workSheet.Cells[i, 74].Value == null ? 0 : float.Parse(workSheet.Cells[i, 74].Value.ToString(), NumberStyles.Any, new CultureInfo("en-au"));
                                plan.CreatedDate = DateTime.Now;
                                plan.Status = 1;
                                plan.Content = String.Empty;
                                plan.Machine = String.Empty;

                                planList.Add(plan);
                            }
                        }
                    }

                    await _context.ProductionPlans.AddRangeAsync(planList);
                    await _context.SaveChangesAsync();
                    string filePath = hostingEnv.WebRootPath + $@"\uploads\import\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day;
                    if (!System.IO.File.Exists(filePath))
                        Directory.CreateDirectory(filePath);

                    using (FileStream fs = System.IO.File.Create(filePath + "\\" + file.FileName))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }

                    var import = new ImportHistory()
                    {
                        ImportDate = DateTime.Now,
                        ImportFileName = filePath + "\\" + file.FileName,
                    };
                    await _context.ImportHistorys.AddAsync(import);
                    await _context.SaveChangesAsync();


                    TempData["ResultOk"] = "Import thành công";
                }
            }
            catch (Exception ex)
            {

                TempData["ResultOk"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
