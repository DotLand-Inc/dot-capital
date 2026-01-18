var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.AddApplicationServices();
builder.AddInfrastructureServices();
builder.AddWebServices();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}


app.UseHealthChecks("/health");
// app.UseHttpsRedirection();

// Authentication must come before authorization
// app.UseAuthentication();

// Custom middleware to check public routes
// app.UseProxyAuthorization();

app.UseExceptionHandler(options => { });

app.MapControllers();

// YARP Reverse Proxy - handles ALL requests
app.MapReverseProxy();

app.Run();

public partial class Program { }
