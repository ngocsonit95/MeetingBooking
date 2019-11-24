
$(function () {

    ///back to top Create by QuyenIT
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('#back-top').fadeIn();
        } else {
            $('#back-top').fadeOut();
        }
    });
    $("#back-top").click(function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
    });

});
