using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|EnquiryDB.mdf;Integrated Security=True");

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        con.Open();
        string query = "insert into Login(username,password) values(@username,@password) ";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@username", txtusername.Text);
        cmd.Parameters.AddWithValue("@password", txtpassword.Text);
        cmd.ExecuteNonQuery();
        Session["username"] = txtusername.Text;

        Response.Redirect("NewEnquiry.aspx");

        con.Close();
    }
}