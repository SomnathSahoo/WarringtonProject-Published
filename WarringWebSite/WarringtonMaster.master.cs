using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WarringtonMaster : System.Web.UI.MasterPage
{
    StringBuilder sbHtml=null;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblToday.InnerText = string.Format("Today is {0}, {1} {2}, {3}",
            DateTime.UtcNow.DayOfWeek, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.UtcNow.Month), 
            DateTime.UtcNow.Day, DateTime.UtcNow.Year);

    }

    protected void GetSiteMapMenu()
    {
        sbHtml=new StringBuilder();
        sbHtml.Append(@"<ul><li><a href=''><i class='fa fa-home'></i> Home</a> <span>/</span></li>
                                    <li><a href=''>Page name</a> <span>/</span></li></ul>");

    }
}
