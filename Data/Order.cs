using System.ComponentModel.DataAnnotations;
using System.Data;
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
    public int Type { get; set; }
    /// <summary>
    /// 订单状态： '0' 表示未付款， '1' 表示已付款， '2' 表示已退款，'3' 表示已取消, '4' 表示已删除
    /// </summary>
    public int State { get; set; } = 0;
    public DateTime CreateTime { get; set; }
    public DateTime? PayTime { get; set; }
    public DateTime? CancelTime { get; set; }
    public DateTime? RefundTime { get; set; }
    /// <summary>
    /// 购买的会员天数
    /// </summary>
    public int? Days { get; set; } = 0;
    public List<Ticket>? Tickets { get; set; }
    public List<DiscountTicket>? Discounts { get; set; }
    public double OriginalPrice { get; set; } = 0.0;
    public double Price { get; set; } = 0.0;
}