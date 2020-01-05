using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using EP.CrudModalDDD.Infra.CrossCutting.Logging.Data;
using EP.CrudModalDDD.Infra.CrossCutting.Logging.Model;
using Microsoft.AspNet.Identity;

namespace EP.CrudModalDDD.Infra.CrossCutting.Logging.Helpers
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class LogAuditoriaHelper : ILogAuditoria
    {
        private readonly LogginContext _context;
        public Dictionary<string, string> Item = new Dictionary<string, string>();

        public LogAuditoriaHelper(LogginContext context)
        {
            _context = context;
        }

        public void RegistrarLog(ActionExecutedContext filterContext)
        {
            try
            {
                var modelJson = "";
                if (filterContext.HttpContext.Request.HttpMethod.ToLower() == "post")
                {
                    var form = Form(filterContext.HttpContext);
                    form.Remove(form.First(c => c.Key == "__RequestVerificationToken"));
                    modelJson = form.Aggregate("{", (current, item) => current + string.Format("'{0}':" + "'{1}',", item.Key, item.Value)) + "}";
                }

                var log = new Auditoria(
                    filterContext.HttpContext.User.Identity.IsAuthenticated
                        ? filterContext.HttpContext.User.Identity.GetUserName()
                        : "Anonimo",
                    "Sistema Modelo MVC",
                    GetIP(filterContext),
                    filterContext.HttpContext.Request.Url.AbsoluteUri,
                    modelJson);

                _context.LogAuditoria.Add(log);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                // Gravar Log de Erro
            }
        }

        public IEnumerable<Auditoria> ObterLogs()
        {
            return _context.LogAuditoria.OrderByDescending(c => c.DataOcorrencia).ToList();
        }

        public IEnumerable<Auditoria> Buscar(Expression<Func<Auditoria, bool>> predicate)
        {
            return _context.LogAuditoria.Where(predicate);
        }

        private static List<Item> Form(HttpContextBase httpContext)
        {
            return httpContext.Request.Form.Keys.OfType<string>().Select(k => new Item(k, httpContext.Request.Form[k])).ToList();
        }

        public string GetIP(ActionExecutedContext filterContext)
        {
            return filterContext.HttpContext.Request.ServerVariables["SERVER_NAME"] == "localhost" ? "Acesso Local" : filterContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"];
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public class Item
    {
        public Item(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}