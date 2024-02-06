<%@ Page Language="C#" Inherits="MicroErp.AddItems" CodeFile="Businesslogic/AddItems.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddItems.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddItems.js"></script>
        <title>Add Items</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add Items</h2>
            </div>
        </div>
        <form runat="server">
            <label>ITEM code
            </label>
            <input type="text" id="ItemCodeTxt" runat="server">
            <br>
            <label>Item name</label>
            <input type="text" id="ItemNameTxt" runat="server">
            <br>
            <label>Item type</label>
            <input type="text" id="ItemTypeTxt" runat="server">
            <br>
            <label>Price</label>
            <input type="text" id="PriceTxt" runat="server">
            <br>
            <label>Current discount</label>
            <input type="text" id="CurrentDiscountTxt" runat="server">
            <br>
            <label>Unit of Measurement</label>
            <input type="text" id="UOMTxt" runat="server">
            <br>
            <input type="submit" runat="server" onserverclick="AddNewItems">
        </form>
    </body>

    </html>