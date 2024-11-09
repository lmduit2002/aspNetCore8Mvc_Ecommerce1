namespace aspNetCore8Mvc_Ecommerce1.Dtos
{
    public class HangHoaSearch
    {
        public int? MaHh { get; set; }
        public string? TenHh { get; set; }
        public int? MaLoai { get; set; }
        public string? TenLoai { get; set; }
        public DateTime? NgaySXFrom { get; set; }
        public DateTime? NgaySXTo { get; set; }
        public double? DonGiaFrom { get; set; }
        public double? DonGiaTo { get; set; }
        public bool? IsDiscount { get; set; }
        public string? TuKhoa { get; set; }
    }
}
