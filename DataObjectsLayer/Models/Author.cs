using DataObjectsLayer.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectsLayer.Models
{
    [MetadataType(typeof(AuthorMetadata))]
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Library> Library { get; set; }
    }
}
