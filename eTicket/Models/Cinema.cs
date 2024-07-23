using System.ComponentModel.DataAnnotations;

namespace eTicket.Models;

public class Cinema
{
    [Key]
    public int Id {get; set;}
    [Display (Name = "Logo")]
    public string CinemaLogoURL {get; set;} = string.Empty;
    [Display (Name = "Name")]
    public string Name  {get; set;} = string.Empty;
    [Display (Name = "Description")]
    public string Description  {get; set;} = string.Empty;

    // Relationships
    public List<Movie> ?Movies  {get; set;} 
}
