using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    //Todo: Make so this only works for one image at a time.
    public class MoveSelectedCommand : Command
    {
        private readonly int _newX;
        private readonly int _newY;
        private readonly int _oldX;
        private readonly int _oldY;
        internal MoveSelectedCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
            {
                _newX = (int)commandParameters[0];
                _newY = (int)commandParameters[1];
            }
        }
        public override void Execute()
        {
            TargetDrawing.MoveSelected(_newX, _newY);
        }

        public override string ToString() //TODO: Update to output the old X and Y coordinates as well.
        {
            return $"move {_newX} {_newY}" + Environment.NewLine;
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
