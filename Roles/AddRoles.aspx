<%@ Page Language="C#" Inherits="MicroErp.AddRoles" CodeFile="Businesslogic/AddRoles.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddRoles.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddRoles.js"></script>
        <title>Add Roles</title>
    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add Roles</h2>
            </div>
        </div>

        <form>
            <label>Role ID</label>
            <input type="text" id="RoleIdTxt">
            <br>
            <label>Department ID</label>
            <select id="department_names">
                <option>None</option>
            </select>
            <br>
            <label>Role Name</label>
            <input type="text" id="RoleNameTxt">
            <br>
        </form>
        <div style="text-align: center;">
            <button id="SubmitNewbtn">Submit</button>
        </div>
    </body>

    </html>