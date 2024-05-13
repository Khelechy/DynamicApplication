using DynamicApplication.Core.Data;
using DynamicApplication.Core.Extensions;
using DynamicApplication.Core.Interfaces;
using DynamicApplication.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cosmosConfig = builder.Configuration.GetSection("CosmosDb");
builder.Services.AddDatabaseServices(cosmosConfig);

builder.Services.AddTransient<IApplicationProgramService, ApplicationProgramService>();
builder.Services.AddTransient<IQuestionService, QuestionService>();

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
