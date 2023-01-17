using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kurs.Data;
using Kurs.Models;

namespace Kurs.Pages.Accounts
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public Account account { get; set; }
        private KursContext db;
        public SignUpModel(KursContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            account = new Account();
        }
        public IActionResult OnPost()
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            db.Accounts.Add(account);
            db.SaveChanges();
            return RedirectToPage("./Index");
        }
        //private readonly Kurs.Data.KursContext _context;

        //public CreateModel(Kurs.Data.KursContext context)
        //{
        //    _context = context;
        //}

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        //[BindProperty]
        //public Account Account { get; set; } = default!;


        //// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{
        //  if (!ModelState.IsValid || _context.Accounts == null || Account == null)
        //    {
        //        return Page();
        //    }

        //    _context.Accounts.Add(Account);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
