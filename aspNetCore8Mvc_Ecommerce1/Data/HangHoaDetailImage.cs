using System;
using System.Collections.Generic;

namespace aspNetCore8Mvc_Ecommerce1.Data;

public partial class HangHoaDetailImage
{
    public int Id { get; set; }

    public int MaHhdetail { get; set; }

    public string? Hinh { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual HangHoaDetail MaHhdetailNavigation { get; set; } = null!;
}
