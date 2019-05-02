using BillOfMaterials.Core;
using BillOfMaterials.Core.Infrastructure;
using System;

namespace BillOfMaterials.View
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log.Debug("Before Generate");
            IWidgetsGenerator widgetsGenerator = new WidgetsGenerator();
            var result = widgetsGenerator.Generate(GetConfiguration());
            Logger.Log.Debug("After Generate");

            Console.Write(result);
            Console.ReadKey();
        }

        private static Configuration GetConfiguration()
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