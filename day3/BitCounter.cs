using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day3;

public class BitCounter
{
    public static int ToInt(string binary)
    {
        return Convert.ToInt32(binary, 2);
    }

    public static string FindMostCommonBit(int position, List<string> lines)
    {
        var bit = lines.Select(i => i[position])
            .ToList();

        var zeroCount = bit.Count(i => i == '0');
        var oneCount = bit.Count(i => i == '1');

        if (zeroCount > oneCount)
        {
            return "0";
        }

        return "1";
    }

    public static string FindLeastCommonBit(int position, List<string> lines)
    {
        var bit = FindMostCommonBit(position, lines);
        return bit == "1" ? "0" : "1";
    }

    public static string FindGammaRate(List<string> lines)
    {
        return FindRate(lines, FindMostCommonBit);
    }

    public static string FindEpsilonRate(List<string> lines)
    {
        return FindRate(lines, FindLeastCommonBit);
    }

    private static string FindRate(List<string> lines, Func<int, List<string>, string> findMethod)
    {
        var epsilonRate = new StringBuilder();
        for (var i = 0; i < lines[0].Length; i++)
        {
            var bit = findMethod(i, lines);
            epsilonRate.Append(bit);
        }

        return epsilonRate.ToString();
    }
}