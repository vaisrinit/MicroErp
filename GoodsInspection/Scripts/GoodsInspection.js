$(document).ready(function () {
    $(".back").click(function(){
        window.location.href="../Transactions.aspx";
    });

    $("#AddDetails").click(function(){
        window.location.href="AddGoodsInspection.aspx";
    });
    $("#AddGiLI").click(function(){
        window.location.href="AddGILineItems.aspx";
    });
});