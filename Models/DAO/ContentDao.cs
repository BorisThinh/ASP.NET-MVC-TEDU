using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ContentDao
    {
        private OnlineShopDbContext db = new OnlineShopDbContext();

        public Content GetById(long id)
        {
            return db.Contents.Find(id);
        }
    
    }
}
