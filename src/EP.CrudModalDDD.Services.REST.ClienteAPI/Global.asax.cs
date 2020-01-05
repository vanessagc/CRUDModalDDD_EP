using System.Web.Http;
using EP.CrudModalDDD.Application.AutoMapper;

namespace EP.CrudModalDDD.Services.REST.ClienteAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
