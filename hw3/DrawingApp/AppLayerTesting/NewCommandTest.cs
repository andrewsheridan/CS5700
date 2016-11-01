using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace AppLayerTesting
{
    [TestClass]
    public class NewCommandTester
    {
        [TestMethod]
        public void NewCommand_NonEmptyDrawing()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            ImageExtrinsicState image1 = new ImageExtrinsicState() { ImageType = "bat", Location = new Point(10, 10), Size = new Size(80, 80) };
            drawing.Add(drawing.Factory.GetImage(image1));
            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "cat", Location = new Point(200, 310), Size = new Size(80, 80) }));
            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "ghost", Location = new Point(240, 150), Size = new Size(80, 80) }));
            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "lantern", Location = new Point(350, 300), Size = new Size(80, 80) }));
            Assert.AreEqual(4, drawing.GetImageCount());

            // setup a New command
            Command newCmd = commandFactory.Create("new");
            Assert.IsNotNull(newCmd);

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.AreEqual(0, drawing.GetImageCount());
        }

        [TestMethod]
        public void NewCommand_EmptyDrawing()
        {
            Drawing drawing = new Drawing(new Size(600, 600));
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());

            Command newCmd = commandFactory.Create("new");
            Assert.IsNotNull(newCmd);
            newCmd.Execute();
            Assert.AreEqual(0, drawing.GetImageCount());

        }

        [TestMethod]
        public void NewCommand_NoDrawing()
        {
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = null };

            Command newCmd = commandFactory.Create("new");
            Assert.IsNotNull(newCmd);
            newCmd.Execute();
            // This didn't throw an exception, then it worked as expected
        }
    }
}
