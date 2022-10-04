using System.Text;

namespace cinima_mgr.Data;

public static class PosStateHelper
{
    public static List<List<char>> Unpack(string pos, int h, int w)
    {
        var res = new List<List<char>>(h);
        for (int i = 0; i < h; i++)
        {
            var tmp = new List<char>(w);
            for (int j = 0; j < w; j++)
            {
                tmp.Add(i * w + j < pos.Length ? pos[i * w + j] : ' ');
            }
            res.Add(tmp);
        }

        return res;
    }

    public static string Pack(List<List<char>> pos)
    {
        var sb = new StringBuilder();
        foreach (var c in pos.SelectMany(cs => cs))
        {
            sb.Append(c);
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