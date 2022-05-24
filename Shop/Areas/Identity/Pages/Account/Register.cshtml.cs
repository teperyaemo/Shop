﻿#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shop.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToPage("Login");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Login");
        }
    }
}
