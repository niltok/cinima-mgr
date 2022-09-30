using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Data;

public class Order
{
    [Key]
    public string Id { get; set; }
    [Required]
    public User User { get; set; }
    [Required]
    public Show Show { get; set; }
    // 订单状态
    // ’0‘ 表示未付款， ’1‘ 表示已付款， ’2‘ 表示已退款
    public int State { get; set; } = 0;
    public Ticket Ticket { get; set; } = null;
    public double Price { get; set; } = 0.0;
}