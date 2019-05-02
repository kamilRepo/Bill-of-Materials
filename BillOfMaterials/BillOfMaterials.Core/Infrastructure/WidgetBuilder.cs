namespace BillOfMaterials.Core.Infrastructure
{
    internal class WidgetBuilder : IWidgetBuilder
    {
        private WidgetsProduct _product;

        public WidgetBuilder()
        {
            _product = new WidgetsProduct()
            {
                IsValid = true
            };
        }

        public void BuildRectangle(RectangleWidget widget)
        {
            _product.Rectangle = GetLine(
                widget,
                $"Rectangle ({widget.PositionX},{widget.PositionY}) width={widget.Width} height={widget.Height}"
            );
        }

        public void BuildSquare(SquareWidget widget)
        {
            _product.Square = GetLine(
                widget,
                $"Square({widget.PositionX},{widget.PositionY}) size = {widget.Width}"
            );
        }

        public void BuildEllipse(EllipseWidget widget)
        {
            _product.Ellipse = GetLine(
                widget,
                $"Ellipse({widget.PositionX},{widget.PositionY}) diameterH = {widget.HorizontalDiameter} diameterV = {widget.VerticalDiameter}"
            );
        }

        public void BuildCircle(CircleWidget widget)
        {
            _product.Circle = GetLine(
                widget,
                $"Circle({widget.PositionX},{widget.PositionY}) size = {widget.Diameter}"
            );
        }

        public void BuildTextbox(TextboxWidget widget)
        {
            var line = string.Empty;

            if (widget.IsText)
                line = $"Textbox({widget.PositionX},{widget.PositionY}) width = {widget.Width} height = {widget.Height} text = \"{widget.Text}\"";
            else
                line = $"Textbox({widget.PositionX},{widget.PositionY}) width = {widget.Width} height = {widget.Height}";

            _product.Textbox = GetLine(
                widget,
                line
            );
        }

        public WidgetsProduct GetProduct()
        {
            return _product;
        }

        private string GetLine(BaseWidget widget, string value)
        {
            string result = null;

            if (Validate(widget) && widget.IsRequired)
                result = value;

            ValidLength(result);

            return result;
        }

        private bool Validate(BaseWidget widget)
        {
            var isValid = widget != null && widget.Validate();
            _product.IsValid = _product.IsValid && isValid;

            return isValid;
        }

        private void ValidLength(string value)
        {
            if (value != null && value.Length > 1000)
                _product.IsValid = false;
        }
    }
}