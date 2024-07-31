var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* builder.Services.AddDbContext<HogwartsDbContext>(
    options => options
    .UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"))
    .LogTo(
        Console.WriteLine, 
        new[]{DbLoggerCategory.Database.Command.Name},
        LogLevel.Information)
    .EnableSensitiveDataLogging()
); */

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
