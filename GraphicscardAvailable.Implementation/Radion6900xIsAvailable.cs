using System.Net.Http;
using System.Threading.Tasks;

namespace GraphicscardAvailable.Implementation
{
    public class Radion6900xIsAvailable : IIsAvailableHandler
    {
        public Radion6900xIsAvailable()
        {
        }

        public async Task<IsAvailableResponse> Handle(IsAvailableRequest request)
        {
            var shoplink = "https://www.amd.com/en/direct-buy/add-to-cart/5458374200";
            var client = new HttpClient();
            var response = await client.GetAsync(shoplink);
            var result = await response.Content.ReadAsStringAsync();
            if (!result.Contains("Web Site Maintenance"))
            {
                return new IsAvailableResponse
                {
                    IsAvailable = true,
                    OrderUrl = "https://www.amd.com/en/direct-buy/shopping-cart/modal"
                };
            }
            return new IsAvailableResponse();
        } 
    }
}