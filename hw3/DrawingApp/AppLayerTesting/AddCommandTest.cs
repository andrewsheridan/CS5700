using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace AppLayerTesting
{
    [TestClass]
    public class AddCommandTest
    {
        [TestMethod]
        public void AddCommand_EmptyDrawing()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };
            
            Assert.AreEqual(0, drawing.GetImageCount());

            // setup a New command
            Command newCmd = commandFactory.Create("add", "bat", 100, 100);
            Assert.IsNotNull(newCmd);

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.AreEqual(1, drawing.GetImageCount());

            Command newCmd2 = commandFactory.Create("add", "witch", 50, 100);
            Command newCmd3 = commandFactory.Create("add", "lantern", 100, 100);
            Command newCmd4 = commandFactory.Create("add", "ghost", 50, 50);
            Command newCmd5 = commandFactory.Create("add", "cat", 100, 100);
            Command newCmd6 = commandFactory.Create("add", "spider", 100, 100);

            newCmd2.Execute();
            newCmd3.Execute();
            newCmd4.Execute();
            newCmd5.Execute();
            newCmd6.Execute();

            Assert.AreEqual(6, drawing.GetImageCount());
        }

        
        [TestMethod]
        public void AddCommand_NoDrawing()
        {
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = null };

            Command newCmd = commandFactory.Create("add");
            Assert.IsNotNull(newCmd);
            newCmd.Execute();
            // This didn't throw an exception, then it worked as expected
        }
    }
}
