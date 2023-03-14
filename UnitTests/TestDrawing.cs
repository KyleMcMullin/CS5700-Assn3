using AppLayer.Command;
using AppLayer.DrawingComponents;
using System.Drawing;

namespace UnitTests
{
    [TestClass]
    public class TestDrawing
    {
        private static Drawing drawing;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            drawing = new Drawing();
        }

        [TestMethod]
        public void TestClear()
        {
            var line = new Line();
            line.Start = new Point(0, 1);
            line.End = new Point(5, 5);
            drawing.ChangeBackground(Color.White.ToArgb());            
            drawing.Add(line);
            drawing.Clear();
            Assert.AreEqual(0, drawing.GetCloneOfElements().Count);
        }

        [TestMethod]
        public void TestChangeBackground()
        {
            drawing.ChangeBackground(Color.Red.ToArgb());
            Assert.AreEqual(Color.Red.ToArgb(), drawing.GetCurrentColor());
        }

        [TestMethod]
        public void TestAdd()
        {
            drawing.Clear();
            var line = new Line();
            line.Start = new Point(0, 1);
            line.End = new Point(5, 5);
            drawing.Add(line);
            Assert.AreEqual(1, drawing.GetCloneOfElements().Count);
            var testLine = drawing.GetCloneOfElements()[0] as Line;
            Assert.AreEqual(line.Start, testLine.Start);
            Assert.AreEqual(line.End, testLine.End);
        }

        [TestMethod]
        public void TestCopy()
        {
            drawing.Clear();
            var line = new Line();
            line.Start = new Point(0, 1);
            line.End = new Point(5, 5);
            drawing.Copy(line);
            Assert.AreEqual(1, drawing.GetCloneOfElements().Count);
            var tempLine = drawing.GetCloneOfElements()[0] as Line;
            Assert.AreEqual(line.Start, tempLine.Start);
            Assert.AreEqual(line.End, tempLine.End);
        }

        [TestMethod]
        public void TestDeleteAllSelected()
        {
            drawing.Clear();
            var line = new Line();
            line.Start = new Point(0, 1);
            line.End = new Point(5, 5);
            var labeledBox = new LabeledBox();
            labeledBox.Label = "label";
            labeledBox.Corner = new Point(0, 1);
            labeledBox.Size = new Size(1, 1);
            drawing.Add(line);
            drawing.Add(labeledBox);
            line.IsSelected = true;
            labeledBox.IsSelected = true;
            var deletedElements = drawing.DeleteAllSelected();
            Assert.AreEqual(2, deletedElements.Count);
            Assert.AreEqual(0, drawing.GetCloneOfElements().Count);
        }
    }
}