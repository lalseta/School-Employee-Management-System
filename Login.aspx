<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Login</title>
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
<form runat="server">


<div class="container_16">

    <div class="grid_6 prefix_5 suffix_5">
   	    <h1><font color="black">Login - SEMS</font></h1>
    	<div id="login">
    	  <p>
              <strong>  <asp:Label ID="lblusername" runat="server" Text="Username"></asp:Label></strong>
<%--<input type="text" name="textfield" class="inputText"  id="textfield" />
    	      </label>--%>
                  <asp:TextBox ID="Txtusername" runat="server" class="textbox"></asp:TextBox>
  	      </p>
    	    <p>
               <strong> <asp:Label ID="lblpass" runat="server" Text="Password" ></asp:Label></strong>
                <asp:TextBox ID="Txtpassword" runat="server" class="textbox" TextMode="Password"></asp:TextBox>
    	      <%--<label><strong>Password</strong>
  <input type="password" name="textfield2" class="inputText" id="textfield2" />
  	        </label>--%>
    	    </p>
            <p>
               <strong> <asp:Label ID="lblDesignation" runat="server" Text="Designation" ></asp:Label></strong>
                <%--<asp:TextBox ID="TextBox1" runat="server" class="inputText"></asp:TextBox>--%>
                 <asp:DropDownList ID="Ddldesignation"  
                        DataSourceID="SqlDataSource1" DataTextField="DesignationName" runat="server" 
                        DataValueField="DesignationId" class="textbox" Width="308">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:SEMSConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_Designation]"></asp:SqlDataSource>
              
    	      <%--<label><strong>Password</strong>
  <input type="password" name="textfield2" class="inputText" id="textfield2" />
  	        </label>--%>
    	    </p>
    		<%--<a class="black_button" href="dashboard.html"><span>Authentification</span></a>
            --%> 
            
            
            
          <asp:Button ID="Btnlogin" runat="server" Text="Login" onclick="Btnlogin_Click" class="black_button"/>
            <label>&nbsp;Remember me<asp:CheckBox ID="chkRememberMe" runat="server" /></label>
    	 
		  <br clear="all" />
    	</div>
        <div id="forgot">
        <a href="ForgotPassword.aspx" class="forgotlink"><span>Forgot your username or password?</span></a></div>
  </div>
</div>
</form>
<br clear="all" />
</body>

</html>
