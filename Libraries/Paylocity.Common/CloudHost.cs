using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Common
{
    public class CloudHost
    {
        public Dictionary<string, object> Headers;
        public string Host;
        public string Body;
        public string Query;

        #region Get
        public Entity.response Get()
        {
            Entity.response response = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                if (Headers != null && Headers.Count > 0)
                {
                    foreach (var header in Headers)
                    {
                        try
                        {
                            if (!client.DefaultRequestHeaders.Contains(header.Key) && header.Value != null && !string.IsNullOrEmpty(header.Value.ToString()))
                            {
                                client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                            }
                        }
                        catch (Exception ex) { string err = ex.ToString(); }
                    }
                }
                response = Post(client);
            }

            return response;
        }
        #endregion
        #region Post
        Entity.response Post(HttpClient client)
        {
            Entity.response apiResponse = null;
            Task<HttpResponseMessage> response = null;
            try
            {
                if (Body == null) response = client.GetAsync(Host + Query);
                //else
                //{
                //    var formVars = new Dictionary<string, string>();
                //    formVars.Add("value", Body);
                //    response = client.PostAsync(Host + Query, new FormUrlEncodedContent(formVars));
                //}
                else
                {
                    response = client.PostAsync(Host + Query, new StringContent("value=" + Body, Encoding.Default, "application/x-www-form-urlencoded"));
                }
                response.Wait();
                if (response.Result != null && response.Result.Content != null)
                {
                    Task<string> content = response.Result.Content.ReadAsStringAsync();
                    if (content.IsCanceled || string.IsNullOrEmpty(content.Result)) content.Wait();
                    apiResponse = Conversion.JsonToType<Entity.response>(content.Result);
                }
            }
            catch (Exception ex)
            {
                apiResponse = new Entity.response { status = new Entity.status { code = Enums.status.Error, detail = ex.StackTrace } };
            }
            return apiResponse;
        }
        #endregion
    }
}
