using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
//using DataAccess.Concrete.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public IResult Add(Product product)
		{
			//business code
			//validation

			var context = new ValidationContext<Product>(product);
			ProductValidator productValidator = new ProductValidator();
			var result = productValidator.Validate(context);
			if (!result.IsValid)
			{
				throw new ValidationException(result.Errors);
			}

			_productDal.Add(product);
			return new SuccessResult(Messages.ProductAdded);
		}

		public IDataResult<List<Product>> GetAll()
		{
			// iş kodları 
			// yetkisi var mı? 
			if (DateTime.Now.Hour == 1)
			{
				return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
			}

			return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
		}

		public IDataResult<List<Product>> GetAllByCategory(int id)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
		}

		public IDataResult<Product> GetById(int productId)
		{
			return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
		}

		public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
		}

		public IDataResult<List<ProductDetailDto>> GetProductDetails()
		{
			return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
		}
	}
}
