namespace BillOfMaterials.Core.Infrastructure
{
    public abstract class BaseWidget
    {
        private bool _isValid;

        public int PositionX { set; get; }
        public int PositionY { set; get; }
        public bool IsRequired { set; get; }

        public virtual bool Validate()
        {
            _isValid = true;

            _isValid = _isValid && WidgetValidator.CorrectInt(PositionX);
            _isValid = _isValid && WidgetValidator.CorrectInt(PositionY);

            return _isValid;
        }
    }
}
