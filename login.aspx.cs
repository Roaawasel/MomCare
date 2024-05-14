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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserWebInformation"] != null)
                {
                    txtb_UserName.Text = Request.Cookies["UserWebInformation"]["username"].ToString();
                    txtb_Password.Text = Request.Cookies["UserWebInformation"]["password"].ToString();
                    lbl_Message.Text = "Cookie is saved on your machine";
                }
                else
                {
                    lbl_Message.Text = "Cookie dose not exist";
                }
            }

        }



        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

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
                HttpCookie Cookie = new HttpCookie("UserwebInformation");

                if (ChkB_CheckMe.Checked)
                {

                    Cookie["UserName"] = txtb_UserName.Text;
                    Cookie["Password"] = txtb_Password.Text;
                    Cookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(Cookie);
                }
                else{
                    Cookie.Expires = DateTime.Now.AddMinutes(-1);
                }
                Response.Redirect("ControlPanel.aspx");
            }
            else
            {
                lbl_Message.Text = "user and password is wrong!";
            }

        }
    }  

}