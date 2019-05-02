namespace BillOfMaterials.Core.Infrastructure
{
    public class Configuration
    {
        public string Title { set; get; }
        public RectangleWidget Rectangle { set; get; }
        public SquareWidget Square { set; get; }
        public EllipseWidget Ellipse { set; get; }
        public CircleWidget Circle { set; get; }
        public TextboxWidget Textbox { set; get; }
    }
}