$(document).ready(function () {
    $(".back").click(function () {
        window.location.href = 'Employees.aspx';
        $('#mySelect').focus().click();
    });
    $.ajax({
        type: "post",
        url: "AddEmployees.aspx/GetDepartments",
        data: "{}",
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            var depts_json = JSON.parse(response.d);
            var depts_select = "<select id='DepartmentTxt'><option value=null>NONE</option>";
            $.each(depts_json, function (indexInArray, valueOfElement) {
                depts_select += "<option value=" + valueOfElement.department_id + ">" + valueOfElement.department_id + "</option>"
            });
            depts_select += "</select>";
            console.log(depts_select);
            $("#DepartmentTxt").html(depts_select);
        }
    });

    $("#DepartmentTxt").change(function () {
        var data = {"department_id":$(this).val()};
        $.ajax({
            type: "post",
            url: "AddEmployees.aspx/GetRoles",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                var roles_json = JSON.parse(response.d);
                var roles_select = "<select id='RolesTxt'><option value=null>NONE</option>";
                $.each(roles_json, function (indexInArray, valueOfElement) {
                    roles_select += "<option value=" + valueOfElement.role_id + ">" + valueOfElement.role_id + "</option>"
                });
                roles_select += "</select>";
                console.log(roles_select);
                $("#RolesTxt").html(roles_select);
            }
        });
    });
});