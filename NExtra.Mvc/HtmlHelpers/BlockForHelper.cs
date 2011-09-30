using System;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This class is used by the various BlockFor helpers. It is used
    /// to generate general markup that surrounds the editor component.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class BlockForHelper
    {
        /// <summary>
        /// Generate an editor block.
        /// </summary>
        /// <typeparam name="TModel">Model type.</typeparam>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="helper">HtmlHelper instance.</param>
        /// <param name="expression">An expression that identifies the property to display.</param>
        /// <param name="editorBlock">The editor that should be appended to the editor field, e.g. a TextAreaFor.</param>
        /// <returns>An editor block for the provided property.</returns>
        public static IHtmlString FormBlockFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel,TValue>> expression, MvcHtmlString editorBlock)
        {
            var sb = new StringBuilder();

            sb.Append("<div class=\"editor-label\">");
            sb.Append(helper.LabelFor(expression));
            sb.Append("</div>");
            
            sb.Append("<div class=\"editor-field\">");
            sb.Append(editorBlock);
            sb.Append(helper.ValidationMessageFor(expression));
            sb.Append("</div>");
            
            return helper.Raw(sb.ToString());
        }
    }
}
