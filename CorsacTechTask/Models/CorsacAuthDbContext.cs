using CorsacTechTask.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsacTechTask.Models
{
    public class CorsacAuthDbContext:IdentityDbContext
    {
        public CorsacAuthDbContext(DbContextOptions<CorsacAuthDbContext> options):base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketContent> TicketContents { get; set; }
    }
}
