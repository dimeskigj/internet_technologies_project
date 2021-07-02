using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameReviews.Models {
    public class Game {
        [Key]
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public string SteamURL { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Upvote> Upvotes { get; set; }

    }
}