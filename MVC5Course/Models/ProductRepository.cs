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

        public IQueryable<Product> Get�Ҧ����_�̾�ProductId�Ƨ�(int takeSize)
        {
            return this.All().OrderByDescending(p => p.ProductId).Take(takeSize);
        }

        public override void Delete(Product product)
        {
            product.IsDeleted = true;
            //�]controller�w�g�I�s�@��UnitOfWork.Commit();�ҥH�o�䤣�ݭn�A�I�s�A���M�|�y���o�X�⦸���
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}