using CS_Actions_WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// MVCのコントローラーとビュー、およびCalcServiceをDIコンテナに登録
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CalcService>();

var app = builder.Build();

app.UseRouting();

// デフォルトのルーティングをCalcControllerのIndexに設定
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calc}/{action=Index}/{id?}");

app.Run();


// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddRazorPages();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseHttpsRedirection();

// app.UseRouting();

// app.UseAuthorization();

// app.MapStaticAssets();
// app.MapRazorPages()
//    .WithStaticAssets();

// app.Run();
