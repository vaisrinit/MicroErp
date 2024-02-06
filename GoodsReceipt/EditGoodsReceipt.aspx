<%@ Page Language="C#" Inherits="MicroErp.EditGoodsReceipt" CodeFile="Businesslogic/EditGoodsReceipt.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddPurchaseOrder.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddGoodsReceipt.js"></script>
        <title>Edit GRN</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Edit GRN</h2>
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
            <% if((string)Session["role"]=="EXECSTOR" ){ %>
                <div>
                    
                    <label>Vendor ID</label>
                    <input type="text" id="VendorIdTxt" runat="server">
                    <br>
                    <label>PO Number</label>
                    <input type="text" id="PoNumberTxt" runat="server">
                    <br>
                    <label>Supplied on</label>
                    <input type="text" id="SuppliedDateTxt" runat="server">
                    <br>
                    <label>Supplied plant</label>
                    <input type="text" id="SuppliedPlantTxt" runat="server">
                    <br>
                    <label>Supplied Stores</label>
                    <input type="text" id="SuppliedStoreTxt" runat="server">
                    <br>
                    <label>Gatepass Number</label>
                    <input type="text" id="GatepassTxt" runat="server">
                    <br>
                    <input type="submit" runat="server" onserverclick="EditGRN">
                </div>
                <% } else if ((string)Session["role"]=="MGRSTOR" ){ %>
                    <div>
                        <label>Vendor ID</label>
                        <input type="text" id="MVendorIdTxt" runat="server">
                        <br>
                        <label>PO Number</label>
                        <input type="text" id="MPoNumberTxt" runat="server">
                        <br>
                        <label>Supplied on</label>
                        <input type="text" id="MSuppliedDateTxt" runat="server">
                        <br>
                        <label>Supplied plant</label>
                        <input type="text" id="MSuppliedPlantTxt" runat="server">
                        <br>
                        <label>Supplied Stores</label>
                        <input type="text" id="MSuppliedStoreTxt" runat="server">
                        <br>
                        <label>Gatepass Number</label>
                        <input type="text" id="MGatepassTxt" runat="server">
                        <br>
                        <label>Status</label>
                        <input type="text" id="MStatusTxt" runat="server">
                        <br>
                        <label>Comments</label>
                        <input type="text" id="MCommentsTxt" runat="server">
                        <br>
                        <input type="submit" runat="server" onserverclick="EditGRN">
                    </div>
                    <% } %>
        </form>

    </body>

    </html>