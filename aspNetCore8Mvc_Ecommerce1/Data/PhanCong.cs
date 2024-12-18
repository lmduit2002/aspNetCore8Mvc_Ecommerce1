﻿using System;
using System.Collections.Generic;

namespace aspNetCore8Mvc_Ecommerce1.Data;

public partial class PhanCong
{
    public int MaPc { get; set; }

    public string MaNv { get; set; } = null!;

    public string MaPb { get; set; } = null!;

    public DateTime? NgayPc { get; set; }

    public bool? HieuLuc { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; } = null!;

    public virtual PhongBan MaPbNavigation { get; set; } = null!;
}
