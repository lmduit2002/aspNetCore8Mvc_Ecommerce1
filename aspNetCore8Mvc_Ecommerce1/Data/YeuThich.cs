using System;
using System.Collections.Generic;

namespace aspNetCore8Mvc_Ecommerce1.Data;

public partial class YeuThich
{
    public int MaYt { get; set; }

    public int? MaHh { get; set; }

    public string? MaKh { get; set; }

    public DateTime? NgayChon { get; set; }

    public string? MoTa { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual HangHoa? MaHhNavigation { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }
}
