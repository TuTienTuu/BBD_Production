using System.ComponentModel.DataAnnotations;

namespace BBD_Production_New.Models
{
    public class ProductionPlan
    {
        [Key]
        public Guid ProductionPlanId { get; set; }
        [Required]
        [Display(Name = "Mã sản xuất")]
        [MaxLength(50, ErrorMessage = "Mã sản xuất không được vượt quá 50 ký tự")]
        public string ProductionCode { get; set; }
        [Display(Name = "Máy")]
        [MaxLength(3, ErrorMessage = "Mã máy không được vượt quá 3 ký tự")]
        public string Machine { get; set; }
        [Display(Name = "Mã Khách hàng")]
        [MaxLength(3, ErrorMessage = "Mã khách hàng không được vượt quá 3 ký tự")]
        public string CustomerCode { get; set; }
        [Display(Name = "Tên khách hàng")]
        [MaxLength(150, ErrorMessage = "Tên khách hàng không được vượt quá 150 ký tự")]
        public string CustomerName { get; set; }
        [Display(Name = "Mã PO")]
        [MaxLength(20, ErrorMessage = "Mã PO không được vượt quá 20 ký tự")]
        public string POCode { get; set; }
        [Display(Name = "Ngày đặt hàng")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Ngày giao hàng")]
        public DateTime DeliveryDate { get; set; }
        [Display(Name = "Loại hàng")]
        [MaxLength(20, ErrorMessage = "Loại hàng không được vượt quá 20 ký tự")]
        public string ProductType { get; set; }
        [Display(Name = "Quy cách dao")]
        [MaxLength(150, ErrorMessage = "Quy cách dao không được vượt quá 150 ký tự")]
        public string KnifeSpec { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Nội dung")]
        [MaxLength(500, ErrorMessage = "Nội dung không được vượt quá 500 ký tự")]
        public string Content { get; set; }
        [Display(Name = "Số công đoạn")]
        public int NumberOfStage { get; set; }
        [Display(Name = "Tổng mã")]
        public int NumberOfCode { get; set; }
        [Display(Name = "Màng cán")]
        [MaxLength(50, ErrorMessage = "Màn cán không được vượt quá 50 ký tự")]
        public string LaminatingFilm { get; set; }
        public int LaminatingSize { get; set; }
        [Display(Name = "Mã giấy")]
        [MaxLength(50, ErrorMessage = "Mã giấy không được vượt quá 50 ký tự")]
        public string PaperCode { get; set; }
        [Display(Name = "Khổ giấy")]
        public int PaperSize { get; set; }
        [Display(Name = "M/Cuộn")]
        public int MetterPerRoll { get; set; }
        [Display(Name = "Tem/Cuộn")]
        public int StampPerRoll { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [MaxLength(50, ErrorMessage = "Đơn vị không được vượt quá 50 ký tự")]
        [Display(Name = "Đơn vị")]
        public string Unit { get; set; }
        [Display(Name = "Lõi/Tờ")]
        public int CorePerSheet { get; set; }
        [Display(Name = "M/Đơn")]
        public int MetterPerOrder { get; set; }
        [Display(Name = "MSX")]
        public int ProductedMetter { get; set; }
        [MaxLength(20, ErrorMessage = "Loại đơn hàng không được vượt quá 20 ký tự")]
        [Display(Name = "Mã layout")]
        public string LayoutCode { get; set; }
        [MaxLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự")]
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        [MaxLength(50, ErrorMessage = "Loại đơn hàng không được vượt quá 50 ký tự")]
        [Display(Name = "Loại sản xuất")]
        public string ProductionType { get; set; }
        [MaxLength(150, ErrorMessage = "Người đặt hàng không được vượt quá 150 ký tự")]
        [Display(Name = "Người đặt hàng")]
        public string OrderBy { get; set; }
        [MaxLength(14, ErrorMessage = "Mã sản phẩm không được vượt quá 14 ký tự")]
        [Display(Name = "Mã sản phẩm")]
        public string ProductCode { get; set; }
        [MaxLength(20, ErrorMessage = "Mã dao không được vượt quá 20 ký tự")]
        [Display(Name = "Mã dao")]
        public string KnifeCode { get; set; }
        [MaxLength(150, ErrorMessage = "Nội dung dao không được vượt quá 150 ký tự")]
        [Display(Name = "Mô tả dao")]
        public string KnifeContent { get; set; }
        [MaxLength(250, ErrorMessage = "Nội dung sản phẩm không được vượt quá 250 ký tự")]
        [Display(Name = "Mô tả sản phẩm")]
        public string ProductContent { get; set; }
        [Display(Name = "Biên")]
        public int Border { get; set; }
        [MaxLength(150, ErrorMessage = "Nhà cung cấp không được vượt quá 150 ký tự")]
        [Display(Name = "Nhà cung cấp")]
        public string PaperSupply { get; set; }
        [Display(Name = "Tổng số lượng")]
        public int TotalQuantity { get; set; }
        [Display(Name = "Tổng số mét")]
        public int TotalMetter { get; set; }
        [Display(Name = "Mã layout chính")]
        public int LayoutMainCode { get; set; }
        [MaxLength(3, ErrorMessage = "Decal Master không được vượt quá 3 ký tự")]
        [Display(Name = "Mã Decal chính")]
        public string DecalMaster { get; set; }
        [MaxLength(50, ErrorMessage = "Mã phim không được vượt quá 50 ký tự")]
        [Display(Name = "Mã phim")]
        public string FilmCode { get; set; }
        [Display(Name = "Tổng mã")]
        public int TotalProduct { get; set; }
        [Display(Name = "Số sản phẩm")]
        public int ProductNumber { get; set; }
        [Display(Name = "Số màu")]
        public int ColorNumber { get; set; }
        [Display(Name = "Số màu pha")]
        public int NumberTiningColor { get; set; }
        [Display(Name = "Số màu chồng")]
        public int NumberStackColor { get; set; }
        [Display(Name = "Số màu gốc")]
        public int NumberRootColor { get; set; }
        [MaxLength(50, ErrorMessage = "Công đoạn 1 không được vượt quá 50 ký tự")]
        [Display(Name = "CĐ1")]
        public string Stage_1 { get; set; }
        [Display(Name = "H.H1")]
        public float Stage_1_Loss { get; set; }
        [Display(Name = "CĐ2")]
        [MaxLength(50, ErrorMessage = "Công đoạn 2 không được vượt quá 50 ký tự")]
        public string Stage_2 { get; set; }
        [Display(Name = "H.H2")]
        public float Stage_2_Loss { get; set; }
        [MaxLength(50, ErrorMessage = "Công đoạn 3 không được vượt quá 50 ký tự")]
        [Display(Name = "CĐ3")]
        public string Stage_3 { get; set; }
        [Display(Name = "H.H3")]
        public float Stage_3_Loss { get; set; }
        [MaxLength(50, ErrorMessage = "Công đoạn 4 không được vượt quá 50 ký tự")]
        [Display(Name = "CĐ4")]
        public string Stage_4 { get; set; }
        [Display(Name = "H.H4")]
        public float Stage_4_Loss { get; set; }
        [MaxLength(50, ErrorMessage = "Công đoạn 5 không được vượt quá 50 ký tự")]
        [Display(Name = "CĐ5")]
        public string Stage_5 { get; set; }
        [Display(Name = "H.H5")]
        public float Stage_5_Loss { get; set; }
        [Display(Name = "H.H in mặt")]
        public float PrintSurfaceLoss { get; set; }
        [Display(Name = "H.H in đế")]
        public float PrintSoleLoss { get; set; }
        [Display(Name = "Thay mã")]
        public float ChangeProductLoss { get; set; }
        [Display(Name = "H.H thay màng")]
        public int ChangeLaminationLoss { get; set; }
        [Display(Name = "% rủi ro")]
        public int LossPercent { get; set; }
        [Display(Name = "Tổng hao hụt")]
        public int LossTotal { get; set; }
        [Display(Name = "Xẻ line")]
        public int SplitLine { get; set; }
        [Display(Name = "Bước dao")]
        public int KnifeStep { get; set; }
        [Display(Name = "Tem/Nhịp")]
        public int StampPerStep { get; set; }
        [Display(Name = "KT ngang")]
        public int With { get; set; }
        [Display(Name = "Số tem ngang")]
        public int NumStampHorizontail { get; set; }
        [Display(Name = "Bước in")]
        public int PrintStep { get; set; }
        [Display(Name = "Cây lõi")]
        public float Core { get; set; }
        [Display(Name = "QC lõi")]
        public float CoreSpec { get; set; }
        [MaxLength(150, ErrorMessage = "Tên layout không được vượt quá 150 ký tự")]
        [Display(Name = "Tên layout")]
        public string LayoutName { get; set; }
        [MaxLength(50, ErrorMessage = "Vị trí không được vượt quá 50 ký tự")]
        [Display(Name = "Vị trí layout")]
        public string LayoutPosition { get; set; }
        [Display(Name = "Time 1")]
        public float Time_1 { get; set; }
        [Display(Name = "Time 2")]
        public float Time_2 { get; set; }
        [Display(Name = "Time 3")]
        public float Time_3 { get; set; }
        [Display(Name = "Time 4")]
        public float Time_4 { get; set; }
        [Display(Name = "Time 5")]
        public float Time_5 { get; set; }
        [Display(Name = "Giữa")]
        public float Middle { get; set; }
        [MaxLength(150,ErrorMessage ="Tên sản phẩm không được vượt quá 150 ký tự")]
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Thời gian tạo")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Thời gian cập nhật")]
        public DateTime ModifiedDate { get; set; }
        [Display(Name = "Thời gian xóa")]
        public DateTime DeletedDate { get; set; }
        [Display(Name = "Đã xóa?")]
        public bool IsDeleted { get; set; }
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }
    }
}
