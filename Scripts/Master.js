$(document).ready(function () {
    $(".Employees").click(function(){
        window.location.href="Employees/Employees.aspx";
    });

    $(".Items").click(function(){
        window.location.href="Items/Items.aspx";
    });

    $(".Plants").click(function(){
        window.location.href="Plants/Plants.aspx";
    });

    $(".Stores").click(function(){
        window.location.href="Stores/Stores.aspx";
    });

    $(".Vendors").click(function(){
        window.location.href="Vendors/Vendors.aspx";
    });

    $(".back").click(function(){
        window.location.href="HomePage.aspx";
    });
});