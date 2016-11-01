using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace AppLayerTesting
{
    [TestClass]
    public class CopyCommandTest
    {
        [TestMethod]
        public void CopyCommand_Success()
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
            
            // Setup New Command
            var newCmd = commandFactory.Create("copy");

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.AreEqual(2, drawing.GetImageCount());
        }

        [TestMethod]
        public void CopyCommand_NoImageSelected()
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
     
            // Setup New Command
            var newCmd = commandFactory.Create("copy");

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.AreEqual(1, drawing.GetImageCount());
        }

        [TestMethod]
        public void CopyCommand_NoImage()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());

            // Setup New Command
            var newCmd = commandFactory.Create("copy");

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.AreEqual(0, drawing.GetImageCount());
        }

        [TestMethod]
        public void CopyCommand_NoDrawing()
        {
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = null };

            Command newCmd = commandFactory.Create("copy");
            Assert.IsNotNull(newCmd);
            newCmd.Execute();
            // This didn't throw an exception, then it worked as expected
        }
    }
}
