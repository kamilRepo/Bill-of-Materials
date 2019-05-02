namespace BillOfMaterials.Core.Infrastructure
{
    public interface IWidgetsGenerator
    {
        /// <summary>
        /// This method genetate widgets for Widget Builder.
        /// </summary>
        /// <param name="conf">Configuration indicate how widgets should be build.</param>
        /// <returns>string</returns>
        /// <exception>Method is exception safety</exception> 
        string Generate(Configuration conf);
    }
}