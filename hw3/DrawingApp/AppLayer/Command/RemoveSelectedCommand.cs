using System;

namespace AppLayer.Command
{
    public class RemoveSelectedCommand : Command
    {
        internal RemoveSelectedCommand() { }

        public override void Execute()
        {
            TargetDrawing?.DeleteAllSelected();
        }

        public override string ToString()
        {
            return "Remove" + Environment.NewLine;
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
