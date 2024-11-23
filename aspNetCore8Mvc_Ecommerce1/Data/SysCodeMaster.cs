using System;
using System.Collections.Generic;

namespace aspNetCore8Mvc_Ecommerce1.Data;

public partial class SysCodeMaster
{
    public int Id { get; set; }

    public string? CdName { get; set; }

    public string? Value { get; set; }

    public string? Type { get; set; }

    public string? MoTa { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }
}
