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
    /// 票房 (实际金额 * 100)
    /// </summary>
    [Required]
    public long BoxOffice { get; set; }
    [Required]
    public string Introduction { get; set; }

    public ICollection<Person> Persons { get; set; }

    public string Preview { get; set; }
    
    public Binary Cover { get; set; }
    public string CoverId { get; set; }

    public List<Show> Shows { get; set; }
    
    public List<Comment> Comments { get; set; }
    
}

public static class MovieHelper
{
    private static readonly string[] StatusLabelTable = {"[已隐藏]", "[在映]", "[未上映]"};

    public static string StatusLabel(this Movie m)
    {
        return m.Status switch
        {
            1 when m.ReleaseDate > DateTime.Now => "[待映]",
            2 when m.ReleaseDate < DateTime.Now => "[已下映]",
            _ => StatusLabelTable[m.Status]
        };
    }

    public static IEnumerable<Movie> DisplayMovie(this IEnumerable<Movie> ms, 
        bool showDisabled = false, 
        bool showOffline = true)
    {
        return ms
            .Where(m => (showDisabled || m.Status != 0) && (showOffline || m.Status != 2))
            .OrderBy(m => m.Status != 1).ThenBy(m => m.Status != 2)
            .ThenBy(m => m.ReleaseDate > DateTime.Now ? m.ReleaseDate : DateTime.MaxValue)
            .ThenByDescending(m => m.RateSum);
    }
    public static IQueryable<Movie> DisplayMovie(this IQueryable<Movie> ms, 
        bool showDisabled = false, 
        bool showOffline = true)
    {
        return ms
            .Where(m => (showDisabled || m.Status != 0) && (showOffline || m.Status != 2))
            .OrderBy(m => m.Status != 1).ThenBy(m => m.Status != 2)
            .ThenBy(m => m.ReleaseDate > DateTime.Now ? m.ReleaseDate : DateTime.MaxValue)
            .ThenByDescending(m => m.RateSum);
    }
}