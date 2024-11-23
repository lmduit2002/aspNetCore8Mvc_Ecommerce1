using System;
using System.Collections.Generic;

namespace aspNetCore8Mvc_Ecommerce1.Data;

public partial class PhanQuyen
{
    public int MaPq { get; set; }

    public string? MaPb { get; set; }

    public int? MaTrang { get; set; }

    public bool Them { get; set; }

    public bool Sua { get; set; }

    public bool Xoa { get; set; }

    public bool Xem { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual PhongBan? MaPbNavigation { get; set; }

    public virtual TrangWeb? MaTrangNavigation { get; set; }
}
