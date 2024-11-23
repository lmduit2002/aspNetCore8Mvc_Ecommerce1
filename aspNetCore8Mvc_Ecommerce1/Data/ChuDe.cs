using System;
using System.Collections.Generic;

namespace aspNetCore8Mvc_Ecommerce1.Data;

public partial class ChuDe
{
    public int MaCd { get; set; }

    public string? TenCd { get; set; }

    public string? MaNv { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<GopY> Gopies { get; set; } = new List<GopY>();

    public virtual NhanVien? MaNvNavigation { get; set; }
}
