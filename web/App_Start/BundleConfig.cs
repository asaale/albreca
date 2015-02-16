using System.Web.Optimization;

namespace Albreca.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/styles/kanzi")
           .IncludeDirectory("~/Content/Styles/Libs/Kanzi", "*.css", false));

            RegisterLibScripts(bundles);
            RegisterCustomScripts(bundles);
        }

        private static void RegisterCustomScripts(BundleCollection bundles)
        {
            var bundle = new ScriptBundle("~/scripts/custom/app")
                .IncludeDirectory("~/Content/Scripts/Custom/Angular", "*.js", true);

            bundles.Add(bundle);
        }

        private static void RegisterLibScripts(BundleCollection bundles)
        {
            var bundle = new ScriptBundle("~/scripts/custom/libs")
                .Include("~/Content/Scripts/Custom/Kanzi/_jq.js")
                .Include("~/Content/Scripts/Custom/Kanzi/_jquery.placeholder.js")
                .Include("~/Content/Scripts/Custom/Kanzi/activeaxon_menu.js")
                .Include("~/Content/Scripts/Custom/Kanzi/animationEnigne.js")
                .Include("~/Content/Scripts/Custom/Kanzi/bootstrap.min.js")
                .Include("~/Content/Scripts/Custom/Kanzi/ie-fixes.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jq.appear.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.base64.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.carouFredSel-6.2.1-packed.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.cycle.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.cycle2.carousel.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.easing.1.3.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.easytabs.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.infinitescroll.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.isotope.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.prettyPhoto.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jQuery.scrollPoint.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.themepunch.plugins.min.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.themepunch.revolution.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.tipsy.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jquery.validate.js")
                .Include("~/Content/Scripts/Custom/Kanzi/jQuery.XDomainRequest.js")
                .Include("~/Content/Scripts/Custom/Kanzi/kanzi.js")
                .Include("~/Content/Scripts/Custom/Kanzi/retina.js")
                .Include("~/Content/Scripts/Libs/Angular/angular.js")
                .Include("~/Content/Scripts/Libs/Angular/angular-ui-router.js");
            bundle.Orderer = new AsIsBundleSorter();
            bundles.Add(bundle);
        }
    }
}