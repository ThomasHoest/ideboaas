using System.Web;
using System.Web.Optimization;

namespace IdeboaasWeb
{
  public class BundleConfig
  {
    // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/js").Include(
                  "~/Scripts/vendor/jquery-{version}.js",
                  "~/Scripts/vendor/bootstrap.js",
                  "~/Scripts/vendor/docs.min.js",
                  "~/Scripts/vendor/moment.min.js",
                  "~/Scripts/vendor/fullcalendar.min.js"
                  ));

      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.validate*"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
        "~/Content/vendor/bootstrap.css",
        "~/Content/vendor/fullcalendar.css",
        "~/Content/sass/ideboaas.css"));

      // Set EnableOptimizations to false for debugging. For more information,
      // visit http://go.microsoft.com/fwlink/?LinkId=301862
      //BundleTable.EnableOptimizations = true;
    }
  }
}
