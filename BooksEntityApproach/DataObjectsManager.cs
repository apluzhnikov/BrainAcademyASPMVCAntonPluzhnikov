using DataObjectsLayer;
using DataObjectsLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksEntityApproach
{
    public abstract class DataObjectsManager<T> : IDisposable, IDataObjectsManager<T>
        where T : class
    {
        protected LibraryDBContext dbContext;

        DbSet<T> dbset;

        private int count;
        public DataObjectsManager() {
            dbContext = new LibraryDBContext();
            dbset = dbContext.Set<T>();
        }

        public T this[int index] {
            get {
                return dbset.ElementAt(index);
            }
        }

        public bool Add(T dataObject) {
            if (dataObject != null)
            {
                dbset.Add(dataObject);
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetAll() {
            return dbset.ToList();
        }

        public bool Remove(T dataObject) {
            if (dataObject != null)
            {
                dbset.Remove(dataObject);
                return true;
            }
            return false;
        }

        public bool Update(T dataObject) {
            if (dataObject != null)
            {
                var index = dbset.Find(dataObject);
                return true;
            }
            return false;
        }

        public void Dispose() {
            if (dbContext != null)
                dbContext.Dispose();
        }

        public void SaveChanges() {
            dbContext.SaveChanges();
        }
    }
}
