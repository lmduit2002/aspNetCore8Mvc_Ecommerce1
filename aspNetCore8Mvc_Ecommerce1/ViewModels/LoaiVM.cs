﻿namespace aspNetCore8Mvc_Ecommerce1.ViewModels
{
    public class LoaiVM
    {
        public int MaLoai { get; set; }

        public string TenLoai { get; set; } = null!;

        public string? TenLoaiAlias { get; set; }

        public string? MoTa { get; set; }

        public string? Hinh { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }
        public string Icon {  get; set; } = string.Empty;
        public int SoLuong { get; set; }

    }
}