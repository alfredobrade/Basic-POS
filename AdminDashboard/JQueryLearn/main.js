// $("selector").accion

// $(document).ready(function(){
//esto es para cuando el documento esta cargado
//empezar a ejecutar el jquery
// });
// $(function(){
//esto es lo mismo que el anterior pero corto
// });

$("h1").hide();

$(document).ready(function () {
    $("#chau").css({"background-color":"red"})
    $("#click1").click(function(){
        //alert("Hola")
        $("#chau").hide()
    })
    $("#click1").dblclick(function(){
        //alert("Hola")
        alert($("#chau").attr("style"))
    })
    $("#click2").click(function(){
        $("#chau").show()
    })

});