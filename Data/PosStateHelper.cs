using System.Text;

namespace cinima_mgr.Data;

public static class PosStateHelper
{
    public static char[,] Unpack(string pos, int h, int w)
    {
        var res = new char[h, w];
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                res[i, j] = i * w + j < pos.Length ? pos[i * w + j] : ' ';
            }
        }
        return res;
    }

    public static string Pack(char[,] pos)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < pos.GetLength(0); i++)
        {
            for (int j = 0; j < pos.GetLength(1); j++)
            {
                sb.Append(pos[i, j]);
            }
        }
        return sb.ToString();
    }

    public static string GenAll0(int h, int w)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < h * w; i++) sb.Append('0');
        return sb.ToString();
    }

    public static string GenSkip1(int h, int w)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                sb.Append((i % 2 + j % 2) % 2 == 1 ? '0' : ' ');
            }
        }
        return sb.ToString();
    }

    public static string FilterSkip1(string s, int h, int w)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                sb.Append((i % 2 + j % 2) % 2 == 1 ? (i * w + j < s.Length ? s[i * w + j] : ' ') : ' ');
            }
        }
        return sb.ToString();
    }
}