$(document).ready(function () {
    //hover effect

    let def = $(".image").width;

/*    $(".image").on({
        mouseenter: function () {
            $(this).animate({ width: "+=1em", margin: "-=0.5em" }, 200);
        },
        mouseleave: function () {
            $(this).animate({ width: "-=1em", margin: "+=0.5em" }, 200)
        }
    });*/

    //paging
/*    let max = 9, current = 0;
    let images = $(".image");
    function reset(current) {
        for (let i in images) {
            if (images[i].id != undefined && Math.floor(parseInt(images[i].id.split("-")[1]) / max) != current) {
                images[i].hidden = true;
            } else { images[i].hidden = false; }
        }
        $(".page-number").html(current + 1);
    }*/

    //uncomment this for browsing
    //reset(current);
    $(".btn-left").on("click", function () {
        if (current != 0) {
            current--;
            reset(current);
        }
    });
    $(".btn-right").on("click", function () {
        if (current != Math.floor(images.length / max)) {
            current++;
            reset(current);
        }
    });
    $(".btn-rightmost").on("click", function () {
        current = Math.floor(images.length / max);
        reset(current);
    });
    $(".btn-leftmost").on("click", function () {
        current = 0;
        reset(current);
    });
});