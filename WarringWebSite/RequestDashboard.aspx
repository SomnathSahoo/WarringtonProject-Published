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
                                        <asp:BoundField HeaderText="Request No" DataField="Request_No" />
                                        <asp:BoundField HeaderText="Request Creation Date" DataField="Request_Date" />
                                        <asp:BoundField HeaderText="Request Change Date" DataField="Request_ChangeDate" />
                                        <asp:BoundField HeaderText="Status" DataField="Request_Status" />
                                        <asp:BoundField HeaderText="Address of Prob" DataField="Request_Address" />
                                        <asp:BoundField HeaderText="Short Desc" DataField="Request_ShortDesc" />
                                        <asp:BoundField HeaderText="Long Desc" DataField="Request_No" />
                                        <asp:BoundField HeaderText="Supporting Doc" DataField="Request_No" />
                                        <asp:BoundField HeaderText="Update Request" DataField="Request_No" />
                                    </Columns>
                                </asp:GridView>
                        </div> 
                </div>
            </div>
    </section>
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
                                    <textarea class="inFldITT inptF"></textarea>
                                    <div class="magic"></div>
                                </li>
    
                                <li>
                                    <label class="flbl">Enter a Short Description of the Request :</label>
                                    <input class="inFldITT inptG" type="text" />
                                    <div class="magic"></div>
                                </li>
    
                                <li>
                                    <label class="flbl">Enter all details about the issue you feel are important :</label>
                                    <textarea class="inFldITT inptH"></textarea>
                                    <div class="magic"></div>
                                </li>
   
                                <li>
    	                            <div class="uplodArea">
        	                            <label class="flbl">Upload a Document :</label>
                                            <a class="hlpBtn" href="#">Help!</a>            	
    		                                <input type="file" class="fileTypeI">        
	
                                            <div class="fileShowLst">
                                                        <div class="fileOne">
                                                            <div class="dltIt"><i class="fa fa-trash-o"></i></div>
                                                            <div class="fileIcn"> <i class="fa fa-file-word-o"></i></div>
                                                            <div class="fileNme">
                                                                fileName.doc
                                                            </div>	
                                                        </div>
    
                                                        <div class="fileOne">
                                                            <div class="dltIt"><i class="fa fa-trash-o"></i></div>
                                                            <div class="fileIcn"> <i class="fa fa-file-code-o"></i></div>
                                                            <div class="fileNme">
                                                                fileName.html
                                                            </div>	
                                                        </div>
    
                                                        <div class="fileOne">
                                                            <div class="dltIt"><i class="fa fa-trash-o"></i></div>
                                                            <div class="fileIcn"> <i class="fa fa-file-excel-o"></i></div>
                                                            <div class="fileNme">
                                                                fileName.xlsx
                                                            </div>	
                                                        </div>
    
                                                        <div class="fileOne">
                                                            <div class="dltIt"><i class="fa fa-trash-o"></i></div>
                                                            <div class="fileIcn"> <i class="fa fa-file-archive-o"></i></div>
                                                            <div class="fileNme">
                                                                fileName.zip
                                                            </div>	
                                                        </div>
    
                                                        <div class="fileOne">
                                                            <div class="dltIt"><i class="fa fa-trash-o"></i></div>
                                                            <div class="fileIcn"> <i class="fa fa-file-image-o"></i></div>
                                                            <div class="fileNme">
                                                                fileName.jpg
                                                            </div>	
                                                        </div>
    
                                                        <div class="fileOne">
                                                            <div class="dltIt"><i class="fa fa-trash-o"></i></div>
                                                            <div class="fileIcn"> <i class="fa fa-file-picture-o"></i></div>
                                                            <div class="fileNme">
                                                                fileName.png
                                                            </div>	
                                                        </div>
                                                        <div class="fileOne">
                                                            <div class="dltIt"><i class="fa fa-trash-o"></i></div>
                                                            <div class="fileIcn"> <i class="fa fa-file-pdf-o"></i></div>
                                                            <div class="fileNme">
                                                                fileName.pdf
                                                            </div>	
                                                        </div>
                                                        <div class="fileOne">
                                                            <div class="dltIt"><i class="fa fa-trash-o"></i></div>
                                                            <div class="fileIcn"> <i class="fa fa-file-text-o"></i></div>
                                                            <div class="fileNme">
                                                                fileName.txt
                                                            </div>	
                                                        </div>
                                                        <div class="fileOne">
                                                            <div class="dltIt"><i class="fa fa-trash-o"></i></div>
                                                            <div class="fileIcn"> <i class="fa fa-file-sound-o"></i></div>
                                                            <div class="fileNme">
                                                                fileName.mp3
                                                            </div>	
                                                        </div>
    
                                                        <div class="magic"></div>
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
   		                            <button class="inptBtn bbtnA bgClr">Send Request</button>
                                    <div class="magic"></div>
                               </div>
                               </li>
    
                            </ul>
                    </form>        
        
                </div>
	        </div>
    </section>
</asp:Content>

