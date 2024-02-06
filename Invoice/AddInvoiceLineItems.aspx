<%@ Page Language="C#" Inherits="MicroErp.AddInvoiceLineItems" CodeFile="Businesslogic/AddInvoiceLineItems.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddInvoiceLineItems.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddInvoiceLineItems.js"></script>
        <title>Add GI Line Items</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add Invoice Line Items</h2>
            </div>
        </div>
        <asp:Repeater id="GrnLIGrid" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>GRN ID</th>
                        <th>Item ID</th>
                        <th>Quantity Supplied</th>
                        <th>UOM</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("grn_id") %>
                    </td>
                    <td>
                        <%# Eval("item_code") %>
                    </td>
                    <td>
                        <%# Eval("quantity_supplied") %>
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
        <hr>
        <form runat="server">
            <label>GI Id</label>
            <input type="text" id="GiIdTxt" runat="server" readonly>
            <br>
            <label>Item ID</label>
            <input type="text" id="ItemCodeTxt" runat="server">
            <br>
            <label>Quantity Accepted</label>
            <input type="text" id="QuantityTxt" runat="server">
            <br>
            <label>Comments</label>
            <input type="text" id="CommentsTxt" runat="server">
            <br>
            <input type="submit" runat="server" onserverclick="AddNewGILineItem">
        </form>
    </body>

    </html>