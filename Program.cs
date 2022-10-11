using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using cinima_mgr;
using cinima_mgr.Data;
using cinima_mgr.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<StateCache>();
builder.Services.AddSingleton<EventMgr>();
builder.Services.AddSingleton<DbCorrect>();
builder.Services.AddSession();
builder.Services
    .AddBlazorise()
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

Global.App = builder.Build();

var app = Global.App;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapGet("/Movie/Cover/{id:guid}",  async (Guid id) =>
{
    await using var db = new MgrContext();
    var movie = await db.Movies
        .Include(m => m.Cover)
        .SingleOrDefaultAsync(m => m.Id == id.ToString());
    return movie is null ? Results.NotFound() : Results.File(movie.Cover.Data, "image/*", movie.Name);
});

app.MapGet("/Binary/Img/{id:guid}",  async (Guid id) =>
{
    await using var db = new MgrContext();
    var bin = await db.Binaries.SingleOrDefaultAsync(b => b.Id == id.ToString());
    return bin is null ? Results.NotFound() : Results.File(bin.Data, "image/*", bin.Id);
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//不要删除这几个没用到的服务，用于触发事件系统的启动
app.Services.GetService<EventMgr>();
app.Services.GetService<DbCorrect>();

app.Run();