using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Json;

namespace AppLayer.DrawingComponents
{
    public class Drawing
    {
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<ImageExtrinsicState>));

        private readonly List<Image> _images = new List<Image>();

        private readonly object _myLock = new object();

        public ImageFactory Factory { get; set; }
        public Image SelectedVar { get; set; }
        public bool IsDirty { get; set; }

        public void Clear()
        {
            lock (_myLock)
            {
                _images.Clear();
                IsDirty = true;
            }
        }

        public void Add(Image image)
        {
            if (image != null)
            {
                lock (_myLock)
                {
                    _images.Add(image);
                    IsDirty = true;
                }
            }
        }

        public void RemoveImage(Image image)
        {
            if (image != null)
            {
                lock (_myLock)
                {
                    if (SelectedVar == image)
                        SelectedVar = null;
                    _images.Remove(image);
                    IsDirty = true;
                }
            }
        }

        public Image FindImageAtPosition(Point location)
        {
            Image result;
            lock (_myLock)
            {
                result = _images.FindLast(t => location.X >= t.Location.X &&
                                              location.X < t.Location.X + t.Size.Width &&
                                              location.Y >= t.Location.Y &&
                                              location.Y < t.Location.Y + t.Size.Height);
            }
            return result;
        }

        public void DeselectAll()
        {
            lock (_myLock)
            {
                foreach (var t in _images)
                    t.IsSelected = false;
                IsDirty = true;
            }    
        }

        public void DeleteAllSelected()
        {
            lock (_myLock)
            {
                _images.RemoveAll(t => t.IsSelected);
                IsDirty = true;
            }
        }

        public bool Draw(Graphics graphics)
        {
            bool didARedraw = false;
            lock (_myLock)
            {
                if (IsDirty)
                {
                    graphics.Clear(Color.White);
                    foreach (var t in _images)
                        t.Draw(graphics);
                    IsDirty = false;
                    didARedraw = true;
                }
            }
            return didARedraw;
        }

        public void LoadFromStream(Stream stream)
        {
            var extrinsicStates = JsonSerializer.ReadObject(stream) as List<ImageExtrinsicState>;
            if (extrinsicStates == null) return;

            lock (_myLock)
            {
                _images.Clear();
                foreach (ImageExtrinsicState extrinsicState in extrinsicStates)
                {
                    Image image = Factory.GetImage(extrinsicState);
                    _images.Add(image);
                }
                IsDirty = true;
            }
        }

        public void SaveToStream(Stream stream)
        {
            List<ImageExtrinsicState> extrinsicStates = new List<ImageExtrinsicState>();
            lock (_myLock)
            {
                foreach (Image image in _images)
                {
                    ImageWithAllState t = image as ImageWithAllState;
                    if (t!=null)
                        extrinsicStates.Add(t.ExtrinsicStatic);                    
                }
            }
            JsonSerializer.WriteObject(stream, extrinsicStates);
        }

        public void ResizeSelected(int size)
        {
            lock (_myLock)
            {
                foreach (Image i in _images)
                {
                    if (i.IsSelected)
                        i.Size = new Size(size, size);
                }
                IsDirty = true;
            }
        }

        public void MoveSelected(int X, int Y)
        {
            lock (_myLock)
            {
                foreach (Image i in _images)
                {
                    if (i.IsSelected)
                    {
                        int newX = X - (i.Size.Width / 2);
                        int newY = Y - (i.Size.Height / 2);
                        i.Location = new Point(newX, newY);
                    }
                }
                IsDirty = true;
            }
        }

        public void ClearSelected()
        {
            lock (_myLock)
            {
                foreach (Image i in _images)
                {
                    i.IsSelected = false;
                }
                IsDirty = true;
            }
        }
    }
}
