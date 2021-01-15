using Newtonsoft.Json;
using Normanet_Entidades.Comites;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Normanet_Comunicaciones.Comites
{
    public class Comites
    {
        public static List<Normanet_Entidades.Comites.getComites> getComites_Get(String ID_CT,String ID_SC)
        {
        string value = System.Configuration.ConfigurationManager.AppSettings["EndpointBase"];

            var client = new RestClient(value + "/comitetecnico/CONANCE/" + ID_CT + "/" + ID_SC);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("token", "ANC3202!");
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8");
            IRestResponse response = client.Execute(request);
            List<Normanet_Entidades.Comites.getComites> Response = JsonConvert.DeserializeObject<List<Normanet_Entidades.Comites.getComites>>(response.Content);
            return Response;
        }
        public static List<Normanet_Entidades.Comites.getComitesDescripcion> getComitesDescripcion_Get(GetDeleteComitesDescripcion_Parameter _Parameter)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings["EndpointBase"] + "comitetecnico/descripcion";

            var client = new RestClient(value);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("token", "ANC3202!");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8");
            String h = JsonConvert.SerializeObject(_Parameter);
            request.AddParameter("application/json", JsonConvert.SerializeObject(_Parameter), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<Normanet_Entidades.Comites.getComitesDescripcion> Response = JsonConvert.DeserializeObject<List<Normanet_Entidades.Comites.getComitesDescripcion>>(response.Content);
            return Response;
        }
        public static String addComite_post(addComite_post_put_Parameter _Parameter)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings["EndpointBase"];

            var client = new RestClient(value + "comitetecnico");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("token", "ANC3202!");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8");
            request.AddParameter("application/json", JsonConvert.SerializeObject(_Parameter), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.StatusCode.ToString();
        }
        public static String addComite_put(addComite_post_put_Parameter _Parameter)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings["EndpointBase"];

            var client = new RestClient(value + "comitetecnico");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("token", "ANC3202!");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8");
            request.AddParameter("application/json", JsonConvert.SerializeObject(_Parameter), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.StatusCode.ToString();
        }
        public String addComite_delete(GetDeleteComitesDescripcion_Parameter _Parameter)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings["EndpointBase"];

            var client = new RestClient(value + "comitetecnico");
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("token", "ANC3202!");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8");
            request.AddParameter("application/json", JsonConvert.SerializeObject(_Parameter), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.StatusCode.ToString();

        }

 

    }
}
