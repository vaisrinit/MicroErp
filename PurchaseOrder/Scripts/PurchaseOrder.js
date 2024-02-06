$(document).ready(function () {
    $(".back").click(function(){
        window.location.href="../Transactions.aspx";
    });

    $("#AddDetails").click(function(){
        window.location.href="AddPurchaseOrder.aspx";
    });
    $("#AddPoLI").click(function(){
        window.location.href="AddPOLineItems.aspx";
    });
});