using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        ApplicationDBContext _dB;
        public CompanyRepository( ApplicationDBContext dB ):base(dB)
        {
            _dB = dB;
        }
        public void Update(Company Obj)
        {
           _dB.Companies.Update(Obj);
        }
    }
}
