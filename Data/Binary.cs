using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class Binary
{
    [Key]
    public string Id { get; set; }
    public byte[] Data { get; set; }
}