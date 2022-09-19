using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinima_mgr.Data;

public class SessionState
{
    [Key]
    public string Id { get; set; }
    
    [ForeignKey("User")]
    public string User { get; set; }
    
    public DateTime CreateTime { get; set; } = DateTime.Now;
}