using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameReviews.Models {
    public class Comment {
        [Key]
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public ApplicationUser User { get; set; }
        public string UserName { get; set; }
        public string UserPhotoURL { get; set; }

    }
}