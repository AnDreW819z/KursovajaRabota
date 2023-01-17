using Kurs.Data;
using Kurs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Pages.Accounts
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public Account account { get; set; }
        private KursContext db;
        public ProfileModel(KursContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            var username = HttpContext.Session.GetString("username");
            account = db.Accounts.SingleOrDefault(a => a.UserName.Equals(username));
        }
        public IActionResult OnPost() 
        {
            if (!string.IsNullOrEmpty(account.Password))
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            }
            else
            {
                account.Password = db.Accounts.AsNoTracking().SingleOrDefault(a => a.Id == account.Id).Password;
            }
            db.SaveChanges();
            db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToPage("../Index");
        }
    }
}
