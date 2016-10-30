using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    public class CopyCommand : Command
    {
        internal CopyCommand(params object[] commandParameters)
        {

        }
        public override void Execute()
        {
            TargetDrawing.CopySelected();
        }
    }
}
