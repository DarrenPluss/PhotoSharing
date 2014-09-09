using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharing.Models
{
    public class PhotoEditModel
    {
        public int PhotoID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }

    public class AdminPhotoEditModel
    {
        public int PhotoID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}