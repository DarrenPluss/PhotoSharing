using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.Model
{
    public class PhotoDetails
    {
        public int PhotoID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
