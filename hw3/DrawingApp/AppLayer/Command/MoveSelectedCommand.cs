using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    public class MoveSelectedCommand : Command
    {
        private readonly int _newX;
        private readonly int _newY;
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
    }
}
