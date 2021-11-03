using CorsacTechTask.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CorsacTechTask.DbModels
{

    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string UID { get; set; } = RandomStr.RandomString(10);
        public string Title { get; set; }
        public string ShortContent { get; set; } 
        public TicketStatusEnum TicketStatus { get; set; } = TicketStatusEnum.WaitingForStaffResponse;
         
        public string IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public virtual IdentityUser IdentityUser { get; set; }

        public virtual List<TicketContent> TicketContents { get; set; }
    }
}
