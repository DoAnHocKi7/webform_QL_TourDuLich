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
    
    public partial class KHACHHANG
    {
        public KHACHHANG()
        {
            this.HOPDONGs = new HashSet<HOPDONG>();
        }
    
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public Nullable<System.DateTime> NgSinh { get; set; }
        public Nullable<int> GioiTinh { get; set; }
        public string Email { get; set; }
        public string SDTKH { get; set; }
        public string DCKH { get; set; }
        public string MaLoaiKH { get; set; }
        public string TenDoanhNghiep { get; set; }
    
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }
        public virtual LOAIKHACHHANG LOAIKHACHHANG { get; set; }
    }
}
