<%@ Page Language="C#" Inherits="MicroErp.EditGoodsInspection" CodeFile="Businesslogic/EditGoodsInspection.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/EditGoodsInspection.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddGoodsInspection.js"></script>
        <title>Edit GRN</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Edit GI</h2>
            </div>
        </div>
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
        <hr>
        <form runat="server">
            <% if((string)Session["role"]=="EXECQC" ){ %>
                <div>

                    <label>GI ID</label>
                    <input type="text" id="GiIdTxt" runat="server" readonly>
                    <br>
                    <label>GRN ID</label>
                    <input type="text" id="GRNIdTxt" runat="server" readonly>
                    <br>
                    <label>Inspected By</label>
                    <input type="text" id="InspectedByTxt" runat="server" readonly>
                    <br>
                    
                    <input type="submit" runat="server" onserverclick="EditGI">
                </div>
                <% } else if ((string)Session["role"]=="MGRQC" ){ %>
                    <div>
                        <label>GI ID</label>
                        <input type="text" id="MGiIdTxt" runat="server" readonly>
                        <br>
                        <label>GRN ID</label>
                        <input type="text" id="MGRNIdTxt" runat="server" readonly>
                        <br>
                        <label>Inspected By</label>
                        <input type="text" id="MInspectedByTxt" runat="server" readonly>
                        <br>
                        <label>Status</label>
                        <input type="text" id="MStatusTxt" runat="server">
                        <br>
                        <label>Comments</label>
                        <input type="text" id="MCommentsTxt" runat="server">
                        <br>
                        <input type="submit" runat="server" onserverclick="EditGI">
                    </div>
                    <% } %>
        </form>

    </body>

    </html>