using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectsLayer
{
    public interface IDataObjectsManager<T>
    {
        T this[int index] { get; }
        IEnumerable<T> GetAll();
        bool Add(T dataObject);
        bool Remove(T dataObject);
        bool Update(T dataObject);
        void SaveChanges();
    }
}
