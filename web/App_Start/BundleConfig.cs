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

            bundles.Add(new ScriptBundle("~/bundles/scripts/Custom")
            .IncludeDirectory("~/Content/Scripts/Custom", "*.js", true));

            bundles.Add(new StyleBundle("~/bundles/styles")
                .IncludeDirectory("~/Content/Styles", "*.css", true));
            
            RegisterKanziRequirements(bundles);
        }
        
        public static void RegisterKanziRequirements(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/styles/kanzi")
               .IncludeDirectory("~/Content/Styles/Libs/Kanzi", "*.css", false));
            
            bundles.Add(new ScriptBundle("~/bundles/scripts/kanzi")
                .Include("~/Content/Scripts/Custom/Kanzi/_j*")
                .Include("~/Content/Scripts/Custom/Kanzi/activeaxon_menu*")
                .Include("~/Content/Scripts/Custom/Kanzi/animationEnigne*")
                .Include("~/Content/Scripts/Custom/Kanzi/bootstrap.min*")
                .Include("~/Content/Scripts/Custom/Kanzi/ie-fixes*")
                .Include("~/Content/Scripts/Custom/Kanzi/jq*")
                .Include("~/Content/Scripts/Custom/Kanzi/kanzi*")
                .Include("~/Content/Scripts/Custom/Kanzi/retina*")
                );
        }
    }
}