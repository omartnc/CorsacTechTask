using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorsacTechTask.DbModels
{
    public enum TicketStatusEnum
    {
        [Display(Name= "Waiting For Staff Response")]
        WaitingForStaffResponse,

        [Display(Name = "Waiting For Customer")]
        WaitingForCustomer,

        [Display(Name = "On Hold")]
        OnHold,

        [Display(Name = "Cancelled")]
        Cancelled,

        [Display(Name = "Compleated")]
        Compleated
    }
}
