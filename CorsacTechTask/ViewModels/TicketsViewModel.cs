using CorsacTechTask.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorsacTechTask.ViewModels
{
    public class TicketsViewModel
    { 
        public string UID { get; set; } 
        public string CustomerName { get; set; } 
        public string CustomerEmail { get; set; } 
        public string Title { get; set; } 
        public string ShortContent { get; set; }
        public TicketStatusEnum TicketStatusCode { get; set; }
        public string TicketStatusName { get; set; }
        public string IdentityUserId { get; set; }
        public string AssignedUser { get; set; }
    }
}
