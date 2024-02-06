$(document).ready(function () {
    $(".back").click(function(){
        window.location.href="../Transactions.aspx";
    });

    $("#AddDetails").click(function(){
        window.location.href="AddGoodsReceipt.aspx";
    });
    $("#AddPoLI").click(function(){
        window.location.href="AddGRNLineItems.aspx";
    });
});