using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class Config
{
    [Key]
    public string Key { get; set; }
    public string Value { get; set; }
}