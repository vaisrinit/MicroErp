<%@ Page Language="C#" Inherits="MicroErp.Stores" CodeFile="Businesslogic/Stores.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/Stores.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/Stores.js"></script>
        <title>Employees</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Stores</h2>
            </div>
            <div class="Addbtn">
                <button id="AddDetails">Add Stores</button>
            </div>
        </div>
        <asp:Repeater id="StoresGrid" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Store ID</th>
                        <th>Plant ID</th>
                        <th>Store Name</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("store_id") %>
                    </td>
                    <td>
                        <%# Eval("plant_id") %>
                    </td>
                    <td>
                        <%# Eval("store_name") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </body>

    </html>