using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class Ticket
{
    [Key] 
    public string Id { get; set; }
    public Order Order { get; set; }
    public Show Show { get; set; }
    /// <summary>
    /// 0 为无效票，1 为未使用，2 为已验票，3 为已过期
    /// </summary>
    public int Status { get; set; }
    public DateTime CreatTime { get; set; }
    public DateTime? UsedTime { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
}