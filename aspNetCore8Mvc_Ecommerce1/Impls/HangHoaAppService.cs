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
            IQueryable<HangHoa> query = _context.HangHoas.Include(hh => hh.MaLoaiNavigation);
            if (model != null)
            {
                query = query.Where(hh => 
                       (hh.MaHh == model!.MaHh || model.MaHh == null)
                       && (hh.TenHh.Contains(model.TenHh!) || string.IsNullOrEmpty(model.TenHh))
                       && (hh.MaLoai == model.MaLoai || model.MaLoai == null)
                       && (hh.MaLoaiNavigation.TenLoai.Contains(model.TenLoai!) || string.IsNullOrEmpty(model.TenLoai))
                       && (hh.NgaySx >= model.NgaySXFrom || string.IsNullOrEmpty(model.NgaySXFrom.ToString()))
                       && (hh.NgaySx <= model.NgaySXTo || string.IsNullOrEmpty(model.NgaySXTo.ToString()))
                       && (hh.TenHh.Contains(model.TuKhoa!) || hh.MaLoaiNavigation.TenLoai.Contains(model.TuKhoa!) || string.IsNullOrWhiteSpace(model.TuKhoa))
                       && ((model!.DonGia == 1 && hh.DonGia < 50) 
                            || (model!.DonGia == 2 && hh.DonGia >= 50 && hh.DonGia < 100)
                            || (model!.DonGia == 3 && hh.DonGia >= 100 && hh.DonGia < 500)
                            || (model!.DonGia == 4 && hh.DonGia > 500)
                            || (model!.DonGia ==  0 || model!.DonGia == null))
                );
            }
           
            if(model?.sortBy != null)
            {
                switch (model.sortBy)
                {
                    case "giatangdan":
                        query = query.OrderBy(hh => hh.DonGia);
                        break;
                    case "giagiamdan":
                        query = query.OrderByDescending(hh => hh.DonGia);
                        break;
                    case "banchaynhat":
                        query = query.OrderByDescending(hh => hh.DaBan);
                        break;
                    case "sanphammoi":
                        query = query.OrderByDescending(hh => hh.NgaySx);
                        break;
                }
            }
            var data = await query.Take(9).ToListAsync();
            return data.Select(hh => new HangHoaVM
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                MaLoai = hh.MaLoai,
                MoTaDonVi = hh.MoTaDonVi ?? "",
                DonGia = hh.DonGia,
                DaBan = hh.DaBan,
                Hinh = hh.Hinh ?? "",
                NgaySx = hh.NgaySx,
                GiamGia = hh.GiamGia,
                Loai = ConvertLoaiToLoaiVM(hh.MaLoaiNavigation),
                GiaDaGiam = hh.GiamGia > 0 ? Math.Round((double)hh.DonGia! - (double)hh.DonGia * hh.GiamGia / 100, 2) : null
            }).ToList();
        }

        public async Task<HangHoaVM?> HangHoa_ById (int id)
        {
            var hh = await _context.HangHoas
                .Include(h => h.MaLoaiNavigation)
                .Include(h => h.HangHoaDetails)
                .ThenInclude(d => d.HangHoaDetailImages)
                .FirstOrDefaultAsync(h => h.MaHh == id);
            if (hh == null) return null;
            var hangHoaDetailVM = await ConvertModelToVM(hh.HangHoaDetails);
            return new HangHoaVM
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
                Loai = ConvertLoaiToLoaiVM(hh.MaLoaiNavigation),
                DiemDanhGia = 5, // tinh sau
                HangHoaDetail = hangHoaDetailVM
            };
        }

        private  async Task<List<HangHoaDetailImageVM>> HangHoaDetailImage_By_HHDetailID(int id)
        {
            return await _context.HangHoaDetailImages.Where(e => e.MaHhdetail == id).
                    Select( e => new HangHoaDetailImageVM
                    {
                        Id = e.Id,
                        MaHhdetail = e.MaHhdetail,
                        Hinh = e.Hinh
                    }).ToListAsync();
        }

        private static LoaiVM ConvertLoaiToLoaiVM (Loai loai)
        {
            return new LoaiVM
            {
                Hinh = loai.Hinh,
                Icon = loai.Hinh!,
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai,
                ModifiedBy = loai.ModifiedBy,
                MoTa = loai.MoTa,
                TenLoaiAlias = loai.TenLoaiAlias,
            };
        }

        private async Task<List<HangHoaDetailVM>> ConvertModelToVM(ICollection<HangHoaDetail> hangHoaDetails)
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
                    HangHoaDetailImages = await HangHoaDetailImage_By_HHDetailID(item.MaHhdetail),
                };
                data.Add(vm);
            }
            return data;
        }
    }
}
