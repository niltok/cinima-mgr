using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class Event
{
    [Key]
    public string Id { get; set; }
    public DateTime TriggerTime { get; set; }
    public string Closure { get; set; }
}