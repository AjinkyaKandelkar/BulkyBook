using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {


        ApplicationDBContext _dbContext;
        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            Category = new CategoryRepository(_dbContext);
            covertype = new CoverTypeRepository(_dbContext);
            product = new ProductRepository(_dbContext);
            Company = new CompanyRepository(_dbContext);
            ApplicationUser = new ApplicationUserRepository(_dbContext);
            ShoppingCart = new ShoppingCartRepository(_dbContext);
            OrderDetail = new OrderDetailRepository(_dbContext);
            OrderHeader = new OrderHeaderRepository(_dbContext);
        }

        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository covertype { get; private set; }
        public IProductRepository product { get; private set; }
        public ICompanyRepository Company { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
