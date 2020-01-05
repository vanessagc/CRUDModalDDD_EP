using System.Web.Mvc;
using EP.CrudModalDDD.Infra.CrossCutting.Logging.Helpers;
using EP.CrudModalDDD.Infra.CrossCutting.MvcFilters;
using SimpleInjector;

namespace EP.CrudModalDDD.UI.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(container.GetInstance<GlobalFilterTool>());
        }
    }
}
