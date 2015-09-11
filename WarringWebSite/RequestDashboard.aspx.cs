using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RequestDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        btnReset.Click += btnReset_Click;
        btnSearch.Click += btnSearch_Click;
        btnSendRequest.Click += btnSendRequest_Click;
        grdRequests.RowDataBound += grdRequests_RowDataBound;
    }

    void grdRequests_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btnUpdate = (Button)e.Row.FindControl("btnUpdate");
            btnUpdate.Click += btnUpdate_Click;
        }
    }

    void btnUpdate_Click(object sender, EventArgs e)
    {
        editDiv.Visible = true;
    }

    void btnSendRequest_Click(object sender, EventArgs e)
    {
       
    }

    void btnSearch_Click(object sender, EventArgs e)
    {
        
    }

    void btnReset_Click(object sender, EventArgs e)
    {
        
    }

    public void BindSearchGrid()
    { }
}