using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        async static void Test()
        {
            try
            {
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync("https://localhost:44341/api/Suppliers");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
