using System.ComponentModel.DataAnnotations;

namespace BBD_Production_New.Models
{
    public class ProductionOrder
    {
        [Key]
        public Guid ProductionOrderId { get; set; }
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
        public string FileName { get; set; }
        [MaxLength(150, ErrorMessage = "Tên file không được vượt quá 150 ký tự")]
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
