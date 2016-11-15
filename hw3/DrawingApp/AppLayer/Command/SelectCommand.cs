using System;
using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class SelectCommand : Command
    {
        private readonly Point _location;
        private Point _prevLocation;
        
        internal SelectCommand(params object[] commandParameters)
        {
            if (commandParameters.Length>1)
                _location = new Point((int)commandParameters[0], (int)commandParameters[1]);
        }

        public override void Execute()
        {
            var image = TargetDrawing?.FindImageAtPosition(_location);
            var prevImage = TargetDrawing?.GetSelected();
            if (prevImage != null)
                _prevLocation = prevImage.Location;
            
            TargetDrawing?.ClearSelected();
            if (image != null)
            {
                image.IsSelected = !image.IsSelected;
                TargetDrawing.IsDirty = true;
            }
        }

        public override string ToString()
        {
            return $"select {_location.X} {_location.Y}" + Environment.NewLine;
        }

        public override void Undo()
        {
            TargetDrawing?.ClearSelected();
            if(_prevLocation.X != 0 && _prevLocation.Y != 0)
            {
                TargetDrawing.FindImageAtPosition(_prevLocation).IsSelected = true;
                TargetDrawing.IsDirty = true;
            }
        }
    }
}
