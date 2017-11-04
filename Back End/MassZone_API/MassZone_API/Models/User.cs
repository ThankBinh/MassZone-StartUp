using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassZone_API.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        [Required]
        [StringLength(50,MinimumLength =4)]
        [Display(Name ="User Name")]
        public string userName { get; set; }
        [Display(Name = "Pass Word")]        
        public string passWord { get; set; }
        public int type { get; set; }
        public int allowed { get; set; }
        public string name { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string userImg { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CheckOut> CheckOuts { get; set; }
        public User()
        {
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
            this.CheckOuts = new HashSet<CheckOut>();
        }

    }
}