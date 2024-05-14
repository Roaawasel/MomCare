using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MomCare
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    lbl_Session.Text = "User Name for this session is " + Session["username"].ToString();

                }
                else
                {
                    lbl_Session.Text = "Session have not been initalize with username yet!";
                }
            }

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["sampleDBConnectionString"].ToString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("select * from userInfoTB where [username]=@username and [password]=@pass", con);
            cmd.Parameters.AddWithValue("username", txtb_UserName.Text);
            cmd.Parameters.AddWithValue("pass", txtb_Password.Text);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            if (dt.Rows.Count > 0)
            {
                Session["UserName"] = txtb_UserName.Text;
                Session["Password"] = txtb_Password.Text;
                lbl_ErrorMessage.Text = Session["UserName"].ToString();
                Response.Redirect("Dashboard.aspx");
                return;
            }
            else
           {
                lbl_ErrorMessage.Text = "user and password is wrong!";
            }
        }

    

    }
}