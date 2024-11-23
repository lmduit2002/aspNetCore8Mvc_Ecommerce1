using aspNetCore8Mvc_Ecommerce1.Dtos;
using aspNetCore8Mvc_Ecommerce1.Intfs;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCore8Mvc_Ecommerce1.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly IHangHoaAppService _hangHoaAppService;
        public HangHoaController(IHangHoaAppService hangHoaAppService) 
        {
            _hangHoaAppService = hangHoaAppService;
        }
        public async Task<IActionResult> Index(HangHoaSearch? model)
        {
            return View(await _hangHoaAppService.HangHoa_SEARCH(model));
        }

        public async Task<IActionResult> Detail(int id)
        {
            
            var data = await _hangHoaAppService.HangHoa_ById(id);
            if (data == null)
            {
                TempData["Message"] = "Không tìm thấy sản phẩm!";
                return Redirect("/404");
            }
            return View(data);
        }
    }
}
