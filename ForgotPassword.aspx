<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Forgot Password</title>
<link rel="shortcut icon" href="images/top.ico" type="image/icon"  />
<link href="css/960.css" rel="stylesheet" type="text/css" media="all" />
<link href="css/reset.css" rel="stylesheet" type="text/css" media="all" />
<link href="css/text.css" rel="stylesheet" type="text/css" media="all" />
<link href="css/login.css" rel="stylesheet" type="text/css" media="all" />
 <style type="text/css">
        .style1
        {
            font-size: xx-large;
        }
    </style>
</head>

<body>
<img src="images/logo.jpg" height="100" width="200"/><marquee ><font color="white" class="style1" font-family="Lucida Handwriting" >School Employee Management System</font></marquee>
<br />
<form id="Form1" runat="server">


<div class="container_16">

    <div class="grid_6 prefix_5 suffix_5">
   	    <h1><font color="black">Forgot Password</font></h1>
    	<div id="login">  <p>
              <strong>  <asp:Label ID="lblusername" runat="server" Text="Username"></asp:Label></strong>
<%--<input type="text" name="textfield" class="inputText"  id="textfield" />
    	      </label>--%>
                  <asp:TextBox ID="TxtUsername" runat="server" class="textbox"></asp:TextBox>
  	      </p>
    		<%--<a class="black_button" href="dashboard.html"><span>Authentification</span></a>
            --%> 
             <p class="error">
                 <asp:Label ID="IfError" runat="server"
                     Text="Enter Correct Username" Visible="False"></asp:Label></p>
             <p class="tip">
                 <asp:Label ID="IfNoError" runat="server" 
                     Text="Your Password is sent to your Email Please Check It Out" Visible="False"></asp:Label></p>
            
          <asp:Button ID="Btnsubmit" runat="server" Text="Submit" onclick="Btnsubmit_Click" class="black_button"/>            
    	 
		  <br clear="all" />
    	</div>
        <div id="forgot">
        <a href="Login.aspx" class="forgotlink"><span>Login</span></a></div>
  </div>
</div>
</form>
<br clear="all" />
</body>

</html>
