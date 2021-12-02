using System.Collections.Generic;
using System.Linq;

namespace day1;

public class IncreaseCounter
{
    public int Count(List<int> input)
    {
        return input
            .Select((item, idx) => idx >= 1 && input[idx - 1] < item)
            .Count(i => i);
    }

    public int CountWithSlidingWindows(List<int> input)
    {
        var windows = BuildWindows(input);

        return Count(windows);
    }

    private static List<int> BuildWindows(List<int> input)
    {
        var windows = new List<int>();
        var run = 1;
        for (var i = 0; i < input.Count; i++)
        {
            if (run >= 3)
            {
                windows.Add(input[i] + input[i - 1] + input[i - 2]);
            }

            run++;
        }

        return windows;
    }
}