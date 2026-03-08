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
        {   //获取已经注册的HTTP客户端实例，apiName是注册时指定的名称
            var httpClient = httpClientFactory.CreateClient(apiName);
            //GetFromJsonAsync发送GET请求到指定的相对URL，并将响应内容反序列化为类型T的对象。
            //GetFromJsonAsync<T>方法会将HTTP响应内容反序列化为指定类型的对象
            //如果响应内容无法被正确反序列化，或者HTTP请求失败，则会返回null。
            return await httpClient.GetFromJsonAsync<T>(relativerUrl);
        }
    }
}
