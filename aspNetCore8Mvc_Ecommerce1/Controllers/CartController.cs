using aspNetCore8Mvc_Ecommerce1.Dtos;
using aspNetCore8Mvc_Ecommerce1.Intfs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace aspNetCore8Mvc_Ecommerce1.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartAppService _cartAppService;
        private readonly IConfiguration _configuration;
        public CartController(ICartAppService cartAppService, IConfiguration configuration)
        {
            _cartAppService = cartAppService;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewData["APIUrl"] = _configuration["Url:localhost"];
            return View(_cartAppService.GetCart());
        }

        [HttpPost("/Cart/AddToCart")]
        public IActionResult AddToCart([FromBody] CartRequest request)
        {
            _cartAppService.AddToCart(request.MaHHDetail, request.SoLuong);
            return Ok(new {success= true, message= "Thêm vào giỏ hàng thành công!!!"});
        }

        [HttpPost("/Cart/RemoveItem")]
        public IActionResult RemoveItem([FromBody] CartRequest request)
        {
            _cartAppService.RemoveItem(request.MaHHDetail);
            return Ok(new { success = true, message = "Xóa sản phẩn khỏi giỏ hàng thành công!!!" });
        }
    }
}
