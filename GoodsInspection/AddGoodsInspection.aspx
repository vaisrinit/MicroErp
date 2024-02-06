<%@ Page Language="C#" Inherits="MicroErp.AddGoodsInspection" CodeFile="Businesslogic/AddGoodsInspection.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddGoodsInspection.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddGoodsInspection.js"></script>
        <title>Add GI</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add GI</h2>
            </div>
        </div>
        
        <form runat="server">
            <label>GI ID</label>
            <input type="text" id="GIIdTxt" runat="server">
            <br>
            <label>GRN ID</label>
            <asp:DropDownList ID="GRNIdTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Inspected by</label>
            <input type="text" id="InspectedByTxt" runat="server" readeonly>
            <br>
            
            <input type="submit" runat="server" onserverclick="AddNewGI">
        </form>
    </body>

    </html>