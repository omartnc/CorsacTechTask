using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorsacTechTask.ViewModels
{
    public class TicketViewModel
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortContent { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
