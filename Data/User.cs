using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class User
{
    [Key]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
    public Binary? HeadPic { get; set; } = null;
    [ConcurrencyCheck]
    public DateTime VIPExpireTime { get; set; } = DateTime.MinValue;
    public bool IsMgr { get; set; } = false;
    public List<Order> Orders { get; set; }
    public List<DiscountTicket> Discounts { get; set; }
    public List<Comment> Comments { get; set; }
}
