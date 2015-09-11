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
            BindSearchGrid();
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        btnReset.Click += btnReset_Click;
        btnSearch.Click += btnSearch_Click;
        btnSendRequest.Click += btnSendRequest_Click;
        grdRequests.PageIndexChanging += grdRequests_PageIndexChanging;
    }

    void grdRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
    }
    void btnSendRequest_Click(object sender, EventArgs e)
    {

    }

    void btnSearch_Click(object sender, EventArgs e)
    {
        BindSearchGrid();
    }

    void btnReset_Click(object sender, EventArgs e)
    {

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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
         objBll = new WarringtonBll.WarringtonBll();
        editDiv.Visible = true;

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
}