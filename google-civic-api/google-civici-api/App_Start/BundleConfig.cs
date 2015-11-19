using System.Web;
using System.Web.Optimization;

namespace google_civici_api
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // JS
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/lib/jquery-1.10.2.js",
                "~/Scripts/lib/bootstrap.js"
                //"~/Scripts/lib/select2.js",
                //"~/Scripts/lib/jquery.fileupload/jquery.fileupload.js",
                //"~/Scripts/lib/jquery.fileupload/vendor/jquery.ui.widget.js",
                //"~/Scripts/bundle.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/frontendjs")
                .Include("~/Toolkit/dist/assets/toolkit/scripts/toolkit.js")
                .Include("~/Scripts/front-end-bundle.js")
                .Include("~/Scripts/global-frontend.js")
                );
            
            // CSS
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/select2.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/Site.css")
                );

            bundles.Add(new StyleBundle("~/Content/frontend-css")
                .Include("~/Content/style.css",
                "~/Toolkit/dist/assets/toolkit/styles/toolkit.css"
                ));
        }
    }
}
