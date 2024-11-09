using aspNetCore8Mvc_Ecommerce1.Data;
using aspNetCore8Mvc_Ecommerce1.Dtos;
using aspNetCore8Mvc_Ecommerce1.Intfs;
using aspNetCore8Mvc_Ecommerce1.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace aspNetCore8Mvc_Ecommerce1.Impls
{
    public class HangHoaAppService: IHangHoaAppService
    {
        private readonly Hshop2023Context _context;
        public HangHoaAppService(Hshop2023Context context)
        {
            _context = context;
        }

        public async Task<List<HangHoaVM>> HangHoa_SEARCH(HangHoaSearch? model)
        {
            int a = 1;
            IQueryable<HangHoaVM> data = (from hh in _context.HangHoas
                                          select new HangHoaVM
                                          {
                                              MaHh = hh.MaHh,
                                              TenHh = hh.TenHh,
                                              MoTa = hh.MoTa,
                                              MaLoai = hh.MaLoai,
                                              MoTaDonVi = hh.MoTaDonVi ?? "",
                                              DonGia = hh.DonGia,
                                              Hinh = hh.Hinh ?? "",
                                              NgaySx = hh.NgaySx,
                                              GiamGia = hh.GiamGia,
                                              SoLanXem = hh.SoLanXem,
                                              MaNcc = hh.MaNcc,
                                              MaLoaiNavigation = hh.MaLoaiNavigation,
                                              MaNccNavigation = hh.MaNccNavigation,
                                          });
            if(model != null)
            {
                data = data.Where(hh => 
                (a == 1)
                       && (hh.MaHh == model!.MaHh || model.MaHh == null)
                       && (hh.TenHh.Contains(model.TenHh!) || string.IsNullOrEmpty(model.TenHh))
                       && (hh.MaLoai == model.MaLoai || model.MaLoai == null)
                       && (hh.MaLoaiNavigation.TenLoai.Contains(model.TenLoai!) || string.IsNullOrEmpty(model.TenLoai))
                       && (hh.NgaySx >= model.NgaySXFrom || string.IsNullOrEmpty(model.NgaySXFrom.ToString()))
                       && (hh.NgaySx <= model.NgaySXTo || string.IsNullOrEmpty(model.NgaySXTo.ToString()))
                       && (hh.DonGia >= model.DonGiaFrom || model.DonGiaFrom == null)
                       && (hh.DonGia <= model.DonGiaTo || model.DonGiaTo == null)
                       && (hh.TenHh.Contains(model.TuKhoa!) || hh.MaLoaiNavigation.TenLoai.Contains(model.TuKhoa!) || string.IsNullOrWhiteSpace(model.TuKhoa))
                );
            }
            return await data.Take(9).ToListAsync();

            
        }
    }
}
