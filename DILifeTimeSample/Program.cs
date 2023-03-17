using DILifeTimeSample.Contracts;
using DILifeTimeSample.Models;
using DILifeTimeSample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Transient
builder.Services.AddTransient<IMessageTransient, Message>();
builder.Services.AddScoped<IMessageScoped, Message>();
builder.Services.AddSingleton<IMessageSingleton, Message>();
builder.Services.AddScoped<IMessageService, MessageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/message", (IMessageTransient messageTransient, IMessageScoped messageScoped, IMessageSingleton messageSingleton, 
    IMessageService messageService) =>
{
    return new { 
        Transient = messageTransient.GuidId,
        Scoped = messageScoped.GuidId,
        Singleton = messageSingleton.GuidId,
        ServiceMessage = messageService.GetMessage()
    };
}).WithName("GetMessage");


app.Run();

