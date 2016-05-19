using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectsLayer.Models
{    
    public class Library
    {
        public virtual ICollection<Author> Authors { get; set; }
        public virtual List<Book> Books { get; set; }
        
        
    }
}
