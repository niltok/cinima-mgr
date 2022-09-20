using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace cinima_mgr.Data;

public class Movie
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required] 
    public string ReleaseDate { get; set; } 
    [Required] 
    public string Type { get; set; }
    [Required]
    public string BoxOffice { get; set; }
    [Required]
    public string Introduction { get; set; }
    
    public ICollection<People> Persons { get; set; }

    public Url Preview { get; set; }
    
    public Url CoverImg { get; set; }
    
}