using Microsoft.OpenApi.Models;
using PersonContacts.Model;
using PersonContacts.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            //.WithOrigins("http://localhost:3000", "https://wonderful-smoke-0e728aa0f.2.azurestaticapps.net/");
            .WithOrigins("http://localhost:3000", "https://poetic-starburst-03ffd1.netlify.app");
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

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP.NET Minimal API Contacts CRUD";
    swaggerUIOptions.SwaggerEndpoint("swagger/v1/swagger.json", "ASP.NET Minimal API Contacts CRUD");
    swaggerUIOptions.RoutePrefix = string.Empty;
});


app.UseCors("CORSPolicy");
app.UseHttpsRedirection();

app.MapGet("/get-all-contacts", async () => await ContactsRepository.GetContactsAsync()).WithTags("Get All Contacts");

app.MapGet("/get-contact-by-id/{contactId}", async (int contactId) =>
{
    Contact contact = await ContactsRepository.GetContactByIdAsync(contactId);

    if (contact != null)
        return Results.Ok(contact);
    else
        return Results.BadRequest();

}).WithTags("Get a contact By Id");

app.MapPost("/create-contact", async (Contact contactToCreate) =>
{
    bool createSuccess = await ContactsRepository.CreateContactAsync(contactToCreate);

    if (createSuccess)
        return Results.Ok("Create Successful");
    else
        return Results.BadRequest();

}).WithTags("Create a Contact");

app.MapPut("/update-contact", async (Contact contactToUpdate) =>
{
    bool updateSuccess = await ContactsRepository.UpdateContactAsync(contactToUpdate);

    if (updateSuccess)
        return Results.Ok("Update Successful");
    else
        return Results.BadRequest();

}).WithTags("Update a Contact");


app.MapDelete("/delete-contact-by-id/{contactId}", async (int contactId) =>
{
    bool deleteSuccess = await ContactsRepository.DeletePostAsync(contactId);

    if (deleteSuccess)
        return Results.Ok("Delete Successful");
    else
        return Results.BadRequest();

}).WithTags("Delete a Contact");

app.Run();