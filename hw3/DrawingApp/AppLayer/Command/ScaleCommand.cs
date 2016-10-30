using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    public class ScaleCommand : Command
    {
        private readonly int _scale;
        internal ScaleCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
            {
                float newSize = 80 * (float)commandParameters[0];
                _scale = (int)System.Convert.ToInt32(newSize);
            }

        }
        public override void Execute()
        {
            TargetDrawing.ResizeSelected(_scale);
        }

    }
}
