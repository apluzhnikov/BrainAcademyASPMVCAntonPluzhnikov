using DataObjectsLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksEntityApproach.Configs
{
    public class LibraryConfig : EntityTypeConfiguration<Library>
    {
        public LibraryConfig()
        {
            /*HasKey(
                key => new {
                    key.AuthorId,
                    key.BookId
                });*/
            HasKey(key => key.Id);

            /*HasKey(key => key.AuthorId);
            HasKey(key => key.BookId);*/

        }
    }
}
