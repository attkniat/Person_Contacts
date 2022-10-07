using Microsoft.OpenApi.Models;
using PersonContacts.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000"/*, "https://calm-water-04859b403.azurestaticapps.net"*/);
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.NET Minimal API Contacts CRUD", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUIOptions =>
    {
        swaggerUIOptions.DocumentTitle = "ASP.NET Minimal API Contacts CRUD";
        swaggerUIOptions.SwaggerEndpoint("swagger/v1/swagger.json", "ASP.NET Minimal API Contacts CRUD");
        swaggerUIOptions.RoutePrefix = string.Empty;
    });
}

app.UseCors("CORSPolicy");
app.UseHttpsRedirection();

app.MapGet("/get-all-contacts", async () => await ContactsRepository.GetContactsAsync());



app.Run();