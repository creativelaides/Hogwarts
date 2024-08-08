using Hogwarts.Api;
using Hogwarts.Api.Extensions;
using Hogwarts.Api.Middleware;
using Hogwarts.Application;
using Hogwarts.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApi();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

await app.SeedDataAuthentication();

app.MapControllers();

app.Run();
