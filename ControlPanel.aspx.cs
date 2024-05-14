using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MomCare
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserWebInformation"] != null)
            {
                lbl_Message.Text = "Logged in as" + Request.Cookies["UserWebInformation"]["username"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }


        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("UserWebInformation");

            Cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(Cookie);
            Response.Redirect("login.aspx");
        }
    }
}