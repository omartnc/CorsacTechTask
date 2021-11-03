using CorsacTechTask.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorsacTechTask.ViewModels
{
    public class TicketContentsViewModel
    {
        public string CustomerName { get; set; } 
        public string CustomerEmail { get; set; } 
        public string Title { get; set; } 
        public string ShortContent { get; set; }
        public string UID { get; set; } 
        public string  Content { get; set; }
        public List<string> Contents { get; set; } 
        public List<TicketContentsUserViewModel> Users { get; set; } 
        public TicketStatusEnum SelectedTicketStatus { get; set; }
        public string SelectedUserId { get; set; }
    }
    public class TicketContentsUserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
         
    }
}
