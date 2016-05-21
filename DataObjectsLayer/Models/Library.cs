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

        public int Id { get; set; }
        //[Key]
        public int BookId { get; set; }

        //[Key]
        public int AuthorId { get; set; }

        
        public virtual Author Author { get; set; }
        
        public virtual Book Book { get; set; }
        
        
    }
}
