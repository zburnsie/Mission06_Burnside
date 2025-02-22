using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Burnside.Models;

public class Movie
{
    //Make this the primary key
    [Key]
    [Required]
    public int MovieId { get; set; }
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    
    [Required(ErrorMessage="You must enter a year")]
    [Range(1888, int.MaxValue, ErrorMessage = "You must enter a year after 1888")]
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    [Required]
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    [Required]
    public bool CopiedToPlex { get; set; }
    [MaxLength(25)]
    public string? Notes { get; set; }
}