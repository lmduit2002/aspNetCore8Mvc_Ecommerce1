using System;
using System.Collections.Generic;

namespace aspNetCore8Mvc_Ecommerce1.Data;

public partial class TrangWeb
{
    public int MaTrang { get; set; }

    public string TenTrang { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<PhanQuyen> PhanQuyens { get; set; } = new List<PhanQuyen>();
}
