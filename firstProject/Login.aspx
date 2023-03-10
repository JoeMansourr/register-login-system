<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="firstProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="LoginForm.css" rel="stylesheet" />
    <script src="https://code.iconify.design/2/2.2.1/iconify.min.js"></script>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="true"/>
    <link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>  
    <title>Login Form</title>
</head>
<body>
    <div class="container">
        <div class="signup">
            <div class="img">
                <img src="img.jpg" alt="Alternate Text" />
                <div class="msg">
                    <h1>Welcome!</h1>
                    <div class="msg2">
                        <p>To keep Connected with us Please Login.</p>
                    </div>
                </div>
            </div>
            <form runat="server">
                <h1>Login</h1>
                <div class="credentials">
                    <!--<span class="iconify" data-icon="ei:sc-facebook" data-width="40" data-height="40"></span>-->
                    <!--<span class="iconify" data-icon="typcn:social-instagram" data-width="35" data-height="40"></span>-->
                    <!--<span class="iconify" data-icon="ei:sc-github" data-width="40" data-height="40"></span>-->
                    <!--<span class="iconify" data-icon="ei:sc-twitter" data-width="40" data-height="40"></span>-->
                </div>
                <!--<span>or use your email for registration</span>-->
                <div class="input">
                    <!--<asp:TextBox Text="User ID" ID="userID" runat="server"></asp:TextBox>-->
                    <!--<span class="iconify" data-icon="wpf:name" data-width="50"></span>--><asp:TextBox ID="username" runat="server" placeholder="Name or Email" required="true"></asp:TextBox>
                    <!--<span class="iconify" data-icon="clarity:email-line" data-width="50"></span><asp:TextBox ID="email" runat="server" placeholder="Email" Type="email"></asp:TextBox>-->
                    <!--<span class="iconify" data-icon="heroicons-solid:lock-closed" data-width="50"></span>--><asp:TextBox ID="password" runat="server" placeholder="Password" Type="password" required="true"></asp:TextBox>                  
                    <asp:Button Text="Sign in" runat="server" id="signup"/>
                    <span class="acc">don't have an account? <a href="Register.aspx">Sign up</a></span>
                    <asp:Label Text="" ID="status" runat="server"></asp:Label>
                </div>
            </form>
        </div>
    </div>
</body>
</html>