using EventBus.Events;
using MassTransit;

namespace Product
{
	public class InventoryConsumer : IConsumer<CreatedOrder>
	{
		public Task Consume(ConsumeContext<CreatedOrder> context)
		{
			var s = context.Message;
			Console.WriteLine("from Product: " + s.Name);
			return Task.CompletedTask;
		}
	}
}
