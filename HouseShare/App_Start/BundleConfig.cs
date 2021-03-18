using System.Web;
using System.Web.Optimization;

namespace HouseShare
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //Script Bundle
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/assets/bootstrap/js/bootstrap.js",
                       "~/assets/script.js",
                       "~/assets/owl-carousel/owl.carousel.js",
                       "~/assets/slitslider/js/modernizr.custom.79639.js",
                       "~/assets/slitslider/js/jquery.ba-cond.min.js",
                       "~/slitslider/js/jquery.slitslider.js"
                      ));

            //Style Bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/bootstrap/css/bootstrap.css",
                      "~/assets/style.css",
                      "~/assets/owl-carousel/owl.carousel.css",
                      "~/assets/owl-carousel/owl.theme.css",
                      "~/assets/slitslider/css/style.css",
                      "~/assets/slitslider/css/custom.css"
                      ));
        }
    }
}