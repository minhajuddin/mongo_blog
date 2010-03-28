using Spark.Web.Mvc;

namespace MongoBlog.Web.Presentation {
    public abstract class ApplicationView<TModel> : SparkView<TModel> where TModel : class {
        protected string CurrentUrl {
            get {
                string controller = ViewContext.RouteData.GetRequiredString("controller");
                string action = ViewContext.RouteData.GetRequiredString("action");

                return Url.Action(action, controller);
            }
        }
    }
}