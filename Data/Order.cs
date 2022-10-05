using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Data;

public class Order
{
    [Key]
    public string Id { get; set; }
    [Required]
    public User User { get; set; }
    /// <summary>
    /// 订单类型： '0' 表示票务订单，'1' 表示会员订单
    /// </summary>
    [Required]
    public int type { get; set; }
    /// <summary>
    /// 订单状态： ’0‘ 表示未付款， ’1‘ 表示已付款， ’2‘ 表示已退款
    /// </summary>
    public int State { get; set; } = 0;
    public List<Ticket> Tickets { get; set; }
    public List<DiscountTicket> Discounts { get; set; }
    public double OriginalPrice { get; set; } = 0.0;
    public double Price { get; set; } = 0.0;
}