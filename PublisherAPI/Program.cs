using Microsoft.EntityFrameworkCore;
using PublisherAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// initialize connection string
var con = builder.Configuration.GetConnectionString("DB");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// configure db context
builder.Services.AddDbContext<AppDbContext>(o => 
    o.UseSqlServer(con, sql => sql.CommandTimeout(60))
    , ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
