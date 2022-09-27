using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Data;

[Index(nameof(EditTime), nameof(UserId))]
public class Comment
{
    [Key]
    public string Id { get; set; }
    [Required]
    public Movie Movie { get; set; }
    [Required]
    public User User { get; set; }
    public string UserId { get; set; }
    [Required]
    public double Rate { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public DateTime CreateTime { get; set; }
    [Required]
    public DateTime EditTime { get; set; }
}