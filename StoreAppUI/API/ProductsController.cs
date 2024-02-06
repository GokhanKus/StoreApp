﻿using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;

namespace StoreAppUI.API
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IServiceManager _manager;

		public ProductsController(IServiceManager manager)
		{
			_manager = manager;
		}
		[HttpGet]
		public IActionResult GetAllProducts()
		{
			//url'ye /api/products yazinca json formatinda productlari goruntuleriz.
			return Ok(_manager.ProductService.GetAllProducts(false));
		}
	}
}
