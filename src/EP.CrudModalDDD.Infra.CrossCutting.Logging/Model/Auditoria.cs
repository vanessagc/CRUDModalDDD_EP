using System;
using System.Web.Script.Serialization;

namespace EP.CrudModalDDD.Infra.CrossCutting.Logging.Model
{
    public class Auditoria
    {
        public Auditoria(string userId, string sistema, string ip, string acao, string model = null)
        {
            UserId = userId;
            Sistema = sistema;
            IP = ip;
            Acao = acao;
            Model = model;
            LogId = Guid.NewGuid();
            DataOcorrencia = DateTime.Now;
        }

        public Guid LogId { get; set; }
        public DateTime DataOcorrencia { get; private set; }
        public string Sistema { get; private set; }
        public string UserId { get; private set; }
        public string IP { get; private set; }
        public string Acao { get; private set; }
        public string Model { get; private set; }

        public string ModelToJson(object model)
        {
            return new JavaScriptSerializer().Serialize(model);
        }
    }
}