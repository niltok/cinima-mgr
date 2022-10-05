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
    public DateTime ReleaseDate { get; set; } 
    [Required]
    public TimeSpan Duration { get; set; }
    [Required] 
    public string Type { get; set; }
    /// <summary>
    /// 0 表示已隐藏，1 表示在映，2 表示不在映
    /// </summary>
    public int Status { get; set; }
    public double RateSum { get; set; }
    public int RateCount { get; set; }
    /// <summary>
    /// 票房
    /// </summary>
    [Required]
    public long BoxOffice { get; set; }
    [Required]
    public string Introduction { get; set; }

    public ICollection<Person> Persons { get; set; }

    public string? Preview { get; set; }
    
    public byte[] CoverImg { get; set; }

    public List<Show> Shows { get; set; }
    
    public List<Comment> Comments { get; set; }
}