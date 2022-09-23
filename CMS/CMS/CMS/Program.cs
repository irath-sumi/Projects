using CMS.Models;
using CMS.Resolvers.Queries;
using CMS.Services;
using Contentful.AspNetCore;
using Contentful.Core;
using Contentful.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

 builder.Services.AddContentful(builder.Configuration);

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddGraphQLServer().AddQueryType(q => q.Name("Query")).AddType<ProductQueryResolver>().AddFiltering().AddSorting().AddProjections();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


app.MapGet("/", () => "Hello World!");


app.Run();
