<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Log In</title>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>

    <link href="font/font-awesome-4.4.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'>
    <script type="text/javascript">
        WebFontConfig = {
            google: { families: ['Open+Sans::latin'] }
        };
        (function () {
            var wf = document.createElement('script');
            wf.src = ('https:' == document.location.protocol ? 'https' : 'http') +
              '://ajax.googleapis.com/ajax/libs/webfont/1/webfont.js';
            wf.type = 'text/javascript';
            wf.async = 'true';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(wf, s);
        })();
    </script>
    <script type="text/javascript">

        var CheckValidation = function () {
            var totalControlToValidate = jQuery('.rqrdFld').length;
            var validationCount = 0;
            jQuery('.rqrdFld').each(function () {
                var currentControl = jQuery(this);
                var validationMessage = currentControl.prev().text() + " is Mandatory.";
                if (currentControl.is('input') && currentControl.val().trim() == "") {
                    if (currentControl.parent().is('div')) {
                        currentControl.parent().next().find('.bubble').remove();
                        currentControl.parent().next().append("<span class='bubble'>" + validationMessage + "</span>");
                    }
                    else if (currentControl.parent().is('li')) {
                        currentControl.parent().find('.bubble').remove();
                        currentControl.parent().append("<span class='bubble'>" + validationMessage + "</span>");
                    }
                    validationCount++;
                }
            });

            if (validationCount == 0) {
                return true;
            }
            else
                return false;
        }
        var ClearAllValidationMessage = function () {
            if (confirm("Are you sure to reset all fields") == true) {
                jQuery('.bubble').remove();
                return true;
            }
            else
                return false;
        }

        jQuery(document).ready(function () {
            jQuery('.rqrdFld').blur(function () {
                var currentControl = jQuery(this);
                var validationMessage = currentControl.prev().text() + " is Mandatory.";
                if (currentControl.is('input') && currentControl.val().trim() == "") {
                    if (currentControl.parent().is('div')) {
                        currentControl.parent().next().find('.bubble').remove();
                        currentControl.parent().next().append("<span class='bubble'>" + validationMessage + "</span>");
                    }
                    else if (currentControl.parent().is('li')) {
                        currentControl.parent().find('.bubble').remove();
                        currentControl.parent().append("<span class='bubble'>" + validationMessage + "</span>");
                    }
                }
                else {
                    if (currentControl.parent().is('div')) {
                        currentControl.parent().next().find('.bubble').remove();
                    }
                    else if (currentControl.parent().is('li')) {
                        currentControl.parent().find('.bubble').remove();
                    }
                }
            });
        });
    </script>

    <link href="App_Themes/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>

            <div class="hdrAA">
                <div class="page">
                    <div class="logoBx lginLgo">
	                    <i class="fa-pagelines fa"></i> Warrington<strong>Township</strong>
                    </div>
                </div>
            </div>
        </header>
        <div class="frmArea">
            <div class="page">
                <section class="logInBx">
	                <div class="hdrBar bgClr" >
    	                <i class="fa fa-unlock-alt"></i> LogIn
                    </div>
                    <div class="whbody">
    	                <div class="whtbdy2">
                            <form>
                                <ul class="forbrdrIt rgstrFrmA">

	                                <li>
                                        <label class="flbl"><i class="fa fa-phone"></i> Phone No</label>
                                        <asp:TextBox ID="txtUserId" runat="server" CssClass="inFldITT inwdtA rqrdFld" ></asp:TextBox>
                                    </li>
    
                                    <li>
                                        <label class="flbl"><i class="fa fa-lock"></i> Pin Number</label>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="inFldITT inwdtA rqrdFld" TextMode="Password"></asp:TextBox>
                                    </li>
    
                                   <li>
                                   <div class="logSbx">
   		                                <asp:Button ID="btnLogin" runat="server" Text="LOGIN" CssClass="inptBtn bbtnC bgClr" />
                                       <asp:Button ID="btnCancel" runat="server" CssClass="inptBtn bbtnB" Text="CANCEl" />
                                        <div class="frgt">
        	                                Forgot password? <a href="#">Click here</a>
                                        </div>
                                        <div class="magic"></div>
                                   </div>
                                   </li>
    
                                </ul>
                            </form>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </form>
</body>
</html>
