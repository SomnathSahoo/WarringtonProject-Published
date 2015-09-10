using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WarringtonBll;
using WarringtonEntity;
using WarringtonSharePointService;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WarringtonSPService obj = new WarringtonSPService();
        //obj.SaveUser();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<LoginHistory> data = new List<LoginHistory>();
        data.Add(new LoginHistory() {UserId=1,ClientIp=HttpContext.Current.Request.UserHostAddress,Activity="Surfing",EntryDate=DateTime.Now });
        WarringtonBll.WarringtonBll objBll = new WarringtonBll.WarringtonBll();
        objBll.SaveLoginHistory(data);
    }
}