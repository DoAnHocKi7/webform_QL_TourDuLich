using QLTourDucLich.Areas.QuanTriVien.Queries.Tour;
using QLTourDucLich.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
namespace QLTourDucLich.Areas.QuanTriVien.ViewModel.Tour
{

    public class TourViewModel
    {
        public string TenHDV { get; set; }

        [Required]
        public int MaHDV { get; set; }

        public int? MaDiaDiemDi { get; set; }

        public int? MaDiaDiemDen { get; set; }

        [Required]
        [DisplayName("Tên Tour")]
        public string TenTour { get; set; }

        [DisplayName("Loại Tour")]
        public string LoaiTour { get; set; }

        [Required(ErrorMessage = Constants.Constants.TRUONGBATBUOC)]
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

        [Required(ErrorMessage = Constants.Constants.TRUONGBATBUOC)]
        [DisplayName("Giá trẻ em")]
        public decimal? GiaTreEm { get; set; }

        [Required(ErrorMessage = Constants.Constants.TRUONGBATBUOC)]
        [DisplayName("Giá người lớn")]
        public decimal? GiaNguoiLon { get; set; }

    }

    //public class HienThiTourViewModel
    //{

    //    [DisplayName("Nơi đi")]
    //    public string DiemDi { get; set; }

    //    [DisplayName("Nơi đến")]
    //    public string DiemDen { get; set; }

    //    public TourViewModel Tour { get; set; }
    //}

    //public class TourDuocChonDTO
    //{
    //    public string MaTour { get; set; }

    //    public int NguoiLon { get; set; }

    //    public int TreEm { get; set; }

    //    public decimal? TongTien { get; set; }

    //    public decimal? GiaTreEm { get; set; }

    //    public decimal? GiaNguoiLon { get; set; }
    //}

    public class TourChiTietViewModel
    {
        public string MaKS { get; set; }

        public TourViewModel Tour { get; set; }

        public decimal? GiaKhachSan { get; set; }

        public string AnhDiaDiem { get; set; }

        public DateTime? TGDi { get; set; }

        public DateTime? TGDen { get; set; }
    }

    //public class ThemTourViewModel
    //{
    //    public string MaHanhTrinh { get; set; }

    //    public TourViewModel TourDTO { get; set; }

    //    public string MaKS { get; set; }

    //    public int? MaHDV { get; set; }

    //    public string AnhDiaDiem { get; set; }

    //    public string MaLoaiTour { get; set; }
    //}

    public class ThaoTacTourViewModel
    {
        [Required]
        [DisplayName("Khách sạn")]
        public string KhachSan { get; set; }

        public TourViewModel Tour { get; set; }

        public SelectList DiemDis { get; set; } 

        public SelectList DiemDens { get; set; } 

        public SelectList KhachSans { get; set; }

        public SelectList LoaiTours { get; set; }

        public SelectList HuongDanViens { get; set; }

        public ThaoTacTourViewModel()
        {
            DiemDis= DiaDiemQueries.LoadDiaDiem();
            //DiemDis.SelectedValue = DiemDis.FirstOrDefault().Value;
            int? maDiemDi = int.Parse(DiemDis.SelectedValue.ToString());
            DiemDens = DiaDiemQueries.TimDiemDen2(maDiemDi);//
            KhachSans = KhachSanQueries.LayDsKhachSan();
            LoaiTours = TourQueries.LoadLoaiTour();
            HuongDanViens = NhanVienQueries.LoadHuongDanVien();//

        }

        public ThaoTacTourViewModel(string maTour)
        {
            TourChiTietViewModel tour = TourQueries.TimTour(maTour);
            Tour = tour.Tour;
            DiemDis = DiaDiemQueries.LoadDiaDiem(tour.Tour.MaDiaDiemDi.ToString());
            DiemDens = DiaDiemQueries.LoadDiaDiem(tour.Tour.MaDiaDiemDen.ToString());
            KhachSans = KhachSanQueries.LayDsKhachSan(tour.MaKS);
            LoaiTours = TourQueries.LoadLoaiTour(tour.Tour.LoaiTour);
            HuongDanViens = NhanVienQueries.LoadHuongDanVien(tour.Tour.MaHDV);
        }
    }

    public class ThemTourDLViewModel
    {
        public ThaoTacTourViewModel Tour { get; set; }

        public HanhTrinhViewModel ThemHanhTrinh { get; set; }
    }
}
