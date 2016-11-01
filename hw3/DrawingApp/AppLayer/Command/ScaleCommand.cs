using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    public class ScaleCommand : Command
    {
        private readonly int _newSize;
        private System.Drawing.Size _oldSize;
        internal ScaleCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
            {
                double size = AddCommand.NormalHeight * Convert.ToDouble(commandParameters[0]);
                _newSize = Convert.ToUInt16(size);
            }

        }
        public override void Execute()
        {
            var image = TargetDrawing?.GetSelected();
            if (image != null) {
                _oldSize = image.Size;
                TargetDrawing.ResizeSelected(_newSize);
            }
        }

        public override string ToString()
        {
            return $"scale {_newSize}" + Environment.NewLine;
        }

        public override void Undo()
        {
            var image = TargetDrawing?.GetSelected();
            if(image != null)
            {
                image.Size = _oldSize;
            }
        }
    }
}
