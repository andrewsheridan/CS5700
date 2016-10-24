﻿using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class ImageExtrinsicState
    {
        [DataMember]
        public string ImageType { get; set; }

        [DataMember]
        public Point Location { get; set; }

        [DataMember]
        public Size Size { get; set; }

        [DataMember]
        public bool IsSelected { get; set; }
    }
}
