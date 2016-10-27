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

            ImageWithIntrinsicState treeWithIntrinsicState;
            if (_sharedImages.ContainsKey(extrinsicState.ImageType))
                treeWithIntrinsicState = _sharedImages[extrinsicState.ImageType];
            else
            {
                treeWithIntrinsicState = new ImageWithIntrinsicState();
                treeWithIntrinsicState.LoadFromResource(resourceName, ReferenceType);
                _sharedImages.Add(extrinsicState.ImageType, treeWithIntrinsicState);
            }

            return new ImageWithAllState(treeWithIntrinsicState, extrinsicState);
        }
    }
}
