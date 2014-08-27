﻿using System.Web;
using System.Web.Optimization;

namespace BlogIt.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Script bundles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/holder.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/global.js",
                "~/Scripts/app/author.js",
                "~/Scripts/app/blog.js",
                "~/Scripts/app/post.js"));
            bundles.Add(new ScriptBundle("~/bundles/shape").Include("~/Scripts/app/shape.js"));

            // Style bundles
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css"));
            bundles.Add(new StyleBundle("~/Content/site").Include(
                "~/Content/app/site.css",
                "~/Content/app/blog.css"));
            bundles.Add(new StyleBundle("~/Content/cover").Include("~/Content/app/cover.css"));
            bundles.Add(new StyleBundle("~/Content/grid").Include("~/Content/app/grid.css"));
            bundles.Add(new StyleBundle("~/Content/custom").Include("~/Content/app/custom.css"));
            bundles.Add(new StyleBundle("~/Content/glass").Include("~/Content/app/glass.css"));
            bundles.Add(new StyleBundle("~/Content/shape").Include("~/Content/app/shape.css"));
        }
    }
}