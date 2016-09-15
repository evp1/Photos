(function () {
    var $sidebar = $("#sidebar");

    $("#sidebar").on("mousemove", function () {
        $sidebar.addClass("open-sidebar");
    });

    $("#sidebar").on("mouseleave", function () {
        $sidebar.removeClass("open-sidebar");
    });
 
})();