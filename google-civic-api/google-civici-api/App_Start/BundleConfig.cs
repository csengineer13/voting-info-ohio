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
            bundles.Add(new ScriptBundle("~/bundles/vendor-and-toolkit-js")
                .Include("~/Scripts/vendor.js")
                .Include("~/Toolkit/dist/assets/toolkit/scripts/toolkit.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/site-js")
                .Include("~/Scripts/app.js")
                .Include("~/Scripts/site.js")
                );
            
            // CSS
            bundles.Add(new StyleBundle("~/Content/vendor-and-toolkit-css")
                .Include("~/Content/vendor.css")
                .Include("~/Toolkit/dist/assets/toolkit/styles/toolkit.css")
                );

            bundles.Add(new StyleBundle("~/Content/site-css")
                .Include("~/Content/site.css")
                );
        }
    }
}
