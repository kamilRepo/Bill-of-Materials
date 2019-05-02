using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillOfMaterials.Core;
using BillOfMaterials.Core.Infrastructure;

namespace BillOfMaterials.Tests
{
    [TestClass]
    public class WidgetsGeneratorTests
    {
        [TestMethod]
        public void GeneratedResult_FullConfiguration_CorrectResult()
        {
            //Preparation
            // In Real app with unit tests we can mock
            StringBuilder expectedResult = new StringBuilder();
            expectedResult = expectedResult.AppendLine("----------------------------------------------------------------");
            expectedResult = expectedResult.AppendLine("Bill of Materials");
            expectedResult = expectedResult.AppendLine("----------------------------------------------------------------");
            expectedResult = expectedResult.AppendLine("Rectangle (10,10) width=30 height=40");
            expectedResult = expectedResult.AppendLine("Square(15,30) size = 35");
            expectedResult = expectedResult.AppendLine("Ellipse(100,150) diameterH = 300 diameterV = 200");
            expectedResult = expectedResult.AppendLine("Circle(1,1) size = 300");
            expectedResult = expectedResult.AppendLine("Textbox(5,5) width = 200 height = 100 text = \"sample text\"");
            expectedResult = expectedResult.Append("----------------------------------------------------------------");
            Configuration conf = GetConfiguration();

            //Action
            IWidgetsGenerator widgetsGenerator = new WidgetsGenerator();
            var result = widgetsGenerator.Generate(conf);

            //Assertions
            Assert.AreEqual(expectedResult.ToString(), result);
        }

        [TestMethod]
        public void GeneratedResult_TextboxNonText_CorrectResult()
        {
            //Preparation
            // In Real app with unit tests we can mock
            StringBuilder expectedResult = new StringBuilder();
            expectedResult = expectedResult.AppendLine("----------------------------------------------------------------");
            expectedResult = expectedResult.AppendLine("Bill of Materials");
            expectedResult = expectedResult.AppendLine("----------------------------------------------------------------");
            expectedResult = expectedResult.AppendLine("Rectangle (10,10) width=30 height=40");
            expectedResult = expectedResult.AppendLine("Square(15,30) size = 35");
            expectedResult = expectedResult.AppendLine("Ellipse(100,150) diameterH = 300 diameterV = 200");
            expectedResult = expectedResult.AppendLine("Circle(1,1) size = 300");
            expectedResult = expectedResult.AppendLine("Textbox(5,5) width = 200 height = 100");
            expectedResult = expectedResult.Append("----------------------------------------------------------------");
            Configuration conf = GetConfiguration();
            conf.Textbox.IsText = false;

            //Action
            IWidgetsGenerator widgetsGenerator = new WidgetsGenerator();
            var result = widgetsGenerator.Generate(conf);

            //Assertions
            Assert.AreEqual(expectedResult.ToString(), result);
        }

        [TestMethod]
        public void GeneratedResult_TooLongText_AbortResult()
        {
            //Preparation
            // In Real app with unit tests we can mock
            var expectedResult = "+++++Abort+++++";
            Configuration conf = GetConfiguration();
            conf.Textbox.Text = "a";
            for (int i = 0; i < 1000; i++)
                conf.Textbox.Text += "a";

            //Action
            IWidgetsGenerator widgetsGenerator = new WidgetsGenerator();
            var result = widgetsGenerator.Generate(conf);

            //Assertions
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GeneratedResult_TextboxNotSet_AbortResult()
        {
            //Preparation
            // In Real app with unit tests we can mock
            var expectedResult = "+++++Abort+++++";
            Configuration conf = GetConfiguration();
            conf.Textbox = null;

            //Action
            IWidgetsGenerator widgetsGenerator = new WidgetsGenerator();
            var result = widgetsGenerator.Generate(conf);

            //Assertions
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GeneratedResult_WrongValue_AbortResult()
        {
            //Preparation
            // In Real app with unit tests we can mock
            var expectedResult = "+++++Abort+++++";
            Configuration conf = GetConfiguration();
            conf.Textbox.PositionX = -10;

            //Action
            IWidgetsGenerator widgetsGenerator = new WidgetsGenerator();
            var result = widgetsGenerator.Generate(conf);

            //Assertions
            Assert.AreEqual(expectedResult, result);
        }

        private Configuration GetConfiguration()
        {
            RectangleWidget rectangle = new RectangleWidget()
            {
                PositionX = 10,
                PositionY = 10,
                Width = 30,
                Height = 40,
                IsRequired = true
            };

            SquareWidget square = new SquareWidget()
            {
                PositionX = 15,
                PositionY = 30,
                Width = 35,
                IsRequired = true
            };

            EllipseWidget ellipse = new EllipseWidget()
            {
                PositionX = 100,
                PositionY = 150,
                HorizontalDiameter = 300,
                VerticalDiameter = 200,
                IsRequired = true
            };

            CircleWidget circle = new CircleWidget()
            {
                PositionX = 1,
                PositionY = 1,
                Diameter = 300,
                IsRequired = true
            };

            TextboxWidget textbox = new TextboxWidget()
            {
                PositionX = 5,
                PositionY = 5,
                Width = 200,
                Height = 100,
                Text = "sample text",
                IsText = true,
                IsRequired = true
            };

            var conf = new Configuration()
            {
                Title = "Bill of Materials",
                Rectangle = rectangle,
                Square = square,
                Ellipse = ellipse,
                Circle = circle,
                Textbox = textbox
            };

            return conf;
        }
    }
}