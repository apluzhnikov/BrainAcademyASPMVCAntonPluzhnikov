using DataObjectsLayer.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataObjectsLayer.Models
{
    //[MetadataType(typeof(BookMetadata))]
    public class Book : LibraryEntity //: IValidatableObject
    {

        [Key]
        [Required]
        [Column("BookId")]
        public override int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required, RegularExpression("^[ISBN]{4}[ ]{0,1}[0-9]{1}[-]{1}[0-9]{3}[-]{1}[0-9]{5}[-]{1}[0-9]{0,1}$", ErrorMessage = "Please use the template: ISBN 0-596-00681-0")]
        public string ISBN { get; set; }

        public virtual ICollection<Library> Library { get; set; }

        public virtual List<Hit> Hits { get; set; }

        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            var results = new List<ValidationResult>();

            var count = Library.Count(arg => arg.BookId == Id && arg.Author != null);
            if(count > 0)
            {
                results.Add(new ValidationResult("This book doesn't have an author. Please add at least one"));
            }

            return results;
        }*/

        
    }
}