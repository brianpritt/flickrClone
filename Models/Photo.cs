using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlickrClone.Models
{
    [Table("Photos")]
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoDescription { get; set; }
        public byte[] Picture { get; set; }
        public virtual ApplicationUser Submitter { get; set; }

        public Photo()
        {

        }
        public Photo(string photoName, string photoDescription, byte[] picture)
        {
            PhotoName = photoName;
            PhotoDescription = photoDescription;
            Picture = picture;
    }
    }
    
}