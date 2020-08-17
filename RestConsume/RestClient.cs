using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RestConsume
{
    class RestClient
    {

        public enum HttpVerbs
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        private string EndPoint;
        private HttpVerbs Httpverb;

        public RestClient()
        {
            this.EndPoint = String.Empty;
            this.Httpverb = HttpVerbs.GET;
        }

        public void SetEndPoint(string EndPoint)
        {
            this.EndPoint = EndPoint;
        }
        public void SetHttpVerb(string verb)
        {
            HttpVerbs newVerb;
            switch(verb)
            {
                case "POST":
                    newVerb = HttpVerbs.POST;
                    break;
                case "PUT":
                    newVerb = HttpVerbs.PUT;
                    break;
                case "DELETE":
                    newVerb = HttpVerbs.DELETE;
                    break;
                default:
                    newVerb = HttpVerbs.GET;
                    break;
            }
            this.Httpverb = newVerb;
        }

        public string RequestRequest<T>(T ObjectRequest)
        {
            string strResponse = string.Empty;

            WebRequest request;

            try
            {
                request = WebRequest.Create(this.EndPoint);
                request.Method = this.Httpverb.ToString();
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";


                if (ObjectRequest != null)
                {
                    //serializamos el objeto
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(ObjectRequest);
                    //Construye el body del request
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }

                }

                WebResponse response = (WebResponse)request.GetResponse();

                using (StreamReader read = new StreamReader(response.GetResponseStream()))
                {
                    if (read != null)
                    {
                        strResponse = read.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error was Ocurred: " + ex.Message);
            }

            return strResponse;
        }

    }
}
