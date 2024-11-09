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

        public DateTime NgaySx { get; set; }

        public double GiamGia { get; set; }

        public int SoLanXem { get; set; }

        public string? MoTa { get; set; }

        public string MaNcc { get; set; } = null!;

        public virtual Loai MaLoaiNavigation { get; set; } = null!;

        public virtual NhaCungCap MaNccNavigation { get; set; } = null!;
    }
}
