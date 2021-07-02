using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameReviews.Models {
    public class CommentViewModel {
        public string Title { get; set; }
        public List<Upvote> Upvotes { get; set; }
        public List<Comment> Comments { get; set; }
        public String Comment { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}