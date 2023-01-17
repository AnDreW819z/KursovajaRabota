using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kurs.Data;
using Kurs.Models;

namespace Kurs.Pages.Accounts
{
    public class SignInModel : PageModel
    {
        private readonly Kurs.Data.KursContext _context;

        public SignInModel(Kurs.Data.KursContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Account account { get; set; }
        public IActionResult OnGet()
        {
            account = new Account();
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Accounts == null || account == null)
            {
                return Page();
            }

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
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
