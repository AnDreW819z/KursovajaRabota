using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kurs.Models 
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string Password { get; set; }
    }
}