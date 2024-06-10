using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Workplace.Shared
{
    public class TaskItemDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Требуется указать название")]
        [Display(Name = "Наименование")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Требуется указать тему")]
        [Display(Name = "Тема")]
        public string? Theme { get; set; }

        [Required(ErrorMessage = "Требуется дать описание")]
        [Display(Name = "Описание")]
        public string? Description { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime? UpdateTime { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Требуется указать время начала")]
        [DateMustBeBefore(nameof(EndTime))]
        [Display(Name = "Время начала")]
        public DateTime? StartTime { get; set; }

        [Required(ErrorMessage = "Требуется указать время окончания")]
        [DateMustBeAfter(nameof(StartTime))]
        [Display(Name = "Время окончания")]
        public DateTime? EndTime { get; set; }
    }
}
