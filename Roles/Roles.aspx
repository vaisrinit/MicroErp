<%@ Page Language="C#" Inherits="MicroErp.Roles" CodeFile="Businesslogic/Roles.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/Roles.js"></script>
        <title>Roles</title>
    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Roles</h2>
            </div>
            <div class="Addbtn">
                <button id="AddDetails">Add Roles</button>
            </div>
        </div>
        <asp:Repeater id="RolesGrid" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Role ID</th>
                        <th>Department ID</th>
                        <th>Role Name</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("role_id") %>
                    </td>
                    <td>
                        <%# Eval("department_id") %>
                    </td>
                    <td>
                        <%# Eval("role_name") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </body>

    </html>