<%@ Page Language="C#" Inherits="MicroErp.AddEmployees" CodeFile="Businesslogic/AddEmployees.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddEmployees.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddEmployees.js"></script>
        <title>Add Employees</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add Employees</h2>
            </div>
        </div>
        <form>
            <label>Employee ID</label>
            <input type="text" id="EmployeeIdTxt">
            <br>
            <label>Name</label>
            <input type="text" id="NameTxt">
            <br>
            <label>Phone</label>
            <input type="text" id="PhoneTxt">
            <br>
            <label>Address</label>
            <input type="text" id="AddressTxt" >
            <br>
            <label>Email</label>
            <input type="text" id="EmailTxt">
            <br>
            <label>DOB</label>
            <input type="text" id="DOBTxt" >
            <br>
            <label>DOJ</label>
            <input type="text" id="DOJTxt">
            <br>
            <label>Department</label>
            <select id="DepartmentTxt"></select>
            <br>
            <label>Role</label>
            <select id="RolesTxt"></select>
            <br>
        </form>
        <button id="AddEmployeebtn">Submit</button>
    </body>

    </html>