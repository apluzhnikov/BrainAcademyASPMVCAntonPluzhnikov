using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataObjectsLayer.Models.Metadata
{
    public class BookMetadata
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }        

        [Required, RegularExpression("^[ISBN]{4}[ ]{0,1}[0-9]{1}[-]{1}[0-9]{3}[-]{1}[0-9]{5}[-]{1}[0-9]{0,1}$", ErrorMessage = "Please use the template: ISBN 0-596-00681-0")]
        public string ISBN { get; set; }

    }
}