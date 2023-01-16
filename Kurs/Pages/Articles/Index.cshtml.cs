using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kurs.Data;
using Kurs.Models;

namespace Kurs.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly Kurs.Data.KursContext _context;

        public IndexModel(Kurs.Data.KursContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Categores { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ArticleCategory { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> categoryQuery = from a in _context.Article
                                            orderby a.Categoru
                                            select a.Categoru;
            var articles = from a in _context.Article
                        select a;
            if (!string.IsNullOrEmpty(SearchString))
            {
                articles = articles.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ArticleCategory))
            {
                articles = articles.Where(x => x.Categoru == ArticleCategory);
            }
            Categores = new SelectList(await categoryQuery.Distinct().ToListAsync());
            Article = await articles.ToListAsync();
        }
    }
}
