<%@ Page Language="C#" Inherits="MicroErp.AddPurchaseOrder" CodeFile="Businesslogic/AddPurchaseOrder.aspx.cs" %>
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
                <h2 style="display: inline;">Add PO</h2>
            </div>
        </div>
        
        <form runat="server">
            <label>PO Number</label>
            <input type="text" id="PoNumberTxt" runat="server">
            <br>
            <label>PO Date</label>
            <input type="text" id="PoDateTxt" runat="server">
            <br>
            <label>Vendor ID</label>
            <asp:DropDownList ID="VendorIdTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Materials Required Before</label>
            <input type="text" id="RequiredBeforeTxt" runat="server">
            <br>
            <label>Delivery Place</label>
            <asp:DropDownList ID="DeliveryPlaceTxt" runat="server"></asp:DropDownList>

            <br>
            <label>PO Given By</label>
            <input type="text" id="GivenByTxt" runat="server" readonly>
            <br>
            <input type="submit" runat="server" onserverclick="AddNewPO">
        </form>
    </body>

    </html>