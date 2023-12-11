using MeetupDotnet8CS.Keyed;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton<Addition>();
//builder.Services.AddSingleton<Multiplication>();
builder.Services.AddKeyedSingleton<IMathCompute, Addition>("add");
builder.Services.AddKeyedSingleton<IMathCompute, Multiplication>("mul");

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Demos nouveautés Random

ReadOnlySpan<int> nomnbres = new[] { 1, 2, 3, 44 , 14};
var auHasardParmis = Random.Shared.GetItems(nomnbres, 10);
foreach (var i in auHasardParmis)
    Console.Write($" {i} ");
Console.WriteLine();


Random.Shared.Shuffle(auHasardParmis);
foreach (var i in auHasardParmis)
    Console.Write($" {i} ");
Console.WriteLine();

app.Run();
