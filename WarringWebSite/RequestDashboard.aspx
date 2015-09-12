<%@ Page Title="" Language="C#" MasterPageFile="~/WarringtonMaster.master" AutoEventWireup="true" CodeFile="RequestDashboard.aspx.cs" Inherits="RequestDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        jQuery(document).ready(function () {
            var htmlScript1 = '';
            var files = jQuery('input[id$=hdnFileList]').val().toString().split(',');
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
    <asp:HiddenField ID="hdnFileList" runat="server" Value="0" />
    <section>
	        <div class="hdrBar bgClr" >
    	        <i class="fa fa-search"></i> View Previous Requests
            </div>
            <div class="whbody">
    	        <div class="whtbdy2">
                            <ul class="forbrdrIt">

	                            <li>
                                    <div class="fclmA">
                                        <label class="flbl">Request Number</label>
                                        <asp:TextBox ID="txtRequestNo" runat="server" CssClass="inFldITT inptA" ></asp:TextBox>
                                    </div>
                                    <div class="fclmB">
                                        <label class="flbl">Status</label>
                                        <asp:TextBox ID="txtStatus" runat="server" CssClass="inFldITT inptB" ></asp:TextBox>
                                    </div>
                                    <div class="magic"></div>
                                </li>
    
                                <li>
                                    <label class="flbl">Request Date</label>
                                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="inFldITT inptC">
        	                            <asp:ListItem Value="=" Text="on"></asp:ListItem>
        	                            <asp:ListItem Value=">" Text="after"></asp:ListItem>
        	                            <asp:ListItem Value="<" Text="before"></asp:ListItem>
                                    </asp:DropDownList>
                                    
                                        <asp:TextBox ID="txtRequestDate" runat="server" CssClass="inFldITT inptD" placeholder="mm/dd/yyyy"  ></asp:TextBox>
                                    <div class="magic"></div>
                                </li>
    
                               <li>
                                       <div class="btnBoxA">
   		                                    <asp:Button ID="btnSearch" runat="server" CssClass="inptBtn bbtnA bgClr" Text="Search" />
                                           <asp:Button ID="btnReset" runat="server" CssClass="inptBtn bbtnB" Text="Reset" />
                                       <div class="magic"></div>
                                       </div>
                               </li>
    
                            </ul>
                        <div class="tblShowBx">
                                <div class="pgerBar">
                                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="inFldITT inptE">
                                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                        <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                        <asp:ListItem Value="50" Text="50"></asp:ListItem>
                                        <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="magic"></div>
                                </div>

                                <asp:GridView ID="grdRequests" runat="server" CssClass="hdingIt" AutoGenerateColumns="false" AllowPaging="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Request No">
                                            <ItemTemplate>
                                                <asp:label ID="lblRequestNo" runat="server" Text='<%#Eval("Request_No") %>'></asp:label>
                                                <asp:HiddenField ID="hdnRequestId" runat="server" Value='<%#Eval("Request_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Request Creation Date">
                                            <ItemTemplate>
                                                <asp:label ID="lblRequestDate" Text='<%#Eval("Request_Date") %>' runat="server"></asp:label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Request Change Date">
                                            <ItemTemplate>
                                                <asp:label ID="lblRequestChangeDate" Text='<%#Eval("Request_ChangeDate") %>' runat="server"></asp:label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:label ID="lblStatus" Text='<%#Eval("Request_Status") %>' runat="server"></asp:label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address of Prob">
                                            <ItemTemplate>
                                                <asp:label ID="lblProbAddress" Text='<%#Eval("Request_Address") %>' runat="server"></asp:label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Short Desc">
                                            <ItemTemplate>
                                                <asp:label ID="lblShortDesc" Text='<%#Eval("Request_ShortDesc") %>' runat="server"></asp:label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Long Desc">
                                            <ItemTemplate>
                                                <asp:label ID="lblLongDesc" Text='<%#Eval("Request_LongDesc") %>' runat="server"></asp:label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Update Request">
                                            <ItemTemplate>
                                                <asp:Button ID="btnUpdate" Text="Update" CssClass="editlnk" OnClick="btnUpdate_Click" runat="server"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                        </div> 
                </div>
            </div>
    </section>
    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        <section>
	        <div class="hdrBar bgClr" >
    	        <i class="fa fa-pencil"></i> Create a New Request
            </div>
            <div class="whbody">
    	        <div class="whtbdy3">
                            <ul class="forbrdrIt">

	                            <li>
                                    <asp:HiddenField ID="hdnReqId" runat="server" Value="0" />
                                    <label class="flbl">Address/Location of the Problem :</label>
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="inFldITT inptF" TextMode="MultiLine"></asp:TextBox>
                                    <div class="magic"></div>
                                </li>
    
                                <li>
                                    <label class="flbl">Enter a Short Description of the Request :</label>
                                    <asp:TextBox ID="txtShortDesc" runat="server" CssClass="inFldITT inptG"></asp:TextBox>
                                    <div class="magic"></div>
                                </li>
    
                                <li>
                                    <label class="flbl">Enter all details about the issue you feel are important :</label>
                                    <asp:TextBox ID="txtLongDesc" runat="server" CssClass="inFldITT inptH" TextMode="MultiLine"></asp:TextBox>
                                    <div class="magic"></div>
                                </li>
   
                                <li>
    	                            <div class="uplodArea">
        	                            <label class="flbl">Upload a Document :</label>
                                            <a class="hlpBtn" href="#">Help!</a>            	
    		                                <asp:FileUpload ID="fuploadDocs" runat="server" AllowMultiple="true" CssClass="fileTypeI" />        
	
                                            <div class="fileShowLst">
                                            </div>  
                                    </div>
                                    <div class="magic"></div>
                                </li>
    
    
                                <li>
    	                            <div class="chkArea">
        	                            <label class="flbl"><asp:CheckBox ID="chkConfirmEmail" runat="server" Text="Check the box to receive conformation by email." /></label>
                                    </div>
                                    <div class="magic"></div>
                                </li>    
    
                               <li>
                                    <div class="btnBoxA">
   		                            <asp:Button ID="btnSendRequest" runat="server" Text="Send Request" OnClick="btnSendRequest_Click" CssClass="inptBtn bbtnA bgClr" />
                                    <div class="magic"></div>
                               </div>
                               </li>
    
                            </ul>
                </div>
	        </div>
    </section>
    </asp:Panel>
</asp:Content>

