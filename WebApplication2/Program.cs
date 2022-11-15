using Microsoft.OpenApi.Models;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IWordService, WordService>();
builder.Services.AddTransient<IUrlService, UrlService>();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ToDo API",
        Version = "v1",
        Description = "An ASP.NET Core Web API for managing ToDo items",
    });
    var filePath = Path.Combine(AppContext.BaseDirectory, "WebApplication2.xml");
    options.IncludeXmlComments(filePath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger/.json", "ToDo API v1");
    });
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapGet("/", () => "Hello World!");

app.Run();
