using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace TechnikiInterentoweClient
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE,
    }

    class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb HttpMethod { get; set; }
        private static RestClient restClientInstance = null;
        private static readonly object m_oPadLock = new object();

        public static RestClient Instance
        {
            get
            {
                lock (m_oPadLock)
                {
                    if (restClientInstance == null)
                    {
                        restClientInstance = new RestClient();
                    }
                    return restClientInstance;
                }

            }
        }

        private void ConfigureBeforeRequest(string routeAndArgs)
        {
            Instance.EndPoint = "http://localhost:4200/" + routeAndArgs;
        }

        public bool MakePostRequest(string route, object inObject)
        {
            ConfigureBeforeRequest(route + "/");
            Instance.HttpMethod = HttpVerb.POST;
            return Instance.MakePostRequest(inObject);
        }

        public string MakeGetRequest(string route)
        {
            ConfigureBeforeRequest(route + "/");
            Instance.HttpMethod = HttpVerb.GET;
            return Instance.MakeRequest();
        }

        private RestClient()
        {
            EndPoint = string.Empty;
            HttpMethod = HttpVerb.GET;
        }

        private string MakeRequest()
        {
            string strResponse = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            request.Method = HttpMethod.ToString();

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new ApplicationException("error code: " + response.StatusCode.ToString());

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponse = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return strResponse;
        }

        private bool MakePostRequest(object toSerialize)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(EndPoint);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = HttpVerb.POST.ToString();

            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(toSerialize);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return Convert.ToBoolean(streamReader.ReadToEnd());
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
