using System;
using System.Collections.Generic;

namespace AppLayer.DrawingComponents
{
    public class ImageFactory
    {
        public string ResourceNamePattern { get; set; }
        public Type ReferenceType { get; set; }

        private readonly Dictionary<string, ImageWithIntrinsicState> _sharedImages = new Dictionary<string, ImageWithIntrinsicState>();

        public ImageWithAllState GetImage(ImageExtrinsicState extrinsicState)
        {
            string resourceName = string.Format(ResourceNamePattern, extrinsicState.ImageType);

            ImageWithIntrinsicState imageWithIntrinsicState;
            if (_sharedImages.ContainsKey(extrinsicState.ImageType))
                imageWithIntrinsicState = _sharedImages[extrinsicState.ImageType];
            else
            {
                imageWithIntrinsicState = new ImageWithIntrinsicState();
                imageWithIntrinsicState.LoadFromResource(resourceName, ReferenceType);
                _sharedImages.Add(extrinsicState.ImageType, imageWithIntrinsicState);
            }

            return new ImageWithAllState(imageWithIntrinsicState, extrinsicState);
        }
    }
}
