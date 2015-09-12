using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WarringtonBll;
using WarringtonEntity;
using WarringtonHelper;
public partial class RequestDashboard : System.Web.UI.Page
{
    WarringtonBll.WarringtonBll objBll = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Utility.GetSessionValue<bool>(Constants._USERISLOGGEDIN))
            {
                BindSearchGrid();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        btnReset.Click += btnReset_Click;
        btnSearch.Click += btnSearch_Click;
        grdRequests.PageIndexChanging += grdRequests_PageIndexChanging;
    }

   protected void grdRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdRequests.PageIndex = e.NewPageIndex;
        grdRequests.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        DataTable dtSearchResult = Utility.GetSessionValue<DataTable>(Constants._SEARCHREQUESTDATA);
        if (!dtSearchResult.DataTableIsEmpty())
        {
            grdRequests.DataSource = dtSearchResult;
            grdRequests.DataBind();
        }
        else
        {
            grdRequests.Dispose();
            grdRequests.DataBind();
        }
    }
   protected void btnSendRequest_Click(object sender, EventArgs e)
    {
        objBll = new WarringtonBll.WarringtonBll();
        List<DocRepository> lstDocs = new List<DocRepository>();
        UserRequest lstUserRequest = new UserRequest()
        {
            RequestId=Convert.ToInt32(hdnReqId.Value),
            CreateDate = DateTime.UtcNow,
            ProblemLocation = txtAddress.Text,
            ShortDescription = txtShortDesc.Text,
            LongDescription = txtLongDesc.Text,
            EmailConfirmation = chkConfirmEmail.Checked,
            Status = "U",
            UpdateDate=DateTime.UtcNow
        };
        RequestStatus lstRequestStatus = new RequestStatus()
        {
            Status = "U",
            UpdateDate = DateTime.UtcNow
        };
        IList<HttpPostedFile> postedFiles = null;
        if (fuploadDocs.HasFile)
        {
            postedFiles = fuploadDocs.PostedFiles;

            foreach (HttpPostedFile postedFile in postedFiles)
            {
                if (!string.IsNullOrEmpty(postedFile.FileName))
                {
                    postedFile.SaveAs(Server.MapPath(@"~\DocRepository\") + postedFile.FileName);
                    lstDocs.Add(new DocRepository()
                    {
                        FileName = postedFile.FileName,
                        FilePath = Server.MapPath(@"~\DocRepository\"),
                        UploadDate = DateTime.UtcNow
                    });
                }
            }
        }
        bool isSaved = objBll.SaveUserRequest(lstUserRequest, lstRequestStatus, lstDocs);
        if (isSaved)
        {
            ClearControl();
            hdnFileList.Value = "";
            BindSearchGrid();
            pnlEdit.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('User Request successfully submited...')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('There are some error...')", true);
        }
    }

   protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindSearchGrid();
    }

   protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
        pnlEdit.Visible = false;
        hdnFileList.Value = "";
    }

    public void BindSearchGrid()
    {
        objBll = new WarringtonBll.WarringtonBll();
        SearchParam objSearchParam = new SearchParam()
        {
            UserId = Utility.GetSessionValue<string>(Constants._LOGINUSERID),
            RequestStatus = txtStatus.Text,
            RequestNo = txtRequestNo.Text,
            RequestDate = string.IsNullOrEmpty(txtRequestDate.Text) ? DateTime.MinValue :
            DateTime.ParseExact(txtRequestDate.Text, "MM/dd/yyyy", null),
            CompareOperator=ddlOperator.SelectedValue,
            NoOfData=Convert.ToInt32(ddlPageSize.SelectedValue)
        };
        List<UserRequest> lstRequest = objBll.SearchRequest(objSearchParam);
        DataTable dtSearchResult = new DataTable();
        dtSearchResult.Columns.Add("Request_No");
        dtSearchResult.Columns.Add("Request_ID");
        dtSearchResult.Columns.Add("Request_Date");
        dtSearchResult.Columns.Add("Request_ChangeDate");
        dtSearchResult.Columns.Add("Request_Status");
        dtSearchResult.Columns.Add("Request_Address");
        dtSearchResult.Columns.Add("Request_ShortDesc");
        dtSearchResult.Columns.Add("Request_LongDesc");

        foreach (UserRequest  objrequest in lstRequest)
        {
            DataRow drRequest = dtSearchResult.NewRow();
            drRequest["Request_No"] = objrequest.RequestNo;
            drRequest["Request_ID"] = objrequest.RequestId;
            drRequest["Request_Date"] = objrequest.CreateDate.Value.Date.ToShortDateString();
            drRequest["Request_ChangeDate"] = objrequest.UpdateDate!=null?objrequest.UpdateDate.Value.Date.ToShortDateString():null;
            drRequest["Request_Status"] = objrequest.Status.Trim().Equals("O")?"Open":"Closed";
            drRequest["Request_Address"] = objrequest.ProblemLocation;
            drRequest["Request_ShortDesc"] = objrequest.ShortDescription;
            drRequest["Request_LongDesc"] = objrequest.LongDescription;
            dtSearchResult.Rows.Add(drRequest);
        }
        dtSearchResult.AcceptChanges(); 
        grdRequests.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        if (!dtSearchResult.DataTableIsEmpty())
        {
            Utility.SetSessionValue(Constants._SEARCHREQUESTDATA, dtSearchResult);
            grdRequests.DataSource = dtSearchResult;
            grdRequests.DataBind();
        }
        else
        {
            grdRequests.Dispose();
            grdRequests.DataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
         objBll = new WarringtonBll.WarringtonBll();
        pnlEdit.Visible = true;

        Button btnUpdate = (Button)sender;
        GridViewRow gvr = (GridViewRow)btnUpdate.NamingContainer;
        var hdnRequestId = (HiddenField)gvr.FindControl("hdnRequestId");
        var lblProbAddress = (Label)gvr.FindControl("lblProbAddress");
        var lblShortDesc = (Label)gvr.FindControl("lblShortDesc");
        var lblLongDesc = (Label)gvr.FindControl("lblLongDesc");

        hdnReqId.Value = hdnRequestId.Value;
        hdnFileList.Value = objBll.GetUploadedFiles(Convert.ToInt32(hdnRequestId.Value));
        txtAddress.Text = lblProbAddress.Text;
        txtShortDesc.Text = lblShortDesc.Text;
        txtLongDesc.Text = lblLongDesc.Text;
    }

    protected void ClearControl()
    {
        ContentPlaceHolder objContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Utility.ClearControl(objContentPlaceHolder);
    }
}