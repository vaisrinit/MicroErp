$(document).ready(function () {
    
    
    $(".back").click(function () {
        window.location.href = "../Master.aspx";
    });

    $("#AddDetails").click(function () {
        window.location.href = "AddEmployees.aspx";
    });
    var page = parseInt($("#PageTxt").val());
    var data = {"page":page};
    $.ajax({
        type: "post",
        url: "Employees.aspx/Paginate",
        data: JSON.stringify(data),
        dataType: "json",
        contentType:"application/json",
        success: function (response) {
            var emp_json = JSON.parse(response.d);
            var emp_table = "<table id=EmpTable><tr><th>Employee ID</th><th>Employee Name</th><th>Phone</th><th>Address</th><th>Email</th><th>Date of Joining</th></tr>";

            $.each(emp_json, function (indexInArray, valueOfElement) { 
                emp_table+="<tr><td>"+valueOfElement.employee_id+"</td><td>"+valueOfElement.name+"</td><td>"+valueOfElement.phone+"</td><td>"+valueOfElement.address+"</td><td>"+valueOfElement.email+"</td><td>"+valueOfElement.date_of_joining+"</td></tr>";
            });
            emp_table+="</table>"
            console.log(emp_table);
            $("#EmpTable").html(emp_table);
        }
    });
});