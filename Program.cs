using WebApp.date;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("ShirtsApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7025/api");
    //添加请求头，告诉服务器我们希望接受JSON格式的响应数据
    client.DefaultRequestHeaders.Add("Accept","application/json");
});
//瞬时生命周期：每次请求都会创建一个新的实例，适用于轻量级、无状态的服务。
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
