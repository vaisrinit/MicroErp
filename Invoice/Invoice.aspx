<%@ Page Language="C#" Inherits="MicroErp.Invoice" CodeFile="Businesslogic/Invoice.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/Invoice.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/Invoice.js"></script>
        <title>Invoice</title>

    </head>

    <body>
        <% if((string)Session["role"]=="OUTVEND" ){ %>
            <div class="MainHeader">
                <div class="Heading">
                    <i class="material-icons back">arrow_back_ios</i>
                    <h2 style="display: inline;">Invoice</h2>
                </div>
                <div class="Addbtn">
                    <button id="AddDetails">Add Invoice</button>
                </div>
            </div>
            <form runat="server">
                <asp:Repeater id="InvGrid" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>Invoice id</th>
                                <th>Invoice date and time</th>
                                <th>Raised by vendor id</th>
                                <th>GRN ref id</th>
                                <th>View Line Items</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("invoice_id") %>
                            </td>
                            <td>
                                <%# Eval("invoice_date") %>
                            </td>
                            <td>
                                <%# Eval("raised_by") %>
                            </td>
                            <td>
                                <%# Eval("grn_id") %>
                            </td>
                            <td>
                                <asp:Button id="ViewLineItemsbtn" runat="server" onClick="ViewLineItems"
                                    CommandArgument='<%# Eval("grn_id") %>' Text="View"></asp:Button>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </form>
            <asp:Repeater id="InvLIGrid" runat="server">
                								
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Item Code</th>
                            <th>Unit of measurement</th>
                            <th>Ordered Qty</th>
                            <th>Supplied Qty</th>
                            <th>Accepted Qty</th>
                            <th>price per uom</th>
                            <th>Cost before tax</th>
                            <th>Tax</th>
                            <th>Cost After Tax</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("item_code") %>
                        </td>
                        <td>
                            <%# Eval("uom") %>
                        </td>
                        <td>
                            <%# Eval("quantity_ordered") %>
                        </td>
                        <td>
                            <%# Eval("quantity_supplied") %>
                        </td>
                        <td>
                            <%# Eval("quantity_accepted") %>
                        </td>
                        <td>
                            <%# Eval("price") %>
                        </td>
                        <td>
                            <%# Eval("cost_before_tax") %>
                        </td>
                        <td>
                            <%# Eval("tax") %>
                        </td>
                        <td>
                            <%# Eval("price_after_tax") %>
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