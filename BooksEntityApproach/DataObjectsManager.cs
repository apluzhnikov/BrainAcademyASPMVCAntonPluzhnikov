using DataObjectsLayer;
using DataObjectsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksEntityApproach
{
    public abstract class DataObjectsManager<T> : IDisposable, IDataObjectsManager<T>
    {
        protected LibraryDBContext dbContext;

        private int count;
        public DataObjectsManager() {
            dbContext = new LibraryDBContext();
            //count = dbContext.Books.Count();
        }

        abstract public T this[int index] { get; }

        abstract public bool Add(T dataObject);
        abstract public bool Remove(T dataObject);
        abstract public bool Update(T dataObject);
        abstract public IEnumerable<T> GetAll();

        public void Dispose() {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
