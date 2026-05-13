using System.ComponentModel.DataAnnotations;

namespace Buoi4.Models
{
    public class Todo
    {
        [Display(Name = "Mã công việc")]
        public string Id { get; set; }

        [Display(Name = "Tên công việc")]
        public string Name { get; set; }

        [Display(Name = "Trạng thái hoàn thành")]
        public bool IsCompleted { get; set; }
    }
}
