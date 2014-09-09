
namespace PhotoSharing.Model
{
    public class Comment
    {
        //CommentID. This is the Primary Key
        public int CommentID { get; set; }

        //PhotoID. This is the ID of the photo that this comment relates to
        public int PhotoID { get; set; }

        //UserName. This is the name of the user who made this comment
        public string UserName { get; set; }

        //Subject.  
        public string Subject { get; set; }

        //Body
        public string Body { get; set; }

        //Photo. This is the photo that this comment relates to as a navigation property
        public virtual Photo Photo { get; set; }
    }
}