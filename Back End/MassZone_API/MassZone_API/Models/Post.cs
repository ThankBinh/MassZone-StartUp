using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassZone_API.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int postId { get; set; }
        public int postType { get; set; }
        [DataType(DataType.Date)]
        public DateTime postTime { get; set; }
        public string title { get; set; }
        public string featureImg { get; set; }
        public string content { get; set; }
        //type Vote
        [DataType(DataType.Date)]
        public DateTime voteEndTime { get; set; }
        public int voteNum { get; set; }
        public int voteRequire { get; set; }
        public int votePrice { get; set; }

        
        public int? userId { get; set; }
        [ForeignKey("userId")]
        public virtual User Users { get; set; }
        public int? cateId { get; set; }
        [ForeignKey("cateId")]
        public virtual Category Categories { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Products = new HashSet<Product>();
        }
    }
}