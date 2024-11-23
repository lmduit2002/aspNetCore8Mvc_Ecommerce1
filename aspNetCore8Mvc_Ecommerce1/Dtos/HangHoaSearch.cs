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
        public double? DonGia { get; set; }
        public bool? IsDiscount { get; set; }
        public string? TuKhoa { get; set; }
        public string? sortBy { get; set; }

    }
}
