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
        <asp:Repeater id="EmployeesGrid" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Employee ID</th>
                        <th>Employee Name</th>
                        <th>Phone</th>
                        <th>Address</th>
                        <th>Email</th>
                        <th>Date of Birth</th>
                        <th>Date of Joining</th>
                        <th>Role ID</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("employee_id") %>
                    </td>
                    <td>
                        <%# Eval("name") %>
                    </td>
                    <td>
                        <%# Eval("phone") %>
                    </td>
                    <td>
                        <%# Eval("address") %>
                    </td>
                    <td>
                        <%# Eval("email") %>
                    </td>
                    <td>
                        <%# Eval("date_of_birth","{0:yyyy-MM-dd}") %>
                    </td>
                    <td>
                        <%# Eval("date_of_joining","{0:yyyy-MM-dd}") %>
                    </td>
                    <td>
                        <%# Eval("role_id") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </body>

    </html>