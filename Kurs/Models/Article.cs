using System.ComponentModel.DataAnnotations;

namespace Kurs.Models;

public class Article
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Categoru { get; set; }
 
}