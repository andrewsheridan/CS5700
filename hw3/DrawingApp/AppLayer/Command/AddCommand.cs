using System;
using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class AddCommand : Command
    {
        private const int NormalWidth = 80;
        private const int NormalHeight = 80;

        private readonly string _imageType;
        private Point _location;
        private readonly float _scale;
        internal AddCommand() { }

        /// <summary>
        /// Constructor
        /// 
        /// </summary>
        /// <param name="commandParameters">An array of parameters, where
        ///     [1]: string     image type -- a fully qualified resource name
        ///     [2]: Point      center location for the image, defaut = top left corner
        ///     [3]: float      scale factor</param>
        internal AddCommand(params object[] commandParameters)
        {
            if (commandParameters.Length>0)
                _imageType = commandParameters[0] as string;

            if (commandParameters.Length > 1)
                _location = (Point) commandParameters[1];
            else
                _location = new Point(0, 0);

            if (commandParameters.Length > 2)
                _scale = (float) commandParameters[2];
            else
                _scale = 1.0F;
        }

        public override void Execute()
        {
            if (string.IsNullOrWhiteSpace(_imageType) || TargetDrawing==null) return;

            Size imageSize = new Size()
            {
                Width = Convert.ToInt16(Math.Round(NormalWidth * _scale, 0)),
                Height = Convert.ToInt16(Math.Round(NormalHeight * _scale, 0))
            };
            Point imageLocation = new Point(_location.X - imageSize.Width / 2, _location.Y - imageSize.Height / 2);

            ImageExtrinsicState extrinsicState = new ImageExtrinsicState()
            {
                ImageType = _imageType,
                Location = imageLocation,
                Size = imageSize
            };
            var image = TargetDrawing.Factory.GetImage(extrinsicState);
            TargetDrawing.Add(image);
        }
    }
}
