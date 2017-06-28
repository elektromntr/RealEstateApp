using System.Web;
using System.Web.Optimization;

namespace dyplomowaApka00
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            /* bundles.Add(new StyleBundle("~/assets/mojCss").Include(
                        "~/assets/web/assets/mobirise-icons/mobirise-icons.css",
                        "~/assets/tether/tether.min.css",
                        "~/assets/bootstrap/css/bootstrap.min.css",
                        "~/assets/bootstrap/css/bootstrap-grid.min.css",
                        "~/assets/bootstrap/css/bootstrap-reboot.min.css",
                        "~/assets/socicon/css/styles.css",
                        "~/assets/animate.css/animate.min.css",
                        "~/assets/dropdown/css/style.css",
                        "~/assets/data-tables/data-tables.bootstrap4.min.css",
                        "~/assets/theme/css/style.css",
                        "~/assets/mobirise-gallery/style.css",
                        "~/assets/mobirise/css/mbr-additional.css"));

            bundles.Add(new ScriptBundle("~/assets/mojScript").Include(
                        "~/assets/web/assets/jquery/jquery.min.js",
                        "~/assets/popper/popper.min.js",
                        "~/assets/tether/tether.min.js",
                        "~/assets/bootstrap/js/bootstrap.min.js",
                        "~/assets/smooth-scroll/smooth-scroll.js",
                        "~/assets/dropdown/js/script.min.js",
                        "~/assets/touch-swipe/jquery.touch-swipe.min.js",
                        "~/assets/jarallax/jarallax.min.js",
                        "~/assets/data-tables/jquery.data-tables.min.js",
                        "~/assets/data-tables/data-tables.bootstrap4.min.js",
                        "~/assets/masonry/masonry.pkgd.min.js",
                        "~/assets/imagesloaded/imagesloaded.pkgd.min.js",
                        "~/assets/bootstrap-carousel-swipe/bootstrap-carousel-swipe.js",
                        "~/assets/jquery-mb-vimeo_player/jquery.mb.vimeo_player.js",
                        "~/assets/viewport-checker/jquery.viewportchecker.js",
                        "~/assets/theme/js/script.js",
                        "~/assets/mobirise-gallery/player.min.js",
                        "~/assets/mobirise-gallery/script.js",
                        "~/assets/mobirise-slider-video/script.js"));

            BundleTable.EnableOptimizations = true; */
        }
    }
}
