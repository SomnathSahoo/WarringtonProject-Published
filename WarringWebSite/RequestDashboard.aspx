<%@ Page Title="" Language="C#" MasterPageFile="~/WarringtonMaster.master" AutoEventWireup="true" CodeFile="RequestDashboard.aspx.cs" Inherits="RequestDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
	        <div class="hdrBar bgClr" >
    	        <i class="fa fa-search"></i> View Previous Requests
            </div>
            <div class="whbody">
    	        <div class="whtbdy2">
        	
                    <form>
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
                    </form>
                        <div class="tblShowBx">
                                <div class="pgerBar">
                                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="inFldITT inptE" AutoPostBack="true">
                                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                        <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                        <asp:ListItem Value="50" Text="50"></asp:ListItem>
                                        <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="magic"></div>
                                </div>

                                <asp:GridView ID="grdRequests" runat="server" CssClass="hdingIt" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Request No">
                                            <ItemTemplate>
                                                <asp:label ID="lblRequestNo" runat="server" Text='<%#Eval("Request_No") %>'></asp:label>
                                                <asp:HiddenField ID="Label1" runat="server" Value='<%#Eval("Request_ID") %>' />
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
                                                <asp:Button ID="btnUpdate" Text="Update" CssClass="editlnk" runat="server"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                        </div> 
                </div>
            </div>
    </section>
    <div id="editDiv" runat="server" visible="false">
        <section>
	        <div class="hdrBar bgClr" >
    	        <i class="fa fa-pencil"></i> Create a New Request
            </div>
            <div class="whbody">
    	        <div class="whtbdy3">
     
                    <form>
                            <ul class="forbrdrIt">

	                            <li>
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
        	                            <label class="flbl"><input type="checkbox" /> Check the box to receive conformation by email.</label>
                                    </div>
                                    <div class="magic"></div>
                                </li>    
    
                               <li>
                                    <div class="btnBoxA">
   		                            <asp:Button ID="btnSendRequest" runat="server" Text="Send Request" CssClass="inptBtn bbtnA bgClr" />
                                    <div class="magic"></div>
                               </div>
                               </li>
    
                            </ul>
                    </form>        
        
                </div>
	        </div>
    </section>
    </div>
</asp:Content>

