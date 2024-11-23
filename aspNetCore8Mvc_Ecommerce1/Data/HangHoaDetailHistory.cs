using System;
using System.Collections.Generic;

namespace aspNetCore8Mvc_Ecommerce1.Data;

public partial class HangHoaDetailHistory
{
    public int Id { get; set; }

    public int MaHhdetail { get; set; }

    public int MaHh { get; set; }

    public string? TenHh { get; set; }

    public string? TenVietTat { get; set; }

    public string? ThongSoKyThuat { get; set; }

    public double? DonGia { get; set; }

    public double? GiamGia { get; set; }

    public int? DaBan { get; set; }

    public string? Hinh { get; set; }

    public int? Version { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual HangHoaDetail MaHhdetailNavigation { get; set; } = null!;
}
