using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class Ticket
{
    [Key] 
    private string Id { get; set; }
}