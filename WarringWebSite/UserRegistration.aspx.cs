using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WarringtonEntity;
using WarringtonSharePointService;
using WarringtonHelper;

public partial class UserRegistration : System.Web.UI.Page
{
    WarringtonBll.WarringtonBll objBll = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var displayMessage = Convert.ToString(Request.QueryString["D"]);
            if (displayMessage == "1")
            {
                liMessage.Visible = true;
            }
            else
            {
                liMessage.Visible = false;
            }
            BindStates();
            FillRegistrationData();
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        btnRegister.Click += btnRegister_Click;
        btnReset.Click += btnReset_Click;
        btnRegister.OnClientClick = "return CheckValidation();";
        btnReset.OnClientClick = "return ClearAllValidationMessage();";
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        objBll = new WarringtonBll.WarringtonBll();
        if (chkAgreePolicy.Checked)
        {
            if (!objBll.CheckPhoneNoExit(txtPrimaryPhoneNumber.Text))
            {
                List<UserMaster> lstUser = new List<UserMaster>();
                lstUser.Add(new UserMaster()
                {
                    EmailId = txtEmailId.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Address1 = txtAddress1.Text,
                    Address2 = txtAddress2.Text,
                    ZipCode = Convert.ToInt32(txtZipCode.Text),
                    CityName = txtCity.Text,
                    StateId = Convert.ToInt32(ddlState.SelectedValue),
                    PrimaryPhoneNo = txtPrimaryPhoneNumber.Text,
                    PrimaryPhoneType = ddlPrimaryPhoneType.SelectedValue,
                    PrimaryMobileProvider = ddlMobileProvider.SelectedValue,
                    SecondaryPhoneNo = txtSecondaryPhoneNumber.Text,
                    SecondaryPhoneType = ddlSecondaryPhoneType.SelectedValue,
                    SecondaryMobileProvider = ddlSecondaryMobileProvider.SelectedValue,
                    PrefferedContactMethod = ddlPrefContactMethod.SelectedValue,
                    CreateDate = DateTime.UtcNow,
                    PinNo = txtPin.Text,
                    Active = true
                });


                bool isSaved = objBll.SaveUserMaster(lstUser);
                if (isSaved)
                {
                    ClearControl();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('User Registration successfully done...')", true);
                    Response.Redirect("Login.aspx?P=" + (int)PageEnum.RequestSubmissionPage);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('There are some error...')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Primary Phone no must be unique. Duplicate Phone no found.')", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Please confirm that you are accepting the privacy rules...')", true);
        }

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
    }

    protected void BindStates()
    {

        WarringtonBll.WarringtonBll objBll = new WarringtonBll.WarringtonBll();
        List<StateMaster> lstStates = objBll.GetStateData();
        Utility.BindDropDownList<StateMaster>(lstStates, ddlState, "Select State", 1, 0);

    }

    protected void ClearControl()
    {
        ContentPlaceHolder objContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Utility.ClearControl(objContentPlaceHolder);
    }

    protected void FillRegistrationData()
    {
        UserRequest lstUserRequest = Utility.GetSessionValue<UserRequest>(Constants._REQUESTDATA);
        List<DocRepository> lstDocs = Utility.GetSessionValue<List<DocRepository>>(Constants._REQUESTDOCS);

        if (lstUserRequest != null)
        {
            txtFirstName.Text = lstUserRequest.FirstName;
            txtLastName.Text = lstUserRequest.LastName;
            txtAddress1.Text = lstUserRequest.Address1;
            txtAddress2.Text = lstUserRequest.Address2;
            txtZipCode.Text = Convert.ToString(lstUserRequest.ZipCode);
            txtCity.Text = lstUserRequest.CityName;
            ddlState.SelectedValue = Convert.ToString(lstUserRequest.StateId);
            txtPrimaryPhoneNumber.Text = lstUserRequest.PrimaryPhoneNo;
            ddlPrimaryPhoneType.SelectedValue = lstUserRequest.PrimaryPhoneType;
            ddlMobileProvider.SelectedValue = lstUserRequest.PrimaryMobileProvider;
            txtSecondaryPhoneNumber.Text = lstUserRequest.SecondaryPhoneNo;
            ddlSecondaryPhoneType.SelectedValue = lstUserRequest.SecondaryPhoneType;
            ddlSecondaryMobileProvider.SelectedValue = lstUserRequest.SecondaryMobileProvider;
            ddlPrefContactMethod.SelectedValue = lstUserRequest.PrefContactMethod;
            txtEmailId.Text = lstUserRequest.EmailId;
        }
    }
}