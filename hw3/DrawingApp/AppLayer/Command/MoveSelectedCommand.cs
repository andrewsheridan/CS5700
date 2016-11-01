using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    public class MoveSelectedCommand : Command
    {
        private readonly int _newX;
        private readonly int _newY;
        private int _oldX;
        private int _oldY;
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
            var image = TargetDrawing?.GetSelected();
            if(image != null)
            {
                _oldX = image.Location.X + image.Size.Width / 2;
                _oldY = image.Location.Y + image.Size.Height / 2;
                TargetDrawing.MoveSelected(_newX, _newY);
            }
        }

        public override string ToString()
        {
            return $"move {_newX} {_newY}" + Environment.NewLine;
        }

        public override void Undo()
        {
            if(_oldX != 0 && _oldY != 0)
                TargetDrawing.MoveSelected(_oldX, _oldY);
        }
    }
}
