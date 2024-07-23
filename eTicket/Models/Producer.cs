using System.ComponentModel.DataAnnotations;
using eTicket.Data.Base;

namespace eTicket.Models;

public class Producer : IEntityBase 
{
    [Key]
    public int Id {get; set;}

    [Display (Name = "Profile Picture")]
    [Required (ErrorMessage = "Profile Picture is Required.")]
    public string ProfilePictureURL {get; set;} = string.Empty;

    [Display (Name = "Name")]
    [Required (ErrorMessage = "Name is Required.")]
    [StringLength(50, MinimumLength =3, ErrorMessage ="Name must be between 3 - 50 chars")]
    public string Name  {get; set;} = string.Empty;
    [Display (Name = "Biography")]
    [Required (ErrorMessage = "Bio is Required.")]
    public string Bio  {get; set;} = string.Empty;

    // Relationships

    public List<Movie> ?Movies  {get; set;} 
}
