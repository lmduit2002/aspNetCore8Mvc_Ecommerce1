
using aspNetCore8Mvc_Ecommerce1.Data;
using aspNetCore8Mvc_Ecommerce1.ViewModels;
using aspNetCore8Mvc_Ecommerce1.Helpers;
using Microsoft.EntityFrameworkCore;
using aspNetCore8Mvc_Ecommerce1.Intfs;
namespace aspNetCore8Mvc_Ecommerce1.Impls
{
    public class CartAppService: ICartAppService
    {
        private readonly Hshop2023Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        const string CART_KEY = "MyCart";
        public CartAppService(Hshop2023Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            var a = 1;
        }
        //public List<CartItemVM> Cart => _httpContextAccessor?.HttpContext?.Session.Get<List<CartItemVM>>(CART_KEY) ?? new List<CartItemVM>();
        public List<CartItemVM> Cart
        {
            get
            {
                if (_httpContextAccessor?.HttpContext?.Session == null)
                {
                    return new List<CartItemVM>();
                }

                var cart = _httpContextAccessor.HttpContext.Session.Get<List<CartItemVM>>(CART_KEY);
                return cart ?? new List<CartItemVM>();
            }
        }
        public List<CartItemVM> GetCart() => Cart;
        public void AddToCart(int MaHHDetail, int SoLuong)
        {
            var cart = Cart;
            bool isExistsItem = cart.Any(item => item.MaHhdetail == MaHHDetail);
            if (isExistsItem)
            {
                cart.Where(item => item.MaHhdetail == MaHHDetail).ToList().ForEach(item => item.SoLuong += SoLuong);
            } else
            {
                var hhDetail = _context.HangHoaDetails.FirstOrDefault(item => item.MaHhdetail == MaHHDetail);
                cart.Add(new CartItemVM
                {
                    MaHhdetail = hhDetail!.MaHhdetail,
                    SoLuong = SoLuong,
                    MaHh = hhDetail.MaHh,
                    TenHh = hhDetail.TenHh,
                    DonGia = (double)hhDetail.DonGia!,
                    GiamGia = hhDetail.GiamGia!,
                    Hinh = hhDetail.Hinh,
                    Version = hhDetail.Version,
                });
            }
            _httpContextAccessor?.HttpContext?.Session.Set(CART_KEY, cart);
        }
        public void RemoveItem(int MaHHDetail)
        {
            var cart = Cart;
            cart.RemoveAll(item => item.MaHhdetail == MaHHDetail);
            _httpContextAccessor?.HttpContext?.Session.Set(CART_KEY, cart);
        }
    }
}
