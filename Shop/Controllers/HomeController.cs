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

        public IActionResult Subscribe(string email)
        {
            emailService.SendEmail("rokudenas@bk.ru", "Подписка на рассылку", $"Необходимо добавить в адресную книгу почту: {email}");
            emailService.SendEmail(email, "Подписка на рассылку", "Теперь вы будете получать новости и изменения о компании Русмет");
            return RedirectToAction("Index");
        }
    }
}
