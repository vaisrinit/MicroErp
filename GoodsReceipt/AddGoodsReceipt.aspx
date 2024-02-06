<%@ Page Language="C#" Inherits="MicroErp.AddGoodsReceipt" CodeFile="Businesslogic/AddGoodsReceipt.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddPurchaseOrder.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddGoodsReceipt.js"></script>
        <title>Add GRN</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add GRN</h2>
            </div>
        </div>
        <form runat="server">
            <label>Vendor ID</label>
            <asp:DropDownList ID="VendorIdTxt" runat="server"></asp:DropDownList>
            <br>
            <label>PO Number</label>
            <asp:DropDownList ID="PoNumberTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Supplied on</label>
            <input type="text" id="SuppliedDateTxt" runat="server">
            <br>
            <label>Supplied plant</label>
            <asp:DropDownList ID="SuppliedPlantTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Supplied Stores</label>
            <asp:DropDownList ID="SuppliedStoreTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Gatepass Number</label>
            <input type="text" id="GatepassTxt" runat="server">
            <br>
            <label>GRN Given By</label>
            <input type="text" id="GivenByTxt" runat="server" readonly>
            <br>
            <input type="submit" runat="server" onserverclick="AddNewGRN">
        </form>
    </body>

    </html>