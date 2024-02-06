<%@ Page Language="C#" Inherits="MicroErp.Departments" CodeFile="Businesslogic/Departments.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/Departments.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/Departments.js"></script>
        <title>Departments</title>
    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Departments</h2>
            </div>
            <div class="Addbtn">
                <button id="AddDetails">Add Department</button>
            </div>
        </div>
        <asp:Repeater id="DepartmentsGrid" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Department ID</th>
                        <th>Department Name</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("department_id") %>
                    </td>
                    <td>
                        <%# Eval("department_name") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </body>

    </html>