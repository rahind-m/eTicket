using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eTicket.Data.Enum;

namespace eTicket.Models;

public class Movie
{
    [Key]
    public int Id {get; set;}
    public string Name  {get; set;} = string.Empty;
    public string Description  {get; set;} = string.Empty;
    public DateTime StartDate  {get; set;} 
    public DateTime EndDate  {get; set;} 
    public double Price {get; set;} 
    public string CinemaName  {get; set;} = string.Empty;
    public MovieCategory MovieCategory  {get; set;} 
    public string ImageURL  {get; set;} = string.Empty;

    // Relationships
    public List<Actor_Movie> ?Actor_Movies  {get; set;} 

    //cinema

    public int CinemaId  {get; set;} 
    [ForeignKey("CinemaId")]
    public Cinema? Cinema  {get; set;} 

    //Producer

    public int ProducerId  {get; set;} 
    [ForeignKey("ProducerId")]
    public Producer? Producer  {get; set;} 






}
