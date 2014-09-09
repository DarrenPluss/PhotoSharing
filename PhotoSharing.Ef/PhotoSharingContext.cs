using PhotoSharing.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.Ef
{
    class PhotoSharingContext : DbContext
    {
        public PhotoSharingContext() 
        {
            Database.SetInitializer(new PhotoSharingInitializer());
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
