<%@ Page Language="C#" Inherits="MicroErp.AddGRNLineItems" CodeFile="Businesslogic/AddGRNLineItems.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddPOLineItems.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddGRNLineItems.js"></script>
        <title>Add GRN Line Items</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add GRN Line Items</h2>
            </div>
        </div>

        <form runat="server">
            <asp:Repeater id="PoLIGrid" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>PO Number</th>
                            <th>Item ID</th>
                            <th>Cost</th>
                            <th>Tax</th>
                            <th>Quantity</th>
                            <th>UOM</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("po_number") %>
                        </td>
                        <td>
                            <%# Eval("item_code") %>
                        </td>
                        <td>
                            <%# Eval("price") %>
                        </td>
                        <td>
                            <%# Eval("tax") %>
                        </td>
                        <td>
                            <%# Eval("quantity") %>
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
            <label>GRN ID</label>
            <input type="text" id="GrnIdTxt" runat="server" readonly>
            <br>
            <label>Item ID</label>
            <asp:DropDownList ID="ItemCodeTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Quantity Supplied</label>
            <input type="text" id="QuantityTxt" runat="server">
            <br>
            <input type="submit" runat="server" onserverclick="AddNewGRNLineItem">
        </form>
    </body>

    </html>