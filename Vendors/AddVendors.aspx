<%@ Page Language="C#" Inherits="MicroErp.AddVendors" CodeFile="Businesslogic/AddVendors.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddVendors.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddVendors.js"></script>
        <title>Add Vendors</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add Vendors</h2>
            </div>
        </div>
        <form runat="server">
            <label>Vendor ID</label>
            <input type="text" id="VendorIdTxt" runat="server">
            <br>
            <label>Vendor Name</label>
            <input type="text" id="VendorNameTxt" runat="server">
            <br>
            <label>Address</label>
            <input type="text" id="AddressTxt" runat="server">
            <br>
            <label>Phone</label>
            <input type="text" id="PhoneTxt" runat="server">
            <br>
            <label>PAN</label>
            <input type="text" id="PanTxt" runat="server">
            <br>
            <input type="submit" runat="server" onserverclick="AddNewVendor">
        </form>
    </body>

    </html>