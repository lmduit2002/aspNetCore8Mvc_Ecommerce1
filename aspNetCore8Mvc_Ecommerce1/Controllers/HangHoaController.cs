using aspNetCore8Mvc_Ecommerce1.Data;
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
    }
}
