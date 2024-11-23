using System;
using System.Collections.Generic;

namespace aspNetCore8Mvc_Ecommerce1.Data;

public partial class BanBe
{
    public int MaBb { get; set; }

    public string? MaKh { get; set; }

    public int MaHh { get; set; }

    public string? HoTen { get; set; }

    public string Email { get; set; } = null!;

    public DateTime NgayGui { get; set; }

    public string? GhiChu { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual HangHoa MaHhNavigation { get; set; } = null!;

    public virtual KhachHang? MaKhNavigation { get; set; }
}
