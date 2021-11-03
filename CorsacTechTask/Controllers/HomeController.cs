using CorsacTechTask.DbModels;
using CorsacTechTask.Helpers;
using CorsacTechTask.Models;
using CorsacTechTask.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CorsacTechTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly CorsacAuthDbContext _db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CorsacAuthDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Tickets(TicketStatusEnum type)
        {
            try
            {
                var tickets = _db.Tickets.Where(x => x.TicketStatus == type)
                .ToList()
                .Select(x => new TicketsViewModel
                {
                    Title = x.Title,
                    CustomerName = x.CustomerName,
                    CustomerEmail = x.CustomerEmail,
                    TicketStatusCode = x.TicketStatus,
                    ShortContent = x.ShortContent,
                    IdentityUserId = x.IdentityUserId,
                    UID = x.UID,
                    TicketStatusName = EnumExtensions.GetDisplayName(x.TicketStatus),
                    AssignedUser = !string.IsNullOrEmpty(x.IdentityUserId) ? userManager.FindByIdAsync(x.IdentityUserId).Result.UserName : "N/A"
                })
                .ToList();
                if (tickets == null)
                    return RedirectToAction("Index");

                return View(tickets);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }


        [AllowAnonymous]
        public IActionResult CreateTicket()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTicket(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ticket = _db.Tickets.Add(new DbModels.Ticket
                    {
                        CustomerEmail = model.CustomerEmail,
                        CustomerName = model.CustomerName,
                        ShortContent = model.ShortContent,
                        Title = model.Title
                    });
                    _db.SaveChanges();
                    _db.TicketContents.Add(new DbModels.TicketContent
                    {
                        Content = model.Content,
                        TicketId = ticket.Entity.Id
                    });
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "An error occurred please try again later");
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTicket(TicketContentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ticket = _db.Tickets.FirstOrDefault(x => x.UID == model.UID);
                    if (ticket == null)
                    {
                        ModelState.AddModelError("", "An error occurred please try again later");
                        return View(model);
                    }
                    if (signInManager.IsSignedIn(User))
                    {
                        ticket.IdentityUserId = model.SelectedUserId;
                        ticket.TicketStatus = model.SelectedTicketStatus;
                        _db.SaveChanges();

                        try
                        { 
                            await MailHelper.Send(new MailSendModel
                            {
                                EmailTo = ticket.CustomerEmail,
                                NameTo = ticket.CustomerName,
                                Subject = $"Your ticket number {ticket.UID} has been answered.",
                                HtmlBody = $"<a   target=\"_blank\"  href=\"https://localhost:5002/Home/Ticket?code={ticket.UID}\">detail</a>"
                            });
                        }
                        catch (Exception e)
                        { 
                        }
                    }
                    if (!string.IsNullOrEmpty(model.Content))
                    {
                        _db.TicketContents.Add(new DbModels.TicketContent
                        {
                            Content = model.Content,
                            TicketId = ticket.Id
                        });
                        _db.SaveChanges();
                    }
                   
                    return RedirectToAction("Ticket", "Home", new { code = model.UID });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "An error occurred please try again later");
                }
            }
            return View("CreateTicket");
        }
        [AllowAnonymous]
        public IActionResult Ticket(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                try
                {
                    var ticket = _db.Tickets.FirstOrDefault(x => x.UID == code);
                    if (ticket == null)
                        return RedirectToAction("Index");

                    var rtrnModel = new TicketContentsViewModel
                    {
                        Contents = _db.TicketContents.Where(x => x.TicketId == ticket.Id).Select(x => x.Content).ToList(),
                        UID = ticket.UID,
                        CustomerEmail = ticket.CustomerEmail,
                        CustomerName = ticket.CustomerName,
                        Title = ticket.Title,
                        ShortContent = ticket.ShortContent,
                        SelectedTicketStatus = ticket.TicketStatus,
                        SelectedUserId = ticket.IdentityUserId,
                        Users = _db.Users.Select(x => new TicketContentsUserViewModel { Id = x.Id, Name = x.UserName }).ToList()
                    };
                    return View(rtrnModel);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
