using QLTourDucLich.Areas.QuanTriVien.Queries;
using QLTourDucLich.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
namespace QLTourDucLich.Areas.QuanTriVien.ViewModel
{

    public class TourViewModel
    {
        [Required(ErrorMessage = MessegeConstants.TRUONGBATBUOC)]
        [DisplayName("Tên Tour")]
        public string TenTour { get; set; }

        [DisplayName("Loại Tour")]
        public string LoaiTour { get; set; }

        [Required(ErrorMessage = MessegeConstants.TRUONGBATBUOC)]
        [DisplayName("Mã Tour")]
        public string MaTour { get; set; }

        [DisplayName("Tên Khách sạn")]
        public string TenKhachSan { get; set; }

        [DisplayName("Ngày khởi hành")]
        public DateTime? NgayKH { get; set; }

        [DisplayName("Ngày trở về")]
        public DateTime? NgayKT { get; set; }

        [DisplayName("Nơi đi")]
        public string DiemDi { get; set; }

        [DisplayName("Nơi đến")]
        public string DiemDen { get; set; }

        [Required(ErrorMessage = MessegeConstants.TRUONGBATBUOC)]
        [DisplayName("Giá trẻ em")]
        public decimal? GiaTreEm { get; set; }

        [Required(ErrorMessage = MessegeConstants.TRUONGBATBUOC)]
        [DisplayName("Giá người lớn")]
        public decimal? GiaNguoiLon { get; set; }

    }

    public class HienThiTourViewModel
    {

        [DisplayName("Nơi đi")]
        public string DiemDi { get; set; }

        [DisplayName("Nơi đến")]
        public string DiemDen { get; set; }

        public TourViewModel Tour { get; set; }
    }

    public class TourDuocChonDTO
    {
        public string MaTour { get; set; }

        public int NguoiLon { get; set; }

        public int TreEm { get; set; }

        public decimal? TongTien { get; set; }

        public decimal? GiaTreEm { get; set; }

        public decimal? GiaNguoiLon { get; set; }
    }

    public class TourChiTietViewModel
    {
        public TourViewModel Tour { get; set; }

        public decimal? GiaKhachSan { get; set; }

        public string AnhDiaDiem { get; set; }

        public DateTime? TGDi { get; set; }

        public DateTime? TGDen { get; set; }
    }

    public class ThemTourViewModel
    {
        public string MaHanhTrinh { get; set; }

        public TourViewModel TourDTO { get; set; }

        public string MaKS { get; set; }

        public int? MaHDV { get; set; }

        public string AnhDiaDiem { get; set; }

        public string MaLoaiTour { get; set; }
    }

    public class ChinhSuaTourViewModel
    {
        public TourViewModel Tour { get; set; }

        public List<SelectListItem> DiemDis { get; set; } = DiaDiemQueries.LoadDiaDiem();

    }
}
