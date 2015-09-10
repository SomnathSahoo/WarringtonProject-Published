<%@ Page Title="" Language="C#" MasterPageFile="~/WarringtonMaster.master" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Warrington User Registration</title> 
    <link href="App_Themes/css/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
	    <div class="hdrBar bgClr" >
    	    <i class="fa fa-pencil"></i> Resident Registration with Warrington Twp
        </div>
        <div class="whbody">
    	    <div class="whtbdy2">
                <form>
                    <ul class="forbrdrIt rgstrFrmA">
                        <li id="liMessage" runat="server">
                            <div class="fclmA">
                                <asp:Label ID="lblMessage" runat="server" CssClass="bubble" Text="You are not registered. Please register to log in."></asp:Label>
                            </div>
                            <div class="fclmB">
                                &nbsp;
                            </div>
                            <div class="magic"></div>
                        </li>
	                    <li>
                            <div class="fclmA">
                                <label class="flbl">First Name</label>
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="inFldITT inptA rqrdFld"></asp:TextBox>
                            </div>
                            <div class="fclmB">
                                &nbsp;
                            </div>
                            <div class="magic"></div>
                        </li>
    
                        <li>
                            <div class="fclmA">
                                <label class="flbl">Last Name</label>
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="inFldITT inptA rqrdFld"></asp:TextBox>
                            </div>
                            <div class="fclmB">
                                &nbsp;
                            </div>
                            <div class="magic"></div>
                        </li>
                        <li>
    	                    <label class="flbl">Address1</label>
                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="inFldITT inptA rqrdFld"></asp:TextBox>
                        </li>
                        <li>
    	                    <label class="flbl">Address2</label>
                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="inFldITT inptA rqrdFld"></asp:TextBox>
                        </li>
                        <li>
                            <div class="fclmA">
                                <label class="flbl">Zip Code</label>
                                 <asp:TextBox ID="txtZipCode" runat="server" CssClass="inFldITT inptA rqrdFld number" MaxLength="5"></asp:TextBox>
                            </div>
                            <div class="fclmB">
                                &nbsp;
                            </div>
                            <div class="magic"></div>
                        </li>
                        <li>
                            <div class="fclmA">
                                <label class="flbl">City</label>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="inFldITT inptA rqrdFld"></asp:TextBox>
                            </div>
                            <div class="fclmB">
                                &nbsp;
                            </div>
                            <div class="magic"></div>
                        </li>
                        <li>
                            <div class="fclmA">
                                <label class="flbl">State</label>
                                 <asp:DropDownList ID="ddlState" runat="server" CssClass="inFldITT inptA rqrdFld" ></asp:DropDownList>
                            </div>
                            <div class="fclmB">
                                &nbsp;
                            </div>
                            <div class="magic"></div>
                        </li>
    
                        <li>
    	                    <label class="flbl lablI">Primary Phone Number</label>
                             <asp:TextBox ID="txtPrimaryPhoneNumber" runat="server" CssClass="inFldITT inptI rqrdFld" ></asp:TextBox>
        
                            <label class="flbl lablJ">Primary Phone Type</label>
                            <asp:DropDownList ID="ddlPrimaryPhoneType" runat="server" CssClass="inFldITT inptK">
                                <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="Line" Text="Line"></asp:ListItem>
                                <asp:ListItem Value="Mobile" Text="Mobile"></asp:ListItem>
                            </asp:DropDownList>
        
                            <label class="flbl lablK">Mobile Provider</label>
                            <asp:DropDownList ID="ddlMobileProvider" runat="server" CssClass="inFldITT inptK">
                                <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="AT & T" Text="AT & T"></asp:ListItem>
                                <asp:ListItem Value="T-mobile" Text="Mobile"></asp:ListItem>
                                <asp:ListItem Value="Verizon" Text="Verizon"></asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        <li>
    	                    <label class="flbl lablI">Secondary Phone Number</label>
                              <asp:TextBox ID="txtSecondaryPhoneNumber" runat="server" CssClass="inFldITT inptI" ></asp:TextBox>
                            <label class="flbl lablJ">Secondary Phone Type</label>
                            <asp:DropDownList ID="ddlSecondaryPhoneType" runat="server" CssClass="inFldITT inptK">
                                <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="Line" Text="Line"></asp:ListItem>
                                <asp:ListItem Value="Mobile" Text="Mobile"></asp:ListItem>
                            </asp:DropDownList>
        
                            <label class="flbl lablK">Mobile Provider</label>
                            <asp:DropDownList ID="ddlSecondaryMobileProvider" runat="server" CssClass="inFldITT inptK">
                                <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="AT & T" Text="AT & T"></asp:ListItem>
                                <asp:ListItem Value="T-mobile" Text="Mobile"></asp:ListItem>
                                <asp:ListItem Value="Verizon" Text="Verizon"></asp:ListItem>
                            </asp:DropDownList>
                        </li>
    
                        <li>
                            <div class="fclmA">
                                <label class="flbl">Email ID</label>
                                 <asp:TextBox ID="txtEmailId" runat="server" CssClass="inFldITT inptA rqrdFld email" ></asp:TextBox>
                            </div>
                            <div class="fclmB">
                                &nbsp;
                            </div>
                            <div class="magic"></div>
                        </li>
                        <li>
                            <div class="fclmA">
                                <label class="flbl">Pin</label>
                                <asp:TextBox ID="txtPin" runat="server" TextMode="Password" CssClass="inFldITT inptA rqrdFld compare1" ></asp:TextBox>
                            </div>
                            <div class="fclmB">
                                &nbsp;
                            </div>
                            <div class="magic"></div>
                        </li>
                        <li>
                            <div class="fclmA">
                                <label class="flbl">Retype Pin</label>
                                 <asp:TextBox ID="txtRetypePin" runat="server" TextMode="Password" CssClass="inFldITT inptA rqrdFld compare2" ></asp:TextBox>
                            </div>
                            <div class="fclmB">
                                &nbsp;
                            </div>
                            <div class="magic"></div>
                        </li>

                        <li>
                            <label class="flbl lablI ">Preferred Contact Method</label>
                            <asp:DropDownList ID="ddlPrefContactMethod" runat="server" CssClass="inFldITT inptK">
                                <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="Email & Phone" Text="Email & Phone"></asp:ListItem>
                                <asp:ListItem Value="Phone" Text="Phone"></asp:ListItem>
                                <asp:ListItem Value="Email" Text="Email"></asp:ListItem>
                            </asp:DropDownList>
                        </li>

                        <li>
                            <div class="chkArea">
                                <label class="flbl"><asp:CheckBox ID="chkAgreePolicy" runat="server" Text="I agree with Privacy rules of Warrington Portal" /> </label>
                            </div>
                            <div class="magic"></div>
                        </li>        
    
                       <li>
                           <div class="btnBoxA">
   		                        <asp:Button ID="btnRegister" runat="server" CssClass="inptBtn bbtnC bgClr"  Text="Register" />
                                <asp:Button ID="btnReset" runat="server" CssClass="inptBtn bbtnB" Text="Reset" />
                                <div class="magic"></div>
                           </div>
                       </li>
    
                    </ul>
                </form>
            </div>
        </div>
    </section>
</asp:Content>

