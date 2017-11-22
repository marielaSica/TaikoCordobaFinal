using System.Web;
using System.Web.Optimization;

namespace TaikoCordobaFinal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.language.es"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/toastr.min.js",
                      "~/Scripts/jquery.blockui.min.js",
                      "~/Scripts/app.js"));
                    


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/toastr.min.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/SiteStyles/css").Include(
                       "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/AdminStyles/css").Include(
                         "~/Content/sb-admin.css"));

            bundles.Add(new ScriptBundle("~/bundles/FancyBoxJs").Include(
                       "~/Scripts/jquery.fancybox.min.js"));

            bundles.Add(new StyleBundle("~/Content/jQueryFancyBoxStyles").Include(
                     "~/Content/jquery.fancybox.min.css"));
        }
    }
}
