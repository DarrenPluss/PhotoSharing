using System;
using System.Collections.Generic;

namespace PhotoSharing.Model
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string Title { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}