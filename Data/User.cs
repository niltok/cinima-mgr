using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class User
{
    [Key]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
    public bool IsVIP { get; set; } = false;
    public bool IsMgr { get; set; } = false;
}
