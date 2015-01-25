using System.Web.Optimization;

namespace Albreca.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts/angular")
            .IncludeDirectory("~/Content/Scripts/Libs/Angular", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/scripts/jquery")
            .IncludeDirectory("~/Content/Scripts/Libs/JQuery", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/scripts/bootstrap")
            .IncludeDirectory("~/Content/Scripts/Libs/Bootstrap", "*.js", true));

            bundles.Add(new StyleBundle("~/bundles/styles")
                .IncludeDirectory("~/Content/Styles", "*.css", true));
        }
    }
}