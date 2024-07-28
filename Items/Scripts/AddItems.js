$(document).ready(function () {
    $(".back").click(function () {
        window.location.href = 'Items.aspx';
    });

    $("#AddItem").click(function () {
        var iserror = false;
        var item_code = $("#ItemCodeTxt").val();
        if (item_code.trim() == "") {
            $("#ItemCodeErr").text("Please enter Item Code");
            iserror = true;
        }
        var item_name = $("#ItemNameTxt").val();
        if (item_name.trim() == "") {
            $("#ItemCodeErr").text("Please enter Item Code");
            iserror = true;
        }
        var item_type = $("#ItemTypeTxt").val();
        if (item_type.trim() == "") {
            $("#ItemCodeErr").text("Please enter Item Code");
            iserror = true;
        }
        var price = $("#PriceTxt").val();
        if (price.trim() == "") {
            $("#ItemCodeErr").text("Please enter Item Code");
            iserror = true;
        }
        var discount = $("#CurrentDiscountTxt").val();
        if (discount.trim() == "") {
            $("#ItemCodeErr").text("Please enter Item Code");
            iserror = true;
        }
        var uom = $("#UOMTxt").val();
        if (uom.trim() == "") {
            $("#ItemCodeErr").text("Please enter Item Code");
            iserror = true;
        }
        if (!iserror) {
            var data = { "item_code": item_code, "item_name": item_name, "item_type": item_type, "price": price, "discount": discount, "uom": uom };
            $.ajax({
                type: "post",
                url: "AddItems.aspx/AddNewItems",
                data: JSON.stringify(data),
                contentType: "application/json",
                dataType: "json",
                success: function (response) {
                    alert(response.d);
                },
                failure:function(err1){
                    alert(err1)
                }
            });
        }

    })
});