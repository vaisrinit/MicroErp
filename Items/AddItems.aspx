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
        <form>
            <label>ITEM code
            </label>
            <input type="text" id="ItemCodeTxt">
            <span id="ItemCodeErr"></span>
            <br>
            <label>Item name</label>
            <input type="text" id="ItemNameTxt">
            <br>
            <label>Item type</label>
            <input type="text" id="ItemTypeTxt">
            <br>
            <label>Price</label>
            <input type="text" id="PriceTxt">
            <br>
            <label>Current discount</label>
            <input type="text" id="CurrentDiscountTxt">
            <br>
            <label>Unit of Measurement</label>
            <input type="text" id="UOMTxt">
            <br>
        </form>
        <button id ="AddItem">Submit</button>
    </body>
    </html>