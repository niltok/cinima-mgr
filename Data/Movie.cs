﻿using System.ComponentModel.DataAnnotations;
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
    /// 票房
    /// </summary>
    [Required]
    public long BoxOffice { get; set; }
    [Required]
    public string Introduction { get; set; }

    public ICollection<Person> Persons { get; set; } = new List<Person>();

    public string? Preview { get; set; }
    
    public byte[] CoverImg { get; set; }

    public ICollection<Show> Shows { get; set; } = new List<Show>();

}