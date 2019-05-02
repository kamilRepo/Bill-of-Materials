using log4net;

namespace BillOfMaterials.Core.Infrastructure
{
    public class Logger
    {
        private static ILog _log;
        public static ILog Log
        {
            get
            {
                if (_log == null)
                    _log = LogManager.GetLogger("Bill of materials");

                return _log;
            }
        }
    }
}
