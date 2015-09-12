using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarringtonHelper
{
    public static class Utility
    {
        /// <summary>
        /// Method to check wheather a DataSet is null or empty
        /// </summary>
        /// <param name="source">DataSet</param>
        /// <returns></returns>
        public static bool DataSetIsEmpty(this DataSet source)
        {
            if (source == null)
            {
                return true;
            }
            else if (source.Tables.Count == 0)
            {
                return true;
            }
            else if (source.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to check wheather a DataTable is null or empty
        /// </summary>
        /// <param name="source">DataTable</param>
        /// <returns></returns>
        public static bool DataTableIsEmpty(this DataTable source)
        {
            if (source == null)
            {
                return true;
            }
            else if (source.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }

        public static void BindDropDownList<T>(List<T> lstData, DropDownList ddlList, string defaultText,int textFieldIndex,int valueFieldIndex)
        {
            if (ddlList.Items.Count > 0)
            {
                ddlList.Items.Clear();
            }
            ddlList.Items.Insert(0, new ListItem(defaultText, "0"));
            if (lstData != null && lstData.Any())
            {
                lstData.ForEach(p =>
                {
                    Type masterType = p.GetType();
                    PropertyInfo[] allProperties = masterType.GetProperties();
                    string itemText = Convert.ToString(allProperties[textFieldIndex].GetValue(p));
                    string itemValue = Convert.ToString(allProperties[valueFieldIndex].GetValue(p));
                    ddlList.Items.Insert(lstData.IndexOf(p) + 1, (new ListItem(itemText, itemValue)));
                });
            }
        }

        public static string GetLanIPAddress()
        {
            //The X-Forwarded-For (XFF) HTTP header field is a de facto standard for identifying the originating IP address of a 
            //client connecting to a web server through an HTTP proxy or load balancer
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip.Replace("::ffff:", "");
        }

        public static void ClearControl(Control contentHolder)
        {
            var allControls = contentHolder.Controls.Cast<Control>().
                Where(c => c.GetType() == typeof(TextBox) || c.GetType() == typeof(DropDownList) || c.GetType() == typeof(CheckBox) || c.GetType() == typeof(Panel));
            foreach (Control ctrl in allControls)
            {
                if (ctrl is TextBox)
                {
                    TextBox txtControl = ctrl as TextBox;
                    txtControl.Text = string.Empty;
                } 
                else if (ctrl is DropDownList)
                {
                    DropDownList ddlControl = ctrl as DropDownList;
                    ddlControl.ClearSelection();
                }
                else if (ctrl is CheckBox)
                {
                    CheckBox chkControl = ctrl as CheckBox;
                    chkControl.Checked=false;
                }
                else if (ctrl is Panel)
                {
                    ClearControl(ctrl);
                }
            }
        }

        public static T GetSessionValue<T>(string key)
        {
            var returnValue = HttpContext.Current.Session[key];
            if (returnValue != null)
            {
                return(T)HttpContext.Current.Session[key];
            }
            return default(T);
        }

        public static void SetSessionValue(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
    }
}
