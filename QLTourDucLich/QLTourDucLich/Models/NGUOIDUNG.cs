//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTourDucLich.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NGUOIDUNG
    {
        public NGUOIDUNG()
        {
            this.PHIEUNHAPTOURs = new HashSet<PHIEUNHAPTOUR>();
            this.QUANLINHOMNGUOIDUNGs = new HashSet<QUANLINHOMNGUOIDUNG>();
        }
    
        public string MaNV { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string AnhDaiDien { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public Nullable<int> TrangThai { get; set; }
        public string MatKhauCap2 { get; set; }
    
        public virtual ICollection<PHIEUNHAPTOUR> PHIEUNHAPTOURs { get; set; }
        public virtual ICollection<QUANLINHOMNGUOIDUNG> QUANLINHOMNGUOIDUNGs { get; set; }
    }
}
