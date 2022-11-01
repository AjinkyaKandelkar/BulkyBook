using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        ApplicationDBContext _db;
        public ProductRepository(ApplicationDBContext db):base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var ObjFromDb = _db.ProductTable.FirstOrDefault(x => x.Id == product.Id);
            if (ObjFromDb != null)
            {
                ObjFromDb.Title = product.Title;
                ObjFromDb.Description = product.Description;    
                ObjFromDb.Price = product.Price;
                ObjFromDb.Category = product.Category;
                ObjFromDb.ListPrice = product.ListPrice;
                ObjFromDb.FinalPrice = product.FinalPrice;
                ObjFromDb.Price50 = product.Price50;
                ObjFromDb.Price100 = product.Price100;
                ObjFromDb.Author = product.Author;
                ObjFromDb.CategoryId = product.CategoryId;
                ObjFromDb.CoverTypeId  = product.CoverTypeId;
                if(product.ImgUrl != null)
                {
                    ObjFromDb.ImgUrl = product.ImgUrl;
                }
            }

        }
    }
}
