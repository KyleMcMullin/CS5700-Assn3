using System.Drawing;

namespace UnitTests
{
    [TestClass]
    public class TestCommandFactory
    {            
        private CommandFactory _commandFactory;
        private Drawing _drawing;
        private Invoker _invoker;

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

            // Act
            _commandFactory.CreateAndDo(commandType);

            // Assert
            Assert.AreEqual(1, _invoker.CommandCount);
        }

        [TestMethod]
        public void TestCreateAndDo_AddEmoteCommand()
        {
            // Arrange
            string commandType = "ADDEMOTE";
            object[] commandParameters = new object[] { typeof(CommandFactoryTests), "resourceName", new Point(0, 0), 1.0f };

            // Act
            _commandFactory.CreateAndDo(commandType, commandParameters);

            // Assert
            Assert.AreEqual(1, _invoker.CommandCount);
        }

        [TestMethod]
        public void TestCreateAndDo_AddBoxCommand()
        {
            // Arrange
            string commandType = "ADDBOX";
            object[] commandParameters = new object[] { new Point(0, 0), new Size(100, 100), Color.Black, Color.White };

            // Act
            _commandFactory.CreateAndDo(commandType, commandParameters);

            // Assert
            Assert.AreEqual(1, _invoker.CommandCount);
        }

        [TestMethod]
        public void TestCreateAndDo_AddLineCommand()
        {
            // Arrange
            string commandType = "ADDLINE";
            object[] commandParameters = new object[] { new Point(0, 0), new Point(100, 100), Color.Black, 5.0f };

            // Act
            _commandFactory.CreateAndDo(commandType, commandParameters);

            // Assert
            Assert.AreEqual(1, _invoker.CommandCount);
        }

        [TestMethod]
        public void TestCreateAndDo_RemoveSelectedCommand()
        {
            // Arrange
            string commandType = "REMOVE";

            // Act
            _commandFactory.CreateAndDo(commandType);

            // Assert
            Assert.AreEqual(1, _invoker.CommandCount);
        }

        [TestMethod]
        public void TestCreateAndDo_UpdateBackgroundCommand()
        {
            // Arrange
            string commandType = "UPDATEBACKGROUND";
            object[] commandParameters = new object[] { Color.White };

            // Act
            _commandFactory.CreateAndDo(commandType, commandParameters);

            // Assert
            Assert.AreEqual(1, _invoker.CommandCount);
        }

        [TestMethod]
        public void TestCreateAndDo_SelectCommand()
        {
            // Arrange
            string commandType = "SELECT";
            object[] commandParameters = new object[] { new Point(0, 0) };

            // Act
            _commandFactory.CreateAndDo(commandType, commandParameters);

            // Assert
            Assert.AreEqual(1, _invoker.CommandCount);
        }

        [TestMethod]
        public void TestCreateAndDo_DeselectAllCommand()
        {
            // Arrange
            string commandType = "DESELECT";

            // Act
            _commandFactory.CreateAndDo(commandType);

            // Assert
            Assert.AreEqual(1, _
    }
}