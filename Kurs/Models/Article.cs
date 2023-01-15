using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kurs.Models
{

    public class Article
    {
        public int Id { get; set; }
        [Display(Name = "Название" )]
        public string? Title { get; set; }
        [Display(Name = "Категория")]
        public string? Categoru { get; set; }
        
        public string? Text { get; set; }

    }
}