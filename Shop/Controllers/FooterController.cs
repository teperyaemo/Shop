using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using SocialApp.Services;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class FooterController : Controller
    {
        public async Task<IActionResult> SendMessage(Addressee addressee)
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(addressee.email, "Подписка на рассылку", "Пожалуйста, подпишите адресата на расслыку");
            return RedirectToAction("Index");
        }
    }
}
