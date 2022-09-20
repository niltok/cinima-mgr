using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinima_mgr.Data;

public class DiscountTicket
{
    [Key]
    public string Id { get; set; }
    public User User { get; set; }
    [Required]
    public double Rate { get; set; }
    public string Name { get; set; }
}