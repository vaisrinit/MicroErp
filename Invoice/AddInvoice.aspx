<%@ Page Language="C#" Inherits="MicroErp.AddInvoice" CodeFile="Businesslogic/AddInvoice.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="../Styles/Common.css">
        <link rel="stylesheet" href="Styles/AddInvoice.css">
        <script src="../Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/AddInvoice.js"></script>
        <title>Add Invoice</title>

    </head>

    <body>
        <div class="MainHeader">
            <div class="Heading">
                <i class="material-icons back">arrow_back_ios</i>
                <h2 style="display: inline;">Add Invoice</h2>
            </div>
        </div>

        <form runat="server">
            <label>Invoice id</label>
            <input type="text" id="InvoiceIdTxt" runat="server">
            <br>
            <label>Invoice date and time</label>
            <input type="text" id="InvoiceDateTimeTxt" runat="server">
            <br>
            <label>Raised by</label>
            <input type="text" id="RaisedByTxt" runat="server" readeonly>
            <br>
            <label>GRN ID</label>
            <asp:DropDownList ID="GRNIdTxt" runat="server"></asp:DropDownList>

            <br>
            <input type="submit" runat="server" onserverclick="AddNewGI">
        </form>
    </body>

    </html>