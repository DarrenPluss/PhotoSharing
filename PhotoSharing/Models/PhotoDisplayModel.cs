using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharing.Models
{
    public class PhotoDisplayModel
    {
        public int PhotoID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString="{0:D}")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
    }
}