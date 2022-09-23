

using GraphQLDemo;

var builder = WebApplication.CreateBuilder(args);

//ND - add the GraphQl related services to the dependency injection container by calling
//AddGraphQlServer on the ServieCollection and register our newly created QueryType
builder.Services.AddGraphQLServer().AddQueryType<Query>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ND

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


app.MapGet("/", () => "Hello World!");

app.UseAuthorization();

app.MapRazorPages();

app.Run();

