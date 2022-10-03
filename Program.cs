using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using cinima_mgr.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<StateCache>();
builder.Services.AddSession();

var app = builder.Build();

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
    var movie = await db.Movies.SingleOrDefaultAsync(m => m.Id == id.ToString());
    return movie is null ? Results.NotFound() : Results.File(movie.CoverImg, "image/*", movie.Name);
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();