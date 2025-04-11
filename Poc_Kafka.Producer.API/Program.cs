using Poc_Kafka.Producer.API.Configurations;
using Poc_Kafka.Producer.API.Services;
using Poc_Kafka.Producer.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProducerService, ProducerService>();

builder.Services
.AddScoped<KafkaConfiguration>()
    .Configure<KafkaConfiguration>(a => builder.Configuration.GetSection(nameof(KafkaConfiguration))
    .Bind(a));

builder.Services.AddControllers();

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
