using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WarringtonBll;
using WarringtonEntity;
using WarringtonHelper;

public partial class Login : System.Web.UI.Page
{   
    WarringtonBll.WarringtonBll objBll = null;
    string pageName = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        btnLogin.Click+=btnLogin_Click;
        btnCancel.Click += btnCancel_Click;
        btnLogin.OnClientClick = "return CheckValidation();";
        btnCancel.OnClientClick = "return ClearAllValidationMessage();";
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(GetPageName());
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string userId = string.Empty;
        objBll = new WarringtonBll.WarringtonBll();
        if (objBll.UserIsAuthenticated(txtUserId.Text.Trim(), txtPassword.Text.Trim(), out userId))
        {
            Utility.SetSessionValue(Constants._USERISLOGGEDIN, true);
            Utility.SetSessionValue(Constants._LOGINUSERID, userId);
            Response.Redirect(GetPageName());
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('The Phone no and Pin you entered don't match. User authentication fails..')", true);
        }
    }

    protected string GetPageName()
    {
        var pageVal = Convert.ToInt32(Request.QueryString["P"]);
        if (pageVal == (int)PageEnum.RequestSubmissionPage)
        {
            pageName = "RequestSubmission.aspx";
        }
        else
        {
            if (Utility.GetSessionValue<bool>(Constants._USERISLOGGEDIN))
            {
                pageName = "RequestDashboard.aspx";
            }
            else
            {
                pageName = "WarringtonHome.aspx";
            }
        }
        return pageName;
    }
}