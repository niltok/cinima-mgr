using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Data;

[Index(nameof(Name), IsUnique = true)]
public class RoomTemplate
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    /// <summary>
    /// 有多少列
    /// </summary>
    public int Width { get; set; }
    /// <summary>
    /// 有多少排
    /// </summary>
    public int Height { get; set; }
    /// <summary>
    /// PosState 字段表示整个厅的座位状态，i 排 j 列在 PosState 中的索引为 i * Width + j
    /// 如果索引不存在或者值为空格则表示该位置不可选（不存在的位置）
    /// 如果值为 0 则表示未选，值为 1 则表示已选，值为 2 则表示已验票
    /// </summary>
    public string PosState { get; set; } = "";
    public List<Show> Shows { get; set; }
}