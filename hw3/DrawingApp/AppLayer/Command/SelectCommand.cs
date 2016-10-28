using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class SelectCommand : Command
    {
        private readonly Point _location;
        
        internal SelectCommand(params object[] commandParameters)
        {
            if (commandParameters.Length>0)
                _location = (Point) commandParameters[0];
        }

        public override void Execute()
        {
            var image = TargetDrawing?.FindImageAtPosition(_location);
            if (image != null)
            {
                image.IsSelected = !image.IsSelected;
                TargetDrawing.IsDirty = true;
            }
        }
    }
}
