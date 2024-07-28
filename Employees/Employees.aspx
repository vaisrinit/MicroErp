<%@ Page Language="C#" Inherits="MicroErp.Employees" CodeFile="Businesslogic/Employees.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/Employees.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/Employees.js"></script>
        <title>Employees</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Employees</h2>
            </div>
            <div class="Addbtn">
                <button id="AddDetails">Add Employee</button>
            </div>
        </div>
        <input type="hidden" id="PageTxt" value="1">
        <table id="EmpTable"></table>
        <div class="paginate">
            <i class="material-icons pagebtn" id="firstpage">first_page</i>
            <i class="material-icons pagebtn" id="previouspage">arrow_back_ios</i>
            <i class="material-icons pagebtn" id="nextpage">arrow_forward_ios</i>
            <i class="material-icons pagebtn" id="lastpage">last_page</i>
        </div>
    </body>

    </html>