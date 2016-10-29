using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{

        public override IQueryable<Product> All()
        {
            return base.All().Where(p=>p.IsDeleted == false);
        }
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public IQueryable<Product> Get所有資料_依據ProductId排序(int takeSize)
        {
            return this.All().OrderByDescending(p => p.ProductId).Take(takeSize);
        }

        public override void Delete(Product product)
        {
            product.IsDeleted = true;
            //因controller已經呼叫一次UnitOfWork.Commit();所以這邊不需要再呼叫，不然會造成發出兩次交易
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}