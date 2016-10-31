using System;
using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class RemoveSelectedCommand : Command
    {
        private string _imageType;
        private int _x;
        private int _y;
        private Size _size;
        internal RemoveSelectedCommand() { }

        public override void Execute()
        {
            var image = TargetDrawing?.GetSelected();
            if (image != null)
            {
                _imageType = image.ExtrinsicStatic.ImageType;
                _x = image.ExtrinsicStatic.Location.X;
                _y = image.ExtrinsicStatic.Location.Y;
                _size = image.ExtrinsicStatic.Size;
            }
            TargetDrawing?.DeleteAllSelected();
        }

        public override string ToString()
        {
            return "Remove" + Environment.NewLine;
        }

        public override void Undo()
        {
            if (string.IsNullOrWhiteSpace(_imageType) || TargetDrawing == null) return;
            
            Point imageLocation = new Point(_x - _size.Width / 2, _y - _size.Height / 2);
            ImageExtrinsicState extrinsicState = new ImageExtrinsicState()
            {
                ImageType = _imageType,
                Location = imageLocation,
                Size = _size
            };
            var newImage = TargetDrawing.Factory.GetImage(extrinsicState);
            TargetDrawing.Add(newImage);
        }
    }
}
