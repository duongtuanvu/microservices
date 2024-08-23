using EventBus.Events;
using MassTransit;

namespace Order
{
	public class OrderSaga : SagaStateMachineInstance
	{
		public Guid CorrelationId { get; set; }
	}

	public class OrderOnboardingSaga : MassTransitStateMachine<OrderSaga>
	{
		public State OrderCreate { get; set; }

		public Event<CreatedOrder> CreatedOrder { get; set; }

		public OrderOnboardingSaga()
		{
			//InstanceState(x => x.CurrenState);
		}
	}
}
