using AppLayer.Command;
using AppLayer.DrawingComponents;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class TestCommandsAndFactory
    {
        private CommandFactory _commandFactory;
        private Drawing _drawing;
        private Invoker _invoker;
        private EmoteFactory _emoteFactory;

        [TestInitialize]
        public void Setup()
        {
            _commandFactory = CommandFactory.Instance;
            _drawing = new Drawing();
            _invoker = new Invoker();
            _commandFactory.TargetDrawing = _drawing;
            _commandFactory.Invoker = _invoker;
        }

        [TestMethod]
        public void TestCreateAndDo_NewCommand()
        {
            // Arrange
            string commandType = "NEW";
            _drawing.ChangeBackground(1);

            // Act
            _commandFactory.CreateAndDo(commandType);
            _invoker.Start();
            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.AreEqual(0, _drawing.GetCloneOfElements().Count);
            Assert.AreEqual(-1, _drawing.GetCurrentColor());
        }

        [TestMethod]
        public void TestCreateAndDo_AddBoxCommand()
        {
            // Arrange
            string commandType = "ADDBOX";
            object[] commandParameters = new object[] { "label", new Point(0, 0), new Size(100, 100) };

            // Act
            _commandFactory.CreateAndDo(commandType, commandParameters);
            _invoker.Start();
            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.AreEqual(1, _drawing.GetCloneOfElements().Count);
        }

        [TestMethod]
        public void TestCreateAndDo_AddLineCommand()
        {
            // Arrange
            string commandType = "ADDLINE";
            object[] commandParameters = new object[] { new Point(0, 0), new Point(100, 100), Color.Black, 5.0f };
            
            // Act
            _commandFactory.CreateAndDo(commandType, commandParameters);
            _invoker.Start();
            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.AreEqual(1, _drawing.GetCloneOfElements().Count);
        }

        [TestMethod]
        public void TestCreateAndDo_RemoveSelectedCommand()
        {
            // Arrange
            string commandType = "REMOVE";
            _commandFactory.CreateAndDo("ADDLINE", new object[] { new Point(0, 0), new Point(100, 100), Color.Black, 5.0f });
            _invoker.Start();
            System.Threading.Thread.Sleep(100);
            _drawing.FindElementAtPosition(new Point(0, 0)).IsSelected = true;

            // Act
            _commandFactory.CreateAndDo(commandType);
            _invoker.Start();
            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.AreEqual(0, _drawing.GetCloneOfElements().Count);
        }

        [TestMethod]
        public void TestCreateAndDo_UpdateBackgroundCommand()
        {
            // Arrange
            string commandType = "UPDATEBACKGROUND";
            object[] commandParameters = new object[] { Color.Blue.ToArgb() };

            // Act
            _commandFactory.CreateAndDo(commandType, commandParameters);
            _invoker.Start();
            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.AreEqual(Color.Blue.ToArgb(), _drawing.GetCurrentColor());
        }

        [TestMethod]
        public void TestCreateAndDo_SelectCommand()
        {
            // Arrange
            string commandType = "SELECT";
            object[] commandParameters = new object[] { new Point(0, 0) };
            _commandFactory.CreateAndDo("ADDLINE", new object[] { new Point(0, 0), new Point(100, 100), Color.Black, 5.0f });
            _invoker.Start();
            System.Threading.Thread.Sleep(100);

            // Act
            _commandFactory.CreateAndDo(commandType, commandParameters);
            _invoker.Start();
            System.Threading.Thread.Sleep(100);
            

            // Assert
            Assert.AreEqual(1, _drawing.DeselectAll().Count);
        }

        [TestMethod]
        public void TestCreateAndDo_DeSelectCommand()
        {
            // Arrange
            string commandType = "DESELECT";
            object[] commandParameters = new object[] { new Point(0, 0) };
            _commandFactory.CreateAndDo("ADDLINE", new object[] { new Point(0, 0), new Point(100, 100), Color.Black, 5.0f });
            _invoker.Start();
            System.Threading.Thread.Sleep(100);

            _commandFactory.CreateAndDo("SELECT", new object[] { new Point(0, 0) });
            System.Threading.Thread.Sleep(100);

            // Act
            _commandFactory.CreateAndDo(commandType, commandParameters);
            _invoker.Start();
            System.Threading.Thread.Sleep(100);


            // Assert
            Assert.AreEqual(0, _drawing.DeselectAll().Count);
        }

        [TestMethod]
        public void TestUndo()
        {
            // Arrange
            _commandFactory.CreateAndDo("ADDLINE", new object[] { new Point(0, 0), new Point(100, 100), Color.Black, 5.0f });
            _invoker.Start();
            System.Threading.Thread.Sleep(100);

            // Act
            _invoker.Undo();
            _invoker.Start();
            System.Threading.Thread.Sleep(100);


            // Assert
            Assert.AreEqual(0, _drawing.GetCloneOfElements().Count);
        }

        [TestMethod]
        public void TestRedo()
        {
            // Arrange
            _commandFactory.CreateAndDo("ADDLINE", new object[] { new Point(0, 0), new Point(100, 100), Color.Black, 5.0f });
            _invoker.Start();
            System.Threading.Thread.Sleep(100);

            _invoker.Undo();
            _invoker.Start();
            System.Threading.Thread.Sleep(100);

            // Act
            _invoker.Redo();
            _invoker.Start();
            System.Threading.Thread.Sleep(100);


            // Assert
            Assert.AreEqual(1, _drawing.GetCloneOfElements().Count);
        }
    }
}
