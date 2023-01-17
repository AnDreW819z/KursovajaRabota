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

namespace Kurs.Pages.Accounts
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
                Msg= "Invalid";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("username", acc.UserName);
                return RedirectToPage("../Index");
            }
        }
        private Account login(string username, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.UserName.Equals(username));
            if(account != null) 
            { 
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }
    }
    //public class IndexModel : PageModel
    //{
    //    private readonly Kurs.Data.KursContext _context;

    //    public IndexModel(Kurs.Data.KursContext context)
    //    {
    //        _context = context;
    //    }

    //    public IList<Account> Account { get;set; } = default!;

    //    public async Task OnGetAsync()
    //    {
    //        if (_context.Accounts != null)
    //        {
    //            Account = await _context.Accounts.ToListAsync();
    //        }
    //    }
    //}
}
