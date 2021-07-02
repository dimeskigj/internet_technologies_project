using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameReviews.Models {
    public class Upvote {
        [Key]
        public int UpvoteId { get; set; }
        public int GameId { get; set; }
        public Game Game { set; get; }
        public string UserId { get; set; }
        public ApplicationUser User { set; get; }
        public string UserName { get; set; }

    }
}