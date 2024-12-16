using aspNetCore8Mvc_Ecommerce1.Dtos;
using aspNetCore8Mvc_Ecommerce1.Intfs;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCore8Mvc_Ecommerce1.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHangHoaAppService _hangHoaAppService;
        public HangHoaController(IHangHoaAppService hangHoaAppService, IConfiguration configuration) 
        {
            _hangHoaAppService = hangHoaAppService;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(HangHoaSearch? model)
        {
            var data = await _hangHoaAppService.HangHoa_SEARCH(model);
            return View(data);
        }

        public async Task<IActionResult> Detail(int id)
        {
            
            var data = await _hangHoaAppService.HangHoa_ById(id);
            if (data == null)
            {
                TempData["Message"] = "Không tìm thấy sản phẩm!";
                return Redirect("/404");
            }
            ViewData["APIUrl"] = _configuration["Url:localhost"];
            return View(data);
        }
    }
}
