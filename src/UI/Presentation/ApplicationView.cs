using Spark.Web.Mvc;
namespace MongoBlog.UI.Presentation {
    public abstract class ApplicationView<TModel> : SparkView<TModel> where TModel : class {

        protected string CurrentUrl {
            get {
                var controller = ViewContext.RouteData.GetRequiredString("controller");
                var action = ViewContext.RouteData.GetRequiredString("action");

                return Url.Action(action, controller);
            }
        }

    }
}