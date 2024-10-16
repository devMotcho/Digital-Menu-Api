using DigitalMenuApi.Data;
using DigitalMenuApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRestService, RestService>();
builder.Services.AddDbContext<IDataContext, DataContext>();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var DbContext = scope.ServiceProvider.GetRequiredService<IDataContext>();
    if (!DbContext.Database.CanConnect())
    {
        throw new NotImplementedException("Can't Connect to the Database");
    }
    await DbContext.Database.MigrateAsync();
}

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
