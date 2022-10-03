﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinima_mgr.Data;

public class DiscountTicket
{
    [Key]
    public string Id { get; set; }
    public User User { get; set; }
    /// <summary>
    /// 优惠券类型
    /// 0 为无效券，1 为满减券， 2 为折扣券
    /// </summary>
    public int Type { get; set; }
    /// <summary>
    /// null 为未使用
    /// </summary>
    public Order? UsedIn { get; set; } = null;
    public double Rate { get; set; }
    /// <summary>
    /// 优惠门槛
    /// </summary>
    public double Satisfy { get; set; }
    public string Name { get; set; }
}