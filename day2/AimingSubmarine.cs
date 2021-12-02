using System;

namespace day2;

public class AimingSubmarine : Submarine
{
    public int Aim { get; private set; }

    protected override void ExecCommand(Command command)
    {
        switch (command.Direction)
        {
            case Direction.forward: HorizontalPosition += command.Value;
                Depth += command.Value * Aim;
                break;
            case Direction.down: Aim += command.Value;
                break;
            case Direction.up: Aim -= command.Value;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}