using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDBContext _dbContext;
        public CoverTypeRepository(ApplicationDBContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(CoverType obj)
        {
            _dbContext.CoverType.Update(obj);
        }
    }
}
