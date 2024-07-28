$(document).ready(function () {
    $(".back").click(function(){
        window.location.href="../Transactions.aspx";
    });

    $("#AddDetails").click(function(){
        window.location.href="AddInvoice.aspx";
    });
    $("#AddGiLI").click(function(){
        window.location.href="AddInvoiceLineItems.aspx";
    });
});