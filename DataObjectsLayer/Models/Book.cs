using DataObjectsLayer.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataObjectsLayer.Models
{
    [MetadataType(typeof(BookMetadata))]
    public class Book  //in case if you need an additional validation, like title depends on Author: IValidatableObject
    {

        public int Id { get; set; }

        public string Title { get; set; }        
                        
        public string ISBN { get; set; }
        
        public virtual ICollection<Library> Library { get; set; }



        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            throw new NotImplementedException();            
        }*/
    }
}