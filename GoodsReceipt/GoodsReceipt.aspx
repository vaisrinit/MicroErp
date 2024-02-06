<%@ Page Language="C#" Inherits="MicroErp.GoodsReceipt" CodeFile="Businesslogic/GoodsReceipt.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/GoodsReceipt.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/GoodsReceipt.js"></script>
        <title>Purchase Orders</title>

    </head>

    <body>
        <% if((string)Session["role"]=="EXECSTOR" || (string)Session["role"]=="MGRSTOR"){ %>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Goods Receipt</h2>
            </div>
            <div class="Addbtn">
                <button id="AddDetails">Add GRN</button>
            </div>
        </div>
        <form runat="server">
            <asp:Repeater id="GrnGrid" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>GRN ID</th>
                            <th>Vendor id</th>
                            <th>PO Number</th>
                            <th>Supplied on</th>
                            <th>Supplied at Stores</th>
                            <th>Gatepass #</th>
                            <th>View Line Items</th>
                            <th>Add Line Items</th>
                            <th>Edit</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("grn_id") %>
                        </td>
                        <td>
                            <%# Eval("vendor_id") %>
                        </td>
                        <td>
                            <%# Eval("po_number") %>
                        </td>
                        <td>
                            <%# Eval("supplied_on") %>
                        </td>
                        <td>
                            <%# Eval("supplied_store") %>
                        </td>
                        <td>
                            <%# Eval("gatepass_number") %>
                        </td>
                        <td>
                            <asp:Button id="ViewLineItemsbtn" runat="server" onClick="ViewLineItems"
                                CommandArgument='<%# Eval("grn_id") %>' Text="View"></asp:Button>
                        </td>
                        <td>
                            <asp:Button id="AddLineItemsbtn" runat="server" onClick="AddLineItems"
                                CommandArgument='<%# Eval("grn_id") %>' Text="Add"></asp:Button>
                        </td>
                        <td>
                            <asp:Button id="EditGrnbtn" runat="server" onClick="EditGRN"
                                CommandArgument='<%# Eval("grn_id") %>' Text="Edit"></asp:Button>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </form>
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
        <% } else { %>
            <h2>You are not authorized to see this screen</h2>
        <% } %>
    </body>

    </html>