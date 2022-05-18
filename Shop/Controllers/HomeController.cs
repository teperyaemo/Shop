using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailService emailService;

        public HomeController(EmailService emailService)
        {
            this.emailService = emailService;
        }
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }

        public IActionResult Subscribe()
        {
            emailService.SendEmail("//", "test", "test");
            return RedirectToAction("Index");
        }
    }
}
