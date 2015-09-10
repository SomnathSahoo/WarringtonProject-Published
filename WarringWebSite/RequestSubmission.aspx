<%@ Page Title="" Language="C#" MasterPageFile="~/WarringtonMaster.master" AutoEventWireup="true" CodeFile="RequestSubmission.aspx.cs" Inherits="RequestSubmission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Request Submission</title>
    <link href="App_Themes/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        jQuery(document).ready(function () {
            var htmlScript1 = '';
            var files = jQuery('input[id$=hdnFileName]').val().toString().split(',');
            for (var i = 0; i < files.length; i++) {
                if (files[i].toString().trim() != '') {
                    htmlScript1 += "<div class=\"fileOne\">" +
                                            "<div class=\"dltIt\"><i class=\"fa fa-trash-o\"></i></div>" +
                                            "<div class=\"fileIcn\"> <i class=\"fa fa-file-word-o\"></i></div>" +
                                           " <div class=\"fileNme\">" + files[i].toString() + " </div>	" + "</div>";
                }

            }
            htmlScript1 += "<div class=\"magic\"></div>";
            jQuery('.fileShowLst').html(htmlScript1);


            jQuery('input[type=file]').change(function () {
                var htmlScript = '';
                var files = jQuery('input[type=file]')[0].files;
                for (var i = 0; i < files.length; i++) {
                    if (files[i].name.toString().trim() != '') {
                        htmlScript += "<div class=\"fileOne\">" +
                                                "<div class=\"dltIt\"><i class=\"fa fa-trash-o\"></i></div>" +
                                                "<div class=\"fileIcn\"> <i class=\"fa fa-file-word-o\"></i></div>" +
                                               " <div class=\"fileNme\">" + files[i].name + " </div>	" + "</div>";
                    }
                }
                htmlScript += "<div class=\"magic\"></div>";
                jQuery('.fileShowLst').html(htmlScript);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdnFileName" runat="server" Value="" />
    <asp:HiddenField ID="hdnRequestID" runat="server" Value="0" />
    <section>
	        <div class="hdrBar bgClr" >
    	        <i class="fa fa-pencil"></i> Form Name Here
            </div>
            <div class="whbody">
    	        <div class="whtbdy2">
                    <form>
                        <ul class="forbrdrIt rgstrFrmA">

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
                                     <asp:TextBox ID="txtZipCode" runat="server" CssClass="inFldITT inptA rqrdFld"></asp:TextBox>


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
                                 <asp:TextBox ID="txtPrimaryPhoneNumber" runat="server" CssClass="inFldITT inptI rqrdFld"></asp:TextBox>

        
                                <label class="flbl lablJ">Primary Phone Type</label>
                                <asp:DropDownList ID="ddlPrimaryPhoneType" runat="server" CssClass="inFldITT inptK">
                                <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="Line" Text="Line"></asp:ListItem>
                                <asp:ListItem Value="Mobile" Text="Mobile"></asp:ListItem>
                            </asp:DropDownList>
        
                            <label class="flbl lablK">Mobile Provider</label>
                            <asp:DropDownList ID="ddlMobileProvider" runat="server" CssClass="inFldITT inptK">
                                <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="AT & T" Text="AT & T"></asp:ListItem>
                                <asp:ListItem Value="T-mobile" Text="Mobile"></asp:ListItem>
                                <asp:ListItem Value="Verizon" Text="Verizon"></asp:ListItem>
                            </asp:DropDownList>
                            </li>
                            <li>
    	                        <label class="flbl lablI">Secondary Phone Number</label>
                                 <asp:TextBox ID="txtSecondaryPhoneNumber" runat="server" CssClass="inFldITT inptI rqrdFld"></asp:TextBox>
        
                                <label class="flbl lablJ">Secondary Phone Type</label>
                               <asp:DropDownList ID="ddlSecondaryPhoneType" runat="server" CssClass="inFldITT inptK">
                                <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="Line" Text="Line"></asp:ListItem>
                                <asp:ListItem Value="Mobile" Text="Mobile"></asp:ListItem>
                            </asp:DropDownList>
        
                            <label class="flbl lablK">Mobile Provider</label>
                            <asp:DropDownList ID="ddlSecondaryMobileProvider" runat="server" CssClass="inFldITT inptK">
                                <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="AT & T" Text="AT & T"></asp:ListItem>
                                <asp:ListItem Value="T-mobile" Text="Mobile"></asp:ListItem>
                                <asp:ListItem Value="Verizon" Text="Verizon"></asp:ListItem>
                            </asp:DropDownList>
                            </li>
    
                            <li>
                                <div class="fclmA">
                                    <label class="flbl">Email ID</label>
                                     <asp:TextBox ID="txtEmailId" runat="server" CssClass="inFldITT inptA rqrdFld"></asp:TextBox>

                                </div>
                                <div class="fclmB">
                                    &nbsp;
                                </div>
                                <div class="magic"></div>
                            </li>
                            <li>
                                <label class="flbl lablI ">Preferred Contact Method</label>
                                <asp:DropDownList ID="ddlPrefContactMethod" runat="server" CssClass="inFldITT inptK">
                                <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="Email & Phone" Text="Email & Phone"></asp:ListItem>
                                <asp:ListItem Value="Phone" Text="Phone"></asp:ListItem>
                                <asp:ListItem Value="Email" Text="Email"></asp:ListItem>
                            </asp:DropDownList>
                            </li>
    
                            <li>
                                <label class="flbl">Address/Location of the Problem</label>
                                <asp:TextBox ID="txtProbLocation" runat="server" CssClass="inFldITT inptF" TextMode="MultiLine"></asp:TextBox>
                                <div class="magic"></div>
                            </li>    
    
                            <li>
                                <label class="flbl lablL ">Short Description of the Problem</label>
                                 <asp:TextBox ID="txtShortDescProblem" runat="server" CssClass="inFldITT inptA rqrdFld"></asp:TextBox>
                            </li>
    
                            <li>
                                <label class="flbl">Long Description of the problem</label>
                                 <asp:TextBox ID="txtLongDescProblem" runat="server" CssClass="inFldITT inptF" TextMode="MultiLine"></asp:TextBox>
                                <div class="magic"></div>
                            </li>
    
                            <li>
    	                        <div class="uplodArea">
        	                        <label class="flbl">Attech supporting document</label>
    		                        <asp:FileUpload ID="fileUpload" EnableViewState="false" AllowMultiple="true" runat="server"  /> 
                                    <div class="fileShowLst">
                                    </div>                 
                                </div>
                                <div class="magic"></div>
                            </li>
    
                            <li>
                                <div class="chkArea">
                                    <label class="flbl"><asp:CheckBox ID="chkConfirm" runat="server" Text="Confirmation by email" /> </label>
                                </div>
                                <div class="magic"></div>
                            </li>   
                            <li>
                                <div class="chkArea">
                                    <label class="flbl"><asp:CheckBox ID="chkOptLogin" runat="server" Text="Want to login" /> </label>
                                </div>
                                <div class="magic"></div>
                            </li>         
    
                           <li>
                               <div class="btnBoxA">
   		                            <asp:Button ID="btnSubmit" runat="server" CssClass="inptBtn bbtnC bgClr" Text="Submit" />
                                    <asp:Button ID="btnReset" runat="server" CssClass="inptBtn bbtnB" Text="Reset"  />
                                <div class="magic"></div>
                               </div>
                           </li>
    
                        </ul>
                    </form>
                </div>
            </div>
    </section>
</asp:Content>

