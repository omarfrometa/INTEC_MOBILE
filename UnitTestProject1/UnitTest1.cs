using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            var httpClient = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44341/api/Suppliers");
            var res = await httpClient.SendAsync(req);

            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadAsStringAsync();
            }
        }
    }
}
