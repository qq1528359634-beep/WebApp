using WebApp.date;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//注册HttpClient服务，命名为ShirtApi，设置基础地址和默认请求头
builder.Services.AddHttpClient("ShirtsApi", client =>
{
    client.BaseAddress=new Uri("https://localhost:7025/api/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
//Transient瞬时生命周期：每次请求都会创建一个新的实例，适用于轻量级、无状态的服务。
//将服务和服务的实现类型注册到依赖注入容器中，
//这样在需要使用IWebApiExecuter的地方，框架会自动提供一个WebApiExecuter实例。
builder.Services.AddTransient<IWebApiExecuter, WebApiExecuter>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
