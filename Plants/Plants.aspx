<%@ Page Language="C#" Inherits="MicroErp.Plants" CodeFile="Businesslogic/Plants.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/Plants.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/Plants.js"></script>
        <title>Plants</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Plants</h2>
            </div>
            <div class="Addbtn">
                <button id="AddDetails">Add Plants</button>
            </div>
        </div>
        <asp:Repeater id="PlantsGrid" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Plant ID</th>
                        <th>Plant Name</th>
                        <th>Address</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("plant_id") %>
                    </td>
                    <td>
                        <%# Eval("plant_name") %>
                    </td>
                    <td>
                        <%# Eval("address") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </body>

    </html>