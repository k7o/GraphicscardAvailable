using System.Net.Http;
using System.Threading.Tasks;

namespace GraphicscardAvailable.Implementation
{
    public class Radion6900xIsAvailable : IIsAvailableHandler
    {
        private readonly IHttpClientFactory httpClientFactory;

        public Radion6900xIsAvailable(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IsAvailableResponse> Handle(IsAvailableRequest request)
        {
            var shoplink = "https://www.amd.com/en/direct-buy/5458374200/nl";
            
            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            // client.DefaultRequestHeaders.Add("referer", "https://www.amd.com/en/direct-buy/nl");
            
            // var response = await client.PostAsync(shoplink, new StringContent(string.Empty));
            var response = await client.GetAsync(shoplink);
            
            var result = await response.Content.ReadAsStringAsync();
            
            if (!result.Contains("Out of stock"))
            {
                return new IsAvailableResponse
                {
                    IsAvailable = true,
                    OrderUrl = "https://www.amd.com/en/direct-buy/5458374200/nl"
                };
            }

            return new IsAvailableResponse();
        } 
    }
}