using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectsLayer.Models.Metadata
{
    class AuthorMetadata
    {
        [Required]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(20)]
        public string LastName { get; set; }
    }
}
