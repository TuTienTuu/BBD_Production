using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBD_Production_New.Models
{
    public class ImportHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Tên file")]
        [MaxLength(150, ErrorMessage = "Tên file không được vượt quá 150 ký tự")]
        public string ImportFileName { get; set; }
        public DateTime ImportDate { get; set; }

    }
}
