using Microsoft.EntityFrameworkCore;
using UESAN_INTRANET.CORE.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Get Connection String
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
// Add dbcontext
builder.Services.AddDbContext<VdiIntranet2Context>(options => options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
