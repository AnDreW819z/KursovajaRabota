using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kurs.Models
{

    public class Article
    {
        public int Id { get; set; }
        [Display(Name = "Название" )]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }
        [Display(Name = "Категория")]
        
        [Required]
        [StringLength(30)]
        public string? Categoru { get; set; }
        [Display(Name = "Текст")]
        
        public string? Text { get; set; }

    }
}