using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normanet_Comunicaciones.Comites
{
    public class getComites
    {
        public Normanet_Entidades.Comites.getComites getComites_Get(String ID_CT,String ID_SC)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings["EndpointBase"];
            var client = new RestClient(value + "/comitetecnico/CONANCE/" + ID_CT + "/" + ID_SC);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("token", "ANC3202!");
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8");
            IRestResponse response = client.Execute(request);
            Normanet_Entidades.Comites.getComites Response = JsonConvert.DeserializeObject<Normanet_Entidades.Comites.getComites>(response.Content);
            return Response;
        }
    }
}
