using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;

namespace RestAPI
{
    public class Tests  
    {
        protected RestClient client = null;
        protected string server = "https://reqres.in/";

        [SetUp]
        public void Setup()
        {
             client = new RestClient(server);
        }

        [Test]
        public void Get()
        {
            var request_listUsers = new RestRequest("api/users", Method.Get);
            request_listUsers.AddParameter("page", "2");
            var response_listUsers = client.Execute(request_listUsers);
            var deserializeObjects = JsonConvert.DeserializeObject<JObject>(response_listUsers.Content);
            var output = deserializeObjects.SelectToken("data[?(@id==12)]");
            Console.WriteLine(output);

            Assert.AreEqual("OK", response_listUsers.StatusCode.ToString());
        }
        [Test]
        public void Post()
        {
            var post_request_listUsers = new RestRequest("api/users", Method.Post);
            post_request_listUsers.AddBody(new post("hey", "ron"));
            var post_response_listUsers = client.Execute(post_request_listUsers);
            var output = JsonConvert.DeserializeObject<JObject>(post_response_listUsers.Content);
            Console.WriteLine(output);
           
            Assert.AreEqual("Completed", post_response_listUsers.ResponseStatus.ToString());
        }
        [Test]
        public void Patch()
        {
            var patch = new RestRequest("api/users/2", Method.Patch);
            patch.AddBody(new patch("kier","QA"));
            var patch_response = client.Execute(patch);
            var ouput = JsonConvert.DeserializeObject<JObject>(patch_response.Content);

            Console.WriteLine(ouput);

            Assert.AreEqual("Completed", patch_response.ResponseStatus.ToString());
        }
    }
}