
using aspNetCore8Mvc_Ecommerce1.ViewModels;

namespace aspNetCore8Mvc_Ecommerce1.Intfs
{
    public interface ICartAppService
    {
        public List<CartItemVM> GetCart();
        public void AddToCart(int MaHHDetail, int SoLuong);
        public void RemoveItem(int MaHHDetail);
    }
}
