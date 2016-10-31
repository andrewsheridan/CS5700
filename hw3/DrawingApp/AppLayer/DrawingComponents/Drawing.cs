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

        private System.Drawing.Image BackgroundImage { get; set; }

        private readonly Size _size;

        public enum BackgroundType { blank, graveyard, hauntedHouse };
        private Dictionary<BackgroundType, string> backgroundDictionary; 

        public Drawing(Size size)
        {
            backgroundDictionary = new Dictionary<BackgroundType, string>();
            backgroundDictionary.Add(BackgroundType.graveyard, "graveyard.jpg");
            backgroundDictionary.Add(BackgroundType.hauntedHouse, "hauntedHouse.png");
            backgroundDictionary.Add(BackgroundType.blank, null);
            _size = size;
        }

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
                    if(BackgroundImage != null)
                        graphics.DrawImage(BackgroundImage, 0, 0, _size.Width, _size.Height);

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

        public void CopySelected()
        {
            lock (_myLock)
            {
                List<ImageWithAllState> newImages = new List<ImageWithAllState>();
                foreach (ImageWithAllState i in _images)
                {
                    if (i.IsSelected)
                    {
                        ImageExtrinsicState extrinsic = new ImageExtrinsicState();
                        extrinsic.ImageType = i.ExtrinsicStatic.ImageType;
                        extrinsic.Location = new Point(i.Location.X + i.Size.Width, i.Location.Y + i.Size.Height);
                        extrinsic.Size = i.Size;
                        extrinsic.IsSelected = true;
                        newImages.Add(Factory.GetImage(extrinsic));
                        i.IsSelected = false;
                    }
                }
                _images.AddRange(newImages);
                IsDirty = true;
            }
        }

        public List<ImageWithAllState> GetAllSelected()
        {
            List<ImageWithAllState> returnImages = new List<ImageWithAllState>();
            foreach (ImageWithAllState i in _images)
            {
                if (i.IsSelected)
                {
                    returnImages.Add(i);
                }
            }
            return returnImages;
        }

        public ImageWithAllState GetSelected()
        {
            foreach (ImageWithAllState i in _images)
            {
                if (i.IsSelected)
                {
                    return i;
                }
            }
            return null;
        }

        public void RemoveLast()
        {
            lock (_myLock)
            {
                if (_images.Count > 0)
                {
                    _images.RemoveAt(_images.Count - 1);
                    IsDirty = true;
                }
            }
        }

        public void SetBackground(BackgroundType bt)
        {
            string backgroundResource;
            backgroundDictionary.TryGetValue(bt, out backgroundResource);
            string filename = backgroundResource != null ? System.Environment.CurrentDirectory + $"\\..\\..\\Graphics\\{backgroundResource}" : null;

            lock (_myLock)
            {
                BackgroundImage = filename != null ? System.Drawing.Image.FromFile(filename) : null;
                IsDirty = true;
            }
        }
    }
}
