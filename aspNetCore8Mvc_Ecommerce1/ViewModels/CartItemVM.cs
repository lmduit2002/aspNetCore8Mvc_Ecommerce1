namespace aspNetCore8Mvc_Ecommerce1.ViewModels
{
    public class CartItemVM
    {
        public int MaHhdetail { get; set; }
        public int MaHh { get; set; }
        public string? TenHh { get; set; }
        public double DonGia { get; set; }
        public double SoLuong { get; set; }
        public double? GiamGia { get; set; }
        public string? Hinh { get; set; }
        public int? Version { get; set; }
        public double ThanhTien => (double)(GiamGia != null && GiamGia != 0 ? DonGia * SoLuong * (100 - GiamGia) / 100 : DonGia * SoLuong);
    }
}
