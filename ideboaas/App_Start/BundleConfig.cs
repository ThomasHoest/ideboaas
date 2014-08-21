using System.Web;
using System.Web.Optimization;

namespace ideboaas
{
  public class BundleConfig
  {
    // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/js").Include(
                  "~/Scripts/vendor/jquery-{version}.js",
                  "~/Scripts/vendor/bootstrap.js",
                  "~/Scripts/vendor/docs.min.js",
                  "~/Scripts/vendor/moment.min.js",
                  "~/Scripts/vendor/fullcalender.js"
                  ));

      bundles.Add(new StyleBundle("~/Content/css").Include(
        "~/Content/vendor/bootstrap.css",
        "~/Content/sass/ideboaas.css"));
    }
  }
}