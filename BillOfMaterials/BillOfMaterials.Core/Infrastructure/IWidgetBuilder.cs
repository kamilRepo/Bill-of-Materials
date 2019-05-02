namespace BillOfMaterials.Core.Infrastructure
{
    internal interface IWidgetBuilder
    {
        void BuildRectangle(RectangleWidget widget);
        void BuildSquare(SquareWidget widget);
        void BuildEllipse(EllipseWidget widget);
        void BuildCircle(CircleWidget widget);
        void BuildTextbox(TextboxWidget widget);

        WidgetsProduct GetProduct();
    }
}