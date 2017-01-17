using System.Web;
using System.Web.Optimization;

namespace TestCaseJob
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css", "~/Content/Menu.css", "~/Content/Style.css"));
        }
    }
}
