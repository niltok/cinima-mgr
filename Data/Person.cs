using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class Person
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }

    public ICollection<Movie> Movies { get; set; }
}