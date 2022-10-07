using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Data;

[Index(nameof(TriggerTime))]
public class Event
{
    [Key]
    public string Id { get; set; }
    public DateTime TriggerTime { get; set; }
    public string Closure { get; set; }
}