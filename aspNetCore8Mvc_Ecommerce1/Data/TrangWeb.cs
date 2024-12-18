﻿using System;
using System.Collections.Generic;

namespace aspNetCore8Mvc_Ecommerce1.Data;

public partial class TrangWeb
{
    public int MaTrang { get; set; }

    public string TenTrang { get; set; } = null!;

    public string Url { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<PhanQuyen> PhanQuyens { get; set; } = new List<PhanQuyen>();
}
