var manage = new window.top.Manage();
var timer = null;
$(document).ready(function () {
    $(".head_pic").mousemove(function () {
        window.clearInterval(timer);
        $("#editHead").css("display", "block");

    });


    $(".head_pic").mouseout(function () {
        timer = window.setInterval(function () {
            $("#editHead").css("display", "none");
        }, 100);

    });

    $(":range").rangeinput({ progress: true });
    manage.setFramesHeight("#menuframe", $("body").height());

    /* Slide Toogle */
    var bclick = true;
    $(".menu li").click(function () {
        $(".menu li").removeClass("selected");
        $(this).addClass("selected");
    });


    $("ul.expmenu li > div.header").click(function () {

        var arrow = $(this).find("span.arrow");

        if (bclick && (arrow.hasClass("up") || arrow.hasClass("down"))) {
            bclick = false;
            if (arrow.hasClass("up")) {
                arrow.removeClass("up");
                arrow.addClass("down");
            }
            else if (arrow.hasClass("down")) {
                arrow.removeClass("down");
                arrow.addClass("up");
            }
            var menu = $(this).parent().find("ul.menu");

            if (menu.css("display") == "none") {
                manage.setFramesHeight("#menuframe", $("body").height() + menu.height());
            }
            manage.init();
            $(this).parent().find("ul.menu").slideToggle(function () {
                manage.setFramesHeight("#menuframe", $("body").height());
                bclick = true;
            });
        }

    });
});