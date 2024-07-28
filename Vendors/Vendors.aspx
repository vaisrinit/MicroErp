<%@ Page Language="C#" Inherits="MicroErp.Vendors" CodeFile="Businesslogic/Vendors.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/Vendors.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/Vendors.js"></script>
        <title>Employees</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Vendors</h2>
            </div>
            <div class="Addbtn">
                <button id="AddDetails">Add Vendors</button>
            </div>
        </div>
        <asp:Repeater id="VendorsGrid" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Vendor ID</th>
                        <th>Name</th>
                        <th>Address</th>
                        <th>Phone</th>
                        <th>PAN</th>

                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("vendor_id") %>
                    </td>
                    <td>
                        <%# Eval("name") %>
                    </td>
                    <td>
                        <%# Eval("address") %>
                    </td>
                    <td>
                        <%# Eval("phone") %>
                    </td>
                    <td>
                        <%# Eval("pan") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </body>

    </html>