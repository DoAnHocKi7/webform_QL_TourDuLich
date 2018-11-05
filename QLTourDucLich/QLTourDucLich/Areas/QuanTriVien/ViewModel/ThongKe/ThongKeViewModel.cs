using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace QLTourDucLich.Areas.QuanTriVien.ViewModel.ThongKe
{
    [DataContract]
    public class ThongKeTheoTourViewModel
    {
        public int MaDiemDen { get; set; }

        [DataMember(Name ="label")]
        public string TenDiemDen { get; set; }

        [DataMember(Name = "y")]
        public decimal? TienDaBan { get; set; }
    }

    [DataContract]
    public class DataPoint
	{
		public DataPoint(string label, double y)
		{
			this.Label = label;
			this.Y = y;
		}
 
		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "label")]
		public string Label = "";
 
		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;

        public string Kha = "Tran kha";
	}
}