using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;

namespace EntityLayer.Repository
{
    public interface IRepository<T> where T : IModel //CRUD işlemleri
    {
        List<T> ToList();
        int Insert(T item);
        int Delete(object key);
        int Update(T item);
        T GetItem(object key);
    }
}
