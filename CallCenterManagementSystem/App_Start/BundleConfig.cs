﻿using System.Web;
using System.Web.Optimization;

namespace CallCenterManagementSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/datatables/jquery.datatables.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/datatables/datatables.bootstrap.js",
                      "~/Scripts/typeahead.bundle.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/pikaday.js"
                      
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-flatly.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/site.css",
                      "~/Content/toastr.css",
                      "~/Content/css/datatables.bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/Content/Pikaday/pikaday.css",
                      //"~/Content/Pikaday/site.css",
                      //"~/Content/Pikaday/theme.css",
                      "~/Content/Pikaday/triangle.css"));
        }
    }
}
