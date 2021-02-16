﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Product:IEntity
	{
		public int ProductId { get; set; }
		public int CategoryId { get; set; }

		//bunu sonradan ayzdım kontrol et
		//public string  CategoryName { get; set; }
		public string ProductName { get; set; }
		public short UnitsInStock { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
