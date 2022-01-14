using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WbSoftwareWebProject.Common;
using WbSoftwareWebProject.Core.IDataAccess;
using WbSoftwareWebProject.Entities.Entity;

namespace WbSoftwareWebProject.DataAccessLayer.EntitiyFramework
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        public DbSet<T> _dbSet;

        public Repository()
        {
            _dbSet = db.Set<T>();
        }

        public int Delete(T obj)
        {
            _dbSet.Remove(obj);
            return Save();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _dbSet.FirstOrDefault(where);
        }

        public int Insert(T obj)
        {
            _dbSet.Add(obj);
            if (obj is MyEntityBase)
            {
                MyEntityBase _obj = obj as MyEntityBase;
                _obj.CreatedOn = DateTime.Now;
                _obj.UpdatedOn = DateTime.Now;
                _obj.SavedUsername = App.Common.GetCurrentUsername(); // TODO : İşlem yapan kullanıcı(Session) adı yazılacak.
            }
            return Save();
        }

        public IQueryable<T> IQueryableList()
        {
            return _dbSet.AsQueryable<T>();
        }

        public List<T> List()
        {
            return _dbSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update(T obj)
        {
            if (obj is MyEntityBase)
            {
                MyEntityBase _obj = obj as MyEntityBase;
                _obj.UpdatedOn = DateTime.Now;
                _obj.SavedUsername = App.Common.GetCurrentUsername(); // TODO : İşlem yapan kullanıcı(Session) adı yazılacak.
            }
            return Save();
        }
    }
}
