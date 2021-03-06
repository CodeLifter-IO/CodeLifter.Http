using System;
using Xunit;

namespace CodeLifter.Http.Test
{
    class Ip
    {
        public string ip { get; set; }
    }

    public class LiveUrlGetTests
    {
        [Fact]
        public async void TestAValidUrlRetrunsJsonAsAType()
        {
            string BaseURI = "https://api.ipify.org?format=json";
            HttpClient Client = new HttpClient(BaseURI);

            HttpRequest request = new HttpRequest("");
            Ip result = await Client.Get<Ip>(request);

            Assert.NotNull(result);
            Assert.IsType<Ip>(result);
        }

        [Fact]
        public async void AnInvalidUrlReturnsNull()
        {
            string BaseURI = "https://this.is.not.a.real.url.com";
            HttpClient Client = new HttpClient(BaseURI);
            Client.Timeout = 5000;

            HttpRequest request = new HttpRequest("");
            Ip result = await Client.Get<Ip>(request);

            Assert.Null(result);
        }
    }
}
