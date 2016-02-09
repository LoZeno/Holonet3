jQuery.fn.center = function (parent) {
    if (parent) {
        parent = this.parent();
    } else {
        parent = window;
    }
    this.css({
        "position": "absolute",
        "top": ((($(window).height() - this.outerHeight()) / 2) + $(window).scrollTop() + "px"),
        "left": ((($(window).width() - this.outerWidth()) / 2) + $(window).scrollLeft() + "px")
    });
    return this;
}