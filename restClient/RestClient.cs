using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace restClient
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE 
    }
   
    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

        public string urlLogin = "http://alphapar.lan/projet_cyber.api/public/login_check";
        public string urlLoginBills = "http://alphapar.lan/projet_cyber.api/public/api/bills";
        public string urlLoginClients = "http://alphapar.lan/projet_cyber.api/public/api/clients";
        public string urlLoginPlans = "http://alphapar.lan/projet_cyber.api/public/api/plans";
        public string urlLoginProducts = "http://alphapar.lan/projet_cyber.api/public/api/products";
        public string urlLoginUsers = "http://alphapar.lan/projet_cyber.api/public/api/users";

        

        private static string token;

        public RestClient()
        {
            endPoint = string.Empty;
            userName = string.Empty;
            userPassword = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public async Task<string> getRequest(string job)
        {
            try
            {
                if (job == "products")
                {
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(urlLoginProducts);
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                            var response = await client.GetAsync("http://alphapar.lan/projet_cyber.api/public/api/products");

                            if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                            {
                                var json = await response.Content.ReadAsStringAsync();
                                return json;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // //Console.WriteLine("test5");
                    // var myUri = new Uri(urlLoginProducts);
                    // HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                    // //HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
                    // myHttpWebRequest.PreAuthenticate = true;
                    // myHttpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                    // myHttpWebRequest.Accept = "application/json";


                    // //HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    // // Sends the HttpWebRequest and waits for the response.			
                    //// HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    // try
                    // {
                    //     var myWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    //     //Stream receiveStream = myHttpWebResponse.GetResponseStream();
                    //     Stream responseStream = myWebResponse.GetResponseStream();
                    //     if (responseStream == null)
                    //     {
                    //         Console.WriteLine("responseStream == null");
                    //     }

                    //     var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                    //     var json = myStreamReader.ReadToEnd();
                    //     //Console.WriteLine("test6");
                    //     //Console.WriteLine(json);
                    //     responseStream.Close();
                    //     myWebResponse.Close();
                    //     return json;
                    // }
                    // catch (Exception ex)
                    // {
                    //     Console.WriteLine(ex.Message);
                    //     throw ex;
                    // }

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public bool postRequest(string user, string password)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlLogin);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"username\":\"" + user + "\"," +
                                  "\"password\":\"" + password + "\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Token t = JsonConvert.DeserializeObject<Token>(result);

                    token = t.token;

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void billsPostRequest(string description, string client, string products)
        {
            var myUri = new Uri(urlLoginBills);
            var myWebRequest = WebRequest.Create(myUri);
            var myHttpWebRequest = (HttpWebRequest)myWebRequest;
            myHttpWebRequest.PreAuthenticate = true;
            Console.WriteLine(token);
            myHttpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            myHttpWebRequest.Accept = "application/json";
            myHttpWebRequest.ContentType = "application/json";
            myHttpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream()))
            {
                string json2 = "{\"description\":\"" + description + "\"," +
                              "\"client\":\"" + client + "\"," +
                              "\"products\":\"" + products + "\"}";

                streamWriter.Write(json2);
                streamWriter.Flush();
                streamWriter.Close();
            }
            //WebResponse response = myHttpWebRequest.GetResponse();
            var httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
        }

        public void productPostRequest(string name, string price)
        {
            try
            {
                var myUri = new Uri(urlLoginProducts);
                var myWebRequest = WebRequest.Create(myUri);
                var myHttpWebRequest = (HttpWebRequest)myWebRequest;
                myHttpWebRequest.PreAuthenticate = true;
                //Console.WriteLine("test1");
                myHttpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                myHttpWebRequest.Accept = "application/json";
                myHttpWebRequest.ContentType = "application/json";
                myHttpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream()))
                {
                    string json2 = "{\"name\":\"" + name + "\"," +
                                  "\"price\":" + price + "}";

                    streamWriter.Write(json2);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //Console.WriteLine("test2");
                //var response = myHttpWebRequest.GetResponse();
                var httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                //Console.WriteLine("test3");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void productUpdateRequest(string id, string name, string price)
        {
            try
            {
                var myUri = new Uri(urlLoginProducts + "/" + id);
                var myWebRequest = WebRequest.Create(myUri);
                var myHttpWebRequest = (HttpWebRequest)myWebRequest;
                myHttpWebRequest.PreAuthenticate = true;
                //Console.WriteLine(token);
                myHttpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                myHttpWebRequest.Accept = "application/json";
                myHttpWebRequest.ContentType = "application/json";
                myHttpWebRequest.Method = "PUT";

                using (var streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream()))
                {
                    string json2 = "{\"name\":\"" + name + "\"," +
                                  "\"price\":" + price + "}";

                    streamWriter.Write(json2);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //var response = myHttpWebRequest.GetResponse();
                var httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void productDeleteRequest(string id)
        {
           
                try
                {
                    var myUri = new Uri(urlLoginProducts + "/" + id);
                    var myWebRequest = WebRequest.Create(myUri);
                    var myHttpWebRequest = (HttpWebRequest)myWebRequest;
                    myHttpWebRequest.PreAuthenticate = true;
                    //Console.WriteLine(token);
                    myHttpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                    myHttpWebRequest.Accept = "application/json";
                    myHttpWebRequest.ContentType = "application/json";
                    myHttpWebRequest.Method = "DELETE";

                    var httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    httpResponse.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
       
        
    }
}

