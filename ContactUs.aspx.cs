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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindRepeaterData();
            attachListData();
        }


        protected void btn_Update_Click(object sender, EventArgs e)
        {
            SqlDataSource1.Update();
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            if (dv != null)
            {
                if (dv.Count > 0)
                {
                    txtb_name.Text = dv[0].Row["Name"].ToString();
                    txtb_email.Text = dv[0].Row["Email"].ToString();
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            if (dv != null)
            {
                dv.RowFilter = "Email ='" + txtb_email.Text + "'";
                if (dv.Count > 0) { lbl_Error.Text = "Email already exists "; return; } else { SqlDataSource1.Insert(); }
            }



            SqlDataSource1.Insert();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        void bindRepeaterData()
        {
            string conStr = ConfigurationManager.ConnectionStrings["sampleDBConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from sampleTB", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            da.Dispose();
            cmd.Dispose();
            conn.Close();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
        protected void attachListData()
        {

            string conStr = ConfigurationManager.ConnectionStrings["sampleDBConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from sampleTB", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            DataList1.DataSource = dt;

            DataList1.DataBind();

            da.Dispose();

            cmd.Dispose();

            conn.Close();
        }
        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile && FileUpload1.FileContent.Length < 100000)
            {
                try
                {


                    string Path = Server.MapPath("/Uploadl/" + FileUpload1.FileName);
                    FileUpload1.SaveAs(Path);
                    lbl_Message.Text = "Upleaded Success";
                }

                catch

                {

                    lbl_Message.Text = "OOPS Some error";
                }
            }
        }


        protected void btn_Upload2_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            if (dv != null)
            {
                dv.RowFilter = "ID='" + txtb_email.Text + "'";
                if (dv.Count > 0)
                {
                    lbl_Message.Text = "ID number already exsits";
                    return;
                }
                else
                {
                    string conStr = ConfigurationManager.ConnectionStrings["sampleDBConnectionString"].ToString();
                    string sql = "Insert into sample TB2 (ID, FirstName, Email, file_path) values (" + txtb_email.Text + "," + txtb_name.Text + "," + txtb_phone.Text + "', ' / Upload1 / "
                   + FileUpload1.FileName + "')";
                    SqlConnection con = new SqlConnection(conStr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con); SqlDataAdapter da = new SqlDataAdapter();
                    da.InsertCommand = new SqlCommand(sql, con);
                    da.InsertCommand.ExecuteNonQuery();
                    try
                    {

                        string Path = Server.MapPath("~/Upload1/" + FileUpload1.FileName);
                        FileUpload1.SaveAs(Path);
                        lbl_Message.Text = "Uploaded Success";
                    }
                    catch (Exception ex)
                    {
                    }
                    lbl_Message.Text = "00PS Some error";
                }
            }
        }

       
    }

}