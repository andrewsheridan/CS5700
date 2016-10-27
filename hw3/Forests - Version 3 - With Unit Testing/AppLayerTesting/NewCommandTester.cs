﻿using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace AppLayerTesting
{
    [TestClass]
    public class NewCommandTester
    {
        //[TestMethod]
        //public void NewCommand_NonEmptyDrawing()
        //{
        //    // Setup a drawing
        //    ImageFactory treefactory = new ImageFactory() {ResourceNamePattern = "AppLayerTesting.Graphics.{0}.png", ReferenceType = typeof(NewCommandTester)};
        //    Drawing drawing = new Drawing();
        //    CommandFactory commandFactory = new CommandFactory() {TargetDrawing = drawing};
        //    //drawing.Add(treefactory.GetTree(new ImageExtrinsicState() { TreeType = "Tree-01", Location = new Point(10,10), Size  = new Size(80, 80) }));
        //    //drawing.Add(treefactory.GetTree(new ImageExtrinsicState() { TreeType = "Tree-01", Location = new Point(200,310), Size = new Size(80, 80) }));
        //    //drawing.Add(treefactory.GetTree(new ImageExtrinsicState() { TreeType = "Tree-01", Location = new Point(240,150), Size = new Size(80, 80) }));
        //    //drawing.Add(treefactory.GetTree(new ImageExtrinsicState() { TreeType = "Tree-01", Location = new Point(350, 300), Size = new Size(80, 80) }));
        //    Assert.AreEqual(4, drawing.TreeCount);

        //    // setup a New command
        //    Command newCmd = commandFactory.Create("new");
        //    Assert.IsNotNull(newCmd);

        //    // Stimulate (Execute newCmd.Execute)
        //    newCmd.Execute();

        //    // Assert the predicated results
        //    Assert.AreEqual(0, drawing.TreeCount);            
        //}

        //[TestMethod]
        //public void NewCommand_EmptyDrawing()
        //{
        //    Drawing drawing = new Drawing();
        //    CommandFactory commandFactory = new CommandFactory() { TargetDrawing = drawing };

        //    Assert.AreEqual(0, drawing.TreeCount);

        //    Command newCmd = commandFactory.Create("new");
        //    Assert.IsNotNull(newCmd);
        //    newCmd.Execute();
        //    Assert.AreEqual(0, drawing.TreeCount);

        //}

        //[TestMethod]
        //public void NewCommand_NoDrawing()
        //{
        //    CommandFactory commandFactory = new CommandFactory() { TargetDrawing = null };

        //    Command newCmd = commandFactory.Create("new");
        //    Assert.IsNotNull(newCmd);
        //    newCmd.Execute();
        //    // This didn't throw an exception, then it worked as expected
        //}

    }
}
