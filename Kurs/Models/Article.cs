using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kurs.Models
{

    public class Article
    {
        public int Id { get; set; }
        [RegularExpression(@"^[�-�]+[�-��-�\s]+[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Display(Name = "��������" )]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }
        [Display(Name = "���������")]
        [RegularExpression(@"^[�-�]+[�-��-�\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Categoru { get; set; }
        [Display(Name = "�����")]
        [RegularExpression(@"^[�-�]+[�-��-�\s]+[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string? Text { get; set; }

    }
}