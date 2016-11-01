using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace AppLayerTesting
{
    [TestClass]
    public class MoveSelectedCommandTesting
    {
        [TestMethod]
        public void MoveSelectedCommand_Success()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());

            // Make sure new drawing is selected
            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "ghost", Location = new Point(100, 100), Size = new Size(80, 80), IsSelected = true }));

            Assert.AreEqual(1, drawing.GetImageCount());
            var image = drawing.GetSelected();
            Assert.IsNotNull(image);
            var prevLocation = image.Location;

            // Setup New Command
            var newCmd = commandFactory.Create("move", 300, 300);

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            drawing.ClearSelected();

            image = drawing.GetSelected();
            Assert.IsNull(drawing.GetSelected());
            commandFactory.Create("select", 300, 300).Execute();
            Assert.IsNotNull(drawing.GetSelected());
        
            image = drawing.GetSelected();
            Assert.AreNotEqual(image.Location.X, prevLocation.X);
            Assert.AreNotEqual(image.Location.Y, prevLocation.Y);
        }

        [TestMethod]
        public void MoveSelectedCommand_NoImage()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());
            // Setup New Command
            var newCmd = commandFactory.Create("move", 100, 100);

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.AreEqual(null, drawing.GetSelected());
        }


        [TestMethod]
        public void MoveSelectedCommand_NoDrawing()
        {
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = null };

            Command newCmd = commandFactory.Create("move", 100, 100);
            Assert.IsNotNull(newCmd);
            newCmd.Execute();
            // This didn't throw an exception, then it worked as expected
        }
    }
}
