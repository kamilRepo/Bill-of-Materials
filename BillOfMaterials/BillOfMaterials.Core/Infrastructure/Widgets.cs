namespace BillOfMaterials.Core.Infrastructure
{
    public class RectangleWidget : BaseWidget
    {
        public int Width { set; get; }
        public int Height { set; get; }

        public override bool Validate()
        {
            bool isValid = base.Validate();

            isValid = isValid && WidgetValidator.CorrectInt(Width);
            isValid = isValid && WidgetValidator.CorrectInt(Height);

            return isValid;
        }
    }

    public class SquareWidget : BaseWidget
    {
        public int Width { set; get; }

        public override bool Validate()
        {
            bool isValid = base.Validate();

            isValid = isValid && WidgetValidator.CorrectInt(Width);

            return isValid;
        }
    }

    public class EllipseWidget : BaseWidget
    {
        public int HorizontalDiameter { set; get; }
        public int VerticalDiameter { set; get; }

        public override bool Validate()
        {
            bool isValid = base.Validate();

            isValid = isValid && WidgetValidator.CorrectInt(HorizontalDiameter);
            isValid = isValid && WidgetValidator.CorrectInt(VerticalDiameter);

            return isValid;
        }
    }

    public class CircleWidget : BaseWidget
    {
        public int Diameter { set; get; }

        public override bool Validate()
        {
            bool isValid = base.Validate();

            isValid = isValid && WidgetValidator.CorrectInt(Diameter);

            return isValid;
        }
    }

    public class TextboxWidget : BaseWidget
    {
        public int Width { set; get; }
        public int Height { set; get; }
        public string Text { set; get; }
        public bool IsText { set; get; }

        public override bool Validate()
        {
            bool isValid = base.Validate();

            isValid = isValid && WidgetValidator.CorrectInt(Width);
            isValid = isValid && WidgetValidator.CorrectInt(Height);
            isValid = isValid && WidgetValidator.CorrectString(Text);

            return isValid;
        }
    }
}
