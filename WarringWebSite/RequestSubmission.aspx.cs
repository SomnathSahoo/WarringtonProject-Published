using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WarringtonEntity;
using WarringtonSharePointService;
using WarringtonHelper;
using WarringtonDb;

public partial class RequestSubmission : System.Web.UI.Page
{
    WarringtonBll.WarringtonBll objBll = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStates();
            FillRequestData();
        }
        
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        btnSubmit.Click += btnSubmit_Click;
        btnReset.Click += btnReset_Click;
        btnSubmit.OnClientClick = "return CheckValidation();";
        btnReset.OnClientClick = "return ClearAllValidationMessage();";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<DocRepository> lstDocs = new List<DocRepository>();
        UserRequest lstUserRequest = new UserRequest()
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
            PrefContactMethod = ddlPrefContactMethod.SelectedValue,
            CreateDate = DateTime.UtcNow,
            ProblemLocation = txtProbLocation.Text,
            ShortDescription = txtShortDescProblem.Text,
            LongDescription = txtLongDescProblem.Text,
            EmailConfirmation = chkConfirm.Checked,
            AttachedDocName = null,
            Status = "O"
        };
        RequestStatus lstRequestStatus = new RequestStatus()
        {
            Status = "O",
            UpdateDate = DateTime.UtcNow
        };

        


        objBll = new WarringtonBll.WarringtonBll();
        if (chkOptLogin.Checked)
        {
            if (objBll.IsUserRegistered(txtPrimaryPhoneNumber.Text))
            {
                if (!Utility.GetSessionValue<bool>(Constants._USERISLOGGEDIN))
                {
                    Utility.SetSessionValue(Constants._REQUESTDATA, lstUserRequest);
                    Utility.SetSessionValue(Constants._REQUESTSTATUSDATA, lstRequestStatus);
                    Utility.SetSessionValue(Constants._REQUESTDOCS, lstDocs);
                    Utility.SetSessionValue(Constants._POSTEDFILES, fileUpload.PostedFiles);
                    Response.Redirect("Login.aspx?P=" + (int)PageEnum.RequestSubmissionPage);
                }
            }
            else
            {
                Utility.SetSessionValue(Constants._REQUESTDATA, lstUserRequest);
                Utility.SetSessionValue(Constants._REQUESTSTATUSDATA, lstRequestStatus);
                Utility.SetSessionValue(Constants._REQUESTDOCS, lstDocs);
                Utility.SetSessionValue(Constants._POSTEDFILES, fileUpload.PostedFiles);
                Response.Redirect("UserRegistration.aspx?D=1");
            }
        }
        IList<HttpPostedFile> postedFiles = null;
        if (fileUpload.HasFile)
        {
            postedFiles = fileUpload.PostedFiles;
        }
        else
        {
            postedFiles = Utility.GetSessionValue<IList<HttpPostedFile>>(Constants._POSTEDFILES);
        }
        foreach (HttpPostedFile  postedFile in postedFiles)
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
        bool isSaved = objBll.SaveUserRequest(lstUserRequest, lstRequestStatus, lstDocs);
        if (isSaved)
        {
            ClearControl();
            hdnFileName.Value = "";
            Utility.SetSessionValue(Constants._REQUESTDATA, null);
            Utility.SetSessionValue(Constants._REQUESTDOCS, null);
            Utility.SetSessionValue(Constants._POSTEDFILES,null);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('User Request successfully submited...')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('There are some error...')", true);
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

    protected void FillRequestData()
    {
        UserRequest lstUserRequest = Utility.GetSessionValue<UserRequest>(Constants._REQUESTDATA);
        IList<HttpPostedFile> postedFiles = Utility.GetSessionValue<IList<HttpPostedFile>>(Constants._POSTEDFILES);
        string strfilename = string.Empty;
        if (postedFiles != null && postedFiles.Any())
        {
            foreach (HttpPostedFile doc in postedFiles)
            {
                strfilename += string.IsNullOrEmpty(strfilename) ? doc.FileName : "," + doc.FileName;
            }
        }
        hdnFileName.Value = strfilename;
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
            txtProbLocation.Text = lstUserRequest.ProblemLocation;
            txtShortDescProblem.Text = lstUserRequest.ShortDescription;
            txtLongDescProblem.Text = lstUserRequest.LongDescription;
            chkConfirm.Checked = (bool)lstUserRequest.EmailConfirmation;
            txtEmailId.Text = lstUserRequest.EmailId;
            chkOptLogin.Checked = true;
        }
    }

    protected void fileUpload_PreRender(object sender, EventArgs e)
    {
        
    }
}