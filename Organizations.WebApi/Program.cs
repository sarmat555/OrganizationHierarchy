using Organizations.WebApi.AppStart;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddApplicationContext(builder.Configuration)
    .AddServices()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

app
    .UseCors("CorsApiPolicy")
    .UseRouting()
    .UseStaticFiles()
    .UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });

app
    .UseSwagger()
    .UseSwaggerUI();

app.Run();

