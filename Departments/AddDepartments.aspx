<%@ Page Language="C#" Inherits="MicroErp.AddDepartments" CodeFile="Businesslogic/AddDepartments.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddDepartments.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddDepartments.js"></script>
        <title>Add Departments</title>
    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add Departments</h2>
            </div>
        </div>

        <form runat="server">
            <label>Department ID</label>
            <input type="text" id="DepartmentIdTxt" runat="server">
            <br>
            <label>Department Name</label>
            <input type="text" id="DepartmentNameTxt" runat="server">
            <br>
            <input type="submit" runat="server" onserverclick="AddNewDepartment">
        </form>
    </body>

    </html>