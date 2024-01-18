<%@ Page Language="C#" Inherits="MicroErp.GoodsIssue" CodeFile="Businesslogic/GoodsIssue.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/GoodsIssue.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/GoodsIssue.js"></script>
        <title>Goods Issue</title>

    </head>

    <body>
        <% if((string)Session["role"]=="EXECSTOR" || (string)Session["role"]=="MGRSTOR" ){ %>
            <div class="MainHeader">
                <div class="Heading">
                    <i class="material-icons back">arrow_back_ios</i>
                    <h2 style="display: inline;">Goods Issue</h2>
                </div>
                <div class="Addbtn">
                    <button id="AddDetails">Add Issue</button>
                </div>
            </div>
            <form runat="server">
                <asp:Repeater id="GISGrid" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>GIS ID</th>
                                <th>Issued By</th>
                                <th>Issued Date and Time</th>
                                <th>Issue to person</th>
                                <th>Issued to department</th>
                                <th>Item code</th>
                                <th>UOM</th>
                                <th>Quantity</th>
                                <th>Comments</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("gis_id") %>
                            </td>
                            <td>
                                <%# Eval("issued_by") %>
                            </td>
                            <td>
                                <%# Eval("issued_on") %>
                            </td>
                            <td>
                                <%# Eval("issued_to") %>
                            </td>
                            <td>
                                <%# Eval("department_id") %>
                            </td>
                            <td>
                                <%# Eval("item_code") %>
                            </td>
                            <td>
                                <%# Eval("uom") %>
                            </td>
                            <td>
                                <%# Eval("quantity") %>
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
            </form>
            <% } else { %>
                <h2>You are not authorized to see this screen</h2>
                <% } %>
    </body>

    </html>