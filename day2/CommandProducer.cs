using System;
using System.Collections.Generic;
using System.Linq;

namespace day2;

public class CommandProducer
{
    public List<Command> ReadCommands(List<string> lines)
    {
        return lines.Select(i =>
        {
            var splitted = i.Split(' ');

            Enum.TryParse(splitted[0], out Direction direction);
            int value = int.Parse(splitted[1]);

            return new Command(direction, value);
        }).ToList();
    }
}