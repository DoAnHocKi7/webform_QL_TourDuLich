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
    
    public partial class HOPDONG
    {
        public HOPDONG()
        {
            this.ChiTietHopDongs = new HashSet<ChiTietHopDong>();
        }
    
        public string MaHD { get; set; }
        public string MaKH { get; set; }
        public Nullable<System.DateTime> ThoiGianDat { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
        public Nullable<decimal> TongTien { get; set; }
    
        public virtual ICollection<ChiTietHopDong> ChiTietHopDongs { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
