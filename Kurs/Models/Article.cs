using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kurs.Models
{

    public class Article
    {
        public int Id { get; set; }
        [RegularExpression(@"^[А-Я]+[а-яА-я\s]+[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Display(Name = "Название" )]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }
        [Display(Name = "Категория")]
        [RegularExpression(@"^[А-Я]+[а-яА-я\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Categoru { get; set; }
        [Display(Name = "Текст")]
        [RegularExpression(@"^[А-Я]+[а-яА-я\s]+[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string? Text { get; set; }

    }
}