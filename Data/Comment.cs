using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinima_mgr.Data;

public class Comment
{
    [Key]
    public string Id { get; set; }
    [Required]
    public Movie Movie { get; set; }
    [Required]
    public User User { get; set; }
    [Required]
    public double Rate { get; set; }
    [Required]
    public double Content { get; set; }
}