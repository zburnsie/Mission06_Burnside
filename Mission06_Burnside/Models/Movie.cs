using System.ComponentModel.DataAnnotations;

namespace Mission06_Burnside.Models;

public class Movie
{
    //Make this the primary key
    [Key]
    [Required]
    public int MovieID { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public string Rating { get; set; }

    //THese three are not required
    public bool? Edited { get; set; } // Nullable because it's not required

    public string? LentTo { get; set; } //adding the question mark should make it not required

    [MaxLength(25)]
    public string? Notes { get; set; }
}