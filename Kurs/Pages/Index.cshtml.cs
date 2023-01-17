using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kurs.Data;
using Kurs.Models;
using Kurs.Migrations;
using Microsoft.CodeAnalysis.Differencing;

namespace Kurs.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public Account account { get; set; }
        private KursContext db;
        public string Msg;
        public SignInModel(KursContext _db)
        {
            this.db = _db;
        }
        public void OnGet()
        {
            account = new Models.Account();
        }
        public IActionResult OnPost()
        {
            var acc = login(account.UserName, account.Password);
            if (acc == null)
            {
                Msg = "Invalid";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("username", acc.UserName);
                if (acc.UserName == "admin")
                {
                    return RedirectToPage("./Articles/Create");
                }
                return RedirectToPage("./Privacy");
            }
        }
        private Account login(string username, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.UserName.Equals(username));
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }
    }
}