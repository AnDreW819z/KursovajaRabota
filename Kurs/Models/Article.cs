using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kurs.Models
{

    public class Article
    {
        public int Id { get; set; }
        [Display(Name = "��������" )]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }
        [Display(Name = "���������")]
        
        [Required]
        [StringLength(30)]
        public string? Categoru { get; set; }
        [Display(Name = "�����")]
        
        public string? Text { get; set; }

    }
}