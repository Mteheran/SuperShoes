using System.Web;
using System.Web.Optimization;

namespace SuperShoesApp
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
         

            //Head Libs 
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/vendor/modernizr/modernizr.js"));

            //Vendor
            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                        "~/Content/vendor/jquery/jquery.js",
                        "~/Content/vendor/jquery-browser-mobile/jquery.browser.mobile.js",
                        "~/Content/vendor/bootstrap/js/bootstrap.js",
                        "~/Content/vendor/nanoscroller/nanoscroller.js",
                        "~/Content/vendor/bootstrap-datepicker/js/bootstrap-datepicker.js",
                        "~/Content/vendor/magnific-popup/jquery.magnific-popup.js",
                        "~/Content/vendor/select2/js/select2.js",
                        "~/Content/vendor/jquery-datatables/media/js/jquery.dataTables.js",
                        "~/Content/vendor/jquery-datatables/extras/TableTools/js/dataTables.tableTools.min.js",
                        "~/Content/vendor/jquery-datatables-bs3/assets/js/datatables.js",
                        "~/Content/vendor/jquery-placeholder/jquery-placeholder.js"));
            //Vendor
            bundles.Add(new ScriptBundle("~/bundles/specificvendor").Include(
                        "~/Content/vendor/jquery-ui/jquery-ui.js",
                        "~/Content/vendor/jqueryui-touch-punch/jqueryui-touch-punch.js",
                        "~/Content/vendor/jquery-appear/jquery-appear.js",
                        "~/Content/vendor/bootstrap-multiselect/bootstrap-multiselect.js",
                        "~/Content/vendor/jquery.easy-pie-chart/jquery.easy-pie-chart.js",
                        "~/Content/vendor/flot/jquery.flot.js",
                        "~/Content/vendor/flot.tooltip/flot.tooltip.js",
                        "~/Content/vendor/flot/jquery.flot.pie.js",
                        "~/Content/vendor/flot/jquery.flot.categories.js",
                        "~/Content/vendor/flot/jquery.flot.resize.js",
                        "~/Content/vendor/jquery-sparkline/jquery-sparkline.js",
                        "~/Content/vendor/raphael/raphael.js",
                        "~/Content/vendor/morris.js/morris.js",
                        "~/Content/vendor/gauge/gauge.js",
                        "~/Content/vendor/snap.svg/snap.svg.js",
                        "~/Content/vendor/liquid-meter/liquid.meter.js",
                        "~/Content/vendor/jstree/jstree.js",
                          "~/Content/vendor/bootstrap-timepicker/bootstrap-timepicker.js",
                        "~/Content/vendor/pnotify/pnotify.custom.js",
                        "~/Content/vendor/jqvmap/jquery.vmap.js",
                        "~/Content/vendor/codemirror/lib/codemirror.js",
                        "~/Content/vendor/codemirror/addon/selection/active-line.js",
                        "~/Content/vendor/codemirror/addon/edit/matchbrackets.js",
                        "~/Content/vendor/codemirror/mode/javascript/javascript.js",
                        "~/Content/vendor/codemirror/mode/xml/xml.js",
                        "~/Content/vendor/codemirror/mode/htmlmixed/htmlmixed.js",
                         "~/Content/vendor/codemirror/mode/css/css.js",
                          "~/Content/vendor/summernote/summernote.js",
                        "~/Content/vendor/jqvmap/data/jquery.vmap.sampledata.js",
                        "~/Content/vendor/jqvmap/maps/jquery.vmap.world.js",
                        "~/Content/vendor/jqvmap/maps/continents/jquery.vmap.africa.js",
                        "~/Content/vendor/jqvmap/maps/continents/jquery.vmap.asia.js",
                        "~/Content/vendor/jqvmap/maps/continents/jquery.vmap.australia.js",
                        "~/Content/vendor/jqvmap/maps/continents/jquery.vmap.europe.js",
                        "~/Content/vendor/jqvmap/maps/continents/jquery.vmap.north-america.js",
                        "~/Content/vendor/jqvmap/maps/continents/jquery.vmap.south-america.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                        "~/Scripts/theme.js",
                        "~/Scripts/theme.custom.js",
                        "~/Scripts/theme.init.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/myscripts").Include(                       
                        "~/Scripts/myscripts/datatable.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                //Vendor CSS
                      "~/Content/vendor/bootstrap/css/bootstrap.css",

                      "~/Content/vendor/font-awesome/css/font-awesome.css",
                      "~/Content/vendor/magnific-popup/magnific-popup.css",
                      "~/Content/vendor/bootstrap-datepicker/css/bootstrap-datepicker3.css",
                      "~/Content/jquery.datetimepicker.css",
                       "~/Content/vendor/bootstrap-timepicker/css/bootstrap-timepicker.css",
                //Specific Page Vendor CSS
                      "~/Content/vendor/jquery-ui/jquery-ui.css",
                      "~/Content/vendor/jquery-ui/jquery-ui.theme.css",
                      "~/Content/vendor/bootstrap-multiselect/bootstrap-multiselect.css",
                      "~/Content/vendor/morris.js/morris.css",
                      "~/Content/vendor/select2/css/select2.css",
                      "~/Content/vendor/select2-bootstrap-theme/select2-bootstrap.css",
                      "~/Content/vendor/jquery-datatables-bs3/assets/css/datatables.css",
                      "~/Content/vendor/pnotify/pnotify.custom.css",
                      "~/Content/vendor/jstree/themes/default/style.css",
                      "~/Content/vendor/bootstrap-markdown/css/bootstrap-markdown.min.css",
                      "~/Content/vendor/summernote/summernote.css",
                      "~/Content/vendor/codemirror/lib/codemirror.css",
                      "~/Content/vendor/codemirror/theme/monokai.css",
                //Theme CSS
                      "~/Content/stylesheets/theme.css",
                //Skin CSS
                      "~/Content/stylesheets/skins/default.css",
                //Theme Custom CSS
                      "~/Content/stylesheets/theme-custom.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
