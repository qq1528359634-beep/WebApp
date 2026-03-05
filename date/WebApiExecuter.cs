namespace WebApp.date
{
    public class WebApiExecuter : IWebApiExecuter
    {
        private const string apiName = "ShirtsApi";
        private readonly IHttpClientFactory httpClientFactory;

        public WebApiExecuter(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<T?> InvokeGet<T>(string relativerUrl)
        {
            var httpClient = httpClientFactory.CreateClient(apiName);
            //可能返回null，所以需要加上nullable
            return await httpClient.GetFromJsonAsync<T>(relativerUrl);
        }
    }
}
