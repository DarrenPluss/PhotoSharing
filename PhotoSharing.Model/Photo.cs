using System;
using System.Collections.Generic;

namespace PhotoSharing.Model
{
    public class Photo
    {
        //PhotoID. This is the primary key
        public int PhotoID { get; set; }

        //Title. The title of the photo
        public string Title { get; set; }

        //PhotoFile. This is a picture file
        public byte[] PhotoFile { get; set; }

        //ImageMimeType, stores the MIME type for the PhotoFile
        public string ImageMimeType { get; set; }

        //Description.
        public string Description { get; set; }

        //CreatedDate
        public DateTime CreatedDate { get; set; }

        //UserName. This is the name of the user who created the photo
        public string UserName { get; set; }

        //All the comments on this photo, as a navigation property
        public virtual ICollection<Comment> Comments { get; set; }
    }
}