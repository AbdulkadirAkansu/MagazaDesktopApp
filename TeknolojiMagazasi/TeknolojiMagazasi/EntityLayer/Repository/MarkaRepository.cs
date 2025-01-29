using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;

namespace EntityLayer.Repository
{
    public class MarkaRepository : IDisposable, IRepository<Marka>
    {
        private readonly DBContext context;

        public MarkaRepository(DBContext context)
        {
            this.context = context;
        }

        public int Delete(object key)
        {
            throw new NotImplementedException();
        }

        public Marka GetItem(object key)
        {
            throw new NotImplementedException();
        }

        public int Insert(Marka item)
        {
            throw new NotImplementedException();
        }

        public List<Marka> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("sp_marka_listele"))
            {
                return context.ListItems<Marka>(cmd);
            }
        }

        public int Update(Marka item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
