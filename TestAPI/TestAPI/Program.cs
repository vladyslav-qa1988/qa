using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestAPI
{
    class Program
    {
        async static void GetPet200()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri("https://petstore.swagger.io/v2/pet/1");
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("Accept", "application/json");

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            using (HttpContent responseContent = response.Content)
                            {
                                var json = await responseContent.ReadAsStringAsync();
                                Console.WriteLine("GetPet200" + "\r\n" + "Status: " + (int)response.StatusCode + "\r\n" + json + "\r\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("GetPet200" + "\r\n" + "Status: " + (int)response.StatusCode + "\r\n" + "Fail" + "\r\n");
                        }

                    }
                }
            }
        }
        async static void GetPet400()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri("https://petstore.swagger.io/v2/pet/123456789");
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("Accept", "application/json");

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            using (HttpContent responseContent = response.Content)
                            {
                                var json = await responseContent.ReadAsStringAsync();
                                Console.WriteLine("GetPet400" + "\r\n" + "Status: " + (int)response.StatusCode + "\r\n" + json + "\r\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("GetPet400" + "\r\n" + "Status: " + (int)response.StatusCode + "\r\n" + "Fail" + "\r\n");
                        }
                    }
                }
            }
        }
        async static void GetPet404()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri("https://petstore.swagger.io/v2/pets");
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("Accept", "application/json");

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            using (HttpContent responseContent = response.Content)
                            {
                                var json = await responseContent.ReadAsStringAsync();
                                Console.WriteLine("GetPet404" + "\r\n" + "Status: " + (int)response.StatusCode + "\r\n" + json + "\r\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("GetPet404" + "\r\n" + "Status: " + (int)response.StatusCode + "\r\n" + "Fail" + "\r\n");
                        }
                    }
                }
            }
        }
        static async Task Main()
        {
            GetPet200();
            GetPet400();
            GetPet404();
            Console.ReadKey();
        }
    }
}
