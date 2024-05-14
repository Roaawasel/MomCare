using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MomCare
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        String conStr = ConfigurationManager.ConnectionStrings["sampleDBconnectionsString2"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void Bind()
        {
            string Sql = "Select* from sampled where convert(navarchar, Email) like '"
             + txtb_Search.Text + "%' or first name like ‘" + txtb_Search.Text + "%'";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = Sql;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
             GridView1.DataSource = ds;
             GridView1.DataBind();
        }
            protected void btn_Search_Click(object sender, EventArgs e)
        {
            Bind();
        }

    
    }
}