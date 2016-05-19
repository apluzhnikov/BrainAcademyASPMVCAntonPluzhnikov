using DataObjectsLayer;
using DataObjectsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksEntityApproach
{
    public class EntityApproachDataManager : DataObjectsManager<Library>
    {
        public override Library this[int index] {
            get {
                return dbContext.Library.ElementAt(index);
            }
        }

        public override bool Add(Library dataObject) {
            if (dataObject != null)
            {
                dbContext.Library.Add(dataObject);
                return true;
            }
            return false;
        }

        public override IEnumerable<Library> GetAll() {
            return dbContext.Library;
        }
        
        public override bool Remove(Library dataObject) {
            if (dataObject != null)
            {
                dbContext.Library.Remove(dataObject);
                return true;
            }
            return false;
        }
                
        public override bool Update(Library dataObject) {                        
            if (dataObject != null)
            {
                //var index = dbContext.Library.Find()
                return true;
            }
            return false;            
        }
    }
}
