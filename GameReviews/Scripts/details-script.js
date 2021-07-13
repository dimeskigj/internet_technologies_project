$(document).ready(function () {
/*    $(".js-delete-game").on("click", function () {
        let button = $(this);
        bootbox.confirm("Are you sure you want to delete this game?", function (result) {
            if (result) {
*//*                $.ajax({
                    url: "/Games/DeleteConfirmed/" + button.attr("data-game-id"),
                    method: "POST",
                    success: function () {
                        setTimeout(null, 50);
                        window.location.replace("~/Games/Index");
                    },
                    error: function (err) {
                        console.log("Error");
                    }
                });*//*
                window.location.replace("~/Games/DeleteConfirmed/" + button.attr("data-game-id"));
            } else {
                //...
            }
        });
    });*/
    $(".js-delete-comment").on("click", function () {
        let button = $(this);
        let to_delete = $("#" + button.attr("data-comment-id"));
        bootbox.confirm("Delete this comment?", function (result) {
            if (result) {
                console.log("/Comments/DeleteConfirmed/" + button.attr("data-comment-id"));
                $.ajax({
                    url: "/Comments/DeleteConfirmed/" + button.attr("data-comment-id"),
                    method: "POST",
                    success: function () {
                        to_delete.remove();
                        setTimeout(null, 50);
                        $(".comments-container").masonry({
                            itemSelector: '.comment-instance',
                            columnWidth: '.comment-instance'
                        });
                    },
                    error: function (err) {
                        console.log("Error");
                    }
                });
            } else {
                //...
            }
        });
    });
    $(".upvote").on("click", function () {
        let upvotecounter = $("#upvote-count");
        let current = parseInt(upvotecounter.html().split(" ")[0]);
        let game_id = $(".upvote").attr("game_id");
        let user = $(".upvote").attr("user");
        $.ajax({
            url: "/Games/Like?game_id=" + game_id + "&user=" + user,
            success: function () {
                console.log("ok")
                if ($(".upvote").html().endsWith("Upvote")) {
                    $(".upvote").html("👎 Downvote");
                    current += 1;
                } else {
                    $(".upvote").html("👍 Upvote");
                    current -= 1;
                }
                upvotecounter.html(current + " upvotes");
            },
            error: function (err) {
                console.log("Error - upvote")
            }
        });
    });

    let width = $(".container-details").innerWidth();
    let height = $(".container-details").innerHeight();
    $(".background-image").width(width);
    $(".background-image").height(height);
    $(".background-black").width(width);
    $(".background-black").height(height);
    $(window).resize(function () {
        $(".background-image").width(width);
        $(".background-image").height(height);
        $(".background-black").width(width);
        $(".background-black").height(height);
    });
});

let margin = 700;
let short = "";
let text = $(".text-details").html();
let split = text.split(" ");
if (text.length > margin) {
    while (short.length < margin) {
        short += " " + split.shift();
    }
    $(".text-details").html(short + "...");
}
else { $(".btn-show-more").remove(); }

function showmore() {
    let btn = $(".btn-show-more");
    if (btn.html() == "show more") {
        btn.html("show less");
        $(".text-details").html(text);
    } else {
        btn.html("show more");
        $(".text-details").html(short + "...");
    }
}