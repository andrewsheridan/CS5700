using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace AppLayerTesting
{
    [TestClass]
    public class ScaleCommandTesting
    {
        [TestMethod]
        public void ScaleCommand_SelectedImage()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());

            Size size = new Size(80, 80);

            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "cat", Location = new Point(200, 310), Size = size, IsSelected = true }));

            // Setup New Command
            var newCmd = commandFactory.Create("scale", 2);

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            var image = drawing.GetSelected();
            var expectedSize = new Size(size.Width * 2, size.Height * 2);
            Assert.AreEqual(expectedSize.Width, image.Size.Width);
            Assert.AreEqual(expectedSize.Height, image.Size.Height);
        }

        [TestMethod]
        public void ScaleCommand_NoSelectedImage()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());

            Size size = new Size(80, 80);

            //Image is not selected
            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "cat", Location = new Point(200, 200), Size = size, IsSelected = false }));

            // Setup New Command
            var newCmd = commandFactory.Create("scale", 2);

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            commandFactory.Create("select", 200, 200).Execute() ;
            // Assert the predicated results
            var image = drawing.GetSelected();
            Assert.AreEqual(size.Width, image.Size.Width);
            Assert.AreEqual(size.Height, image.Size.Height);
        }


        [TestMethod]
        public void ScaleCommand_NoDrawing()
        {
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = null };

            Command newCmd = commandFactory.Create("scale", 2.0);
            Assert.IsNotNull(newCmd);
            newCmd.Execute();
            // This didn't throw an exception, then it worked as expected
        }
    }
}
