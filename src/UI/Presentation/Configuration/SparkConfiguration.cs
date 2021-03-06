using System.Web.Mvc;
using MongoBlog.Web.Domain;
using Spark;
using Spark.Web.Mvc;

namespace MongoBlog.Web.Presentation.Configuration {
    public class SparkConfigurator : IConfigurator {
        private readonly ViewEngineCollection _engines;

        public SparkConfigurator(ViewEngineCollection engines) {
            _engines = engines;
        }

        public void Configure() {
            _engines.Clear();
            var settings = new SparkSettings
                               {
                                   AutomaticEncoding = true,
                                   Debug = true,
                               };

            settings
                .AddAssembly(typeof(IConfigurator).Assembly)
                .AddAssembly(typeof(Controller).Assembly)
                .SetPageBaseType("ApplicationView");
            var viewFactory = new SparkViewFactory(settings);
            //PrecompileViews(viewFactory);
            _engines.Add(viewFactory);
        }

        private static void PrecompileViews(SparkViewFactory viewFactory) {
            var batch = new SparkBatchDescriptor();
            batch
                .For<ApplicationController>();
            viewFactory.Precompile(batch);
        }
    }
}