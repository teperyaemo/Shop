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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(string? email)
        {            
            emailService.SendEmail(email, "Подписка на рассылку", "тест");
            return RedirectToAction(nameof(Index));
        }
    }
}
