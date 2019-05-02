using System.Linq;

namespace BillOfMaterials.Core.Infrastructure
{
    internal class WidgetValidator
    {
        public static bool CorrectInt(int value)
        {
            if (value >= 0)
                return true;
            else
                return false;
        }

        public static bool CorrectString(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Count() > 500)
                return false;
            else
                return true;
        }
    }
}