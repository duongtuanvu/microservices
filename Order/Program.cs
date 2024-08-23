using EventBus.Events;
using MassTransit;
using MassTransit.Configuration;
using Microsoft.AspNetCore.Mvc;
using Order;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(busConfigurator =>
{
	busConfigurator.SetKebabCaseEndpointNameFormatter();

	busConfigurator.AddConsumers(typeof(Program).Assembly);

	busConfigurator.UsingRabbitMq((context, cfg) =>
	{
		cfg.Host(new Uri("rabbitmq://localhost:5672"), hst =>
		{
			hst.Username("guest");
			hst.Password("guest");
		});

		// multiple Sub in single queue
		cfg.ReceiveEndpoint("order-service", e => 
		{
			e.ConfigureConsumer<OrderConsumer>(context);
		});

		//cfg.ConfigureEndpoints(context);
	});
});

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
