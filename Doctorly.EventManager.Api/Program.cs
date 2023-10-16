using Doctorly.EventManager.Api.Configs;
using Doctorly.EventManager.Api.Mappers;
using Doctorly.EventManager.Api.Services;
using Doctorly.EventManager.Infrastructure;
using Doctorly.EventManager.Infrastructure.Data;
using Doctorly.EventManager.Infrastructure.Data.Repositries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var databaseConfig = builder.Configuration.GetSection("DatabaseConfig").Get<DatabaseConfig>();

builder.Services.AddDbContext<EFContext>(options => 
{
    options.UseSqlServer(databaseConfig.ConnectionString, sqlServerOptionsAction: sqlOptions => 
    {
        sqlOptions.EnableRetryOnFailure();
    });
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEventService, EventService>();
//builder.Services.AddHostedService<EventNotificationService>();

builder.Services.AddAutoMapper(typeof(EventMapper).Assembly, typeof(AttendeeMapper).Assembly);


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();