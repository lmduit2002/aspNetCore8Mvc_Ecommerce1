using aspNetCore8Mvc_Ecommerce1.Data;
using aspNetCore8Mvc_Ecommerce1.Dtos;
using aspNetCore8Mvc_Ecommerce1.Intfs;
using aspNetCore8Mvc_Ecommerce1.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

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
            double number = 123.45666;
            double roued = Math.Round(1000 - number*100, 2);
            int a = 1;
            IQueryable<HangHoaVM> data = (from hh in _context.HangHoas
                                          select new HangHoaVM
                                          {
                                              MaHh = hh.MaHh,
                                              TenHh = hh.TenHh,
                                              MaLoai = hh.MaLoai,
                                              MoTaDonVi = hh.MoTaDonVi ?? "",
                                              DonGia = hh.DonGia,
                                              Daban = hh.DaBan,
                                              Hinh = hh.Hinh ?? "",
                                              NgaySx = hh.NgaySx,
                                              GiamGia = hh.GiamGia,
                                              Loai = hh.MaLoaiNavigation,
                                              GiaDaGiam = hh.GiamGia > 0 ? Math.Round((double)hh.DonGia! - (double)hh.DonGia*hh.GiamGia/100, 2) : null
                                          });
            if(model != null)
            {
                data = data.Where(hh => 
                (a == 1)
                       && (hh.MaHh == model!.MaHh || model.MaHh == null)
                       && (hh.TenHh.Contains(model.TenHh!) || string.IsNullOrEmpty(model.TenHh))
                       && (hh.MaLoai == model.MaLoai || model.MaLoai == null)
                       && (hh.Loai.TenLoai.Contains(model.TenLoai!) || string.IsNullOrEmpty(model.TenLoai))
                       && (hh.NgaySx >= model.NgaySXFrom || string.IsNullOrEmpty(model.NgaySXFrom.ToString()))
                       && (hh.NgaySx <= model.NgaySXTo || string.IsNullOrEmpty(model.NgaySXTo.ToString()))
                       && (hh.TenHh.Contains(model.TuKhoa!) || hh.Loai.TenLoai.Contains(model.TuKhoa!) || string.IsNullOrWhiteSpace(model.TuKhoa))
                       && ((model!.DonGia == 1 && hh.DonGia < 50) 
                            || (model!.DonGia == 2 && hh.DonGia >= 50 && hh.DonGia < 100)
                            || (model!.DonGia == 3 && hh.DonGia >= 100 && hh.DonGia < 500)
                            || (model!.DonGia == 4 && hh.DonGia > 500)
                            || (model!.DonGia ==  0 || model!.DonGia == null))
                );
            }
            var notSortedData = data;
            if(model != null && model.sortBy != null)
            {
                switch (model.sortBy)
                {
                    case "giatangdan":
                        data = data.OrderBy(hh => hh.DonGia);
                        break;
                    case "giagiamdan":
                        data = data.OrderByDescending(hh => hh.DonGia);
                        break;
                    case "banchaynhat":
                        data = data.OrderByDescending(hh => hh.Daban);
                        break;
                    case "sanphammoi":
                        data = data.OrderByDescending(hh => hh.NgaySx);
                        break;
                    default : // mặc định
                        data = notSortedData;
                        break;
                           
                }
            }
            return await data.Take(9).ToListAsync();
        }

        public async Task<HangHoaVM?> HangHoa_ById (int id)
        {
            IQueryable<HangHoaVM> hangHoa = from hh in _context.HangHoas
                                               where hh.MaHh == id
                                               select new HangHoaVM
                                               {
                                                   MaHh = hh.MaHh,
                                                   TenHh = hh.TenHh,
                                                   MaLoai = hh.MaLoai,
                                                   MoTaDonVi = hh.MoTaDonVi,
                                                   DonGia = hh.DonGia,
                                                   Hinh = hh.Hinh,
                                                   NgaySx = hh.NgaySx,
                                                   GiamGia = hh.GiamGia,
                                                   SoLanXem = hh.SoLanXem,
                                                   MoTa = hh.MoTa,
                                                   Loai = hh.MaLoaiNavigation,
                                                   DiemDanhGia = 5, // tinh sau
                                                   HangHoaDetail = ConvertModelToVM(hh.HangHoaDetails)
                                               };
            if (hangHoa == null) return null!;
            return await hangHoa.FirstOrDefaultAsync();
        }

        private static List<HangHoaDetailVM> ConvertModelToVM(ICollection<HangHoaDetail> hangHoaDetails)
        {
            var data = new List<HangHoaDetailVM>();
            foreach (var item in hangHoaDetails)
            {
                var vm = new HangHoaDetailVM
                {
                    MaHhdetail = item.MaHhdetail,
                    MaHh = item.MaHh,
                    TenHh = item.TenHh,
                    TenVietTat = item.TenVietTat,
                    ThongSoKyThuat = item.ThongSoKyThuat,
                    DonGia = item.DonGia,
                    GiamGia = item.GiamGia,
                    DaBan = item.DaBan,
                    Hinh = item.Hinh,
                    Version = item.Version,
                    HangHoaDetailImages = item.HangHoaDetailImages,
                };
                data.Add(vm);
            }
            return data;
        }
    }
}
