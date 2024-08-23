using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Events
{
	public class CreatedOrder : BaseEvent
	{
		public int Id { get; set; } = 10;
		public string Name { get; set; } = "vudt";
	}
}
