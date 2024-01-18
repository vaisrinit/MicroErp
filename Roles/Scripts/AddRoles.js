$(document).ready(function () {
    $(".back").click(function () {
        window.location.href = 'Roles.aspx';
    });

    $.ajax({
        type: "post",
        url: "AddRoles.aspx/GetDepartments",
        data: "{}",
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            var dept_json = JSON.parse(response.d);
            var dept_select = "<select><option value=null>NONE</option>"
            $.each(dept_json, function (indexInArray, valueOfElement) {
                dept_select += "<option value='" + valueOfElement.department_id + "'>" + valueOfElement.department_name + "</option>"
            });
            dept_select += "</select>";
            console.log(dept_select);
            $("#department_names").html(dept_select);
        }
    });

    $("#SubmitNewbtn").click(function () {
        var role_id = $("#RoleIdTxt").val();
        var department_id = $("#department_names").val();
        var role_name = $("#RoleNameTxt").val();
        var data = {"role_id":role_id,"department_id":department_id,"role_name":role_name};
        $.ajax({
            type: "post",
            url: "AddRoles.aspx/AddNewRole",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                console.log(response.d);
            }
        });

    })
});