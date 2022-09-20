using System.ComponentModel.DataAnnotations;

namespace cinima_mgr.Data;

public class RoomTemplate
{
    [Key]
    public string Name { get; set; }
    /// <summary>
    /// 有多少列
    /// </summary>
    [Required]
    public int Width { get; set; }
    /// <summary>
    /// 有多少排
    /// </summary>
    [Required]
    public int Height { get; set; }
    /// <summary>
    /// PosState 字段表示整个厅的座位状态，i 排 j 列在 PosState 中的索引为 i * Width + j
    /// 如果索引不存在或者值为空格则表示该位置不可选（不存在的位置）
    /// 如果值为 0 则表示未选，值为 1 则表示已选，值为 2 则表示已验票
    /// </summary>
    public string PosState { get; set; } = "";
}