using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace AppLayerTesting
{
    [TestClass]
    public class LoadSaveCommandTesting
    {
        [TestMethod]
        public void SaveCommand_Success()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());
            
            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "ghost", Location = new Point(100, 100), Size = new Size(80, 80), IsSelected = true }));
            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "bat", Location = new Point(200, 200), Size = new Size(80, 80), IsSelected = false }));

            Assert.AreEqual(2, drawing.GetImageCount());

            // Setup New Command
            var newCmd = commandFactory.Create("save", "testing.json");

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.IsTrue(System.IO.File.Exists("testing.json"));
        }

        [TestMethod]
        public void LoadCommand_Success()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());
            
            // Setup New Command
            var newCmd = commandFactory.Create("load", "testing.json");

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            Assert.AreEqual(2, drawing.GetImageCount());
        }

        [TestMethod]
        public void DeselectCommand_NoImageSelected()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };
            Assert.AreEqual(0, drawing.GetImageCount());

            // Make sure new drawing is not selected
            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "ghost", Location = new Point(100, 100), Size = new Size(80, 80), IsSelected = false }));
            Assert.AreEqual(1, drawing.GetImageCount());
            Assert.AreEqual(null, drawing.GetSelected());
            // Setup New Command
            var newCmd = commandFactory.Create("deselect");

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.AreEqual(null, drawing.GetSelected());
        }

        [TestMethod]
        public void DeselectCommand_NoImage()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());
            Assert.AreEqual(null, drawing.GetSelected());
            // Setup New Command
            var newCmd = commandFactory.Create("deselect");

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.AreEqual(null, drawing.GetSelected());
        }

        [TestMethod]
        public void DeselectComand_NoDrawing()
        {
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = null };

            Command newCmd = commandFactory.Create("deselect");
            Assert.IsNotNull(newCmd);
            newCmd.Execute();
            // This didn't throw an exception, then it worked as expected
        }
    }
}
