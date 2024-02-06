<%@ Page Language="C#" Inherits="MicroErp.PurchaseOrder" CodeFile="Businesslogic/PurchaseOrder.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/PurchaseOrder.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/PurchaseOrder.js"></script>
        <title>Purchase Orders</title>

    </head>

    <body>
        <% if((string)Session["role"]=="EXECPURC" || (string)Session["role"]=="MGRPURC"){ %>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Purchase Order</h2>
            </div>
            <div class="Addbtn">
                <button id="AddDetails">Add PO</button>
                <button id="AddPoLI">Add PO Line Items</button>
            </div>
        </div>
        <form runat="server">
            <asp:Repeater id="PoGrid" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>PO Number</th>
                            <th>PO Date</th>
                            <th>Vendor ID</th>
                            <th>Required Before</th>
                            <th>Delivery Place</th>
                            <th>status</th>
                            <th>Comment</th>
                            <th>Given by</th>
                            <th>View Line Items</th>
                            <th>Edit</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("po_number") %>
                        </td>
                        <td>
                            <%# Eval("po_date","{0:yyyy-MM-dd}") %>
                        </td>
                        <td>
                            <%# Eval("vendor_id") %>
                        </td>
                        <td>
                            <%# Eval("materials_required_before","{0:yyyy-MM-dd}") %>
                        </td>
                        <td>
                            <%# Eval("expected_delivery_place") %>
                        </td>
                        <td>
                            <%# Eval("status") %>
                        </td>
                        <td>
                            <%# Eval("comment") %>
                        </td>
                        <td>
                            <%# Eval("created_by") %>
                        </td>
                        <td>
                            <asp:Button id="ViewLineItemsbtn" runat="server" onClick="ViewLineItems"
                                CommandArgument='<%# Eval("po_number") %>' Text="View"></asp:Button>
                        </td>
                        <td>
                            <asp:Button id="EditPobtn" runat="server" onClick="EditPO"
                                CommandArgument='<%# Eval("po_number") %>' Text="Edit"></asp:Button>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </form>
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
        <% } else { %>
            <h2>You are not authorized to see this screen</h2>
        <% } %>
    </body>

    </html>