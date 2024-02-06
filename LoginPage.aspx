<%@ Page Language="C#" Inherits="MicroErp.LoginPage" CodeFile="Businesslogic/LoginPage.aspx.cs" %>
    <!DOCTYPE>
    <html>

    <head>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <link rel="stylesheet" href="Styles/Common.css">

        <link rel="stylesheet" href="Styles/LoginPage.css">
        <script src="Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/LoginPage.js"></script>
        <title>Login Page</title>

    </head>

    <body>

        <form runat="server">
            <h1>Welcome To Login Page</h1>
            <label>Username</label>
            <input type="text" id="UserNameTxt" runat="server">
            <br>
            <label>Password</label>
            <input type="text" id="PasswordTxt" runat="server">
            <br>
            <input type="submit" runat="server" onserverclick="Login">
        </form>
        <div>
            This tag is Opened by Charu
        </div>
    </body>
    <div>
         This tag  is opened by Subathra
    </div>

    </html>