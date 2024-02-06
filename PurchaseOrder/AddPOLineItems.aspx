<%@ Page Language="C#" Inherits="MicroErp.AddPOLineItems" CodeFile="Businesslogic/AddPOLineItems.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddPOLineItems.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddPOLineItems.js"></script>
        <title>Add PO Line Items</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add PO Line Items</h2>
            </div>
        </div>
        
        <form runat="server">
            <label>PO Number</label>
            <asp:DropDownList ID="PoNumberTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Item Code</label>
            <asp:DropDownList ID="ItemCodeTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Tax</label>
            <input type="text" id="TaxTxt" runat="server">
            <br>
            <label>Quantity</label>
            <input type="text" id="QuantityTxt" runat="server">
            <br>
            <input type="submit" runat="server" onserverclick="AddNewPOLineItem">
        </form>
    </body>

    </html>