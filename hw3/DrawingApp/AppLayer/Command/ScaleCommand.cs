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
        private System.Drawing.Size _oldSize;
        internal ScaleCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
            {
                float newSize = AddCommand.NormalHeight * (float)commandParameters[0];
                _scale = (int)System.Convert.ToInt32(newSize);
            }

        }
        public override void Execute()
        {
            var image = TargetDrawing?.GetSelected();
            if (image != null) {
                _oldSize = image.Size;
            }
            TargetDrawing.ResizeSelected(_scale);
        }

        public override string ToString()
        {
            return $"scale {_scale}" + Environment.NewLine;
        }

        public override void Undo()
        {
            var image = TargetDrawing.GetSelected();
            if(image != null)
            {
                image.Size = _oldSize;
            }
        }
    }
}
