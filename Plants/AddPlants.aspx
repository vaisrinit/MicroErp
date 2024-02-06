<%@ Page Language="C#" Inherits="MicroErp.AddPlants" CodeFile="Businesslogic/AddPlants.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddPlants.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddPlants.js"></script>
        <title>Add Plants</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add Plants</h2>
            </div>
        </div>
        <form runat="server">
            <label>Plant ID</label>
            <input type="text" id="PlantIdTxt" runat="server">
            <br>
            <label>Plant Name</label>
            <input type="text" id="PlantNameTxt" runat="server">
            <br>
            <label>Address</label>
            <input type="text" id="AddressTxt" runat="server">
            <br>
            <input type="submit" runat="server" onserverclick="AddNewPlant">
        </form>
    </body>

    </html>