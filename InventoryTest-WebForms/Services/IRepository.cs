using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTest_WebForms.Services
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        T FindById(int id);
        int SaveChanges();
    }
}
