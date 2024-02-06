<%@ Page Language="C#" Inherits="MicroErp.GoodsInspection" CodeFile="Businesslogic/GoodsInspection.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/GoodsInspection.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/GoodsInspection.js"></script>
        <title>Purchase Orders</title>

    </head>

    <body>
        <% if((string)Session["role"]=="EXECQC" || (string)Session["role"]=="MGRQC" ){ %>
            <div class="MainHeader">
                <div class="Heading">
                    <i class="material-icons back">arrow_back_ios</i>
                    <h2 style="display: inline;">Goods Inspection</h2>
                </div>
                <div class="Addbtn">
                    <button id="AddDetails">Add GI</button>
                </div>
            </div>
            <form runat="server">
                <asp:Repeater id="GiGrid" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>GI Id</th>
                                <th>GRN ref Id</th>
                                <th>Inspected by</th>
                                <th>Inspected on</th>
                                <th>Inspected at time</th>
                                <th>Status</th>
                                <th>Comments</th>
                                <th>Add Line Items</th>
                                <th>View Line Items</th>
                                <th>Edit</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("gi_id") %>
                            </td>
                            <td>
                                <%# Eval("grn_id") %>
                            </td>
                            <td>
                                <%# Eval("created_by") %>
                            </td>
                            <td>
                                <%# Eval("created_on") %>
                            </td>
                            <td>
                                <%# Eval("created_on") %>
                            </td>
                            <td>
                                <%# Eval("status") %>
                            </td>
                            <td>
                                <%# Eval("comment") %>
                            </td>
                            <td>
                                <asp:Button id="AddLineItemsbtn" runat="server" onClick="AddLineItems"
                                    CommandArgument='<%# Eval("gi_id") %>' Text="Add LI"></asp:Button>
                            </td>
                            <td>
                                <asp:Button id="ViewLineItemsbtn" runat="server" onClick="ViewLineItems"
                                    CommandArgument='<%# Eval("gi_id") %>' Text="View"></asp:Button>
                            </td>
                            <td>
                                <asp:Button id="EditGrnbtn" runat="server" onClick="EditGI"
                                    CommandArgument='<%# Eval("gi_id") %>' Text="Edit"></asp:Button>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </form>
            <asp:Repeater id="GiLIGrid" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>GI ID</th>
                            <th>Item ID</th>
                            <th>Quantity Supplied</th>
                            <th>Quantity Accepted</th>
                            <th>Quantity Rejected</th>
                            <th>Comments</th>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("gi_id") %>
                        </td>
                        <td>
                            <%# Eval("item_code") %>
                        </td>
                        <td>
                            <%# Eval("quantity_supplied") %>
                        </td>
                        <td>
                            <%# Eval("quantity_accepted") %>
                        </td>
                        <td>
                            <%# Eval("quantity_rejected") %>
                        </td>
                        <td>
                            <%# Eval("comments") %>
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