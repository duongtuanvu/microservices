﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Events
{
	public class BaseEvent
	{
		public Guid CorrelationId { get; set; } = Guid.NewGuid();
	}
}
