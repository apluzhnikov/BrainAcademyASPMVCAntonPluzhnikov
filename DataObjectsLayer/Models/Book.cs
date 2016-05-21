using DataObjectsLayer.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataObjectsLayer.Models
{
    [MetadataType(typeof(BookMetadata))]
    public class Book  //in case if you need an additional validation, like title depends on Author: IValidatableObject
    {

        [Key]
        [Required]
        [Column("BookId")]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required, RegularExpression("^[ISBN]{4}[ ]{0,1}[0-9]{1}[-]{1}[0-9]{3}[-]{1}[0-9]{5}[-]{1}[0-9]{0,1}$", ErrorMessage = "Please use the template: ISBN 0-596-00681-0")]
        public string ISBN { get; set; }

        public virtual ICollection<Library> Library { get; set; }



        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            throw new NotImplementedException();            
        }*/
    }
}