using aspNetCore8Mvc_Ecommerce1.Data;

namespace aspNetCore8Mvc_Ecommerce1.ViewModels
{
    public class HangHoaVM
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; } = null!;
        public int MaLoai { get; set; }
        public string? MoTaDonVi { get; set; }
        public double? DonGia { get; set; }
        public string? Hinh { get; set; }
        public string? MoTa { get; set; }
        public DateTime NgaySx { get; set; }
        public int SoLanXem { get; set; }
        public double? GiamGia { get; set; }
        public double? GiaDaGiam { get; set; }
        public int? Daban {  get; set; }
        public float? DiemDanhGia { get; set; }

        public virtual Loai Loai { get; set; } = null!;
        public virtual List<HangHoaDetailVM> HangHoaDetail { get; set; } = null!;
        public virtual List<HangHoaHistory> HangHoaHistory { get; set; } = null!;
    }
}
