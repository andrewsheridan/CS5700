using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace AppLayerTesting
{
    [TestClass]
    public class SelectCommandTesting
    {
        [TestMethod]
        public void SelectCommand_Success()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());

            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "cat", Location = new Point(200, 200), Size = new Size(80, 80)}));
            Assert.AreEqual(1, drawing.GetImageCount());
            Assert.IsNull(drawing.GetSelected());

            // Setup New Command
            var newCmd = commandFactory.Create("select", 200, 200);

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.IsNotNull(drawing.GetSelected());
        }

        [TestMethod]
        public void ScaleCommand_NoImageHere()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());

            drawing.Add(drawing.Factory.GetImage(new ImageExtrinsicState() { ImageType = "cat", Location = new Point(100, 100), Size = new Size(80, 80) }));
            Assert.AreEqual(1, drawing.GetImageCount());
            Assert.IsNull(drawing.GetSelected());

            // Setup New Command
            var newCmd = commandFactory.Create("select", 400, 400);

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.IsNull(drawing.GetSelected());
        }

        [TestMethod]
        public void ScaleCommand_NoImage()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());
            Assert.IsNull(drawing.GetSelected());

            // Setup New Command
            var newCmd = commandFactory.Create("select", 400, 400);

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.IsNull(drawing.GetSelected());
        }

        [TestMethod]
        public void ScaleCommand_NoDrawing()
        {
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = null };

            Command newCmd = commandFactory.Create("select", 100, 100);
            Assert.IsNotNull(newCmd);
            newCmd.Execute();
            // This didn't throw an exception, then it worked as expected
        }
    }
}
