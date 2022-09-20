using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class User
{
    [Key]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
    public byte[]? HeadPic { get; set; } = null;
    public DateTime VIPExpireTime { get; set; } = DateTime.MinValue;
    public bool IsMgr { get; set; } = false;
    public List<Ticket> Tickets { get; set; }
    public List<DiscountTicket> Discounts { get; set; }
    public List<Comment> Comments { get; set; }
}
