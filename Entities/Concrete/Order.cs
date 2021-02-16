using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Order:IEntity
	{
		public int OrderId { get; set; }
		public string CustomerId { get; set; } //normalize değil. bu yuzden string
		public int EmployeeId { get; set; }
		public DateTime OrderDate { get; set; }
		public string ShipCity { get; set; }
	}
}
