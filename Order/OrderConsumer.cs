using EventBus.Events;
using MassTransit;

namespace Order
{
	public class OrderConsumer : IConsumer<CreatedOrder>
	{
		public Task Consume(ConsumeContext<CreatedOrder> context)
		{
			var s = context.Message;
			Console.WriteLine("from Order: " + s.Name);
			return Task.CompletedTask;
		}
	}
}
