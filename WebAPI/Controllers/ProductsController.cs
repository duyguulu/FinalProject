﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		//loosely coupled: gevşek baglılık, yani sistem buna baglı ama interface'a baglı, bu yuzden servis değiştiğinde bir sorun olmayacak.
		//IoC Container -- Inversion of Control
		IProductService _productService;
		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			//Thread.Sleep(3000);
			var result = _productService.GetAll();
			if (result.Success)
			{
				return Ok(result); //200
			}
			
			return BadRequest(result); //400
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _productService.GetById(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbycategory")]
		public IActionResult GetByCategory(int categoryId)
		{
			var result = _productService.GetAllByCategory(categoryId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(Product product)
		{
			var result = _productService.Add(product);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

	}
}
