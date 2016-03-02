$(function () {
    var listaItems = ["Novedades", "Recomendaciones", "MasVistos"];

    for (i = 0; i < listaItems.length; i++) {
        $("#" + listaItems[i] + " .SeriePeliculas .Lista").css("width", $("#" + listaItems[i] + " .SeriePeliculas .Lista li").length * 85);
    }

    $('.Next').click(function () {
        $("#" + $(this).parent().attr("id") + " .SeriePeliculas").scrollLeft($("#" + $(this).parent().attr("id") + " .SeriePeliculas").scrollLeft() + 80);
    });
    $('.Prev').click(function () {
        $("#" + $(this).parent().attr("id") + " .SeriePeliculas").scrollLeft($("#" + $(this).parent().attr("id") + " .SeriePeliculas").scrollLeft() - 80);
    });

});