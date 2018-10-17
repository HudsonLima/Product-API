using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ProductAPI.Tests
{
    [TestClass]
    public class BrandsServiceTest
    {
        [TestMethod]
        public void CallBrandsService() //object data, string path
        {
            string path = Configuration.Default.Resource
                + "/api/brands";

            var request = WebRequest.Create(path);
            request.Method = "GET";

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(responseStream))
                    {
                        string responseString = streamReader.ReadToEnd();

                        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                    }
                }
            }
        }
    }
}
