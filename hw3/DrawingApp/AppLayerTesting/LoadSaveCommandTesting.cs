﻿using System;
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
        public void SaveLoadCommand_NoImages()
        {
            // Setup a drawing
            ImageFactory imageFactory = new ImageFactory() { ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester) };
            Drawing drawing = new AppLayer.DrawingComponents.Drawing(new Size(600, 600));
            drawing.Factory = imageFactory;
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

            Assert.AreEqual(0, drawing.GetImageCount());

            // Setup New Command
            var newCmd = commandFactory.Create("save", "loadSaveTest.json");

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            // Assert the predicated results
            Assert.IsTrue(System.IO.File.Exists("loadSaveTest.json"));

            newCmd = commandFactory.Create("load", "loadSaveTest.json");

            // Stimulate (Execute newCmd.Execute)
            newCmd.Execute();

            Assert.AreEqual(0, drawing.GetImageCount());
        }

        [TestMethod]
        public void SaveCommand_NoDrawing()
        {
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = null };

            Command newCmd = commandFactory.Create("save", "failedTest.json");
            Assert.IsNotNull(newCmd);
            newCmd.Execute();
            // This didn't throw an exception, then it worked as expected
        }
        [TestMethod]
        public void LoadCommand_NoFile()
        {
            CommandFactory commandFactory = new CommandFactory() { TargetDrawing = null };

            Command newCmd = commandFactory.Create("load", "DOESNTEXIST.json");
            Assert.IsNotNull(newCmd);
            newCmd.Execute();
            // This didn't throw an exception, then it worked as expected
        }
    }
}
