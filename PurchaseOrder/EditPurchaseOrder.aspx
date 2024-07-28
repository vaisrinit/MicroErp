<%@ Page Language="C#" Inherits="MicroErp.EditPurchaseOrder" CodeFile="Businesslogic/EditPurchaseOrder.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddPurchaseOrder.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddPurchaseOrder.js"></script>
        <title>Add PO</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Edit PO</h2>
            </div>
        </div>
        <asp:Repeater id="PoLIGrid" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>

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
        <hr>
        <form runat="server">
            <% if((string)Session["role"]=="EXECPURC" ){ %>
                <div>
                    <label>PO Number</label>
                    <input type="text" id="PoNumberTxt" runat="server" readonly>
                    <br>
                    <label>PO Date</label>
                    <input type="text" id="PoDateTxt" runat="server">
                    <br>
                    <label>Vendor ID</label>
                    <input type="text" id="VendorIdTxt" runat="server">
                    <br>
                    <label>Materials Required Before</label>
                    <input type="text" id="RequiredBeforeTxt" runat="server">
                    <br>
                    <label>Delivery Place</label>
                    <input type="text" id="DeliveryPlaceTxt" runat="server">
                    <br>
                    <input type="submit" runat="server" onserverclick="EditPO">
                </div>
            <% } else if ((string)Session["role"]=="MGRPURC" ){ %>
                <div>
                    <label>PO Number</label>
                    <input type="text" id="MPoNumberTxt" runat="server">
                    <br>
                    <label>PO Date</label>
                    <input type="text" id="MPoDateTxt" runat="server">
                    <br>
                    <label>Vendor ID</label>
                    <input type="text" id="MVendorIdTxt" runat="server">
                    <br>
                    <label>Materials Required Before</label>
                    <input type="text" id="MRequiredBeforeTxt" runat="server">
                    <br>
                    <label>Delivery Place</label>
                    <input type="text" id="MDeliveryPlaceTxt" runat="server">
                    <br>
                    <label>Status</label>
                    <input type="text" id="MStatusTxt" runat="server">
                    <br>
                    <label>Comments</label>
                    <input type="text" id="MCommentsTxt" runat="server">
                    <br>
                    <input type="submit" runat="server" onserverclick="EditPO">
                </div>
            <% } %>
        </form>
           
    </body>

    </html>