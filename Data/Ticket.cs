using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class Ticket
{
    [Key] 
    public string Id { get; set; }
    [Required]
    public Order Order { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
}