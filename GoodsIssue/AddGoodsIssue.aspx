<%@ Page Language="C#" Inherits="MicroErp.AddGoodsIssue" CodeFile="Businesslogic/AddGoodsIssue.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddGoodsIssue.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddGoodsIssue.js"></script>
        <title>Add Issue</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add Issue</h2>
            </div>
        </div>
        <form runat="server">
            <label>GIS ID</label>
            <input type="text" id="GISIDTxt" runat="server">
            <br>
            <label>Issued By</label>
            <input type="text" id="IssuedByTxt" runat="server">
            <br>
            <label>Issued on</label>
            <input type="text" id="IssuedOnTxt" runat="server">
            <br>
            <label>Issued to Department</label>
            <asp:DropDownList ID="IssueToDeptTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Issued to person</label>
            <asp:DropDownList ID="IssueToTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Item code</label>
            <asp:DropDownList ID="ItemCodeTxt" runat="server"></asp:DropDownList>
            <br>
            <label>Quantity</label>
            <input type="text" id="QuantityTxt" runat="server">
            <br>
            <label>Comments</label>
            <input type="text" id="CommentsTxt" runat="server">
            <br>
            <input type="submit" runat="server" onserverclick="AddNewIssue">
        </form>
    </body>

    </html>