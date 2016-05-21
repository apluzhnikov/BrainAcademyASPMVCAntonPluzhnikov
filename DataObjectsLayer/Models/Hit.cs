using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectsLayer.Models
{
    public class Hit
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }


        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
