using aspNetCore8Mvc_Ecommerce1.Data;
using aspNetCore8Mvc_Ecommerce1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspNetCore8Mvc_Ecommerce1.ViewComponents
{
    public class MenuLoaiViewComponent: ViewComponent
    {
        private readonly Hshop2023Context _dbContext;
        public MenuLoaiViewComponent(Hshop2023Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IQueryable<MenuLoaiVM> data =  _dbContext.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai,
                SoLuong = lo.HangHoas.Count,
                Icon = lo.Hinh!
            });
            return View(await data.ToListAsync());
        }
    }
}
