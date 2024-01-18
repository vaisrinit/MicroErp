<%@ Page Language="C#" Inherits="MicroErp.Items" CodeFile="Businesslogic/Items.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/Items.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/Items.js"></script>
        <title>Items</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Items</h2>
            </div>
            <div class="Addbtn">
                <button id="AddDetails">Add Items</button>
            </div>
        </div>
        <asp:Repeater id="ItemsGrid" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Item Code</th>
                        <th>Item Name</th>
                        <th>Item Type</th>
                        <th>Price</th>
                        <th>Current Discount</th>
                        <th>UOM</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("item_code") %>
                    </td>
                    <td>
                        <%# Eval("item_name") %>
                    </td>
                    <td>
                        <%# Eval("item_type") %>
                    </td>
                    <td>
                        <%# Eval("price") %>
                    </td>
                    <td>
                        <%# Eval("current_discount") %>
                    </td>
                    <td>
                        <%# Eval("uom") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </body>

    </html>