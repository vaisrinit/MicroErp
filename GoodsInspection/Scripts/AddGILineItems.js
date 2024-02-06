$(document).ready(function () {
    $(".back").click(function () {
        window.location.href = 'GoodsInspection.aspx';
    });
    var data = { "gi_id": $("#GiIdTxt").val() };
    var item_json, x;
    $.ajax({
        type: "post",
        url: "AddGILineItems.aspx/GetItems",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            item_json = JSON.parse(response.d);
            var item_select = "<select><option value=null>NONE</option>"
            $.each(item_json, function (indexInArray, valueOfElement) {
                item_select += "<option value='" + valueOfElement.item_code + "'>" + valueOfElement.item_code + "</option>"
            });
            item_select += "</select>";
            console.log(item_select);
            $("#items").html(item_select);
        }
    });
    $("#items").change(function () {
        x = item_json.filter((x) => x.item_code == $(this).val());
        $("#QuantityTxt").val(0);
        $("#QuantityRejectedTxt").val(x[0].quantity_supplied);
    });
    $("#QuantityTxt").on("input", function () {
        $("#QuantityRejectedTxt").val(x[0].quantity_supplied - parseInt($(this).val()));
    });
    $("#AddLibtn").click(function () {
        var gi_id = $("#GiIdTxt").val();
        var item_code = $("#items").val();
        var quantity_accepted = $("#QuantityTxt").val();
        var quantity_rejected = $("#QuantityRejectedTxt").val();
        var comments = $("#CommentsTxt").val();
        var created_by = $("#AddedByTxt").val();

        var data = {"gi_id":gi_id,"item_code":item_code,"quantity_accepted":parseInt(quantity_accepted),"quantity_rejected":parseInt(quantity_rejected),"comments":comments,"created_by":created_by};
        $.ajax({
            type: "post",
            url: "AddGILineItems.aspx/AddNewGILineItem",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                console.log(response)
            }
        });
    })
});

