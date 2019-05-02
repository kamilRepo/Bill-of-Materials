using System;
using System.Text;
using System.Text.RegularExpressions;
using BillOfMaterials.Core.Infrastructure;

namespace BillOfMaterials.Core
{
    public class WidgetsGenerator : IWidgetsGenerator
    {
        public const string LineSeparator = "----------------------------------------------------------------";
        public const string AbortLine = "+++++Abort+++++";

        /// <summary>
        /// This method genetate widgets for Widget Builder.
        /// </summary>
        /// <param name="conf">Configuration indicate how widgets should be build.</param>
        /// <returns>string</returns>
        /// <exception>Method is exception safety</exception>  
        public string Generate(Configuration conf)
        {
            IWidgetBuilder builder = new WidgetBuilder();
            var result = new StringBuilder();

            try
            {
                WidgetsProduct product = Construct(builder, conf);

                if (product.IsValid)
                {
                    CreateHeader(result, conf.Title);
                    CreateBody(result, product);
                    result = result.Append(LineSeparator);

                    if (Regex.Matches(result.ToString(), Environment.NewLine).Count > 1000)
                        result = Abort();
                }
                else
                    result = Abort();
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                result = new StringBuilder();
                result = result.Append(AbortLine);
            }

            return result.ToString();
        }

        private WidgetsProduct Construct(IWidgetBuilder builder, Configuration conf)
        {
            builder.BuildRectangle(conf.Rectangle);
            builder.BuildSquare(conf.Square);
            builder.BuildEllipse(conf.Ellipse);
            builder.BuildCircle(conf.Circle);
            builder.BuildTextbox(conf.Textbox);

            return builder.GetProduct();
        }

        private StringBuilder CreateHeader(StringBuilder result, string value)
        {
            result = result.AppendLine(LineSeparator);
            result = result.AppendLine(value);
            result = result.AppendLine(LineSeparator);

            return result;
        }

        private StringBuilder CreateBody(StringBuilder result, WidgetsProduct product)
        {
            result = AppendLine(result, product.Rectangle);
            result = AppendLine(result, product.Square);
            result = AppendLine(result, product.Ellipse);
            result = AppendLine(result, product.Circle);
            result = AppendLine(result, product.Textbox);

            return result;
        }

        private StringBuilder AppendLine(StringBuilder result, string value)
        {
            if (string.IsNullOrEmpty(value))
                return result;
            else
                return result.AppendLine(value);
        }

        private StringBuilder Abort()
        {
            Logger.Log.Info("Validation fault");
            return new StringBuilder().Append(AbortLine);
        }
    }
}