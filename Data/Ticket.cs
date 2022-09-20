using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class Ticket
{
    [Key] 
    public string Id { get; set; }
}