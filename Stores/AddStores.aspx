<%@ Page Language="C#" Inherits="MicroErp.AddStores" CodeFile="Businesslogic/AddStores.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddStores.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddStores.js"></script>
        <title>Add Stores</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add Stores</h2>
            </div>
        </div>
        <form runat="server">
            <label>Plant ID</label>
            <asp:DropDownList ID="PlantIdTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Store ID</label>
            <input type="text" id="StoreIdTxt" runat="server">
            <br>
            <label>Store Name</label>
            <input type="text" id="StoreNameTxt" runat="server">
            <br>
            <input type="submit" runat="server" onserverclick="AddNewStore">
        </form>
    </body>

    </html>