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
        <form runat="server">
            <label>Employee ID</label>
            <input type="text" id="EmployeeIdTxt" runat="server">
            <br>
            <label>Name</label>
            <input type="text" id="NameTxt" runat="server">
            <br>
            <label>Phone</label>
            <input type="text" id="PhoneTxt" runat="server">
            <br>
            <label>Address</label>
            <input type="text" id="AddressTxt" runat="server">
            <br>
            <label>Email</label>
            <input type="text" id="EmailTxt" runat="server">
            <br>
            <label>DOB</label>
            <input type="text" id="DOBTxt" runat="server">
            <br>
            <label>DOJ</label>
            <input type="text" id="DOJTxt" runat="server">
            <br>
            <label>Department</label>
            <asp:DropDownList ID="DepartmentTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Role</label>
            <asp:DropDownList ID="RoleTxt" runat="server"></asp:DropDownList>
            
            <br>
            <input type="submit" runat="server" onserverclick="AddNewEmployee">
        </form>
    </body>

    </html>