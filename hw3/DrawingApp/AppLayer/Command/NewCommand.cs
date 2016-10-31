using System;

namespace AppLayer.Command
{
    public class NewCommand : Command
    {
        internal NewCommand() {}

        public override void Execute()
        {
            TargetDrawing?.Clear();
            CommandHistory.Instance.Clear();
        }

        public override string ToString()
        {
            return "";
        }

        public override void Undo()
        {
        }
    }
}
