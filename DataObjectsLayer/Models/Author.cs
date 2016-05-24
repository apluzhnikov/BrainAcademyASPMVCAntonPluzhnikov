using DataObjectsLayer.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectsLayer.Models
{
    //[MetadataType(typeof(AuthorMetadata))]
    public class Author : LibraryEntity
    {
        [Key]
        [Required]
        [Column("AuthorId")]
        public override int Id { get; set; }

        [Required, MinLength(2), MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(20)]
        public string LastName { get; set; }

        public virtual ICollection<Library> Library { get; set; }
    }
}
