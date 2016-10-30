using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    public class MoveSelectedCommand : Command
    {
        internal MoveSelectedCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
            {
                
            }

        }
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
