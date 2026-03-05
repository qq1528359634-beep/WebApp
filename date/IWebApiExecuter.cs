namespace WebApp.date
{
    public interface IWebApiExecuter
    {
        Task<T?> InvokeGet<T>(string relativerUrl);
    }
}