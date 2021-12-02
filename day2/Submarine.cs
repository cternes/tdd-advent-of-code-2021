using System;
using System.Collections.Generic;

namespace day2;

public class Submarine
{
    public int HorizontalPosition { get; protected set; }
    public int Depth { get; protected set; }
    public int MultipliedPosition => HorizontalPosition * Depth;

    public void Move(List<Command> commands)
    {
        commands.ForEach(ExecCommand);
    }

    protected virtual void ExecCommand(Command command)
    {
        switch (command.Direction)
        {
            case Direction.forward: HorizontalPosition += command.Value;
                break;
            case Direction.down: Depth += command.Value;
                break;
            case Direction.up: Depth -= command.Value;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}