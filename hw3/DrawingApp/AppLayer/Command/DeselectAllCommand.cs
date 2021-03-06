﻿using System;

namespace AppLayer.Command
{
    public class DeselectAllCommand : Command
    {
        internal DeselectAllCommand() { }

        public override void Execute()
        {
            TargetDrawing?.DeselectAll();
        }

        public override void Undo()
        {
            
        }

        public override string ToString()
        {
            return "deselect" + Environment.NewLine;
        }
    }
}
