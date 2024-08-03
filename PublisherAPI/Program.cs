using Microsoft.EntityFrameworkCore;
using PublisherAPI.Common.Enum;
using PublisherAPI.Common.Request;
using PublisherAPI.Common.Response;
using PublisherAPI.Data;
using PublisherAPI.Models;

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

// Store topic
app.MapPost("api/topics", async (AppDbContext context, StoreTopicRequest request) =>
{
    StoreTopicResponse response = new StoreTopicResponse();
    try
    {
        Topic data = new Topic
        {
            TopicName = request.TopicName,
            CreatedAt = DateTime.Now,
            CreatedBy = "SYSTEM",
            RowStatus = (int)EnumType.Active
        };

        await context.Topics.AddAsync(data);

        await context.SaveChangesAsync();

       
        response.Acknowledge = true;
        response.Message = "Success!";
        response.Item = data;

        return Results.Created($"api/topics/{data.Id}", response);
    }
    catch(Exception ex) 
    {
        response.Acknowledge = false;
        response.Message = "An error occurred while creating the topic. " + ex.Message;
        return Results.Ok(response);
    }
});

// Retrive topic list
app.MapGet("api/topics", async (AppDbContext context) =>
{
    RetriveTopicResponse response = new RetriveTopicResponse();
    try
    {
        var data = await context.Topics.Where(Q => Q.RowStatus == 0).ToListAsync();

        response.Message = "Success retrive data!";
        response.Acknowledge = true;
        response.Items = data;

        return Results.Ok(response);

    }
    catch (Exception ex)
    {
        response.Acknowledge = false;
        response.Message = "An error occurred while retriving the topic. " + ex.Message;
        return Results.Ok(response);
    }
});
app.Run();
